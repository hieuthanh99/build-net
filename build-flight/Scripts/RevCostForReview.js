RevCostForReviewPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
        this.VersionState = { View: "List" };
        this.VerCompanyState = { View: "List" };
        this.VersionCallback = "";
        this.VerCompanyCallback = "";
        this.StoreCallback = "";
    },

    ClientQuery_Click: function (s, e) {
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('Reload');
        });
    },

    ClientContentSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "VersionsPane") {
            ClientVersionGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "VersionCompanyPane") {
            ClientVersionCompanyGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "CompanyStores") {
            ClientStoresGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientVersionGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var versionID = s.GetRowKey(s.GetFocusedRowIndex());

        ClientRevCostHiddenField.Set("VersionID", versionID);
        RevCost.ChangeVersionState("List", "", versionID);
        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + versionID);
        });
    },

    ClientVersionGrid_BeginCallback: function (s, e) {
        this.VersionCallback = e.command;
    },

    ClientVersionGrid_EndCallback: function (s, e) {
        if (this.VersionCallback == "CUSTOMCALLBACK") {
            this.VersionCallback = "";
            if (s.cpCommand == "Reload") {
                if (s.GetVisibleRowsOnPage() > 0) {
                    s.SetFocusedRowIndex(-1);
                    s.SetFocusedRowIndex(0);
                }
                else {
                    ClientRevCostHiddenField.Set("VersionID", 0);
                    RevCost.ChangeVersionState("List", "", 0);
                    RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                        ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + 0);
                    });
                }
            }
        }
    },


    ClientVersionCompanyGrid_BeginCallback: function (s, e) {
        this.VerCompanyCallback = e.command;
    },

    ClientVersionCompanyGrid_EndCallback: function (s, e) {
        if (this.VerCompanyCallback == "CUSTOMCALLBACK") {
            this.VerCompanyCallback = "";
            if (s.cpCommand == "LoadVerCompany") {                
                if (s.GetVisibleRowsOnPage() > 0) {
                    s.SetFocusedRowIndex(-1);
                    s.SetFocusedRowIndex(0);
                }
                else {
                    ClientRevCostHiddenField.Set("VerCompanyID", 0);
                    RevCost.ChangeVerCompanyState("List", "", 0);
                    RevCost.DoCallback(ClientStoresGrid, function () {
                        ClientStoresGrid.PerformCallback('LoadStore|' + 0);
                    });
                }
            }
        }
    },

    ClientVersionCompanyGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var verCompanyID = s.GetRowKey(s.GetFocusedRowIndex());

        ClientRevCostHiddenField.Set("VerCompanyID", verCompanyID);
        RevCost.ChangeVerCompanyState("List", "", verCompanyID);
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('LoadStore|' + verCompanyID);
        });
    },

    ClientCompanies_ValueChanged: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var versionID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + versionID);
        });
    }

});

(function () {
    var pageModule = new RevCostForReviewPageModule();
    window.RevCost = pageModule;
})();