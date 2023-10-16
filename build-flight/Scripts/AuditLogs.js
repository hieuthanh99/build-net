AuditLogsPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
    },

    ShowMessage: function (message) {
        window.setTimeout("alert('" + message + "')", 0);
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "AuditLogs") {
            ClientAuditLogGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientQueryButton_Click: function (s, e) {
        RevCost.DoCallback(ClientAuditLogGrid, function () {
            ClientAuditLogGrid.PerformCallback('LoadData');
        });
    },

    ClientAuditLogGrid_EndCallback: function(s, e){
        if (s.cpMissAircraft) {
            ClientMissAircraft.SetText(s.cpMissAircraft);
        }
    },

    ClientSyncVMSButton_Click: function (s, e) {
        ClientParamsPopup.Show();
    },

    ClientSyncVMSQuantity_Click: function (s, e) {
        RevCost.DoCallback(ClientAuditLogGrid, function () {
            ClientAuditLogGrid.PerformCallback('SyncVMS');
        });
    },

    ClientAllocateOthRevButton_Click: function (s, e) {
        ClientAllocateOthRevPopup.Show();
    },

    ClientApplyAllocate_Click: function (s, e) {
        RevCost.DoCallback(ClientAuditLogGrid, function () {
            ClientAuditLogGrid.PerformCallback('RunAllocateOthRev');
        });
    }
   

});

(function () {
    var pageModule = new AuditLogsPageModule();
    window.RevCost = pageModule;
})();
