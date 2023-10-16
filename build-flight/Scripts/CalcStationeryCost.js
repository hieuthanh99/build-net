StationeryCostPageModule = CreateClass(PageModuleBase, {
    constructor: function () {

    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "PositionGridPane") {
            ClientPositionGrid.SetHeight(e.pane.GetClientHeight());
        }
        if (e.pane.name == "CommonGridPane") {
            ClientCommonGrid.SetHeight(e.pane.GetClientHeight());
        }

    },

    ClientFilterButton_Click: function (s, e) {
        RevCost.DoCallback(ClientPositionGrid, function () {
            ClientPositionGrid.PerformCallback('FILTER');
        });
        RevCost.DoCallback(ClientCommonGrid, function () {
            ClientCommonGrid.PerformCallback('FILTER');
        });
    },

    ClientCalcStationeryCostButton_Click: function (s, e) {
        var cf = confirm("Xác nhận chạy tính toán chi phí văn phòng phẩm?");
        if (cf) {

            var aAreaCode = ClientAreaCode.GetValue();
            var aVersionID = ClientVersion.GetValue();
            if (aVersionID == null) {
                alert("Bạn phải chọn một version trước khi thực hiện chức năng này.");
                return;
            }
            RevCost.ShowLoadingPanel(ClientSplitter.GetMainElement());
            RevCost.DoCallback(ClientCalcStationeryCallback, function () {
                ClientCalcStationeryCallback.PerformCallback('CALC_STATIONERY_COST|' + aVersionID + "|" + aAreaCode);
            });
        }
    },

    ClientAreaCode_ValueChanged: function (s, e) {
        var value = s.GetValue();
        RevCost.ShowLoadingPanel(ClientCompany.GetMainElement());
        RevCost.DoCallback(ClientCompany, function () {
            ClientCompany.PerformCallback(value);
        });
    },

    ClientCompany_EndCallback: function (s, e) {
        RevCost.HideLoadingPanel();

        RevCost.ClientFilterButton_Click(null, null);
    },

    ClientApplyToVersionButton_Click: function (s, e) {

    },

    ClientCalcStationeryCallback_CallbackComplete: function (s, e) {
        RevCost.HideLoadingPanel();
        if (e.result == "Success") {
            RevCost.ClientFilterButton_Click(null, null);
        }
        else {
            alert(e.result);
        }
    }

});

(function () {
    var pageModule = new StationeryCostPageModule();
    window.RevCost = pageModule;
})();