FuelNormsPageModule = CreateClass(PageModuleBase, {
    constructor: function () {

    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "NormPane") {
            ClientMasterGrid.SetHeight(e.pane.GetClientHeight() - 30);
            ClientDetailGrid.SetHeight(e.pane.GetClientHeight() - 30);
        }
    },

    ClientNormYearGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID", key);

        RevCost.DoCallback(ClientMasterGrid, function () {
            ClientMasterGrid.PerformCallback("LOAD_MASTER|" + key);
        });

        RevCost.DoCallback(ClientDetailGrid, function () {
            ClientDetailGrid.PerformCallback("LOAD_DETAIL|" + key);
        });
    },

    ClientMasterGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());
    },


    ClientMasterGrid_AddNewButtonClick: function (s, e) {
        //if (ClientMasterGrid.batchEditApi.HasChanges()) {
        //    ClientMasterGrid.UpdateEdit();
        //    //if (!ClientMasterGrid.batchEditApi.ValidateRows(true, false)) {
        //    //    alert("Không thể lưu thông tin do lỗi dữ liệu.");
        //    //    return;
        //    //}
        //}

        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;

        ClientMasterGrid.AddNewRow();
    },

    ClientDetailGrid_AddNewButtonClick: function (s, e) {
        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;

        ClientDetailGrid.AddNewRow();
    },

    ClientMasterGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "MasterGridDelete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientMasterGrid, function () {
                    ClientMasterGrid.PerformCallback("DELETE_MASTER_ROW|" + key);
                });
            }
        }
    },

    ClientDetailGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "DetailGridDelete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientDetailGrid, function () {
                    ClientDetailGrid.PerformCallback("DELETE_DETAIL_ROW|" + key);
                });
            }
        }
    },

    ClientSaveDataGridButton_Click: function (s, e) {
        if (ClientMasterGrid.batchEditApi.HasChanges()) {
            ClientMasterGrid.UpdateEdit();
        }

        if (ClientDetailGrid.batchEditApi.HasChanges()) {
            ClientDetailGrid.UpdateEdit();
        }
    },

    ClientCancelDataGridButton_Click: function (s, e) {
        if (ClientMasterGrid.batchEditApi.HasChanges()) {
            ClientMasterGrid.CancelEdit();
        }

        if (ClientDetailGrid.batchEditApi.HasChanges()) {
            ClientDetailGrid.CancelEdit();
        }
    },

    ClientDetailGrid_EndCallback: function (s, e) {
        ClientSplitter.AdjustControl();
    }
});

(function () {
    var pageModule = new FuelNormsPageModule();
    window.RevCost = pageModule;
})();