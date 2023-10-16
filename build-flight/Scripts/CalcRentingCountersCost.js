CountersCostPageModule = CreateClass(PageModuleBase, {
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
        //var cf = confirm("Xác nhận chạy tính toán chi phí thuê quầy?");
        //if (cf) {

        var aAreaCode = ClientAreaCode.GetValue();
        var aVersionID = ClientVersion.GetValue();
        var aFromDate = ClientFromDate.GetValue();
        var aToDate = ClientToDate.GetValue();
        if (aVersionID == null) {
            alert("Bạn phải chọn một version trước khi thực hiện chức năng này.");
            return;
        }

        ClientCalcCounterCostPopup.Show();


        //}
    },

    ClientCalcCounterCostPopup_Shown: function (s, e) {
        //var d = new Date();
        //var n = d.getMonth();
        //ClientCalcCounterCostFromMonth.SetValue(n);
        //ClientCalcCounterCostToMonth.SetValue(n);
    },

    ClientCalcCounterCostButton_Click: function (s, e) {
        if (ClientCalcCounterCostFromMonth.GetValue() == null || ClientCalcCounterCostToMonth.GetValue() == null)
            return;

        RevCost.DoCallback(ClientGrid, function () {
            ClientGrid.PerformCallback('CALC_RENTING_COUNTER_COST');
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

    ClientSaveCloseCofficientKButton_Click: function (s, e) {
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

    ClientNormYear_ValueChanged: function (s, e) {
        RevCost.DoCallback(ClientVersion, function () {
            ClientVersion.PerformCallback(s.GetValue());
        });
    }
});

(function () {
    var pageModule = new CountersCostPageModule();
    window.RevCost = pageModule;
})();