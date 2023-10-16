RevCostPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        //this.VersionState = { View: "List" };
        //this.VerCompanyState = { View: "List" };
        //this.StoreState = { View: "List" };
        //this.IsPageload = true;
        //this.CopyVersion = "";
        //this.VersionCallback = "";
        //this.VerCompanyCallback = "";
        //this.StoreCallback = "";
        //this.StoreDetailCallback = "";
    },

    OnPageInit: function (s, e) {
        //if (RevCost.IsPageload) {
        //    RevCost.IsPageload = false;
        //    ClientNewVersionButton.SetVisible(ClientRevCostHiddenField.Get("CompanyType") == 'K');
        //    ClientChangeCompanyButton.SetVisible(ClientRevCostHiddenField.Get("CompanyType") == 'K');
        //    window.setTimeout(function () {
        //        RevCost.showLeftPane();
        //    }, 500);
        //}
    },

    ShowMessage: function (message) {
        window.setTimeout("alert('" + message + "')", 0);
    },

    ClientContentSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "pnPlanning") {
            grdVersion.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "pnVersion") {
            grdVersionCompany.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "pnStore") {
            grdStore.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "pnTree") {
            tltVersion.SetHeight(e.pane.GetClientHeight())
        }
    },

    ClientView_Click: function (s, e) {
        RevCost.DoCallback(grdVersion, function () {
            grdVersion.PerformCallback('Reload');
        });
    },

    ClientDivisionFocusedRowChanged: function (s, e) {
        RevCost.DoCallback(grdVersionCompany, function () {
            grdVersionCompany.PerformCallback('Reload|0');
        });
    },

    ClientVersionCompany_FocusedRowChanged: function (s, e) {
        var verCompanyID = s.GetRowKey(s.GetFocusedRowIndex());
        if (verCompanyID != null) { //haidd
            tltVersion.PerformCustomCallback('Reload|' + verCompanyID);
        }
    },

    ClientVersionCompany_EndCallback: function (s, e) {
        s.SetFocusedRowIndex(-1);
        if (s.GetVisibleRowsOnPage() > 0) {
            s.SetFocusedRowIndex(0);
        }
        else {
            tltVersion.PerformCustomCallback('Reload|' + 0);
        }
    },

    ClientVersion_FocusedRowChanged: function (s, e) {
        var verID = s.GetRowKey(s.GetFocusedRowIndex());
        RevCost.DoCallback(grdVersionCompany, function () {
            grdVersionCompany.PerformCallback('Reload|' + verID);
        });
    },

    ClientTreeVersion_NodeDbClick: function (s, e) {
        if (!grdVersionCompany.IsDataRow(grdVersionCompany.GetFocusedRowIndex()))
            return;
        var verID = grdVersionCompany.GetRowKey(grdVersionCompany.GetFocusedRowIndex());

        var nodeValue = e.nodeKey;
        RevCost.DoCallback(grdStore, function () {
            grdStore.PerformCallback('General|' + verID + '|' + nodeValue);
        });
    },

    ClientVersionCompany_General: function (s, e) {
        var verCompanyID = s.GetRowKey(s.GetFocusedRowIndex());
        grdStore.PerformCallback('Gen|' + verCompanyID);
    },

    grdVersion_EndCallback: function (s, e) {
        s.SetFocusedRowIndex(-1);
        if (s.GetVisibleRowsOnPage() > 0)
            s.SetFocusedRowIndex(0);
        else {
            RevCost.DoCallback(grdVersionCompany, function () {
                grdVersionCompany.PerformCallback('Reload|' + 0);
            });
        }
    },

    // Bao cao
    ClientbtnPrintStoreButton_Click: function (s, e) {
        //var State = RevCost.VerCompanyState;
        //var Year = VersionYearEditor.GetValue();
        //var VerType = rdoVersionType.GetValue();

        //ClientRevCostHiddenField.Set("VerCompanyID", State.Key);
        var URL = window.location.protocol + "//" + window.location.host + "/Reports/Report_RevCost_Division.aspx";
        window.open(URL, "_blank");
    },

});

(function () {
    var pageModule = new RevCostPageModule();
    window.RevCost = pageModule;
})();
