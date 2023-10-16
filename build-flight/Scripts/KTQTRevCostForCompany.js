RevCostPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.VersionState = { View: "List" };
        this.VerCompanyState = { View: "List" };
        this.StoreState = { View: "List" };
        this.IsPageload = true;
        this.CopyVersion = "";
        this.VersionCallback = "";
        this.VerCompanyCallback = "";
        this.StoreCallback = "";
        this.StoreDetailCallback = "";
        this.RunAllocateType = "";
        this.AllowEdit = false;
        this.VersionType = "";
    },

    OnPageInit: function (s, e) {
        if (RevCost.IsPageload) {
            RevCost.IsPageload = false;
            //ClientNewVersionButton.SetVisible(ClientHiddenField.Get("CompanyType") == 'K');
            //ClientChangeCompanyButton.SetVisible(ClientHiddenField.Get("CompanyType") == 'K');
            window.setTimeout(function () {
                RevCost.showLeftPane();
            }, 500);
        }
    },

    ShowMessage: function (message) {
        window.setTimeout("alert('" + message + "')", 0);
    },

    ClientSplitterVersion_PaneResized: function (s, e) {
        if (e.pane.name == "VersionsPane") {
            ClientVersionGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "VersionCompanyPane") {
            ClientVersionCompanyGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientContentSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "CompanyStores") {
            ClientStoresGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "StoreDetail") {
            ClientStoreDetailsGrid.SetHeight(e.pane.GetClientHeight());
        }
        //else if (e.pane.name == "StoreFiles") {
        //    ClientStoreFilesGrid.SetHeight(e.pane.GetClientHeight());
        //}
        //else if (e.pane.name == "StoreNote") {
        //    ClientStoreNoteEditor.SetHeight(e.pane.GetClientHeight() - 1);
        //}
    },

    ClientShowMenuButton_Click: function (s, e) {
        RevCost.showLeftPane();
    },

    ClientHideMenuButton_Click: function (s, e) {
        RevCost.hideLeftPane();
    },

    ClientMenuButton_CheckedChanged: function (s, e) {
        var mainContainer = ClientMainPanel.GetMainElement();
        if (s.GetChecked()) {
            RevCost.showLeftPane();
        }
        else {
            RevCost.hideLeftPane();
        }
    },

    hideLeftPane: function () {
        $(ClientMainPanel.GetMainElement()).removeClass("show-menu");
        //MenuButton.SetChecked(false);
    },

    showLeftPane: function () {
        $(ClientMainPanel.GetMainElement()).addClass("show-menu");
    },

    ReloadVersion: function (s, e) {
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('Reload');
        });
    },

    ClientQuery_Click: function (s, e) {
        RevCost.ReloadVersion();
    },

    ClientVersionYearEditor_ValueChanged: function (s, e) {
        RevCost.ReloadVersion();
    },

    ClientAmountType_ValueChanged: function (s, e) {
        var value = s.GetValue();

        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('ShowHideColumn|' + value);
        });

        RevCost.DoCallback(ClientStoreDetailsGrid, function () {
            ClientStoreDetailsGrid.PerformCallback('ShowHideColumn|' + value);
        });
    },

    ClientVersionGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var versionID = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("VersionID", versionID);
        RevCost.ChangeVersionState("List", "", versionID);
        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + versionID);
        });
    },

    ClientVersionGrid_BeginCallback: function (s, e) {
        this.VersionCallback = e.command;
    },

    ClientVersionGrid_EndCallback: function (s, e) {
        //ClientNewVersionButton.SetVisible(ClientHiddenField.Get("CompanyType") == 'K');
        if (this.VersionCallback == "CUSTOMCALLBACK") {
            this.VersionCallback = "";
            if (s.cpCommand == "Reload") {
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0) {
                    s.SetFocusedRowIndex(0);
                    if (!s.IsDataRow(s.GetFocusedRowIndex()))
                        return;
                    var versionID = s.GetRowKey(s.GetFocusedRowIndex());

                    ClientHiddenField.Set("VersionID", versionID);
                    RevCost.ChangeVersionState("List", "", versionID);
                }
                else {
                    ClientHiddenField.Set("VersionID", "0");
                    RevCost.ChangeVersionState("List", "", 0);
                    RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                        ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + 0);
                    });
                }
            }
        }
    },

    ClientVersionCompanyGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var verCompanyID = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("VerCompanyID", verCompanyID);
        RevCost.ChangeVerCompanyState("List", "", verCompanyID);

        //Check Version Company Status
        RevCost.DoCallback(ClientRevCostCallback, function () {
            ClientRevCostCallback.PerformCallback('CheckVerCompanyStatus|' + verCompanyID);
        });

        //Load Store
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('LoadStore|' + verCompanyID);
        });

    },


    ClientRevCostCallback_CallbackComplete: function (s, e) {
        this.AllowEdit = e.result != "APPROVED";
        if (e.result == "APPROVED") {
            ClientApproveButton.SetEnabled(false);
            ClientUnapprovedButton.SetEnabled(true);
            ClientCalculateButton.SetEnabled(false);
            ClientAllocateStoreButton.SetEnabled(false);
            ClientRunAllocateButton.SetEnabled(false);
        }
        else {
            ClientApproveButton.SetEnabled(true);
            ClientUnapprovedButton.SetEnabled(false);
            ClientCalculateButton.SetEnabled(true);
            ClientAllocateStoreButton.SetEnabled(true);
            ClientRunAllocateButton.SetEnabled(true);
        }
    },

    ClientStoreDetailsGrid_BatchEditStartEditing: function (s, e) {
        e.cancel = !this.AllowEdit;
    },

    ClientVersionCompanyGrid_BeginCallback: function (s, e) {
        this.VerCompanyCallback = e.command;
    },

    ClientVersionCompanyGrid_EndCallback: function (s, e) {
        //ClientChangeCompanyButton.SetVisible(ClientHiddenField.Get("CompanyType") == 'K');
        //ClientNewVersionCompanyButton.SetVisible(ClientHiddenField.Get("CompanyType") == 'K');
        if (this.VerCompanyCallback == "CUSTOMCALLBACK") {
            this.VerCompanyCallback = "";
            if (s.cpCommand == "LoadVerCompany" || s.cpCommand == "ChangeCompany" || s.cpCommand == "NewVersionCompany" || s.cpCommand == "ApproveUnApproved") {
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0) {
                    s.SetFocusedRowIndex(0);
                    if (!s.IsDataRow(s.GetFocusedRowIndex()))
                        return;
                    var verCompanyID = s.GetRowKey(s.GetFocusedRowIndex());

                    ClientHiddenField.Set("VerCompanyID", verCompanyID);
                    RevCost.ChangeVerCompanyState("List", "", verCompanyID);
                }
                else {
                    ClientHiddenField.Set("VerCompanyID", "0");
                    RevCost.ChangeVerCompanyState("List", "", 0);
                    RevCost.DoCallback(ClientStoresGrid, function () {
                        ClientStoresGrid.PerformCallback('LoadStore|' + 0);
                    });
                }
                if (s.cpCommand == "ChangeCompany") {
                    ClientCompanyName.SetText(s.cpCompanyName);
                }

                if (s.cpCommand == "ApproveUnApproved") {

                }

                if (s.cpCommand == "LoadVerCompany")
                    this.VersionType = s.cpVersionType;

            }
        }
    },

    ClientVersionCompanyGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "btnVersionFiles") {
            ClientVerCompanyDescriptionEditor.SetValue("");
            ClientVerCompanyApproveNoteEditor.SetValue("");
            ClientVerCompanyReviewNoteEditor.SetValue("");
            ClientVerCompanyCreateNoteEditor.SetValue("");

            if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
                return;
            var key = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

            ClientVersionCompanyGrid.GetValuesOnCustomCallback("EditForm|" + key, function (values) {
                var setValuesFunc = function () {
                    RevCost.HideLoadingPanel();
                    if (!values)
                        return;

                    ClientVerCompanyDescriptionEditor.SetValue(values["Description"]);
                    ClientVerCompanyApproveNoteEditor.SetValue(values["ApprovedNote"]);
                    ClientVerCompanyReviewNoteEditor.SetValue(values["ReviewedNote"]);
                    ClientHotDataEditor.SetValue(values["HotData"] == "True");
                    //ClientVerCompanyCreateNoteEditor.SetValue(values["CreateNote"]);

                    ClientVerCompanyDescriptionEditor.Focus();
                    ClientVersionCompanyFilesPopup.Show();
                };
                RevCost.PostponeAction(setValuesFunc, function () { return !!window.ClientVerCompanyDescriptionEditor });
            });
            RevCost.ShowLoadingPanel(ClientVersionCompanyGrid.GetMainElement());

            e.processOnServer = false;
        }
    },

    ClientStoresGrid_FocusedNodeChanged: function (s, e) {
        var storeID = s.GetFocusedNodeKey();
        ClientHiddenField.Set("StoreID", storeID);
        RevCost.ChangeStoreState("List", "", storeID);
        RevCost.DoCallback(ClientStoreDetailsGrid, function () {
            ClientStoreDetailsGrid.PerformCallback('LoadStoreDetail|' + storeID);
        });

        //RevCost.DoCallback(ClientStoreFilesGrid, function () {
        //    ClientStoreFilesGrid.PerformCallback('LoadStoreFiles|' + storeID);
        //});

        //$.ajax({
        //    type: "GET",
        //    url: "../../Handler/GetStoreNote.ashx",
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    data: { 'key': storeID },
        //    responseType: "text/plain",
        //    success: RevCost.OnGetStoreNoteSuccess,
        //    error: RevCost.OnGetStoreNoteFail
        //});
    },

    OnGetStoreNoteSuccess: function (value) {
        ClientStoreNoteEditor.SetValue(value);
    },

    OnGetStoreNoteFail: function (error) {
        RevCost.ShowMessage(error);
    },

    ClientStoresGrid_BeginCallback: function (s, e) {
        this.StoreCallback = e.command;
    },

    ClientStoresGrid_EndCallback: function (s, e) {
        if (this.StoreCallback == "CustomCallback") {
            this.StoreCallback = "";
            if (s.cpCommand == "LoadStore") {
                RevCost.HideLoadingPanel();
                ClientStoresGrid.SetFocusedNodeKey(null);
                ClientHiddenField.Set("StoreID", "0");
                RevCost.ChangeStoreState("List", "", 0);
                RevCost.DoCallback(ClientStoreDetailsGrid, function () {
                    ClientStoreDetailsGrid.PerformCallback('LoadStoreDetail|' + 0);
                });

            }
            if (s.cpCommand == "CalculateStore") {
                var State = RevCost.VerCompanyState;
                RevCost.DoCallback(ClientStoresGrid, function () {
                    ClientStoresGrid.PerformCallback('RefreshStore|' + State.Key);
                });
            }
        }
    },

    ClientRefreshSrore_Click: function (s, e) {
        var State = RevCost.VerCompanyState;
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('RefreshStore|' + State.Key);
        });
    },

    ClientCalculateStore_Click: function (s, e) {
        var State = RevCost.VerCompanyState;
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('CalculateStore|' + State.Key);
        });
    },

    ClientStoreIsOK_ValueChanged: function (key, value) {
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('IsOK|' + key + "|" + value);
        });
    },

    ClientStoreDetailPosted_ValueChanged: function (key, value) {
        RevCost.DoCallback(ClientStoreDetailsGrid, function () {
            ClientStoreDetailsGrid.PerformCallback('Posted|' + key + "|" + value);
        });
    },

    ClientSaveStoreDetail_Click: function (s, e) {
        if (ClientStoreDetailsGrid.batchEditApi.HasChanges()) {
            ClientStoreDetailsGrid.UpdateEdit();
        }
    },

    ClientStoreDetailsGrid_BeginCallback: function (s, e) {
        this.StoreDetailCallback = e.command;
    },

    RefreshStore: function () {
        var State = RevCost.VerCompanyState;
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('RefreshStore|' + State.Key);
        });
    },

    ClientStoreDetailsGrid_EndCallback: function (s, e) {
        if (this.StoreDetailCallback == "UPDATEEDIT") {
            RevCost.RefreshStore();
        }
        else if (this.StoreDetailCallback == "CUSTOMCALLBACK") {
            if (s.cpCommand == "Allocate") {
                RevCost.RefreshStore();
            }
        }
    },

    ClientUploadStoreFile_Click: function () {
        if (ClientStoreFilesUploadControl.GetText() == "")
            return;
        ClientStoreFilesUploadControl.Upload();
    },

    ClientStoreFilesUploadControl_FileUploadStart: function (s, e) {

    },

    ClientStoreFilesUploadControl_UploadingProgressChanged: function (s, e) {

    },

    ClientStoreFilesUploadControl_FilesUploadComplete: function (s, e) {
        if (e.callbackData == "error") {
            RevCost.ShowMessage(e.errorText);
        }
        else {
            var State = RevCost.StoreState;
            var storeID = State.Key;
            RevCost.DoCallback(ClientStoreFilesGrid, function () {
                ClientStoreFilesGrid.PerformCallback('SaveStoreFile|' + storeID + "|" + e.callbackData);
            });
        }
    },

    ClientSaveStoreFiles_Click: function (s, e) {
        if (ClientStoreFilesGrid.batchEditApi.HasChanges()) {
            ClientStoreFilesGrid.UpdateEdit();
        }
    },

    ClientStoreFilesGrid_CustomButtonClick: function (s, e) {
        var storeFileID = s.GetRowKey(s.GetFocusedRowIndex());
        if (e.buttonID == "Download") {
            window.location = "../../Handler/DownloadFile.ashx?FileType=StoreFile&FileID=" + storeFileID;
            e.processOnServer = false;
        }
    },

    ClientAllocate_CollapsedChanged: function (s, e) {
        ClientContentSplitter.AdjustControl();
    },

    ClientCompanyListPopup_Shown: function (s, e) {
        RevCost.DoCallback(ClientCompanyGrid, function () {
            ClientCompanyGrid.PerformCallback('LoadCompany');
        });
    },

    ClientApplyButton_Click: function (s, e) {
        if (!ClientCompanyGrid.IsDataRow(ClientCompanyGrid.GetFocusedRowIndex()))
            return;
        var companyID = ClientCompanyGrid.GetRowKey(ClientCompanyGrid.GetFocusedRowIndex());

        var State = RevCost.VersionState;
        ClientCompanyListPopup.Hide();
        RevCost.ShowLoadingPanel(ClientContentSplitter.GetMainElement());
        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('ChangeCompany|' + State.Key + "|" + companyID);
        });
    },

    ClientCompanyGrid_RowDblClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var companyID = s.GetRowKey(s.GetFocusedRowIndex());

        var State = RevCost.VersionState;
        ClientCompanyListPopup.Hide();
        RevCost.ShowLoadingPanel(ClientContentSplitter.GetMainElement());
        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('ChangeCompany|' + State.Key + "|" + companyID);
        });
    },

    ClientAllocateApply_Click: function (s, e) {
        //var amountType = ClientAmountType.GetValue();
        //if (amountType == null || amountType == "AS") {
        //    RevCost.ShowMessage("Action not allowed here.");
        //    return;
        //}
        var cf = confirm("Confirm?");
        if (cf) {
            var State = RevCost.StoreState;
            var storeID = State.Key;
            RevCost.DoCallback(ClientStoreDetailsGrid, function () {
                ClientStoreDetailsGrid.PerformCallback('Allocate|' + storeID);
            });
        }
    },

    ClientVersionCompanyFilesPopup_Shown: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;
        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientVersionCompanyFilesGrid, function () {
            ClientVersionCompanyFilesGrid.PerformCallback('LoadVerCompanyFiles|' + verCompanyID);
        });
    },

    ClientUploadVerCompanyFile_Click: function () {
        if (ClientVerCompanyFilesUC.GetText() == "")
            return;
        ClientVerCompanyFilesUC.Upload();
    },

    ClientVerCompanyFilesUC_FilesUploadComplete: function (s, e) {
        if (e.callbackData == "error") {
            RevCost.ShowMessage(e.errorText);
        }
        else {
            var State = RevCost.VerCompanyState;
            var verCompanyID = State.Key;
            RevCost.DoCallback(ClientVersionCompanyFilesGrid, function () {
                ClientVersionCompanyFilesGrid.PerformCallback('SaveVerCompanyFile|' + verCompanyID + "|" + e.callbackData);
            });
        }
    },

    ClientVersionCompanyFilesGrid_CustomButtonClick: function (s, e) {
        var verCompanyFileID = s.GetRowKey(s.GetFocusedRowIndex());
        if (e.buttonID == "DownloadFile") {
            window.location = "../../Handler/DownloadFile.ashx?FileType=VersionCompanyFile&FileID=" + verCompanyFileID;
            e.processOnServer = false;
        }
    },

    ClientApplyVersionCompanyFilesButton_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;
        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

        var State = RevCost.VersionState;
        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('SaveNote|' + State.Key + "|" + verCompanyID);
        });

    },

    ClientStoreNoteEditor_KeyDown: function (s, e) {
        window.clearTimeout(this.storeNoteTimer);
        this.storeNoteTimer = window.setTimeout(function () {
            RevCost.ClientStoreNoteEditor_TextChanged();
        }, 1200);
    },

    ClientStoreNoteEditor_KeyPress: function (s, e) {
        //e = e.htmlEvent;
        //if (e.keyCode === 13) {
        //    // prevent default browser form submission
        //    if (e.preventDefault)
        //        e.preventDefault();
        //    else
        //        e.returnValue = false;
        //}
    },

    OnSaveStoreNoteSuccess: function (sucess) {

    },

    OnSaveStoreNoteFail: function (error) {
        RevCost.ShowMessage(error);
    },

    ClientStoreNoteEditor_TextChanged: function () {
        window.clearTimeout(this.storeNoteTimer);
        var noteText = ClientStoreNoteEditor.GetText();
        var State = RevCost.StoreState;
        var key = State.Key;
        $.ajax({
            type: "GET",
            url: "../../Handler/SaveStoreNote.ashx",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: { 'note': noteText, 'key': key },
            responseType: "text/plain",
            success: RevCost.OnSaveStoreNoteSuccess,
            error: RevCost.OnSaveStoreNoteFail
        });
    },

    ClientChangeCompanyButton_Click: function (s, e) {
        //if (ClientHiddenField.Get("CompanyType") == "D") {
        //    alert("You do not have permission to perform this action.");
        //    return;
        //}
        ClientCompanyListPopup.Show();
    },

    ClientNewVersionButton_Click: function (s, e) {
        if (ClientHiddenField.Get("CompanyType") == "D") {
            alert("You do not have permission to perform this action.");
            return;
        }
    },

    ClientCopyVersionButton_Click: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var verID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
        this.CopyVersion = "Version";

        ClientCopyVersionCompanyPopup.Show();
    },

    ClientNewVersionCompanyButton_Click: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;

        var cf = confirm("Confirm create new version?");
        if (cf) {
            var verID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
            RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                ClientVersionCompanyGrid.PerformCallback('NewVersionCompany|' + verID);
            });
        }
    },

    ClientCopyVersionCompanyButton_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;
        //var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

        var cf = confirm("Confirm copy?");
        if (cf) {
            this.CopyVersion = "VersionCompany";
            ClientCopyVersionCompanyPopup.Show();
        }
    },

    ClientClientDuplicateVersionCompanyButton_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;

        var cf = confirm("Confirm duplicate?");
        if (cf) {
            var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

            var State = RevCost.VersionState;
            RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                ClientVersionCompanyGrid.PerformCallback('Duplicate|' + State.Key + "|" + verCompanyID);
            });
        }
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

        if (this.CopyVersion == "Version") {
            if (desVerID == RevCost.VersionState.Key) {
                alert("Please select another version to copy.");
                return;
            }

            var State = RevCost.VersionState;
            var oriVerID = State.Key;
            RevCost.DoCallback(ClientVersionCopyGrid, function () {
                ClientVersionCopyGrid.PerformCallback('CopyVersion|' + oriVerID + '|' + desVerID);
            });
        }
        else if (this.CopyVersion == "VersionCompany") {
            var State = RevCost.VerCompanyState;
            var verCompanyID = State.Key;
            RevCost.DoCallback(ClientVersionCopyGrid, function () {
                ClientVersionCopyGrid.PerformCallback('CopyVersionCompany|' + verCompanyID + '|' + desVerID);
            });
        }
    },

    ClientCopyVersionCompanyPopup_CloseUp: function (s, e) {
        if (this.CopyVersion == "VersionCompany") {
            var State = RevCost.VersionState;
            RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + State.Key);
            });
        }
        this.CopyVersion = "";
    },

    ClientVersionCompanyBaseGrid_Shown: function (s, e) {
        var State = RevCost.VerCompanyState;
        var verCompanyID = State.Key;
        RevCost.DoCallback(ClientVersionCompanyBaseGrid, function () {
            ClientVersionCompanyBaseGrid.PerformCallback('LoadVersionBase|' + verCompanyID);
        });
    },

    ClientVersionCompanyBaseGrid_CloseUp: function (s, e) {
        var State = RevCost.VerCompanyState;
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('RefreshStore|' + State.Key);
        });
    },

    ClientSelectVersionBase_Click: function (s, e) {
        ClientVersionCompanyPopup.Show();
    },

    ClientApplyVersionBase_Click: function (s, e) {
        var State = RevCost.VerCompanyState;
        RevCost.DoCallback(ClientVersionCompanyBaseGrid, function () {
            ClientVersionCompanyBaseGrid.PerformCallback('ApplyVersionBase|' + State.Key);
        });
    },

    ClientRunAllocateButton_Click: function (s, e) {
        this.RunAllocateType = "RunAllocate";
        ClientAllocateParamsPopup.SetHeaderText("Run Allocate");
        ClientAllocateParamsPopup.Show();
    },

    ClientRunAllocateAllButton_Click: function (s, e) {
        this.RunAllocateType = "RunAllocateAll";
        ClientAllocateParamsPopup.SetHeaderText("Run Allocate All");
        ClientAllocateParamsPopup.Show();
    },

    ClientRunAllocateOneStore_Click: function (s, e) {
        this.RunAllocateType = "RunAllocate1Store";
        ClientAllocateParamsPopup.SetHeaderText("Run Allocate 1 Store");
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
        var VerCompanyState = RevCost.VerCompanyState;
        if (this.RunAllocateType == "RunAllocate") {
            var cf = confirm("Confirm run allocate?");
            if (!cf) return;
            RevCost.DoCallback(ClientStoresGrid, function () {
                ClientStoresGrid.PerformCallback('RunAllocate|' + VerCompanyState.Key);
            });
            RevCost.hideLeftPane();
        }
        else if (this.RunAllocateType == "RunAllocateAll") {
            var cf = confirm("Confirm run allocate all?");
            if (!cf) return;
            RevCost.DoCallback(ClientStoresGrid, function () {
                ClientStoresGrid.PerformCallback('RunAllocateAll|' + VerCompanyState.Key);
            });
            RevCost.hideLeftPane();
        }
        else if (this.RunAllocateType == "RunAllocate1Store") {
            var cf = confirm("Confirm run allocate this store?");
            if (!cf) return;
            var StoreState = RevCost.StoreState;
            RevCost.DoCallback(ClientStoresGrid, function () {
                ClientStoresGrid.PerformCallback('RunAllocate1Store|' + VerCompanyState.Key + '|' + StoreState.Key);
            });
        }
        ClientAllocateParamsPopup.Hide();
        this.RunAllocateType = "";
    },

    ClientViewAllocateData_Click: function (s, e) {
        var key = ClientStoresGrid.GetFocusedNodeKey();
        if (key != null) {
            ClientViewDataPopupControl.SetHeaderText("View Allocated Data");
            RevCost.UpdateViewDataPopupControl();
            ClientViewDataPopupControl.Show();
        }
    },

    UpdateViewDataPopupControl: function () {
        var width = document.body.offsetWidth - document.body.offsetWidth * 0.05;
        var height = document.body.offsetHeight - document.body.offsetWidth * 0.05;

        ClientViewDataPopupControl.SetWidth(width);
        ClientViewDataPopupControl.SetHeight(height);

        ClientFltOpsGrid.SetWidth(width);
        ClientFltOpsGrid.SetHeight(height - 80);

        ClientStoreAllocateLogGrid.SetWidth(width);
        ClientStoreAllocateLogGrid.SetHeight(height - 80);

        ClientStoreErrorListGrid.SetWidth(width);
        ClientStoreErrorListGrid.SetHeight(height - 80);

        ClientViewDataPopupControl.UpdatePosition();
    },

    ClientViewDataPopupControl_Show: function (s, e) {
        var State = RevCost.StoreState;
        ClientHiddenField.Set("StoreID", State.Key);
        RevCost.DoCallback(ClientFltOpsGrid, function () {
            ClientFltOpsGrid.PerformCallback('ViewAllocate|' + State.Key);
        });
    },

    ClientViewDataPopupControl_CloseUp: function (s, e) {
        //ClientFltOpsGrid.ClearFilter();
    },

    ClientDirectToQuantity_Click: function (s, e) {
        var URL = "";
        if (this.VersionType == "E" || this.VersionType == "A")
            URL = window.location.protocol + "//" + window.location.host + "/Business/KTQT/Quantity.aspx";
        else
            URL = window.location.protocol + "//" + window.location.host + "/Business/KTQT/PlanQuantity.aspx";

        window.open(URL, "_blank");
    },

    ClientShowApproveNoteButton_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;

        ClientApproveNotePopup.Show();
        ClientApproveNoteEditor.Focus();
    },

    ClientUnaprovedButton_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;

        ClientApproveNotePopup.Show();
        ClientApproveNoteEditor.Focus();
    },

    ClienApproveButton_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;
        var cf = confirm("Confirm approve/unapproved?");
        if (!cf) return;

        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('ApproveUnApproved|' + verCompanyID);
        });

        ClientApproveNotePopup.Hide();
    },

    ClientFlsOpsStoreView_ActiveTabChanged: function (s, e) {
        var activeTab = s.GetActiveTab();
        RevCost.UpdateViewDataPopupControl();
        if (activeTab.name == "StoreAllocateLog") {
            RevCost.DoCallback(ClientStoreAllocateLogGrid, function () {
                ClientStoreAllocateLogGrid.PerformCallback("refresh");
            });
        }
        else if (activeTab.name == "StoreErrorList") {
            RevCost.DoCallback(ClientStoreErrorListGrid, function () {
                ClientStoreErrorListGrid.PerformCallback("refresh");
            });
        }
    },

    ClientViewAllocateError_Click: function (s, e) {
        ClientViewAllocateErrorPopup.SetHeaderText("View Allocated Errors");
        var width = document.body.offsetWidth - document.body.offsetWidth * 0.3;
        var height = document.body.offsetHeight - document.body.offsetWidth * 0.1;

        ClientViewAllocateErrorPopup.SetWidth(width);
        ClientViewAllocateErrorPopup.SetHeight(height);

        ClientStoreAllocateErrorGrid.SetWidth(width);
        ClientStoreAllocateErrorGrid.SetHeight(height - 80);

        ClientViewAllocateErrorPopup.UpdatePosition();
        ClientViewAllocateErrorPopup.Show();
    },

    ClientViewAllocateErrorPopup_Show: function (s, e) {
        var State = RevCost.VerCompanyState;
        ClientHiddenField.Set("VerCompanyID", State.Key);
        RevCost.DoCallback(ClientStoreAllocateErrorGrid, function () {
            ClientStoreAllocateErrorGrid.PerformCallback('ViewAllocateError|' + State.Key);
        });
    },

    ClientViewAllocateErrorPopup_CloseUp: function (s, e) {

    },

    ClientVersionCompanyGrid_ContextMenuItemClick: function (s, e) {
        if (e.item.name == "NewVerCompany") {
            RevCost.ClientNewVersionCompanyButton_Click(null, null);
            e.processOnServer = false;
            e.usePostBack = true;
        }
        else if (e.item.name == "CopyVerCompany") {
            RevCost.ClientCopyVersionCompanyButton_Click(null, null);
            e.processOnServer = false;
            e.usePostBack = true;
        }
        else if (e.item.name == "DuplicateVerCompany") {
            RevCost.ClientClientDuplicateVersionCompanyButton_Click(null, null);
            e.processOnServer = false;
            e.usePostBack = true;
        }
        else if (e.item.name == "SetWorkingVersion") {
            if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
                return;
            var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());
            RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                ClientVersionCompanyGrid.PerformCallback('SetWorkingVersion|' + verCompanyID);
            });
            e.processOnServer = false;
            e.usePostBack = true;
        }
    },

    ClientVersionGrid_ContextMenuItemClick: function (s, e) {
        if (e.item.name == "CopyVersion") {
            RevCost.ClientCopyVersionButton_Click(null, null);
            e.processOnServer = false;
            e.usePostBack = true;
        }
    },

    ClientSummaryData_Click: function (s, e) {
        var State = RevCost.VerCompanyState;
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('SummaryData|' + State.Key);
        });
    }

});

(function () {
    var pageModule = new RevCostPageModule();
    window.RevCost = pageModule;
})();
