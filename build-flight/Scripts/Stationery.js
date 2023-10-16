StationeryPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "View" };
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "GridPane") {
            ClientDataGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientDataGrid_AddNewButtonClick: function (s, e) {
        ASPxClientEdit.ClearEditorsInContainerById('EditForm');

        ClientStationeryNameEditor.SetValue("");
        ClientUnitOfMeasureEditor.SetValue("");
        ClientStationeryTypeEditor.SetValue("DC");
        ClientDescriptionEditor.SetValue("");
        ClientInactiveEditor.SetValue(false);
        ClientStationeryNameEditor.Focus();

        RevCost.ChangeState("EditForm", "Add");
        ClientEditPopupControl.SetHeaderText("Thêm mới");
        ClientEditPopupControl.Show();
    },

    ClientDataGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "GridEdit") {
            if (!s.IsDataRow(s.GetFocusedRowIndex()))
                return;
            var key = s.GetRowKey(s.GetFocusedRowIndex());
            RevCost.ChangeState("EditForm", "Edit", key);

            s.GetValuesOnCustomCallback("EditForm|" + key, function (values) {
                var setValuesFunc = function () {
                    RevCost.HideLoadingPanel();
                    if (!values)
                        return;

                    ClientStationeryNameEditor.SetValue(values["StationeryName"]);
                    ClientUnitOfMeasureEditor.SetValue(values["UnitOfMeasure"]);
                    ClientStationeryTypeEditor.SetValue(values["StationeryType"]);
                    ClientDescriptionEditor.SetValue(values["Description"]);
                    ClientInactiveEditor.SetValue(values["Inactive"] == "True" ? true : false);

                    ClientStationeryNameEditor.Focus();
                    ClientEditPopupControl.SetHeaderText("Cập nhật");
                    ClientEditPopupControl.Show();
                };
                RevCost.PostponeAction(setValuesFunc, function () { return !!window.ClientStationeryNameEditor });
            });
            RevCost.ShowLoadingPanel(ClientSplitter.GetMainElement());
        }
        else if (e.buttonID == "GridDelete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                if (!s.IsDataRow(s.GetFocusedRowIndex()))
                    return;
                var key = s.GetRowKey(s.GetFocusedRowIndex());

                RevCost.DoCallback(ClientDataGrid, function () {
                    ClientDataGrid.PerformCallback("DELETE_STATIONERY|" + key);
                });
            }
        }

    },

    ClientCancelButton_Click: function (s, e) {
        ASPxClientEdit.ClearEditorsInContainerById('EditForm');
        ClientEditPopupControl.Hide();
    },

    ClientSaveButton_Click: function (s, e) {
        if (!ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
            return;

        var state = RevCost.State;
        var args = "SAVE_STATIONERY|" + state.Command + "|" + state.Key;
        RevCost.DoCallback(ClientDataGrid, function () {
            ClientDataGrid.PerformCallback(args);
        });

        ClientEditPopupControl.Hide();
    }

});

(function () {
    var pageModule = new StationeryPageModule();
    window.RevCost = pageModule;
})();