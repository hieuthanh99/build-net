FuelCostPageModule = CreateClass(PageModuleBase, {
    constructor: function () {

    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "GridPane") {
            ClientGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientFilterButton_Click: function (s, e) {
        RevCost.DoCallback(ClientGrid, function () {
            ClientGrid.PerformCallback('FILTER');
        });
    },

    ClientCalcRentingCounterCostButton_Click: function (s, e) {
        var cf = confirm("Xác nhận chạy tính toán chi phí trang thiết bị?");
        if (cf) {

            var aAreaCode = ClientAreaCode.GetValue();
            var aVersionID = ClientVersion.GetValue();
            var aFromDate = ClientFromDate.GetValue();
            var aToDate = ClientToDate.GetValue();
            if (aVersionID == null) {
                alert("Bạn phải chọn một version trước khi thực hiện chức năng này.");
                return;
            }

            RevCost.DoCallback(ClientGrid, function () {
                ClientGrid.PerformCallback('CALC_FUEL_COST|' + aVersionID + "|" + aAreaCode + '|' + aFromDate + '|' + aToDate);
            });
        }
    },

    ClientGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == 'btnFuelDetail') {
            if (!s.IsDataRow(s.GetFocusedRowIndex()))
                return;

            ClientViewFuelDetailPopup.Show();
        }

        if (e.buttonID == 'btnDepreDetail') {
            if (!s.IsDataRow(s.GetFocusedRowIndex()))
                return;

            ClientViewDepreDetailPopup.Show();
        }
    },


    ClientViewFuelDetailPopup_Shown: function (s, e) {
        if (!ClientGrid.IsDataRow(ClientGrid.GetFocusedRowIndex()))
            return;

        var key = ClientGrid.GetRowKey(ClientGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientFuelDetailGrid, function () {
            ClientFuelDetailGrid.PerformCallback(key);
        });
    },

    ClientViewDepreDetailPopup_Shown: function (s, e) {
        if (!ClientGrid.IsDataRow(ClientGrid.GetFocusedRowIndex()))
            return;

        var key = ClientGrid.GetRowKey(ClientGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientDepreDetailGrid, function () {
            ClientDepreDetailGrid.PerformCallback(key);
        });
    },

    ClientCofficientKButton_Click: function (s, e) {
        ClientCofficientKPopup.Show();
    },

    ClientCofficientKPopup_Shown: function (s, e) {
        RevCost.DoCallback(ClientCofficientKGrid, function () {
            ClientCofficientKGrid.PerformCallback('LOAD_COFFICIENT');
        });
    },

    ClientSaveCloseCofficientKButton_Click: function(s, e){
        if (ClientCofficientKGrid.batchEditApi.HasChanges()) {
            ClientCofficientKGrid.UpdateEdit();
        }

        ClientCofficientKPopup.Hide();
    },

    ClientSaveCofficientKButton_Click: function (s, e) {
        if (ClientCofficientKGrid.batchEditApi.HasChanges()) {
            ClientCofficientKGrid.UpdateEdit();
        }
    },

    ClientNormType_ValueChanged: function (s, e) {
        RevCost.DoCallback(ClientCofficientKGrid, function () {
            ClientCofficientKGrid.PerformCallback('LOAD_COFFICIENT');
        });
    },

    ClientNormYear_ValueChanged: function (s, e) {
        RevCost.DoCallback(ClientVersion, function () {
            ClientVersion.PerformCallback(s.GetValue());
        });
    }
});

(function () {
    var pageModule = new FuelCostPageModule();
    window.RevCost = pageModule;
})();