CKICountersPageModule = CreateClass(PageModuleBase, {
    constructor: function () {

    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "CKICountersPane") {
            ClientCKICountersGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "CKIAverageTimePane") {
            ClientCKIAverageTimeGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "VNAACConfigPane") {
            ClientVNAACConfigGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientNormYearGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID", key);

        RevCost.DoCallback(ClientCKICountersGrid, function () {
            ClientCKICountersGrid.PerformCallback('LOAD_COUNTER|' + key);
        });

        RevCost.DoCallback(ClientCKIAverageTimeGrid, function () {
            ClientCKIAverageTimeGrid.PerformCallback('LOAD_AVERAGE|' + key);
        });

        RevCost.DoCallback(ClientVNAACConfigGrid, function () {
            ClientVNAACConfigGrid.PerformCallback('LOAD_VNACCONFIG|' + key);
        });
    },

    ClientCKICountersGridSaveButton_Click: function (s, e) {
        if (ClientCKICountersGrid.batchEditApi.HasChanges()) {
            ClientCKICountersGrid.UpdateEdit();
        }

        if (ClientCKIAverageTimeGrid.batchEditApi.HasChanges()) {
            ClientCKIAverageTimeGrid.UpdateEdit();
        }

        if (ClientVNAACConfigGrid.batchEditApi.HasChanges()) {
            ClientVNAACConfigGrid.UpdateEdit();
        }
    },

    ClientCKICountersGridCancelButton_Click: function (s, e) {
        if (ClientCKICountersGrid.batchEditApi.HasChanges()) {
            ClientCKICountersGrid.CancelEdit();
        }

        if (ClientCKIAverageTimeGrid.batchEditApi.HasChanges()) {
            ClientCKIAverageTimeGrid.CancelEdit();
        }

        if (ClientVNAACConfigGrid.batchEditApi.HasChanges()) {
            ClientVNAACConfigGrid.CancelEdit();
        }
    },

    ClientCKIAverageTimeGridSaveButton_Click: function (s, e) {
        if (ClientCKIAverageTimeGrid.batchEditApi.HasChanges()) {
            ClientCKIAverageTimeGrid.UpdateEdit();
        }
    },

    ClientCKIAverageTimeGridCancelButton_Click: function (s, e) {
        if (ClientCKIAverageTimeGrid.batchEditApi.HasChanges()) {
            ClientCKIAverageTimeGrid.CancelEdit();
        }
    },

    ClientVNAACConfigGridSaveButton_Click: function (s, e) {
        if (ClientVNAACConfigGrid.batchEditApi.HasChanges()) {
            ClientVNAACConfigGrid.UpdateEdit();
        }
    },

    ClientVNAACConfigGridCancelButton_Click: function (s, e) {
        if (ClientVNAACConfigGrid.batchEditApi.HasChanges()) {
            ClientVNAACConfigGrid.CancelEdit();
        }
    },


    ClientCKICountersGrid_AddNewButtonClick: function (s, e) {
        ClientCKICountersGrid.AddNewRow();
    },

    ClientCKIAverageTimeGrid_CustomButtonClick: function (s, e) {

    },

    ClientCKICountersGrid_CustomButtonClick: function (s, e) {

    },

    ClientCKICountersGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "CKICountersGridDelete") {
            var cf = confirm("Bạn chắc chắn muốn xóa bản ghi này?");
            if (cf) {
                if (!s.IsDataRow(s.GetFocusedRowIndex()))
                    return;
                var key = s.GetRowKey(s.GetFocusedRowIndex());

                RevCost.DoCallback(ClientCKICountersGrid, function () {
                    ClientCKICountersGrid.PerformCallback('DELETE_CKI_COUNTERS|' + key);
                });
            }
        }
    },

    ClientCKIAverageTimeGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "CKIAverageTimeGridDelete") {
            var cf = confirm("Bạn chắc chắn muốn xóa bản ghi này?");
            if (cf) {
                if (!s.IsDataRow(s.GetFocusedRowIndex()))
                    return;
                var key = s.GetRowKey(s.GetFocusedRowIndex());

                RevCost.DoCallback(ClientCKIAverageTimeGrid, function () {
                    ClientCKIAverageTimeGrid.PerformCallback('DELETE_CKI_AVG_TIME|' + key);
                });
            }
        }
    },

    ClientVNAACConfigGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "VNAACConfigGridDelete") {
            var cf = confirm("Bạn chắc chắn muốn xóa bản ghi này?");
            if (cf) {
                if (!s.IsDataRow(s.GetFocusedRowIndex()))
                    return;
                var key = s.GetRowKey(s.GetFocusedRowIndex());

                RevCost.DoCallback(ClientVNAACConfigGrid, function () {
                    ClientVNAACConfigGrid.PerformCallback('DELETE_VNA_AC_CONFIG|' + key);
                });
            }
        }
    },




});

(function () {
    var pageModule = new CKICountersPageModule();
    window.RevCost = pageModule;
})();