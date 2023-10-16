PlanVMSQtyPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
        this.HistoryCallback = "";
        this.FileName = "";
    },

    ClientContentSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "History") {
            ClientHistoryGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "DataHistory") {
            ClientDataGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ShowMessage: function (message) {
        window.setTimeout("alert('" + message + "')", 0);
    },

    ClientHistoryGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());
        RevCost.DoCallback(ClientDataGrid, function () {
            ClientDataGrid.PerformCallback("LoadDataHistory|" + key);
        });
    },

    ClientHistoryGrid_BeginCallback: function (s, e) {
        this.HistoryCallback = e.command;
    },

    ClientHistoryGrid_EndCallback: function (s, e) {
        if (this.HistoryCallback == "CUSTOMCALLBACK") {
            this.HistoryCallback = "";
            if (s.cpCommand == "LoadHistory" || s.cpCommand == "SyncVMSData") {
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0)
                    s.SetFocusedRowIndex(0);
            }
        }
    },

    ClientQueryButton_Click: function (s, e) {
        RevCost.DoCallback(ClientHistoryGrid, function () {
            ClientHistoryGrid.PerformCallback('LoadHistory');
        });
    },

    ClientSyncDataButton_Click: function (s, e) {
        ClientKHFlightVersionPopup.Show();        
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

        if (!ClientHistoryGrid.IsDataRow(ClientHistoryGrid.GetFocusedRowIndex()))
            return;
        var hisId = ClientHistoryGrid.GetRowKey(ClientHistoryGrid.GetFocusedRowIndex());

        var versionID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

        //var fromMonth = ClientFromMonthEditor.GetValue();
        //var toMonth = ClientToMonthEditor.GetValue();

        RevCost.DoCallback(ClientDataGrid, function () {
            ClientDataGrid.PerformCallback('ApplyToVersion|' + versionID + '|' + hisId);
        });
    },

    ClientShowVersionButton_Click: function (s, e) {
        if (!ClientHistoryGrid.IsDataRow(ClientHistoryGrid.GetFocusedRowIndex()))
            return;

        ClientApplyVersionPopup.Show();
    },

    ClientSyncButton_Click: function (s, e) {
        if (!ClientKHFlightGrid.IsDataRow(ClientKHFlightGrid.GetFocusedRowIndex()))
            return;
        var cf = confirm("Sync VMS Plan quantity confirm?");
        if (cf) {
            var key = ClientKHFlightGrid.GetRowKey(ClientKHFlightGrid.GetFocusedRowIndex());

            RevCost.DoCallback(ClientHistoryGrid, function () {
                ClientHistoryGrid.PerformCallback('SyncVMSData|' + key);
            });

            ClientKHFlightVersionPopup.Hide();
        }
    },

    ClientKHFlightVersionPopup_Shown: function (s, e) {
        RevCost.DoCallback(ClientKHFlightGrid, function () {
            ClientKHFlightGrid.PerformCallback('LoadVersion');
        });
    },

    ClientKHFlightVersionPopup_CloseUp: function (s, e) {

    }

});

(function () {
    var pageModule = new PlanVMSQtyPageModule();
    window.RevCost = pageModule;
})();