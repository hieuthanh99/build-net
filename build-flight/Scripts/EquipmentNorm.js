EquipmentNormPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.DetailState = { Command: "VIEW_DETAIL_NORM", Key: 0 };
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "ACConfigPane") {
            ClientACConfigGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "GridEquipmentNormPane") {
            ClientEquipmentNormGrid.SetHeight(e.pane.GetClientHeight());
        }
    },


    ClientACConfigGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("ACConfigID", key);
        if (ClientHiddenField.Get("NormYearID") == null || ClientHiddenField.Get("NormYearID") == "undefined")
            return;

        RevCost.DoCallback(ClientEquipmentNormGrid, function () {
            ClientEquipmentNormGrid.PerformCallback('LOAD_DETAIL_NORM|' + key);
        });
    },


    ClientNormYearGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID", key);
        if (ClientHiddenField.Get("ACConfigID") == null || ClientHiddenField.Get("ACConfigID") == "undefined")
            return;

        RevCost.DoCallback(ClientEquipmentNormGrid, function () {
            ClientEquipmentNormGrid.PerformCallback('LOAD_DETAIL_NORM|' + key);
        });
    },

    ClientEquipmentNormGrid_EndCallback: function (s, e) {
        if (s.GetVisibleRowsOnPage() > 0 && s.GetFocusedRowIndex() <= 0) {
            s.SetFocusedRowIndex(0);
        }
    },

    ClientEquipmentNormGrid_AddNewButtonClick: function (s, e) {

        if (!ClientACConfigGrid.IsDataRow(ClientACConfigGrid.GetFocusedRowIndex()))
            return;

        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;

        var aACConfigID = ClientACConfigGrid.GetRowKey(ClientACConfigGrid.GetFocusedRowIndex());
        var aNormYearID = ClientNormYearGrid.GetRowKey(ClientNormYearGrid.GetFocusedRowIndex());

        ClientHiddenField.Set("ACConfigID", aACConfigID);
        ClientHiddenField.Set("NormYearID", aNormYearID);

        ASPxClientEdit.ClearEditorsInContainerById('DetailNormForm');
        ClientGroupEditor.SetValue(null);
        ClientSoluongTTBEditor.SetValue(1);
        ClientCodeEditor.SetValue("");
        ClientPrepareTimeEditor.SetValue(0);
        ClientMovingTimeEditor.SetValue(0);
        ClientWaitingTimeEditor.SetValue(0);
        ClientApproachTimeEditor.SetValue(0);
        ClientTimeServedAtPlaneEditor.SetValue(0);
        ClientTimeServedAtStoreEditor.SetValue(0);
        ClientTimeServedAtBCEditor.SetValue(0);
        ClientNightServedTimeEditor.SetValue(0);
        ClientCleaningTimeEditor.SetValue(0);
        ClientTotalTimeEditor.SetValue(0);

        ClientFrequencyEditor.SetValue(0);

        this.DetailState = { Command: "ADD_DETAIL_NORM", Key: 0 };
        ClientDetailNormAddOrEditPopup.SetWidth(550);
        ClientDetailNormAddOrEditPopup.SetHeight(450);
        ClientDetailNormAddOrEditPopup.SetHeaderText("Thêm mới");
        ClientDetailNormAddOrEditPopup.Show();
    },

    ClientEquipmentNormGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        var command = "EDIT_DETAIL_NORM";
        if (e.buttonID == "DetailEdit") {
            ASPxClientEdit.ClearEditorsInContainerById('DetailNormForm');
            this.DetailState = { Command: "EDIT_DETAIL_NORM", Key: key };

            ClientEquipmentNormGrid.GetValuesOnCustomCallback("DetailNormForm|" + this.DetailState.Command + "|" + key, function (values) {
                var setValuesFunc = function () {
                    RevCost.HideLoadingPanel();
                    if (!values)
                        return;

                    ClientGroupEditor.SetValue(values["GroupItem"]);
                    ClientSoluongTTBEditor.SetValue(values["NumberOfEquipment"]);
                    ClientPrepareTimeEditor.SetValue(values["PreparationTime"]);
                    ClientMovingTimeEditor.SetValue(values["MovingTime"]);
                    ClientWaitingTimeEditor.SetValue(values["WaitingTime"]);
                    ClientApproachTimeEditor.SetValue(values["ApproachTime"]);
                    ClientTimeServedAtPlaneEditor.SetValue(values["TimeServedAtPlane"]);
                    ClientTimeServedAtStoreEditor.SetValue(values["TimeServedAtStore"]);
                    ClientTimeServedAtBCEditor.SetValue(values["TimeServedAtBC"]);
                    ClientNightServedTimeEditor.SetValue(values["NightServedTime"]);
                    ClientCleaningTimeEditor.SetValue(values["CleaningTime"]);
                    ClientTotalTimeEditor.SetValue(values["TotalTime"]);

                    ClientFrequencyEditor.SetValue(values["Frequency"]);

                    RevCost.ShowLoadingPanel(ClientCodeEditor.GetMainElement());
                    RevCost.DoCallback(ClientCodeEditor, function () {
                        ClientCodeEditor.PerformCallback(values["GroupItem"]);
                    });
                    ClientCodeEditor.SetValue(values["ItemID"]);
                    ClientCodeEditor.SetText(values["ItemName"]);

                    ClientCodeEditor.Focus();

                    ClientDetailNormAddOrEditPopup.SetWidth(550);
                    ClientDetailNormAddOrEditPopup.SetHeight(450);
                    ClientDetailNormAddOrEditPopup.SetHeaderText("Cập nhật");
                    ClientDetailNormAddOrEditPopup.Show();
                };
                RevCost.PostponeAction(setValuesFunc, function () { return !!window.ClientCodeEditor });
            });
            RevCost.ShowLoadingPanel(ClientSplitter.GetMainElement());

        }

        if (e.buttonID == "DetailDelete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientEquipmentNormGrid, function () {
                    ClientEquipmentNormGrid.PerformCallback("DELETE_DETAIL_NORM|" + key);
                });
            }
        }
    },

    ClientDetailNormAddOrEditPopup_Hide: function (s, e) {
        ASPxClientEdit.ClearEditorsInContainerById('DetailNormForm');
        ClientDetailNormAddOrEditPopup.Hide();
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

    ClientDetailNormAddOrEditPopup_Save: function (s, e) {
        if (!ASPxClientEdit.ValidateEditorsInContainerById("DetailNormForm"))
            return;

        var state = this.DetailState;
        //alert(state.Command);
        var args = "SAVE_DETAIL_NORM|" + state.Command + "|" + state.Key;
        RevCost.ShowLoadingPanel(ClientDetailNormForm.GetMainElement());
        RevCost.DoCallback(ClientEquipmentNormCallback, function () {
            ClientEquipmentNormCallback.PerformCallback(args);
        });
    },

    ClientEquipmentNormCallback_CallbackComplete: function (s, e) {
        RevCost.HideLoadingPanel();
        var args = e.result.split('|');
        if (args[0] == "SAVE_DETAIL_NORM") {
            if (args[1] == "SUCCESS") {
                ClientDetailNormAddOrEditPopup.Hide();
                ClientEquipmentNormGrid.Refresh();
            } else {
                alert(args[1]);
            }
        }
    },

    ClientCodeEditor_EndCallback: function (s, e) {
        RevCost.HideLoadingPanel();
    },

    CalculateTotalTimes: function (s, e) {
        RevCost.Calclate();
    },

    IsNull: function (value, replace) {
        if (value == null || value == "undefined")
            return replace;

        return value;
    },

    Calclate: function () {
        var a = ClientSoluongTTBEditor.GetValue();
        var b = ClientPrepareTimeEditor.GetValue();
        var c = ClientMovingTimeEditor.GetValue();
        var d = ClientWaitingTimeEditor.GetValue();
        var e = ClientApproachTimeEditor.GetValue();
        var f = ClientTimeServedAtPlaneEditor.GetValue();
        var g = ClientTimeServedAtStoreEditor.GetValue();
        var h = ClientTimeServedAtBCEditor.GetValue();
        var i = ClientNightServedTimeEditor.GetValue();
        var k = ClientCleaningTimeEditor.GetValue();
        var minuts = (RevCost.IsNull(b, 0) + RevCost.IsNull(c, 0) + RevCost.IsNull(d, 0) +
            RevCost.IsNull(e, 0) + RevCost.IsNull(f, 0) + RevCost.IsNull(g, 0) +
            RevCost.IsNull(h, 0) + RevCost.IsNull(i, 0) + RevCost.IsNull(k, 0)) * RevCost.IsNull(a, 0);

        ClientTotalTimeEditor.SetValue(minuts);
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
        RevCost.DoCallback(ClientEquipmentNormGrid, function () {
            ClientEquipmentNormGrid.PerformCallback(args);
        });
    }
});

(function () {
    var pageModule = new EquipmentNormPageModule();
    window.RevCost = pageModule;
})();