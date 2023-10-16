StationeryNormPageModule = CreateClass(PageModuleBase, {
    constructor: function () {

    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "GridCompanyPane") {
            ClientCompanyGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "PositionNormGridPane") {
            ClientPositionNormGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "CommonNormGridPane") {
            ClientCommonNormGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "PositionPane") {
            ClientPositionGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientNormYearGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID", key);

        RevCost.DoCallback(ClientCommonNormGrid, function () {
            ClientCommonNormGrid.PerformCallback('LOAD_COMMON_STATIONERY|' + key);
        });

        RevCost.DoCallback(ClientPositionGrid, function () {
            ClientPositionGrid.PerformCallback('LOAD_POSITION|' + key);
        });
    },

    ClientCompanyGrid_FocusedNodeChanged: function (s, e) {
        var aCompanyID = s.GetFocusedNodeKey();

        ClientHiddenField.Set("CompanyID", aCompanyID);

        RevCost.DoCallback(ClientCommonNormGrid, function () {
            ClientCommonNormGrid.PerformCallback('LOAD_COMMON_STATIONERY|' + aCompanyID);
        });

        RevCost.DoCallback(ClientPositionGrid, function () {
            ClientPositionGrid.PerformCallback('LOAD_POSITION|' + aCompanyID);
        });
    },


    ClientClientCommonNormGrid_AddNewButtonClick: function (s, e) {
        var nodeKey = ClientCompanyGrid.GetFocusedNodeKey();
        var nodeState = ClientCompanyGrid.GetNodeState(nodeKey);

        if (nodeState == "Child") {
            if (nodeKey != null)
                ClientCommonStationeryPopup.Show();
        }
    },

    ClientAddCommonStationeryButton_Click: function (s, e) {
        var aCompanyID = ClientCompanyGrid.GetFocusedNodeKey();
        if (aCompanyID != null) {
            var keys = [];
            keys = ClientLOVCommonStationeryGrid.GetSelectedKeysOnPage();
            if (keys.length == 0) {
                alert("Bạn phải chọn ít nhất một văn phòng phẩm.");
                return;
            }
            if (keys.length > 0) {
                RevCost.DoCallback(ClientCommonNormGrid, function () {
                    ClientCommonNormGrid.PerformCallback("ADD_STATIONERY|" + aCompanyID + "|" + keys.join("|"));
                });
            }

            ClientLOVCommonStationeryGrid.UnselectAllRowsOnPage();

            ClientCommonStationeryPopup.Hide();
        }
    },

    ClientSaveCommonStationeryButton_Click: function (s, e) {
        if (ClientPositionNormGrid.batchEditApi.HasChanges()) {
            ClientPositionNormGrid.UpdateEdit();
        }

        if (ClientPositionGrid.batchEditApi.HasChanges()) {
            ClientPositionGrid.UpdateEdit();
        }

        if (ClientCommonNormGrid.batchEditApi.HasChanges()) {
            ClientCommonNormGrid.UpdateEdit();
        }
    },

    ClientCancelCommonStationeryButton_Click: function (s, e) {
        if (ClientPositionNormGrid.batchEditApi.HasChanges()) {
            ClientPositionNormGrid.CancelEdit();
        }

        if (ClientPositionGrid.batchEditApi.HasChanges()) {
            ClientPositionGrid.CancelEdit();
        }

        if (ClientCommonNormGrid.batchEditApi.HasChanges()) {
            ClientCommonNormGrid.CancelEdit();
        }
    },

    ClientCommonNormGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "CommonNormGridDelete") {
            var cf = confirm("Bạn chắc chắn muốn xóa bản ghi này?");
            if (cf) {
                if (!s.IsDataRow(s.GetFocusedRowIndex()))
                    return;
                var key = s.GetRowKey(s.GetFocusedRowIndex());

                RevCost.DoCallback(ClientCommonNormGrid, function () {
                    ClientCommonNormGrid.PerformCallback('DELETE_COMMON_STATIONERY|' + key);
                });
            }
        }
    },

    ClientSavePositionStationeryButton_Click: function (s, e) {
        if (ClientPositionNormGrid.batchEditApi.HasChanges()) {
            ClientPositionNormGrid.UpdateEdit();
        }
    },

    ClientCancelPositionStationeryButton_Click: function (s, e) {
        if (ClientPositionNormGrid.batchEditApi.HasChanges()) {
            ClientPositionNormGrid.CancelEdit();
        }
    },

    ClientPositionNormGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "PositionNormGridDelete") {
            var cf = confirm("Bạn chắc chắn muốn xóa bản ghi này?");
            if (cf) {
                if (!s.IsDataRow(s.GetFocusedRowIndex()))
                    return;
                var key = s.GetRowKey(s.GetFocusedRowIndex());

                RevCost.DoCallback(ClientPositionNormGrid, function () {
                    ClientPositionNormGrid.PerformCallback('DELETE_POSITION_STATIONERY|' + key);
                });
            }
        }
    },

    ClientPositionGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "PositionGridDelete") {
            var cf = confirm("Bạn chắc chắn muốn xóa bản ghi này?");
            if (cf) {
                if (!s.IsDataRow(s.GetFocusedRowIndex()))
                    return;
                var key = s.GetRowKey(s.GetFocusedRowIndex());

                RevCost.DoCallback(ClientPositionGrid, function () {
                    ClientPositionGrid.PerformCallback('DELETE_POSITION|' + key);
                });
            }
        }
    },

    ClientPositionGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("PostionCompanyID", key);

        RevCost.DoCallback(ClientPositionNormGrid, function () {
            ClientPositionNormGrid.PerformCallback('LOAD_POSITION_STATIONERY|' + key);
        });

    },

    ClientPositionNormGrid_AddNewButtonClick: function (s, e) {
        var nodeKey = ClientCompanyGrid.GetFocusedNodeKey();
        var nodeState = ClientCompanyGrid.GetNodeState(nodeKey);

        if (nodeState == "Child") {
            if (!ClientPositionGrid.IsDataRow(ClientPositionGrid.GetFocusedRowIndex()))
                return;

            ClientPositionStationeryPopup.Show();
        }
    },


    ClientPositionGrid_AddNewButtonClick: function (s, e) {
        var nodeKey = ClientCompanyGrid.GetFocusedNodeKey();
        var nodeState = ClientCompanyGrid.GetNodeState(nodeKey);

        if (nodeState == "Child")
            ClientPositionGrid.AddNewRow();
    },

    ClientCancelPositionGridButton_Click: function (s, e) {
        if (ClientPositionGrid.batchEditApi.HasChanges()) {
            ClientPositionGrid.CancelEdit();
        }
    },

    ClientSavePositionGridButton_Click: function (s, e) {
        if (ClientPositionGrid.batchEditApi.HasChanges()) {
            ClientPositionGrid.UpdateEdit();
        }
    },


    ClientAddPositionStationeryButton_Click: function (s, e) {
        if (!ClientPositionGrid.IsDataRow(ClientPositionGrid.GetFocusedRowIndex()))
            return;

        var aPositionCompanyID = ClientPositionGrid.GetRowKey(ClientPositionGrid.GetFocusedRowIndex());
        var keys = [];
        keys = ClientLOVPositionStationeryGrid.GetSelectedKeysOnPage();
        if (keys.length == 0) {
            alert("Bạn phải chọn ít nhất một văn phòng phẩm.");
            return;
        }
        if (keys.length > 0) {
            RevCost.DoCallback(ClientPositionNormGrid, function () {
                ClientPositionNormGrid.PerformCallback("ADD_STATIONERY|" + aPositionCompanyID + "|" + keys.join("|"));
            });
        }

        ClientLOVPositionStationeryGrid.UnselectAllRowsOnPage();
        ClientPositionStationeryPopup.Hide();
    },

    ClientPositionGrid_EndCallback: function (s, e) {
        ClientSplitter.AdjustControl();
        if (s.GetVisibleRowsOnPage() > 0 && s.GetFocusedRowIndex() <= 0) {
            s.SetFocusedRowIndex(0);
        }
        if (s.GetVisibleRowsOnPage() <= 0) {
            var key = "0";
            ClientHiddenField.Set("PostionCompanyID", key);
            RevCost.DoCallback(ClientPositionNormGrid, function () {
                ClientPositionNormGrid.PerformCallback('LOAD_POSITION_STATIONERY|' + key);
            });
        }
    },

    ClientCommonNormGrid_EndCallback: function (s, e) {
        ClientSplitter.AdjustControl();
    }

});

(function () {
    var pageModule = new StationeryNormPageModule();
    window.RevCost = pageModule;
})();