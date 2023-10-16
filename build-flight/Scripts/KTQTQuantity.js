KTQTQuantityPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
    },

    ShowMessage: function (message) {
        window.setTimeout("alert('" + message + "')", 0);
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "FltOps") {
            ClientFltOpsGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientQueryButton_Click: function (s, e) {
        RevCost.DoCallback(ClientFltOpsGrid, function () {
            ClientFltOpsGrid.PerformCallback('LoadData');
        });
    },

    ClientFltOpsGrid_EndCallback: function(s, e){
        if (s.cpMissAircraft) {
            ClientMissAircraft.SetText(s.cpMissAircraft);
        }
    },

    ClientSyncVMSButton_Click: function (s, e) {
        ClientParamsPopup.Show();
    },

    ClientSyncVMSQuantity_Click: function (s, e) {
        RevCost.DoCallback(ClientFltOpsGrid, function () {
            ClientFltOpsGrid.PerformCallback('SyncVMS');
        });
    },

    ClientAllocateOthRevButton_Click: function (s, e) {
        ClientAllocateOthRevPopup.Show();
    },

    ClientApplyAllocate_Click: function (s, e) {
        RevCost.DoCallback(ClientFltOpsGrid, function () {
            ClientFltOpsGrid.PerformCallback('RunAllocateOthRev');
        });
    },

    ClientSyncDataButton_Click: function (s, e) {
        var cf = confirm("Bạn chắc chắn muốn đồng bộ dữ liệu từ PMS không?");
        if (cf) {
            RevCost.DoCallback(ClientFltOpsGrid, function () {
                ClientFltOpsGrid.PerformCallback('SYNC_DATA');
            });
        }
    },

    ClientFilterYearEditor_ValueChanged: function (s, e) {
        RevCost.DoCallback(ClientVersionEditor, function () {
            ClientVersionEditor.PerformCallback();
        });
    },

    ClientVersionEditor_EndCallback: function (s, e) {
        RevCost.ClientQueryButton_Click(null, null);
    },

});

(function () {
    var pageModule = new KTQTQuantityPageModule();
    window.RevCost = pageModule;
})();
