UnitPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
    
    },

    ShowMessage: function (message) {
        window.setTimeout("alert('" + message + "')", 0);
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "Unit") {
            ClientUnitGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientQueryButton_Click: function (s, e) {
        RevCost.DoCallback(ClientUnitGrid, function () {
            ClientUnitGrid.PerformCallback('LoadData');
        });
    },

    ClientSaveGridButton_Click: function (s, e) {
        if (ClientUnitGrid.batchEditApi.HasChanges()) {
            ClientUnitGrid.UpdateEdit();
        }
    },

    ClientCancelEditButton_Click: function (s, e) {
        if (ClientUnitGrid.batchEditApi.HasChanges()) {
            ClientUnitGrid.CancelEdit();
        }
    },

    ClientDataGrid_AddNewButtonClick: function (s, e) {
        ClientUnitGrid.AddNewRow();
    },

    ClientDataGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "btnDelete") {
            var cf = confirm("Record will be deleted?");
            if (cf) {
                if (!s.IsDataRow(s.GetFocusedRowIndex()))
                    return;
                var key = s.GetRowKey(s.GetFocusedRowIndex());

                RevCost.DoCallback(ClientUnitGrid, function () {
                    ClientUnitGrid.PerformCallback('DELETE|' + key);
                });
            }
        }
    },

    ClientSyncDataButton_Click: function (s, e) {
        var cf = confirm("Bạn chắc chắn muốn đồng bộ dữ liệu từ PMS không?");
        if (cf) {
            RevCost.DoCallback(ClientUnitGrid, function () {
                ClientUnitGrid.PerformCallback('SYNC_DATA');
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
    var pageModule = new UnitPageModule();
    window.RevCost = pageModule;
})();
