AutoAmountPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "View" };
        this.VersionCallback = "";
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "Versions") {
            ClientVersionGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "AllocateHis") {
            ClientAllocateHisGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "VersionCompany") {
            ClientVersionCompanyGrid.SetHeight(e.pane.GetClientHeight());
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

        RevCost.ChangeState("View", "", key);
        ClientHiddenField.Set("VersionID", key);
        RevCost.DoCallback(ClientAllocateHisGrid, function () {
            ClientAllocateHisGrid.PerformCallback('Reload|' + key);
        });

        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('Reload|' + key);
        });
    },

    ClientVersionGrid_BeginCallback: function(s, e){
        this.VersionCallback = e.command;
    },

    ClientVersionGrid_EndCallback: function (s, e) {
        if (this.VersionCallback == "CUSTOMCALLBACK") {
            if (s.cpCommand == "Reload") {
                RevCost.ClientVersionGrid_FocusedRowChanged(s, null);
            }
        }

        this.VersionCallback = "";
    },

    ClientQuery_Click: function (s, e) {
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('Reload');
        });
    },

    ClientNewScheduleJobButton_Click: function (s, e) {
        ClientTypeEditor.SetValue("ALL");
        ClientIsueDateEditor.SetValue(new Date());
        ClientStartTimeEditor.SetValue(new Date());
        ClientEndTimeEditor.SetValue(null);
        ClientRemarkEditor.SetValue("");

        RevCost.ChangeState("EditForm", "NEW", "");
        ClientEditPopupControl.Show();
    },

    ClientEditScheduleJobButton_Click: function (s, e) {
        if (!ClientAllocateHisGrid.IsDataRow(ClientAllocateHisGrid.GetFocusedRowIndex()))
            return;
        var key = ClientAllocateHisGrid.GetRowKey(ClientAllocateHisGrid.GetFocusedRowIndex());

        var command = "EDIT";
        RevCost.ChangeState("EditForm", command, key);
        ClientAllocateHisGrid.GetValuesOnCustomCallback("EditForm|" + command + "|" + key, function (values) {
            var setValuesFunc = function () {
                RevCost.HideLoadingPanel();
                if (!values)
                    return;

                ClientTypeEditor.SetValue(values["AllocateType"]);
                if (values["IssueDate"] != null && values["IssueDate"] != "") {
                    ClientIsueDateEditor.SetDate(new Date(values["IssueDate"]));
                }
                if (values["StartTime"] != null && values["StartTime"] != "") {                    
                    ClientStartTimeEditor.SetDate(new Date(values["StartTime"]));
                }
                if (values["EndTime"] != null && values["EndTime"] != "") {
                    ClientEndTimeEditor.SetValue(new Date(values["EndTime"]));
                }
                ClientRemarkEditor.SetValue(values["Note"]);

                ClientTypeEditor.Focus();
                ClientEditPopupControl.Show();
            };
            RevCost.PostponeAction(setValuesFunc, function () { return !!window.ClientTypeEditor });
        });
        RevCost.ShowLoadingPanel(ClientSplitter.GetMainElement());
    },

    ClientAllocateHisGrid_EndCallback: function (s, e) {
        var state = RevCost.State;
        if (state.View == "SaveForm" && (state.Command == "NEW" || state.Command == "EDIT")) {
            if (s.cpResult == "Success") {
                ClientEditPopupControl.Hide();
                RevCost.ChangeState("View", "", state);
            }
            else {
                alert(s.cpResult);
            }
        }
    },

    ClientDeleteScheduleJobButton_Click: function (s, e) {
        if (!ClientAllocateHisGrid.IsDataRow(ClientAllocateHisGrid.GetFocusedRowIndex()))
            return;
        var key = ClientAllocateHisGrid.GetRowKey(ClientAllocateHisGrid.GetFocusedRowIndex());
        var cf = confirm("Confirm delete?");
        if (!cf) return;
        RevCost.DoCallback(ClientAllocateHisGrid, function () {
            ClientAllocateHisGrid.PerformCallback("Delete|" + key);
        });
    },

    ClientSaveButton_Click: function (s, e) {
        if (window.ClientTypeEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
            return;
        var state = RevCost.State;
        var args = "SaveForm|" + state.Command + "|" + state.Key;
        RevCost.ChangeState("SaveForm", state.Command, state.Key);
        RevCost.DoCallback(ClientAllocateHisGrid, function () {
            ClientAllocateHisGrid.PerformCallback(args);
        });
    },

    ClientEditPopupControl_Closing: function (s, e) {

    },

    ClientRunAllocate_Click: function (s, e) {
        var keys = [];
        keys = ClientVersionCompanyGrid.GetSelectedKeysOnPage();
        if (keys.length <= 0) {
            alert("No version selected.");
            return;
        }

        ClientAllocateParamsPopup.Show();
    },

    ClientApplyAllocate_Click: function (s, e) {
        var fromMonth = ClientFromMonthEditor.GetValue();
        var toMonth = ClientToMonthEditor.GetValue();
        if (fromMonth == null || toMonth == null) {
            alert("From Month and To Month must be enterd!");
            return;
        }
        if (fromMonth > toMonth) {
            alert("From Month must be smaller than To Month");
            return;
        }

        var keys = [];
        keys = ClientVersionCompanyGrid.GetSelectedKeysOnPage();
        if (keys.length <= 0) {
            alert("No version selected.");
            return;
        }

        var cf = confirm("Confirm run allocate?");
        if (!cf) return;
        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('RunAllocate|' + keys.join("|"));
        });


        ClientAllocateParamsPopup.Hide();
    },

});

(function () {
    var pageModule = new AutoAmountPageModule();
    window.RevCost = pageModule;
})();