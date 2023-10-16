﻿CountersUnitPricesPageModule = CreateClass(PageModuleBase, {
    constructor: function () {

    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }
        if (e.pane.name == "MasterPane") {
            ClientMasterGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "CountersCostPane") {
            ClientCountersCostGrid.SetHeight(e.pane.GetClientHeight() - 81);
        }

        if (e.pane.name == "CarrierPane") {
            ClientCarrierGrid.SetHeight(e.pane.GetClientHeight() - 51);
        }

        if (e.pane.name == "CarrierUsageRatePane") {
            ClientCarrierUsageRateGrid.SetHeight(e.pane.GetClientHeight() - 51);
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

        //RevCost.DoCallback(ClientMasterGrid, function () {
        //    ClientMasterGrid.PerformCallback("LOAD_COUNTERS|" + key);
        //});
    },


    ClientQuantityVersion_ValueChanged: function (s, e) {
        if (!ClientMasterGrid.IsDataRow(ClientMasterGrid.GetFocusedRowIndex()))
            return;

        var versionID = s.GetValue();
        ClientHiddenField.Set("VersionID", versionID.toString());

        var key = ClientMasterGrid.GetRowKey(ClientMasterGrid.GetFocusedRowIndex());
        ClientHiddenField.Set("CounterTypeID", key);

        if (ClientHiddenField.Get("CounterTypeID") == null || ClientHiddenField.Get("CounterTypeID") == "undefined")
            return;

        RevCost.DoCallback(ClientCountersCostGrid, function () {
            ClientCountersCostGrid.PerformCallback("LOAD_COST|" + key + "|" + versionID);
        });

        RevCost.DoCallback(ClientUnitPriceGrid, function () {
            ClientUnitPriceGrid.PerformCallback("LOAD_UNIT_PRICE|" + key + "|" + versionID);
        });
    },

    ClientQuantityVersion_EndCallback: function (s, e) {
        var key = ClientHiddenField.Get("NormYearID");
        RevCost.DoCallback(ClientMasterGrid, function () {
            ClientMasterGrid.PerformCallback("LOAD_COUNTERS|" + key);
        });
    },

    ClientMasterGrid_EndCallback: function (s, e) {
        ClientSplitter.AdjustControl();
        if (s.GetVisibleRowsOnPage() > 0) {
            if (s.GetFocusedRowIndex() < 0) {
                s.SetFocusedRowIndex(0);
            } else {
                RevCost.ClientMasterGrid_FocusedRowChanged(s, null);
            }
        }
        else {
            ClientHiddenField.Set("CounterTypeID", "0");
            ClientHiddenField.Set("VersionID", "0");

            RevCost.DoCallback(ClientCountersCostGrid, function () {
                ClientCountersCostGrid.PerformCallback("LOAD_COST|0|0");
            });

            RevCost.DoCallback(ClientCarrierGrid, function () {
                ClientCarrierGrid.PerformCallback("LOAD_CARRIER|0");
            });
        }
    },

    ClientMasterGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        var versionID = ClientQuantityVersion.GetValue();
        ClientHiddenField.Set("VersionID", versionID.toString());

        ClientHiddenField.Set("CounterTypeID", key);
        if (ClientHiddenField.Get("VersionID") == null || ClientHiddenField.Get("VersionID") == "undefined")
            return;


        RevCost.DoCallback(ClientCountersCostGrid, function () {
            ClientCountersCostGrid.PerformCallback("LOAD_COST|" + key + "|" + versionID);
        });

        RevCost.DoCallback(ClientCarrierGrid, function () {
            ClientCarrierGrid.PerformCallback("LOAD_CARRIER|" + key);
        });
    },

    ClientCarrierGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("CarrierCounterID", key);

        var versionID = ClientQuantityVersion.GetValue();
        ClientHiddenField.Set("VersionID", versionID.toString());

        RevCost.DoCallback(ClientCarrierUsageRateGrid, function () {
            ClientCarrierUsageRateGrid.PerformCallback("LOAD_DETAIL|" + key + "|" + versionID);
        });

        RevCost.DoCallback(ClientUnitPriceGrid, function () {
            ClientUnitPriceGrid.PerformCallback("LOAD_UNIT_PRICE|" + key + "|" + versionID);
        });
    },

    ClientCarrierGrid_EndCallback: function (s, e) {
        if (s.GetVisibleRowsOnPage() > 0) {
            if (s.GetFocusedRowIndex() < 0) {
                s.SetFocusedRowIndex(0);
            } else {
                RevCost.ClientCarrierGrid_FocusedRowChanged(s, null);
            }
        }
        else {
            ClientHiddenField.Set("CarrierCounterID", "0");

            RevCost.DoCallback(ClientUnitPriceGrid, function () {
                ClientUnitPriceGrid.PerformCallback("LOAD_UNIT_PRICE|0");
            });
        }
    },

    ClientUnitPriceGrid_EndCallback: function (s, e) {
        if (s.GetVisibleRowsOnPage() > 0 && s.GetFocusedRowIndex() <= 0) {
            s.SetFocusedRowIndex(0);
        }
    },

    ClientMasterGrid_AddNewButtonClick: function (s, e) {
        ClientMasterGrid.AddNewRow();
    },


    ClientMasterGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "MasterGridDelete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientMasterGrid, function () {
                    ClientMasterGrid.PerformCallback("DELETE_MASTER_ROW|" + key);
                });
            }
        }
    },


    ClientUnitPriceGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "UnitDelete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientUnitPriceGrid, function () {
                    ClientUnitPriceGrid.PerformCallback("DELETE_UNIT_PRICE|" + key);
                });
            }
        }
    },

    ClientSaveDataGridButton_Click: function (s, e) {
        if (ClientMasterGrid.batchEditApi.HasChanges()) {
            ClientMasterGrid.UpdateEdit();
        }

        if (ClientUnitPriceGrid.batchEditApi.HasChanges()) {
            ClientUnitPriceGrid.UpdateEdit();
        }

        if (ClientCarrierGrid.batchEditApi.HasChanges()) {
            ClientCarrierGrid.UpdateEdit();
        }

        if (ClientCountersCostGrid.batchEditApi.HasChanges()) {
            ClientCountersCostGrid.UpdateEdit();
        }

        if (ClientCarrierUsageRateGrid.batchEditApi.HasChanges()) {
            ClientCarrierUsageRateGrid.UpdateEdit();
        } 

    },

    ClientCancelDataGridButton_Click: function (s, e) {
        if (ClientMasterGrid.batchEditApi.HasChanges()) {
            ClientMasterGrid.CancelEdit();
        }

        if (ClientUnitPriceGrid.batchEditApi.HasChanges()) {
            ClientUnitPriceGrid.CancelEdit();
        }

        if (ClientCarrierGrid.batchEditApi.HasChanges()) {
            ClientCarrierGrid.CancelEdit();
        }

        if (ClientCountersCostGrid.batchEditApi.HasChanges()) {
            ClientCountersCostGrid.CancelEdit();
        }

        if (ClientCarrierUsageRateGrid.batchEditApi.HasChanges()) {
            ClientCarrierUsageRateGrid.CancelEdit();
        }
    },


    ClientUnitPriceGrid_AddNewButtonClick: function (s, e) {
        if (!ClientMasterGrid.IsDataRow(ClientMasterGrid.GetFocusedRowIndex()))
            return;
        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;

        ClientUnitPriceGrid.AddNewRow();
    },

    ClientCarrierGrid_AddNewButtonClick: function (s, e) {
        if (!ClientMasterGrid.IsDataRow(ClientMasterGrid.GetFocusedRowIndex()))
            return;
        //var key = ClientMasterGrid.GetRowKey(ClientMasterGrid.GetFocusedRowIndex());

        ClientCarrierPopup.Show();
    },

    ClientCarrierPopup_Shown: function (s, e) {
        if (!ClientMasterGrid.IsDataRow(ClientMasterGrid.GetFocusedRowIndex()))
            return;
        var key = ClientMasterGrid.GetRowKey(ClientMasterGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientLOVCarrierGrid, function () {
            ClientLOVCarrierGrid.PerformCallback("LOAD_CARRIER|" + key);
        });
    },

    ClientAddCarrierButton_Click: function (s, e) {
        if (!ClientMasterGrid.IsDataRow(ClientMasterGrid.GetFocusedRowIndex()))
            return;

        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;

        var aCounterTypeID = ClientMasterGrid.GetRowKey(ClientMasterGrid.GetFocusedRowIndex());
        var aNormYearID = ClientNormYearGrid.GetRowKey(ClientNormYearGrid.GetFocusedRowIndex());

        var keys = [];
        keys = ClientLOVCarrierGrid.GetSelectedKeysOnPage();

        if (keys.length == 0) {
            alert("Bạn phải chọn ít nhất hãng bay.");
            return;
        }
        if (keys.length > 0) {
            RevCost.DoCallback(ClientCarrierGrid, function () {
                ClientCarrierGrid.PerformCallback("ADD_CARRIER;" + aCounterTypeID + ";" + aNormYearID + ";" + keys);
            });
        }

        ClientLOVCarrierGrid.UnselectAllRowsOnPage();

        ClientCarrierPopup.Hide();

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
                    ClientCarrierGrid.PerformCallback("REMOVE_CARRIER;" + keys.join(";"));
                });

                ClientCarrierGrid.UnselectAllRowsOnPage();
            }
        }
    },

    ClientCalculateUnitPriceButton_Click: function (s, e) {
        var cf = confirm("Thực hiện tính đơn giá thuê quầy?");
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

        //ClientCalcUnitPriceVersion.SetValue(null);
        //ClientCalcUnitPriceFromMonth.SetValue(1);
        //ClientCalcUnitPriceToMonth.SetValue(12);

        RevCost.DoCallback(ClientCalcUnitPriceVersion, function () {
            ClientCalcUnitPriceVersion.PerformCallback("LOAD_VERSION|" + key);
        });
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

    ClientCountersCostGrid_EndCallback: function (s, e) {
        if (s.GetVisibleRowsOnPage() > 0) {
            if (s.GetFocusedRowIndex() < 0) {
                s.SetFocusedRowIndex(0);
            }
        }
    }

});

(function () {
    var pageModule = new CountersUnitPricesPageModule();
    window.RevCost = pageModule;
})();