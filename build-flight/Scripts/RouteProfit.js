RouteProfitPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "Versions") {
            ClientVersionGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "AllocateHis") {
            ClientAllocateHisGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "VersionCompany") {
            ClientVersionCompanyGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientVersionType_ValueChanged: function (s, e) {
        var versionType = s.GetValue();
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('Reload|' + versionType);
        });
    },

    ClientVersionGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());
        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('Reload|' + key);
        });
    }

});

(function () {
    var pageModule = new RouteProfitPageModule();
    window.RevCost = pageModule;
})();