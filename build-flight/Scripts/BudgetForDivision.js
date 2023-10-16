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
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var verCompanyID = s.GetRowKey(s.GetFocusedRowIndex());
        ClientRevCostHiddenField.Set("VerCompanyID", verCompanyID);

        tltVersion.PerformCustomCallback('Reload|' + verCompanyID);
    },

    ClientVersionCompany_EndCallback: function (s, e) {
        s.SetFocusedRowIndex(-1);
        if (s.GetVisibleRowsOnPage() > 0) {
            s.SetFocusedRowIndex(0);
        }
        else {
            ClientRevCostHiddenField.Set("VerCompanyID", 0);
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

    ClientbtnPrint_Click: function (s, e) {
        ClientReportPopup.Show();
    },

    rdReport_Init: function (s, e) {
        dedFromDate.SetEnabled(false);
        dedToDate.SetEnabled(false);
    },

    rdReport_SelectedIndexChanged: function (s, e) {
        if (rdReport.GetValue() == "2") {
            dedFromDate.SetEnabled(true);
            dedToDate.SetEnabled(true);
        }
        else {
            dedFromDate.SetEnabled(false);
            dedToDate.SetEnabled(false);
        }
    },

    btnPrintReport_Click: function (s, e) {

        if (rdReport.GetValue() == "2" && (dedFromDate.GetValue() == null || dedToDate.GetValue() == null)) {
            alert('Bạn chưa nhập giai đoạn !!!');
        }
        else {
            ClientReportViewer.Refresh();
        }
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

});

(function () {
    var pageModule = new RevCostPageModule();
    window.RevCost = pageModule;
})();
