BCNPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
    },

    ClientContentSplitter_PaneResized: function (s, e) {
       if (e.pane.name == "DataHistory") {
           ClientDataGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ShowMessage: function (message) {
        window.setTimeout("alert('" + message + "')", 0);
    },

    ClientQueryButton_Click: function (s, e) {
        RevCost.DoCallback(ClientDataGrid, function () {
            ClientDataGrid.PerformCallback("LoadData");
        });
    },

    ClientSaveBcnTotal_Click: function (s, e) {
        if (ClientDataGrid.batchEditApi.HasChanges()) {
            ClientDataGrid.UpdateEdit();
        }
    }
   
});

(function () {
    var pageModule = new BCNPageModule();
    window.RevCost = pageModule;
})();