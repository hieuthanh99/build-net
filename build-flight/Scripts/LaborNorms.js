LaborNormsPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.LaborNormState = { Command: "VIEW_LABOR_NORM", Key: 0 };
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "ACConfigPane") {
            ClientACConfigGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "GridLaborNormPane") {
            ClientLaborNormGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientACConfigGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("ACConfigID", key);
        if (ClientHiddenField.Get("NormYearID") == null || ClientHiddenField.Get("NormYearID") == "undefined")
            return;

        RevCost.DoCallback(ClientLaborNormGrid, function () {
            ClientLaborNormGrid.PerformCallback('LOAD_LABOR_NORM|' + key);
        });
    },

    ClientNormYearGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID", key);
        if (ClientHiddenField.Get("ACConfigID") == null || ClientHiddenField.Get("ACConfigID") == "undefined")
            return;

        RevCost.DoCallback(ClientLaborNormGrid, function () {
            ClientLaborNormGrid.PerformCallback('LOAD_LABOR_NORM|' + key);
        });
    },

    ClientLaborNormGrid_EndCallback: function (s, e) {
        if (s.GetVisibleRowsOnPage() > 0 && s.GetFocusedRowIndex() < 0) {
            s.SetFocusedRowIndex(0);
        }
    },


    ClientLaborNormGrid_AddNewButtonClick: function (s, e) {

        if (!ClientACConfigGrid.IsDataRow(ClientACConfigGrid.GetFocusedRowIndex()))
            return;

        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;

        var aACConfigID = ClientACConfigGrid.GetRowKey(ClientACConfigGrid.GetFocusedRowIndex());
        var aNormYearID = ClientNormYearGrid.GetRowKey(ClientNormYearGrid.GetFocusedRowIndex());

        ClientHiddenField.Set("ACConfigID", aACConfigID);
        ClientHiddenField.Set("NormYearID", aNormYearID);

        ASPxClientEdit.ClearEditorsInContainerById('LaborNormForm');
        ClientGroupEditor.SetValue(null);
        ClientCodeEditor.SetValue(null);
        ClientPrepareTimeEditor.SetValue(0);
        ClientOperatingTimeEditor.SetValue(0);
        ClientPeopleEditor.SetValue(1);
        ClientCoefficientKEditor.SetValue(1);
        ClientExpendMinutesEditor.SetValue(0);
        ClientExpendHoursEditor.SetValue(0);

        ClientLaborNormDetailDescriptionEditor.SetValue("");
        ClientLaborNormDetailInactiveEditor.SetValue(false);

        this.LaborNormState = { Command: "ADD_LABOR_NORM", Key: 0 };
        ClientLaborNormDetailAddOrEditPopup.SetWidth(500);
        ClientLaborNormDetailAddOrEditPopup.SetHeight(450);
        ClientLaborNormDetailAddOrEditPopup.SetHeaderText("Thêm mới");
        ClientLaborNormDetailAddOrEditPopup.Show();
    },


    ClientLaborNormGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        var command = "EDIT_LABOR_NORM";
        if (e.buttonID == "DetailEdit") {
            ASPxClientEdit.ClearEditorsInContainerById('LaborNormForm');
            this.LaborNormState = { Command: "EDIT_LABOR_NORM", Key: key };

            ClientLaborNormGrid.GetValuesOnCustomCallback("LaborNormForm|" + this.LaborNormState.Command + "|" + key, function (values) {
                var setValuesFunc = function () {
                    RevCost.HideLoadingPanel();
                    if (!values)
                        return;

                    ClientGroupEditor.SetValue(values["ItemGroup"]);
                    ClientPrepareTimeEditor.SetValue(values["PreparationTime"]);
                    ClientOperatingTimeEditor.SetValue(values["OperatingTime"]);
                    ClientPeopleEditor.SetValue(values["NumberOfPeople"]);
                    ClientCoefficientKEditor.SetValue(values["CoefficientK"]);
                    ClientExpendMinutesEditor.SetValue(values["NormInMinutes"]);
                    ClientExpendHoursEditor.SetValue(values["NormInHours"]);

                    ClientLaborNormDetailDescriptionEditor.SetValue(values["Description"]);
                    ClientLaborNormDetailInactiveEditor.SetValue(values["Inactive"] == "True" ? true : false);

                    RevCost.ShowLoadingPanel(ClientCodeEditor.GetMainElement());
                    RevCost.DoCallback(ClientCodeEditor, function () {
                        ClientCodeEditor.PerformCallback(values["ItemGroup"]);
                    });
                    ClientCodeEditor.SetValue(values["ItemID"]);
                    ClientCodeEditor.SetText(values["ItemName"]);

                    ClientCodeEditor.Focus();

                    ClientLaborNormDetailAddOrEditPopup.SetWidth(500);
                    ClientLaborNormDetailAddOrEditPopup.SetHeight(450);
                    ClientLaborNormDetailAddOrEditPopup.SetHeaderText("Cập nhật");
                    ClientLaborNormDetailAddOrEditPopup.Show();
                };
                RevCost.PostponeAction(setValuesFunc, function () { return !!window.ClientCodeEditor });
            });
            RevCost.ShowLoadingPanel(ClientSplitter.GetMainElement());

        }

        if (e.buttonID == "DetailDelete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientLaborNormGrid, function () {
                    ClientLaborNormGrid.PerformCallback("DELETE_LABOR_NORM|" + key);
                });
            }
        }
    },

    ClientLaborNormDetailAddOrEditPopup_Hide: function (s, e) {
        ASPxClientEdit.ClearEditorsInContainerById('LaborNormForm');
        ClientLaborNormDetailAddOrEditPopup.Hide();
    },

    ClientGroupEditor_ValueChanged: function (s, e) {
        RevCost.ShowLoadingPanel(ClientCodeEditor.GetMainElement());
        var args = s.GetValue();
        RevCost.DoCallback(ClientCodeEditor, function () {
            ClientCodeEditor.PerformCallback(args);
        });
    },

    IsNull: function (value, replace) {
        if (value == null || value == "undefined")
            return replace;

        return value;
    },

    ClientCodeEditor_EndCallback: function (s, e) {
        RevCost.HideLoadingPanel();
    },

    CalculateLaborNormTimes: function (s, e) {
        var prepareTime = ClientPrepareTimeEditor.GetValue();
        var operatingTime = ClientOperatingTimeEditor.GetValue();
        var people = ClientPeopleEditor.GetValue();
        var k = ClientCoefficientKEditor.GetValue();
        if (k == 0) k = 1;
        var minuts = (RevCost.IsNull(prepareTime, 0) + RevCost.IsNull(operatingTime, 0)) * RevCost.IsNull(people, 0) * RevCost.IsNull(k, 1);

        ClientExpendMinutesEditor.SetValue(minuts);
        ClientExpendHoursEditor.SetValue(minuts / 60);
    },


    ClientLaborNormDetailAddOrEditPopup_Save: function (s, e) {
        if (!ASPxClientEdit.ValidateEditorsInContainerById("LaborNormForm"))
            return;

        var state = this.LaborNormState;
        //alert(state.Command);
        var args = "SAVE_LABOR_NORM|" + state.Command + "|" + state.Key;
        RevCost.ShowLoadingPanel(ClientLaborNormForm.GetMainElement());
        RevCost.DoCallback(ClientLaborNormCallback, function () {
            ClientLaborNormCallback.PerformCallback(args);
        });
    },

    ClientLaborNormCallback_CallbackComplete: function (s, e) {
        RevCost.HideLoadingPanel();
        var args = e.result.split('|');
        if (args[0] == "SAVE_LABOR_NORM") {
            if (args[1] == "SUCCESS") {
                ClientLaborNormDetailAddOrEditPopup.Hide();
                ClientLaborNormGrid.Refresh();
            } else {
                alert(args[1]);
            }
        }
    },

    ClientCopyButton_Click: function (s, e) {
        ClientCopyNormPopup.Show();
    },

    ClientFromNormYear_ValueChanged: function (s, e) {
        var args = "LOAD_TO_NORM|" + s.GetValue();
        RevCost.DoCallback(ClientCopyToNormYear, function () {
            ClientCopyToNormYear.PerformCallback(args);
        });
    },

    ClientApplyCopyButton_Click: function (s, e) {
        var aACConfigID = ClientHiddenField.Get("ACConfigID");
        var aNormYearID = ClientHiddenField.Get("NormYearID");

        var args = "COPY_NORM|" + aNormYearID + "|" + aACConfigID;
        RevCost.DoCallback(ClientLaborNormGrid, function () {
            ClientLaborNormGrid.PerformCallback(args);
        });
    }
});

(function () {
    var pageModule = new LaborNormsPageModule();
    window.RevCost = pageModule;
})();