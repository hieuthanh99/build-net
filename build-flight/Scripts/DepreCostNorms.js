DepreCostNormPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.DetailCallback = "";
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "ItemPane") {
            ClientDepreCostGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "CostDetailPane") {
            ClientCostDetailGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "CarrierPane") {
            ClientCarrierGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "UnitPricePane") {
            ClientUnitPriceGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientNormYearGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID", key);

        RevCost.DoCallback(ClientQuantityVersion, function () {
            ClientQuantityVersion.PerformCallback(key);
        });

        //RevCost.DoCallback(ClientDepreCostGrid, function () {
        //    ClientDepreCostGrid.PerformCallback('LOAD_DEPRE_COST|' + key);
        //});
    },

    ClientQuantityVersion_EndCallback: function (s, e) {
        var key = ClientHiddenField.Get("NormYearID");
        RevCost.DoCallback(ClientDepreCostGrid, function () {
            ClientDepreCostGrid.PerformCallback("LOAD_DEPRE_COST|" + key);
        });
    },

    ClientQuantityVersion_ValueChanged: function (s, e) {
        if (!ClientDepreCostGrid.IsDataRow(ClientDepreCostGrid.GetFocusedRowIndex()))
            return;

        var versionID = s.GetValue();
        ClientHiddenField.Set("VersionID", versionID.toString());

        var key = ClientDepreCostGrid.GetRowKey(ClientDepreCostGrid.GetFocusedRowIndex());
        ClientHiddenField.Set("DepreCostID", key);

        if (ClientHiddenField.Get("DepreCostID") == null || ClientHiddenField.Get("DepreCostID") == "undefined")
            return;

        RevCost.DoCallback(ClientCostDetailGrid, function () {
            ClientCostDetailGrid.PerformCallback("LOAD_COST|" + key + "|" + versionID);
        });

        RevCost.DoCallback(ClientUnitPriceGrid, function () {
            ClientUnitPriceGrid.PerformCallback("LOAD_UNIT_PRICE|" + versionID);
        });
    },

    ClientDepreCostGrid_EndCallback: function (s, e) {
        ClientSplitter.AdjustControl();
        if (s.GetVisibleRowsOnPage() > 0) {
            if (s.GetFocusedRowIndex() < 0) {
                s.SetFocusedRowIndex(0);
            } else {
                RevCost.ClientDepreCostGrid_FocusedRowChanged(s, null);
            }
        }
        else {
            ClientHiddenField.Set("DepreCostID", "0");

            RevCost.DoCallback(ClientCarrierGrid, function () {
                ClientCarrierGrid.PerformCallback("LOAD_CARRIER|0");
            });
        }
    },

    ClientDepreCostGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("DepreCostID", key);


        var versionID = ClientQuantityVersion.GetValue();
        ClientHiddenField.Set("VersionID", versionID.toString());

        if (ClientHiddenField.Get("VersionID") == null || ClientHiddenField.Get("VersionID") == "undefined")
            return;

        RevCost.DoCallback(ClientCostDetailGrid, function () {
            ClientCostDetailGrid.PerformCallback("LOAD_DETAIL|" + key + "|" + versionID);
        });

        RevCost.DoCallback(ClientCarrierGrid, function () {
            ClientCarrierGrid.PerformCallback('LOAD_CARRIER;' + key);
        });
    },

    ClientCarrierGrid_AddNewButtonClick: function (s, e) {
        if (!ClientDepreCostGrid.IsDataRow(ClientDepreCostGrid.GetFocusedRowIndex()))
            return;

        ClientCarrierPopup.Show();
    },


    ClientCarrierPopup_Shown: function (s, e) {
        if (!ClientDepreCostGrid.IsDataRow(ClientDepreCostGrid.GetFocusedRowIndex()))
            return;
        var key = ClientDepreCostGrid.GetRowKey(ClientDepreCostGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientLOVCarrierGrid, function () {
            ClientLOVCarrierGrid.PerformCallback("LOAD_CARRIER|" + key);
        });
    },

    ClientAddCarrierButton_Click: function (s, e) {
        if (!ClientDepreCostGrid.IsDataRow(ClientDepreCostGrid.GetFocusedRowIndex()))
            return;

        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;

        var aDepreCostID = ClientDepreCostGrid.GetRowKey(ClientDepreCostGrid.GetFocusedRowIndex());
        var aNormYearID = ClientNormYearGrid.GetRowKey(ClientNormYearGrid.GetFocusedRowIndex());

        var keys = [];
        keys = ClientLOVCarrierGrid.GetSelectedKeysOnPage();

        if (keys.length == 0) {
            alert("Bạn phải chọn ít nhất hãng bay.");
            return;
        }
        if (keys.length > 0) {
            RevCost.DoCallback(ClientCarrierGrid, function () {
                ClientCarrierGrid.PerformCallback("ADD_CARRIER;" + aDepreCostID + ";" + aNormYearID + ";" + keys);
            });
        }

        ClientLOVCarrierGrid.UnselectAllRowsOnPage();

        ClientCarrierPopup.Hide();
    },

    ClientSaveDataGridButton_Click: function (s, e) {
        if (ClientDepreCostGrid.batchEditApi.HasChanges()) {
            ClientDepreCostGrid.UpdateEdit();
        }
        if (ClientCarrierGrid.batchEditApi.HasChanges()) {
            ClientCarrierGrid.UpdateEdit();
        }

        if (ClientCostDetailGrid.batchEditApi.HasChanges()) {
            ClientCostDetailGrid.UpdateEdit();
        }

    },

    ClientCancelDataGridButton_Click: function (s, e) {
        if (ClientDepreCostGrid.batchEditApi.HasChanges()) {
            ClientDepreCostGrid.CancelEdit();
        }

        if (ClientCarrierGrid.batchEditApi.HasChanges()) {
            ClientCarrierGrid.CancelEdit();
        }

        if (ClientCostDetailGrid.batchEditApi.HasChanges()) {
            ClientCostDetailGrid.CancelEdit();
        }
    },

    ClientCarrierGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("DepreCostCarrierID", key);

        RevCost.DoCallback(ClientUnitPriceGrid, function () {
            ClientUnitPriceGrid.PerformCallback("LOAD_UNIT_PRICE|" + key);
        });
    },


    ClientCarrierGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "CarrierDelete") {
            var cf = confirm("Bạn thực sự muốn xóa (các) bản ghi này không?");
            if (cf) {

                var keys = [];
                keys = ClientCarrierGrid.GetSelectedKeysOnPage();
                if (keys.length == 0) {
                    keys = [key];
                }

                RevCost.DoCallback(ClientCarrierGrid, function () {
                    ClientCarrierGrid.PerformCallback("REMOVE_CARRIER|" + keys.join("|"));
                });

                ClientCarrierGrid.UnselectAllRowsOnPage();
            }
        }
    },

    ClientCarrierGrid_EndCallback: function (s, e) {
        ClientSplitter.AdjustControl();
        if (s.GetVisibleRowsOnPage() > 0) {
            if (s.GetFocusedRowIndex() < 0) {
                s.SetFocusedRowIndex(0);
            } else {
                RevCost.ClientCarrierGrid_FocusedRowChanged(s, null);
            }
        }
        else {
            ClientHiddenField.Set("DepreCostCarrierID", "0");

            RevCost.DoCallback(ClientUnitPriceGrid, function () {
                ClientUnitPriceGrid.PerformCallback("LOAD_UNIT_PRICE|0");
            });
        }
    },


    ClientCalculateUnitPriceButton_Click: function (s, e) {
        var cf = confirm("Thực hiện tính đơn giá khấu hao trang thiết bị?");
        if (cf) {
            if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
                return;
            var key = ClientNormYearGrid.GetRowKey(ClientNormYearGrid.GetFocusedRowIndex());

            ClientCalcUnitPricePopup.Show();

        }
    },


    ClientCalcUnitPricePopup_Shown: function (s, e) {
        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;
        var key = ClientNormYearGrid.GetRowKey(ClientNormYearGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientCalcUnitPriceVersion, function () {
            ClientCalcUnitPriceVersion.PerformCallback("LOAD_VERSION|" + key);
        });

    },


    ClientUnitPriceGrid_CustomButtonClick: function (s, e) {

    },

    ClientUnitPriceGrid_EndCallback: function (s, e) {
        ClientSplitter.AdjustControl();
    },


    ClientCalcUnitPriceButton_Click: function (s, e) {
        if (!ASPxClientEdit.ValidateEditorsInContainerById("CalcUnitPriceForm"))
            return;

        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;
        var key = ClientNormYearGrid.GetRowKey(ClientNormYearGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientUnitPriceGrid, function () {
            ClientUnitPriceGrid.PerformCallback("CALC_UNIT|" + key);
        });
    },

    ClientCostDetailGrid_BeginCallback: function (s, e) {
        this.DetailCallback = e.command;
    },

    ClientCostDetailGrid_EndCallback: function (s, e) {
        if (this.DetailCallback == "UPDATEEDIT") {
            ClientDepreCostGrid.Refresh();

            this.DetailCallback = "";
        }

        if (s.GetVisibleRowsOnPage() > 0) {
            if (s.GetFocusedRowIndex() < 0) {
                s.SetFocusedRowIndex(0);          
            }
        }
    }


});

(function () {
    var pageModule = new DepreCostNormPageModule();
    window.RevCost = pageModule;
})();