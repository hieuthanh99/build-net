KTQTQuantityPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
    },

    ShowMessage: function (message) {
        window.setTimeout("alert('" + message + "')", 0);
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "DataGrid") {
            ClientDataGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientQueryButton_Click: function (s, e) {
        RevCost.DoCallback(ClientDataGrid, function () {
            ClientDataGrid.PerformCallback('LoadData');
        });
    },

    ClientSyncFASTButton_Click: function (s, e) {
        ClientParamsPopup.Show();
    },

    ClientApplySyncFASTData_Click: function (s, e) {
        RevCost.DoCallback(ClientDataGrid, function () {
            ClientDataGrid.PerformCallback('SyncFASTData');
        });
    },

    ClientShowVersionButton_Click: function (s, e) {
        ClientApplyVersionPopup.Show();
    },

    ClientApplyVersionPopup_Shown: function (s, e) {
        //var areaCode = ClientAirport.GetValue();
        //RevCost.DoCallback(ClientApplyCompany, function () {
        //    ClientApplyCompany.PerformCallback('LoadCompany|' + areaCode);
        //});
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('LoadVersion');
        });
    },

    ClientApplyVersionPopup_CloseUp: function (s, e) {

    },

    ClientApplyToVersionButton_Click: function (s, e) {
        //if (ClientApplyCompany.GetValue() == null) {
        //    alert("Select a Company.");
        //    return;
        //}
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex())) {
            alert("Select a Version.");
            return;
        }
        var versionID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientDataGrid, function () {
            ClientDataGrid.PerformCallback('ApplyToVersion|' + versionID);
        });
    },

    ClientApplyToVersionSplliter_PaneResized: function (s, e) {
        if (e.pane.name == "VersionGrid") {
            ClientVersionGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientExportTemplateButton_Click: function (s, e) {
        var area = ClientAirport.GetValue();
        var fromMonth = ClientQueryFromMonthEditor.GetValue();
        var toMonth = ClientQueryToMonthEditor.GetValue();
        var year = ClientQueryYearEditor.GetValue();
        var url = "/Handler/CreateFastDataTemplate.ashx?etCode=GL&area=" + area + "&fromMonth=" + fromMonth + "&toMonth=" + toMonth + "&year=" + year;
        url = window.location.protocol + "//" + window.location.host + url;
        document.location = url;
    },


    ClientImportDataButton_Click: function (s, e) {
        var URL = window.location.protocol + "//" + window.location.host + "/Imports/ImportFastData.aspx";

        window.open(URL, "_blank");
    },

    ClientDataGrid_CustomButtonClick: function (s, e) {
        ClientAdjustCost.SetValue(0);
        ClientAdjustPopup.Show();
    },

    ClientAdjustPopup_Shown: function (s, e) {
        if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
            return;
        var aFASTDataID = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientFASTDataCallback, function () {
            ClientFASTDataCallback.PerformCallback(aFASTDataID);
        });
    },

    ClientFASTDataCallback_CallbackComplete: function (s, e) {
        ClientAdjustCost.SetValue(e.result);
    },

    ClientSaveData_Click: function (s, e) {
        if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
            return;
        var aFASTDataID = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientDataGrid, function () {
            ClientDataGrid.PerformCallback('SaveAdjust|' + aFASTDataID);
        });
    }

});

(function () {
    var pageModule = new KTQTQuantityPageModule();
    window.RevCost = pageModule;
})();
