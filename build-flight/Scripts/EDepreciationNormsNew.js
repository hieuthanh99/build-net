BoardingUnitPricesPageModule = CreateClass(PageModuleBase, {
    constructor: function () {

    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "ItemPane") {
            ClientItemGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "EDNormPane") {
            ClientEDNormGrid.SetHeight(e.pane.GetClientHeight());
        }
        if (e.pane.name == "CostDetailPane") {
            ClientDepreCostDetailGrid.SetHeight(e.pane.GetClientHeight());
        }
        
        if (e.pane.name == "UnitPricePane") {
            ClientUnitPriceGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientPageControl_ActiveTabChanged: function (s, e) {
        ClientSplitter.AdjustControl();
        ClientSplitter2.AdjustControl();
    },

    ClientNormYearGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID", key);
        if (ClientHiddenField.Get("ItemID") == null || ClientHiddenField.Get("ItemID") == "undefined")
            return;

        RevCost.DoCallback(ClientEDNormGrid, function () {
            ClientEDNormGrid.PerformCallback('LOAD_ED|' + key);
        });
    },

    ClientItemGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("ItemID", key);
        if (ClientHiddenField.Get("NormYearID") == null || ClientHiddenField.Get("NormYearID") == "undefined")
            return;

        RevCost.DoCallback(ClientEDNormGrid, function () {
            ClientEDNormGrid.PerformCallback("LOAD_ED|" + key);
        });
    },

    ClientEDNormGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("EDNormID", key);

        RevCost.DoCallback(ClientDepreCostDetailGrid, function () {
            ClientDepreCostDetailGrid.PerformCallback("LOAD_COST|" + key);
        });

        RevCost.DoCallback(ClientUnitPriceGrid, function () {
            ClientUnitPriceGrid.PerformCallback("LOAD_UNIT_PRICE|" + key);
        });
    },

    ClientEDNormGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "EDNormGridDelete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientEDNormGrid, function () {
                    ClientEDNormGrid.PerformCallback("DELETE_ED_NORM|" + key);
                });
            }
        }
    },

    ClientSaveDataGridButton_Click: function (s, e) {
        if (ClientEDNormGrid.batchEditApi.HasChanges()) {
            ClientEDNormGrid.UpdateEdit();
        }
    },

    ClientCancelDataGridButton_Click: function (s, e) {
        if (ClientEDNormGrid.batchEditApi.HasChanges()) {
            ClientEDNormGrid.CancelEdit();
        }
    },

    ClientEDNormGrid_AddNewButtonClick: function (s, e) {
        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;

        if (!ClientItemGrid.IsDataRow(ClientItemGrid.GetFocusedRowIndex()))
            return;

        var aNormYearID = ClientNormYearGrid.GetRowKey(ClientNormYearGrid.GetFocusedRowIndex());
        var aItemID = ClientItemGrid.GetRowKey(ClientItemGrid.GetFocusedRowIndex());

        ClientHiddenField.Set("ItemID", aItemID);
        ClientHiddenField.Set("NormYearID", aNormYearID);

        ClientEDNormGrid.AddNewRow();
    },

    ClientEDNormGrid_EndCallback: function (s, e) {
        ClientSplitter.AdjustControl();
        if (s.GetVisibleRowsOnPage() > 0) {
            if (s.GetFocusedRowIndex() < 0) {
                s.SetFocusedRowIndex(0);
            } else {
                RevCost.ClientEDNormGrid_FocusedRowChanged(s, null);
            }
        }
        else {
            ClientHiddenField.Set("EDNormID", "0");

            RevCost.DoCallback(ClientDepreCostDetailGrid, function () {
                ClientDepreCostDetailGrid.PerformCallback("LOAD_COST|0");
            });

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

    ClientUnitPriceGrid_EndCallback: function (s, e) {
        ClientSplitter.AdjustControl();
        if (s.GetVisibleRowsOnPage() > 0) {
            if (s.GetFocusedRowIndex() < 0) {
                s.SetFocusedRowIndex(0);
            }
        }
    }

});

(function () {
    var pageModule = new BoardingUnitPricesPageModule();
    window.RevCost = pageModule;
})();