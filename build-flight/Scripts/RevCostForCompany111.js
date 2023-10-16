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
    },

    OnPageInit: function (s, e) {
        if (RevCost.IsPageload) {
            RevCost.IsPageload = false;
            ClientNewVersionButton.SetVisible(ClientRevCostHiddenField.Get("CompanyType") == 'K');
            ClientChangeCompanyButton.SetVisible(ClientRevCostHiddenField.Get("CompanyType") == 'K');
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
        else if (e.pane.name == "StoreFiles") {
            ClientStoreFilesGrid.SetHeight(e.pane.GetClientHeight());
        }
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

    ClientQuery_Click: function (s, e) {
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('Reload');
        });
    },

    ClientAmountType_ValueChanged: function (s, e) {
        var value = s.GetValue();

        //RevCost.DoCallback(ClientStoresGrid, function () {
        //    ClientStoresGrid.PerformCallback('ShowHideColumn|' + value);
        //});

        RevCost.DoCallback(ClientStoreDetailsGrid, function () {
            ClientStoreDetailsGrid.PerformCallback('ShowHideColumn|' + value);
        });
    },

    ClientVersionGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var versionID = s.GetRowKey(s.GetFocusedRowIndex());

        ClientRevCostHiddenField.Set("VersionID", versionID);
        RevCost.ChangeVersionState("List", "", versionID);
        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + versionID);
        });
    },

    ClientVersionGrid_BeginCallback: function (s, e) {
        this.VersionCallback = e.command;
    },

    ClientVersionGrid_EndCallback: function (s, e) {
        ClientNewVersionButton.SetVisible(ClientRevCostHiddenField.Get("CompanyType") == 'K');
        if (this.VersionCallback == "CUSTOMCALLBACK") {
            this.VersionCallback = "";
            if (s.cpCommand == "Reload") {
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0)
                    s.SetFocusedRowIndex(0);
                else {
                    ClientRevCostHiddenField.Set("VersionID", 0);
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

        ClientRevCostHiddenField.Set("VerCompanyID", verCompanyID);
        RevCost.ChangeVerCompanyState("List", "", verCompanyID);
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('LoadStore|' + verCompanyID);
        });
    },

    ClientVersionCompanyGrid_BeginCallback: function (s, e) {
        this.VerCompanyCallback = e.command;
    },

    ClientVersionCompanyGrid_EndCallback: function (s, e) {
        ClientChangeCompanyButton.SetVisible(ClientRevCostHiddenField.Get("CompanyType") == 'K');
        //ClientNewVersionCompanyButton.SetVisible(ClientRevCostHiddenField.Get("CompanyType") == 'K');
        if (this.VerCompanyCallback == "CUSTOMCALLBACK") {
            this.VerCompanyCallback = "";
            if (s.cpCommand == "LoadVerCompany" || s.cpCommand == "ChangeCompany" || s.cpCommand == "NewVersionCompany") {
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0)
                    s.SetFocusedRowIndex(0);
                else {
                    ClientRevCostHiddenField.Set("VerCompanyID", 0);
                    RevCost.ChangeVerCompanyState("List", "", 0);
                    RevCost.DoCallback(ClientStoresGrid, function () {
                        ClientStoresGrid.PerformCallback('LoadStore|' + 0);
                    });
                }
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
        //if (!s.IsDataRow(s.GetFocusedRowIndex()))
        //    return;
        //var storeID = s.GetRowKey(s.GetFocusedRowIndex());
        var storeID = s.GetFocusedNodeKey();

        ClientRevCostHiddenField.Set("StoreID", storeID);
        RevCost.ChangeStoreState("List", "", storeID);
        RevCost.DoCallback(ClientStoreDetailsGrid, function () {
            ClientStoreDetailsGrid.PerformCallback('LoadStoreDetail|' + storeID);
        });

        RevCost.DoCallback(ClientStoreFilesGrid, function () {
            ClientStoreFilesGrid.PerformCallback('LoadStoreFiles|' + storeID);
        });

        $.ajax({
            type: "GET",
            url: "../../Handler/GetStoreNote.ashx",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: { 'key': storeID },
            responseType: "text/plain",
            success: RevCost.OnGetStoreNoteSuccess,
            error: RevCost.OnGetStoreNoteFail
        });
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

    ClientStoresGrid_Init: function (s, e) {
        s.SetHorizontalScrollPosition(0);
    },

    ClientStoresGrid_EndCallback: function (s, e) {
        if (this.StoreCallback == "CUSTOMCALLBACK") {
            this.StoreCallback = "";
            if (s.cpCommand == "LoadStore") {
                RevCost.HideLoadingPanel();
                /*  s.SetFocusedRowIndex(-1);*/
                //if (s.GetVisibleRowsOnPage() > 0)
                //    s.SetFocusedRowIndex(0);
                //else {
                ClientStoresGrid.SetFocusedNodeKey(null);
                ClientStoreNoteEditor.SetValue("");
                ClientRevCostHiddenField.Set("StoreID", 0);
                RevCost.ChangeStoreState("List", "", 0);
                RevCost.DoCallback(ClientStoreDetailsGrid, function () {
                    ClientStoreDetailsGrid.PerformCallback('LoadStoreDetail|' + 0);
                });

                RevCost.DoCallback(ClientStoreFilesGrid, function () {
                    ClientStoreFilesGrid.PerformCallback('LoadStoreFiles|' + 0);
                });
                //}
            }
            if (s.cpCommand == "ShowHideColumn") {
                s.SetHorizontalScrollPosition(0);
                var value = ClientAmountType.GetValue();
                var pane = ClientContentSplitter.GetPaneByName("StoreDetail");
                var isCollapsed = pane.IsCollapsed();
                if (value == 'AN' || value == 'CO' || value == 'GE' || value == 'OT') {
                    if (!isCollapsed)
                        pane.Collapse(pane);
                }
                else {
                    if (isCollapsed)
                        pane.Expand();
                }
            }
        }
    },

    ClientRefreshSrore_Click: function (s, e) {
        var State = RevCost.VerCompanyState;
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('LoadStore|' + State.Key);
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
        //RevCost.ShowLoadingPanel(ClientContentSplitter.GetMainElement());
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
        var amountType = ClientAmountType.GetValue();
        if (amountType == null || amountType == "AS") {
            RevCost.ShowMessage("Action not allowed here.");
            return;
        }
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
        if (ClientRevCostHiddenField.Get("CompanyType") == "D") {
            alert("You do not have permission to perform this action.");
            return;
        }
        ClientCompanyListPopup.Show();
    },

    ClientNewVersionButton_Click: function (s, e) {
        if (ClientRevCostHiddenField.Get("CompanyType") == "D") {
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
    }

});

(function () {
    var pageModule = new RevCostPageModule();
    window.RevCost = pageModule;
})();
