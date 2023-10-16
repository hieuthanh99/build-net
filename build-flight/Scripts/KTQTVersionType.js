VersionPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
        this.VersionCallback = "";
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "Versions") {
            ClientVersionGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientQuery_Click: function (s, e) {
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('Reload');
        });
    },

    ClientVersionType_ValueChanged: function (s, e) {
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('Reload');
        });
    },

    ClientNewVersionButton_Click: function (s, e) {
        ClientYearBase1Editor.SetValue(null);
        ClientYearBase2Editor.SetValue(null);
        ClientYearBase3Editor.SetValue(null);
        ClientYearBase4Editor.SetValue(null);
        ClientYearBase5Editor.SetValue(null);

        ClientYearEditor.SetValue((new Date()).getFullYear());
        ClientTypeEditor.SetValue("P");
        ClientNameEditor.SetValue("");
        ClientVersionEditor.SetValue("");
        ClientLevelEditor.SetValue(1);
        ClientCalculationEditor.SetValue("BOTTOMUP");
        ClientDescriptionEditor.SetValue("");
        ClientCreateNoteEditor.SetValue("");
        //ClientActualTypeEditor.SetValue(0);
        ClientVerbase01Editor.SetValue(null);
        ClientVerbase02Editor.SetValue(null);
        ClientVerbase03Editor.SetValue(null);
        ClientVerbase04Editor.SetValue(null);
        ClientVerbase05Editor.SetValue(null);
  
        const year = (new Date()).getFullYear();

        ClientYearBase1Editor.SetValue(year);
        RevCost.DoCallback(ClientVerbase01Editor, function () {
            ClientVerbase01Editor.PerformCallback(year);
        });
        ClientYearBase2Editor.SetValue(year);
        RevCost.DoCallback(ClientVerbase02Editor, function () {
            ClientVerbase02Editor.PerformCallback(year);
        });
        ClientYearBase3Editor.SetValue(year);
        RevCost.DoCallback(ClientVerbase03Editor, function () {
            ClientVerbase03Editor.PerformCallback(year);
        });
        ClientYearBase4Editor.SetValue(year);
        RevCost.DoCallback(ClientVerbase04Editor, function () {
            ClientVerbase04Editor.PerformCallback(year);
        });
        ClientYearBase5Editor.SetValue(year);
        RevCost.DoCallback(ClientVerbase05Editor, function () {
            ClientVerbase05Editor.PerformCallback(year);
        });

        ClientActiveEditor.SetValue(false);

        RevCost.ChangeState("EditForm", "New", "");
        ClientEditPopupControl.SetHeaderText("New");
        ClientEditPopupControl.Show();
    },

    ClientEditVersionButton_Click: function (s, e) {
        ClientYearBase1Editor.SetValue(null);
        ClientYearBase2Editor.SetValue(null);
        ClientYearBase3Editor.SetValue(null);
        ClientYearBase4Editor.SetValue(null);
        ClientYearBase5Editor.SetValue(null);

        ClientYearEditor.SetValue("");
        ClientTypeEditor.SetValue("P");
        ClientNameEditor.SetValue("");
        ClientVersionEditor.SetValue("");
        ClientLevelEditor.SetValue(1);
        ClientCalculationEditor.SetValue("BOTTOMUP");
        ClientDescriptionEditor.SetValue("");
        ClientCreateNoteEditor.SetValue("");
        //ClientActualTypeEditor.SetValue(0);
        ClientVerbase01Editor.SetValue(null);
        ClientVerbase02Editor.SetValue(null);
        ClientVerbase03Editor.SetValue(null);
        ClientVerbase04Editor.SetValue(null);
        ClientVerbase05Editor.SetValue(null);

        ClientYearBase1Editor.SetValue((new Date()).getFullYear());
        ClientYearBase2Editor.SetValue((new Date()).getFullYear());
        ClientYearBase3Editor.SetValue((new Date()).getFullYear());
        ClientYearBase4Editor.SetValue((new Date()).getFullYear());
        ClientYearBase5Editor.SetValue((new Date()).getFullYear());

        ClientActiveEditor.SetValue(false);

        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var key = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
        RevCost.ChangeState("EditForm", "Edit", key);
        ClientEditPopupControl.SetHeaderText("Edit");

        ClientVersionGrid.GetValuesOnCustomCallback("EditForm|Edit|" + key, function (values) {
            var setValuesFunc = function () {
                RevCost.HideLoadingPanel();
                if (!values)
                    return;

                ClientYearEditor.SetValue(values["VersionYear"]);
                ClientTypeEditor.SetValue(values["VersionType"]);
                ClientNameEditor.SetValue(values["VersionName"]);
                ClientVersionEditor.SetValue(values["VersionQuantityName"]);
                ClientLevelEditor.SetValue(values["VersionLevel"]);
                ClientCalculationEditor.SetValue(values["Calculation"]);
                ClientDescriptionEditor.SetValue(values["Description"]);
                ClientCreateNoteEditor.SetValue(values["CreateNote"]);
                //ClientActualTypeEditor.SetValue(values["OnTop"]);
                ClientYearBase1Editor.SetValue(values["VerYearBase1"]);
                RevCost.DoCallback(ClientVerbase01Editor, function () {
                    ClientVerbase01Editor.PerformCallback(values["VerYearBase1"]);
                });

                ClientYearBase2Editor.SetValue(values["VerYearBase2"]);
                RevCost.DoCallback(ClientVerbase02Editor, function () {
                    ClientVerbase02Editor.PerformCallback(values["VerYearBase2"]);
                });

                ClientYearBase3Editor.SetValue(values["VerYearBase3"]);
                RevCost.DoCallback(ClientVerbase03Editor, function () {
                    ClientVerbase03Editor.PerformCallback(values["VerYearBase3"]);
                });

                ClientYearBase4Editor.SetValue(values["VerYearBase4"]);
                RevCost.DoCallback(ClientVerbase04Editor, function () {
                    ClientVerbase04Editor.PerformCallback(values["VerYearBase4"]);
                });

                ClientYearBase5Editor.SetValue(values["VerYearBase5"]);
                RevCost.DoCallback(ClientVerbase05Editor, function () {
                    ClientVerbase05Editor.PerformCallback(values["VerYearBase5"]);
                });

                ClientVerbase01Editor.SetValue(values["VerIDBase"] == '' ? null : values["VerIDBase"]);
                ClientVerbase02Editor.SetValue(values["VerIDBase1"] == '' ? null : values["VerIDBase1"]);
                ClientVerbase03Editor.SetValue(values["VerIDBase2"] == '' ? null : values["VerIDBase2"]);
                ClientVerbase04Editor.SetValue(values["VerIDBase3"] == '' ? null : values["VerIDBase3"]);
                ClientVerbase05Editor.SetValue(values["VerIDBase4"] == '' ? null : values["VerIDBase4"]);

                ClientVerbase01Editor.SetText(values["VerNameBase1"]);
                ClientVerbase02Editor.SetText(values["VerNameBase2"]);
                ClientVerbase03Editor.SetText(values["VerNameBase3"]);
                ClientVerbase04Editor.SetText(values["VerNameBase4"]);
                ClientVerbase05Editor.SetText(values["VerNameBase5"]);

                ClientActiveEditor.SetValue(values["Active"] == "True");

                ClientYearEditor.Focus();
                ClientEditPopupControl.Show();
            };
            RevCost.PostponeAction(setValuesFunc, function () { return !!window.ClientYearEditor });
        });
        RevCost.ShowLoadingPanel(ClientSplitter.GetMainElement());
    },

    ClientDeleteVersionButton_Click: function (s, e) {
        var cf = confirm("Confirm delete?");
        if (cf) {
            if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
                return;
            var key = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
            DoCallback(ClientVersionGrid, function () {
                ClientVersionGrid.PerformCallback('DELETE|' + key);
            });
        }
    },

    ClientSaveButton_Click: function (s, e) {
        if (window.ClientYearEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
            return;

        var state = RevCost.State;
        var args = "SaveForm|" + state.Command + "|" + state.Key;
        RevCost.ChangeState("SaveForm", state.Command, state.Key);
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback(args);
        });
    },

    ClientVersionGrid_BeginCallback: function (s, e) {
        this.VersionCallback = e.command;
    },

    ClientVersionGrid_EndCallback: function (s, e) {
        if (this.VersionCallback == "CUSTOMCALLBACK") {
            this.VersionCallback = "";
            if (s.cpCommand == "Reload") {
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0)
                    s.SetFocusedRowIndex(0);
            }
            var state = RevCost.State;
            if (s.cpCommand == "SaveForm" && (state.Command == "New" || state.Command == "Edit")) {
                if (s.cpResult == "Success") {
                    ClientEditPopupControl.Hide();
                    RevCost.ChangeState("List", "", "");
                }
                else {
                    alert(s.cpResult);
                }
            }
            if (s.cpCommand == "DELETE") {
                if (s.cpResult != "Success") {
                    alert(s.cpResult);
                }
            }
            if (s.cpCommand == "ApproveUnApproved") {
                RevCost.ClientVersionGrid_FocusedRowChanged(s, null);
            }
        }
    },

    ClientEditPopupControl_Closing: function (s, e) {
        ClientYearEditor.SetValue("");
        ClientTypeEditor.SetValue("P");
        ClientNameEditor.SetValue("");
        ClientVersionEditor.SetValue("");
        ClientLevelEditor.SetValue(1);
        ClientCalculationEditor.SetValue("BOTTOMUP");
        ClientDescriptionEditor.SetValue("");
        ClientCreateNoteEditor.SetValue("");
        ClientActiveEditor.SetValue(false);

        RevCost.ChangeState("List", "", "");
    },

    ClientApplyToDepartment_Click: function (s, e) {
        var cf = confirm("Confirm apply?");
        if (!cf) return;
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var key = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback("ApplyVersion|" + key);
        });
    },

    ClientShowApproveNoteButton_Click: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;

        ClientApproveNotePopup.Show();
        ClientApproveNoteEditor.Focus();
    },

    ClientUnaprovedButton_Click: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;

        ClientApproveNotePopup.Show();
        ClientApproveNoteEditor.Focus();
    },

    ClienApproveButton_Click: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var cf = confirm("Confirm approve/unapproved?");
        if (!cf) return;

        var verID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('ApproveUnApproved|' + verID);
        });

        ClientApproveNotePopup.Hide();
    },

    ClientVersionGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var verID = s.GetRowKey(s.GetFocusedRowIndex());
        //Check Version Company Status
        RevCost.DoCallback(ClientRevCostCallback, function () {
            ClientRevCostCallback.PerformCallback('CheckVerStatus|' + verID);
        });
    },

    ClientRevCostCallback_CallbackComplete: function (s, e) {
        if (e.result == "APPROVED") {
            //ClientCopyButton.SetEnabled(false);
            ClientApproveButton.SetEnabled(false);
            ClientUnapprovedButton.SetEnabled(true);
            ClientApplyToDepartment.SetEnabled(false);
        }
        else {
            //ClientCopyButton.SetEnabled(true);
            ClientApproveButton.SetEnabled(true);
            ClientUnapprovedButton.SetEnabled(false);
            ClientApplyToDepartment.SetEnabled(true);
        }
    },

    ClientSynchronizeFASTData_Click: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;

        ClientParamsPopup.Show();
    },


    ClientSyncFASTData_Click: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;

        var fromMonth = ClientFromMonthEditor.GetValue();
        var toMonth = ClientToMonthEditor.GetValue();

        if (fromMonth == null || toMonth == null) {
            alert("Select a month to synchronize.");
            return
        }
        if (fromMonth > toMonth) {
            alert("From Month must be less than To Month.");
            return
        }

        var cf = confirm("Confirm Synchronize FAST Data?");
        if (!cf) return;

        var verID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('SynchronizeFASTData|' + verID + '|' + fromMonth + '|' + toMonth);
        });

        ClientParamsPopup.Hide();

    },

    ClientCopyVersionButton_Click: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var verID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

        RevCost.ChangeState("Copy", "", verID);
        ClientCopyVersionCompanyPopup.Show();
    },

    ClientCopyVersionCompanyPopup_Shown: function (s, e) {
        RevCost.DoCallback(ClientVersionCopyGrid, function () {
            ClientVersionCopyGrid.PerformCallback('LoadAllVersion');
        });
    },

    ClientApplyCopyVersionCompanyButton_Click: function (s, e) {
        if (!ClientVersionCopyGrid.IsDataRow(ClientVersionCopyGrid.GetFocusedRowIndex()))
            return;
        var desVerID = ClientVersionCopyGrid.GetRowKey(ClientVersionCopyGrid.GetFocusedRowIndex());

        if (desVerID == RevCost.State.Key) {
            alert("Please select another version to copy.");
            return;
        }

        var State = RevCost.State;
        var sourceVerID = State.Key;
        RevCost.DoCallback(ClientVersionCopyGrid, function () {
            ClientVersionCopyGrid.PerformCallback('CopyVersion|' + sourceVerID + '|' + desVerID);
        });
        ClientCopyVersionCompanyPopup.Hide();
        toastr.options.positionClass = "toast-bottom-right";
        toastr.success("Tiến trình đã đưa vào queued để chạy.");
    },

    ClientCopyPlanData_Click: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var verID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

        RevCost.ChangeState("Copy", "", verID);
        ClientPlanVersionPopup.Show();
    },

    ClientCopyPlanVersionPopup_Shown: function (s, e) {
        RevCost.DoCallback(ClientPlanVersionCopyGrid, function () {
            ClientPlanVersionCopyGrid.PerformCallback('LoadPlanVersion');
        });
    },

    ClientApplyCopyPlanVersionButton_Click: function (s, e) {
        if (!ClientPlanVersionCopyGrid.IsDataRow(ClientPlanVersionCopyGrid.GetFocusedRowIndex()))
            return;
        var sourceVerID = ClientPlanVersionCopyGrid.GetRowKey(ClientPlanVersionCopyGrid.GetFocusedRowIndex());

        var State = RevCost.State;
        var desVerID = State.Key;
        RevCost.DoCallback(ClientPlanVersionCopyGrid, function () {
            ClientPlanVersionCopyGrid.PerformCallback('CopyPlanVersion|' + sourceVerID + '|' + desVerID);
        });
    },

    ClientCopyPlanVersionSplliter_PaneResized: function (s, e) {
        if (e.pane.name == "VersionGrid") {
            ClientPlanVersionCopyGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientSyncData_Click: function (s, e) {
        var cf = confirm("Bạn chắc chắn muốn đồng bộ dữ liệu version từ PMS không?");
        if (cf) {
            RevCost.DoCallback(ClientVersionGrid, function () {
                ClientVersionGrid.PerformCallback('SYNC_DATA');
            });

        }
    },

    ClientPMSData_Click: function (s, e) {
        var cf = confirm("Bạn chắc chắn muốn đồng bộ dữ liệu từ PMS không?");
        if (cf) {
            if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
                return;
            var verID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

            RevCost.DoCallback(ClientVersionGrid, function () {
                ClientVersionGrid.PerformCallback('SYNC_PMS_DATA|' + verID);
            });

        }
    },

    ClientYearBase1Editor_ValueChanged: function (s, e) {
        RevCost.DoCallback(ClientVerbase01Editor, function () {
            ClientVerbase01Editor.PerformCallback(s.GetValue());
        });
    },

    ClientYearBase2Editor_ValueChanged: function (s, e) {
        RevCost.DoCallback(ClientVerbase02Editor, function () {
            ClientVerbase02Editor.PerformCallback(s.GetValue());
        });
    },


    ClientYearBase3Editor_ValueChanged: function (s, e) {
        RevCost.DoCallback(ClientVerbase03Editor, function () {
            ClientVerbase03Editor.PerformCallback(s.GetValue());
        });
    },

    ClientYearBase4Editor_ValueChanged: function (s, e) {
        RevCost.DoCallback(ClientVerbase04Editor, function () {
            ClientVerbase04Editor.PerformCallback(s.GetValue());
        });
    },

    ClientYearBase5Editor_ValueChanged: function (s, e) {
        RevCost.DoCallback(ClientVerbase05Editor, function () {
            ClientVerbase05Editor.PerformCallback(s.GetValue());
        });
    },

});

(function () {
    var pageModule = new VersionPageModule();
    window.RevCost = pageModule;
})();