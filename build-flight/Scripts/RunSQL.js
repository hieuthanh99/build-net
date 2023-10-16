RunSQLPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "DataResult") {
            ClientDataGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ExecuteSQL: function (s, e) {
        var sql = ClientSqlEditor.GetValue();
        if (sql == '' || sql == null || sql == undefined) {
            toastr.options.positionClass = "toast-bottom-right";
            toastr.warning("Câu lệnh trống.");
            return;
        }
        var inputElement = ClientSqlEditor.GetInputElement();
        var selection = inputElement.value.substring(inputElement.selectionStart, inputElement.selectionEnd);

        if (selection !== '' && selection !== null && selection !== undefined) {
            sql = selection;
        }

        RevCost.DoCallback(ClientDataGrid, function () {
            ClientDataGrid.PerformCallback('Exec|' + sql);
        });
    }


});

(function () {
    var pageModule = new RunSQLPageModule();
    window.RevCost = pageModule;
})();