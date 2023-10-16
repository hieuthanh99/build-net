LaborPositionPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.LaborNormState = { Command: "VIEW_LABOR_NORM", PositionKey: 0, NormKey: 0 };
    },

    ControlsInitialized: function (s, e) {
        if (!e.isCallback) {
            var aGroupID = ClientGroupGrid.GetFocusedNodeKey();

            RevCost.DoCallback(ClientPositionGrid, function () {
                ClientPositionGrid.PerformCallback('LOAD_POSITION|' + aGroupID);
            });
        }
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "GridPGPane") {
            ClientGroupGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "GridPositionPane") {
            ClientPositionGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "CompanyGridPane") {
            ClientCompanyGrid.SetHeight(e.pane.GetClientHeight());
        }

        else if (e.pane.name == "LaborNormGridPane") {
            ClientLaborNormGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientGroupGrid_AddNewButtonClick: function (s, e) {

    },

    ClientPositionGrid_AddNewButtonClick: function (s, e) {
        ClientPositionPopup.Show();
    },

    ClientNormYearGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID", key);

        RevCost.DoCallback(ClientLaborNormGrid, function () {
            ClientLaborNormGrid.PerformCallback('LOAD_LABOR_NORM|' + key);
        });
    },

    ClientGroupGrid_FocusedNodeChanged: function (s, e) {
        var aDMGroupID = s.GetFocusedNodeKey();

        ClientHiddenField.Set("DMGroupID", aDMGroupID);

        RevCost.DoCallback(ClientPositionGrid, function () {
            ClientPositionGrid.PerformCallback('LOAD_POSITION|' + aDMGroupID);
        });

    },

    ClientGroupGrid_EndCallback: function (s, e) {

    },

    ClientAddPositionButton_Click: function (s, e) {
        var aGroupID = ClientGroupGrid.GetFocusedNodeKey();
        var keys = [];
        keys = ClientLOVPositionGrid.GetSelectedKeysOnPage();
        if (keys.length == 0) {
            alert("Bạn phải chọn ít nhất một đơn vị.");
            return;
        }
        if (keys.length > 0) {
            RevCost.DoCallback(ClientPositionGrid, function () {
                ClientPositionGrid.PerformCallback("ADD_POSITION|" + aGroupID + "|" + keys.join("|"));
            });
        }

        ClientLOVPositionGrid.UnselectAllRowsOnPage();
    },

    ClientCompanyGrid_AddNewButtonClick: function (s, e) {
        var aGroupID = ClientGroupGrid.GetFocusedNodeKey();
        if (aGroupID != null)
            ClientCompanyPopup.Show();
    },

    ClientPositionGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("DMPositionID", key);

        RevCost.DoCallback(ClientLaborNormGrid, function () {
            ClientLaborNormGrid.PerformCallback("LOAD_LABOR_NORM|" + key);
        });

        RevCost.DoCallback(ClientCompanyGrid, function () {
            ClientCompanyGrid.PerformCallback('LOAD_COMPANY|' + key);
        });
    },

    IsNull: function (value, replace) {
        if (value == null || value == "undefined")
            return replace;

        return value;
    },

    CalculateWorkTotal: function () {
        var peopleNbr = ClientPeopleNbrEditor.GetValue();
        var shiftNbr = ClientShiftNbrEditor.GetValue();

        var workTotal = (RevCost.IsNull(peopleNbr, 0)) * RevCost.IsNull(shiftNbr, 0);
        ClientWorkTotalEditor.SetValue(workTotal);
    },

    ClientLaborNormGrid_AddNewButtonClick: function (s, e) {
        if (!ClientPositionGrid.IsDataRow(ClientPositionGrid.GetFocusedRowIndex())) {
            alert("Bạn phải chọn một chức danh để nhập định mức.");
            return;
        }
        ClientLaborNormGrid.AddNewRow();

        //var aPositionKey = ClientPositionGrid.GetRowKey(ClientPositionGrid.GetFocusedRowIndex());

        //ASPxClientEdit.ClearEditorsInContainerById('LaborNormForm');
        ////ClientForYearEditor.SetValue((new Date()).getFullYear());
        //ClientAreaCodeEditor.SetValue(AreaCode);
        //ClientPeopleNbrEditor.SetValue(1);
        //ClientShiftNbrEditor.SetValue(1);
        //ClientWorkTotalEditor.SetValue(1);
        //ClientDescriptionEditor.SetValue("");
        //ClientInactiveEditor.SetValue(false);

        //this.LaborNormState = { Command: "ADD_LABOR_NORM", PositionKey: aPositionKey, NormKey: 0 };
        //ClientLaborPositionNormPopup.SetHeaderText("Thêm mới");
        //ClientLaborPositionNormPopup.Show();
    },

    ClientSaveDataGridButton_Click: function (s, e) {
        if (ClientLaborNormGrid.batchEditApi.HasChanges()) {
            ClientLaborNormGrid.UpdateEdit();
        }
    },

    ClientCancelDataGridButton_Click: function(s, e){
        if (ClientLaborNormGrid.batchEditApi.HasChanges()) {
            ClientLaborNormGrid.CancelEdit();
        }
    },

    ClientLaborNormGrid_CustomButtonClick: function (s, e) {

        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        var aPositionKey = ClientPositionGrid.GetRowKey(ClientPositionGrid.GetFocusedRowIndex());

        if (e.buttonID == "NormEdit") {

            this.LaborNormState = { Command: "EDIT_LABOR_NORM", PositionKey: aPositionKey, NormKey: key };
            ASPxClientEdit.ClearEditorsInContainerById('LaborNormForm');
            ClientLaborPositionNormPopup.SetHeaderText("Cập nhật");
            ClientLaborPositionNormPopup.Show();
        }
        else if (e.buttonID == "NormDelete") {
            var cf = confirm("Xác nhận xóa bản ghi định mức lao động?");
            //if (cf) {

            //}
        }
    },

    ClientAddLaborNormButton_Click: function (s, e) {
        if (!ASPxClientEdit.ValidateEditorsInContainerById("LaborNormForm"))
            return;

        var state = this.LaborNormState;
        //alert(state.Command + "|" + state.NormKey);
        var args = "SAVE_LABOR_NORM|" + state.Command + "|" + state.PositionKey + "|" + state.NormKey;
        RevCost.DoCallback(ClientLaborNormGrid, function () {
            ClientLaborNormGrid.PerformCallback(args);
        });

        ClientLaborPositionNormPopup.Hide();
    },

    ClientAddCompanyButton_Click: function (s, e) {
        if (!ClientPositionGrid.IsDataRow(ClientPositionGrid.GetFocusedRowIndex()))
            return;
        var aDMPositionID = ClientPositionGrid.GetRowKey(ClientPositionGrid.GetFocusedRowIndex());

        var keys = [];
        keys = ClientLOVCompanyGrid.GetSelectedKeysOnPage();
        if (keys.length == 0) {
            alert("Bạn phải chọn ít nhất một đơn vị.");
            return;
        }
        if (keys.length > 0) {
            RevCost.DoCallback(ClientCompanyGrid, function () {
                ClientCompanyGrid.PerformCallback("ADD_COMPANY|" + aDMPositionID + "|" + keys.join("|"));
            });
        }

        ClientLOVCompanyGrid.UnselectAllRowsOnPage();

    },

    ClientCompanyGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "CompanyRemove") {
            if (!s.IsDataRow(s.GetFocusedRowIndex()))
                return;
            var key = s.GetRowKey(s.GetFocusedRowIndex());

            var cf = confirm("Bạn chắc chắn muốn xóa bản ghi này?");
            if (cf) {
                RevCost.DoCallback(ClientCompanyGrid, function () {
                    ClientCompanyGrid.PerformCallback('DELETE_COMPANY|' + key);
                });
            }

        }
    },

    ClientPositionGrid_BeginCallback: function (s, e) {
        this.CallbackCommand = e.command;
    },

    ClientPositionGrid_EndCallback: function (s, e) {
        if (this.CallbackCommand != undefined && this.CallbackCommand == 'CUSTOMCALLBACK') {
            s.SetFocusedRowIndex(-1);
            if (s.GetVisibleRowsOnPage() > 0)
                s.SetFocusedRowIndex(0);
            else {
                var key = "-1";
                ClientHiddenField.Set("DMPositionID", key);
                RevCost.DoCallback(ClientLaborNormGrid, function () {
                    ClientLaborNormGrid.PerformCallback("LOAD_LABOR_NORM|" + key);
                });

                RevCost.DoCallback(ClientCompanyGrid, function () {
                    ClientCompanyGrid.PerformCallback('LOAD_COMPANY|' + key);
                });
            }
        } else {
            if (s.GetVisibleRowsOnPage() > 0 && s.GetFocusedRowIndex() <= 0) {
                s.SetFocusedRowIndex(0);
            }
        }
    },

});

(function () {
    var pageModule = new LaborPositionPageModule();
    window.RevCost = pageModule;
})();