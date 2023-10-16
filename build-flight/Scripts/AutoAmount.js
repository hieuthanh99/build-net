AutoAmountPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "Versions") {
            ClientVersionGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "Jobs") {
            ClientJobGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientVersionType_ValueChanged: function (s, e) {
        var versionType = s.GetValue();
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('Reload|' + versionType);
        });
    },

    ClientVersionGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());
        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('Reload|' + key);
        });
    },
    ClientVersionGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());
        RevCost.DoCallback(ClientJobGrid, function () {
            ClientJobGrid.PerformCallback('LoadJobs|' + key);
        });
    },

    ClientSaveButton_Click: function (s, e) {

        if (window.ClientJobTypeEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
            return;

        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var key = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientJobGrid, function () {
            ClientJobGrid.PerformCallback('CreateJob|' + key);
        });

        ClientEditPopup.Hide();

        toastr.options.positionClass = "toast-bottom-right";
        toastr.success("Tiến trình đã đưa vào queued để chạy.");
    },

    ClientRefreshButtonClick: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var key = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientJobGrid, function () {
            ClientJobGrid.PerformCallback('LoadJobs|' + key);
        });
    }

});

(function () {
    var pageModule = new AutoAmountPageModule();
    window.RevCost = pageModule;
})();