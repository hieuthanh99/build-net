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

    ClientSyncDTNCBButton_Click: function (s, e) {
        RevCost.DoCallback(ClientDataGrid, function () {
            ClientDataGrid.PerformCallback('SyncDTNCBData');
        });
    },

    ClientShowVersionButton_Click: function (s, e) {
        ClientApplyVersionPopup.Show();
    },

    ClientApplyVersionPopup_Shown: function (s, e) {
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('LoadVersion');
        });
    },

    ClientApplyVersionPopup_CloseUp: function (s, e) {

    },

    ClientApplyToVersionButton_Click: function (s, e) {
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
        var month = ClientQueryMonthEditor.GetValue();
        var year = ClientQueryYearEditor.GetValue();
        var url = "/Handler/CreateFastDataTemplate.ashx?etCode=GL&area=" + area + "&month=" + month + "&year=" + year;
        url = window.location.protocol + "//" + window.location.host + url;
        document.location = url;       
    },


    ClientImportDataButton_Click: function (s, e) {
        var URL = window.location.protocol + "//" + window.location.host + "/Imports/ImportFastData.aspx";

        window.open(URL, "_blank");
    }


});

(function () {
    var pageModule = new KTQTQuantityPageModule();
    window.RevCost = pageModule;
})();
