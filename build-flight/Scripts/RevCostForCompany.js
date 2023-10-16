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
        this.CurrentStoreID = 0;
    },

    OnPageInit: function (s, e) {
        if (RevCost.IsPageload) {
            RevCost.IsPageload = false;
            ClientNewVersionButton.SetVisible(ClientRevCostHiddenField.Get("CompanyType") == 'K');
            //ClientChangeCompanyButton.SetVisible(ClientRevCostHiddenField.Get("CompanyType") == 'K');

            ClientVersionCompanyUnitPopup.SetHeight(window.innerHeight - 100);
            ClientVersionCompanyUnitPopup.SetWidth(window.innerWidth - 100);

            window.setTimeout(function () {
                RevCost.showLeftPane();
            }, 500);

            window.addEventListener('resize', RevCost.WindowResize);
        }
    },

    WindowResize: function () {
        ClientSplitterVersion.AdjustControl();
    },

    ShowMessage(message) {
        toastr.options.positionClass = "toast-bottom-right";
        toastr.warning(message);
        //window.setTimeout("alert('" + message + "')", 0);
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

        ClientVersionCompanyUnitPopup.SetHeight(window.innerHeight - 100);
        ClientVersionCompanyUnitPopup.SetWidth(window.innerWidth - 100);
        ClientSplitterVersion.AdjustControl();
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
        ClientSplitterVersion.AdjustControl();
    },

    showLeftPane: function () {
        $(ClientMainPanel.GetMainElement()).addClass("show-menu");
        ClientSplitterVersion.AdjustControl();
    },

    ClientQuery_Click: function (s, e) {
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('Reload');
        });
    },

    ClientApproveVersion_Click: function (s, e) {
        var versionID;
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        const DNDALERT = new DNDAlert({
            title: "Confirm",
            message:
                "Confirm?.",
            type: "warning",
            html: false,
            buttons: [
                {
                    text: "Ok",
                    type: "primary",
                    onClick: (bag) => {
                        versionID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
                        RevCost.DoCallback(ClientVersionGrid, function (a, b) {
                            ClientVersionGrid.PerformCallback('ApproveVersion|' + versionID);
                        });
                        /*RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                            ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + versionID);
                        });*/
                        bag.CLOSE_MODAL();
                    },
                },
                {
                    text: "Cancel",
                    onClick: (bag) => {
                        bag.CLOSE_MODAL();
                    },
                },
            ],
            closeBackgroundClick: true,
            portalElement: document.querySelector("body"),
            portalOverflowHidden: true,
            textAlign: "center",
            theme: "white",
            onOpen: (bag) => {
                console.log("Modal Opened");
                console.log(bag.PROPERTIES);
            },
            onClose: (bag) => {
                console.log("Modal Closed");
                console.log(bag);
            },
            opacity: 1,
            autoCloseDuration: 6000,
            draggable: true,
            animationStatus: false,
            closeIcon: false,
            sourceControlWarning: true,

        });


    },

    ClientDisApproveVersion_Click: function (s, e) {
        var versionID;
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        const DNDALERT = new DNDAlert({
            title: "Confirm",
            message:
                "Confirm?.",
            type: "warning",
            html: false,
            buttons: [
                {
                    text: "Ok",
                    type: "primary",
                    onClick: (bag) => {
                        versionID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
                        RevCost.DoCallback(ClientVersionGrid, function (a, b) {
                            ClientVersionGrid.PerformCallback('DisApproveVersion|' + versionID);
                        });
                        /*RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                            ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + versionID);
                        });*/
                        bag.CLOSE_MODAL();
                    },
                },
                {
                    text: "Cancel",
                    onClick: (bag) => {
                        bag.CLOSE_MODAL();
                    },
                },
            ],
            closeBackgroundClick: true,
            portalElement: document.querySelector("body"),
            portalOverflowHidden: true,
            textAlign: "center",
            theme: "white",
            onOpen: (bag) => {
                console.log("Modal Opened");
                console.log(bag.PROPERTIES);
            },
            onClose: (bag) => {
                console.log("Modal Closed");
                console.log(bag);
            },
            opacity: 1,
            autoCloseDuration: 6000,
            draggable: true,
            animationStatus: false,
            closeIcon: false,
            sourceControlWarning: true,

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
                        ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + -1);
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
        //ClientChangeCompanyButton.SetVisible(ClientRevCostHiddenField.Get("CompanyType") == 'K');
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
            if (s.cpCommand == "POST" || s.cpCommand == "UNPOST" || s.cpCommand == "APPROVE" || s.cpCommand == "UNAPPROVE") {
                if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
                    return;
                var versionID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

                RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                    ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + versionID);
                });

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
        s.SetFocusedNodeKey(e.nodeKey);
        var storeID = s.GetFocusedNodeKey();
        if (this.CurrentStoreID == storeID)
            return;
        this.CurrentStoreID = storeID;
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

    ClientStoresGrid_BatchEditStartEditing: function (s, e) {
        if (s.batchEditApi.GetCellValue(s.focusedKey, 'Calculation') == 'SUM')
            e.cancel = true;

        if (e.focusedColumn.fieldName == "OutStandards") {
            var allowed = s.batchEditApi.GetCellValue(s.focusedKey, 'OutAllowUpdate');
            if (!allowed)
                e.cancel = true;
        }

        if (e.focusedColumn.fieldName == "Decentralization") {
            var allowed = s.batchEditApi.GetCellValue(s.focusedKey, 'DecAllowUpdate');
            if (!allowed)
                e.cancel = true;
        }
    },

    OnGetStoreNoteSuccess: function (value) {
        ClientStoreNoteEditor.SetValue(value);
    },

    OnGetStoreNoteFail: function (error) {
        RevCost.ShowMessage(error);
    },

    ClientStoresGrid_BeginCallback: function (s, e) {
        console.log(e.command);
        this.StoreCallback = e.command;
    },

    ClientStoresGrid_Init: function (s, e) {
        s.SetHorizontalScrollPosition(0);
    },

    ClientStoresGrid_EndCallback: function (s, e) {
        RevCost.HideLoadingPanel();
        if (this.StoreCallback == "UpdateEdit") {
            var storeID = s.GetFocusedNodeKey();
            RevCost.DoCallback(ClientStoreDetailsGrid, function () {
                ClientStoreDetailsGrid.PerformCallback('LoadStoreDetail|' + storeID);
            });

            var State = RevCost.VerCompanyState;
            RevCost.DoCallback(ClientStoresGrid, function () {
                ClientStoresGrid.PerformCallback('RefreshStore|' + State.Key);
            });
        }
        else if (this.StoreCallback == "CustomCallback") {
            this.StoreCallback = "";
            //Load Title Company Name

            if (s.cpCommand == "LoadStore" || s.cpCommand == "RefreshStore") {
                ClientlbTitle.SetText(s.cpTitle);
            }

            if (s.cpCommand == "AutoItem" || s.cpCommand == "AutoAllItem" || s.cpCommand == "CalculateStore") {
                if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
                    return;
                var key = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

                RevCost.DoCallback(ClientStoresGrid, function () {
                    ClientStoresGrid.PerformCallback('LoadStore|' + key);
                });
            }
            if (s.cpCommand == "LoadStore") {
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

    ClientAutoItem_Click: function (s, e) {
        var State = RevCost.VerCompanyState;
        var StoreState = RevCost.StoreState;
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('AutoItem|' + State.Key + '|' + StoreState.Key);
        });
        toastr.options.positionClass = "toast-bottom-right";
        toastr.success("Tiến trình đã đưa vào queued để chạy.");
    },

    ClientAutoAllItem_Click: function (s, e) {
        var State = RevCost.VerCompanyState;
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('AutoAllItem|' + State.Key);
        });
        toastr.options.positionClass = "toast-bottom-right";
        toastr.success("Tiến trình đã đưa vào queued để chạy.");
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
        else if (e.buttonID == "Delete") {
            if (!ClientStoreFilesGrid.IsDataRow(ClientStoreFilesGrid.GetFocusedRowIndex()))
                return;
            var cf = confirm("Are you sure?");
            if (cf) {
                var key = ClientStoreFilesGrid.GetRowKey(ClientStoreFilesGrid.GetFocusedRowIndex());
                RevCost.DoCallback(ClientStoreFilesGrid, function () {
                    ClientStoreFilesGrid.PerformCallback('Delete|' + key);
                });
            }
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
        //var amountType = ClientAmountType.GetValue();
        //if (amountType == null || amountType == "AS") {
        //    RevCost.ShowMessage("Action not allowed here.");
        //    return;
        //}
        const DNDALERT = new DNDAlert({
            title: "Confirm",
            message:
                "Confirm?.",
            type: "warning",
            html: false,
            buttons: [
                {
                    text: "Ok",
                    type: "primary",
                    onClick: (bag) => {
                        var State = RevCost.StoreState;
                        var storeID = State.Key;
                        RevCost.DoCallback(ClientStoreDetailsGrid, function () {
                            ClientStoreDetailsGrid.PerformCallback('Allocate|' + storeID);
                        });
                        bag.CLOSE_MODAL();
                    },
                },
                {
                    text: "Cancel",
                    onClick: (bag) => {
                        bag.CLOSE_MODAL();
                    },
                },
            ],
            closeBackgroundClick: true,
            portalElement: document.querySelector("body"),
            portalOverflowHidden: true,
            textAlign: "center",
            theme: "white",
            onOpen: (bag) => {
                console.log("Modal Opened");
                console.log(bag.PROPERTIES);
            },
            onClose: (bag) => {
                console.log("Modal Closed");
                console.log(bag);
            },
            opacity: 1,
            autoCloseDuration: 6000,
            draggable: true,
            animationStatus: false,
            closeIcon: false,
            sourceControlWarning: true,

        });
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
        else if (e.buttonID == "DeleteVersionFile") {
            var cf = confirm("Are you sure?");
            if (cf) {
                RevCost.DoCallback(ClientVersionCompanyFilesGrid, function () {
                    ClientVersionCompanyFilesGrid.PerformCallback('Delete|' + verCompanyFileID);
                });
            }
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
        //if (ClientRevCostHiddenField.Get("CompanyType") == "D") {
        //    toastr.options.positionClass = "toast-bottom-right";
        //    toastr.warning("You do not have permission to perform this action.");
        //    //alert("You do not have permission to perform this action.");
        //    return;
        //}
        ClientCompanyListPopup.Show();
    },

    ClientNewVersionButton_Click: function (s, e) {
        if (ClientRevCostHiddenField.Get("CompanyType") == "D") {
            toastr.options.positionClass = "toast-bottom-right";
            toastr.warning("You do not have permission to perform this action.");
            //alert("You do not have permission to perform this action.");
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
        const DNDALERT = new DNDAlert({
            title: "Confirm",
            message:
                "Confirm create new version?.",
            type: "warning",
            html: false,
            buttons: [
                {
                    text: "Ok",
                    type: "primary",
                    onClick: (bag) => {
                        var verID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
                        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                            ClientVersionCompanyGrid.PerformCallback('NewVersionCompany|' + verID);
                        });
                        bag.CLOSE_MODAL();
                    },
                },
                {
                    text: "Cancel",
                    onClick: (bag) => {
                        bag.CLOSE_MODAL();
                    },
                },
            ],
            closeBackgroundClick: true,
            portalElement: document.querySelector("body"),
            portalOverflowHidden: true,
            textAlign: "center",
            theme: "white",
            onOpen: (bag) => {
                console.log("Modal Opened");
                console.log(bag.PROPERTIES);
            },
            onClose: (bag) => {
                console.log("Modal Closed");
                console.log(bag);
            },
            opacity: 1,
            autoCloseDuration: 6000,
            draggable: true,
            animationStatus: false,
            closeIcon: false,
            sourceControlWarning: true,

        });


        //var cf = confirm("Confirm create new version?");
        //if (cf) {
        //    var verID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
        //    RevCost.DoCallback(ClientVersionCompanyGrid, function () {
        //        ClientVersionCompanyGrid.PerformCallback('NewVersionCompany|' + verID);
        //    });
        //}
    },

    ClientCopyVersionCompanyButton_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;
        //var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());
        const DNDALERT = new DNDAlert({
            title: "Confirm",
            message:
                "Confirm copy?.",
            type: "warning",
            html: false,
            buttons: [
                {
                    text: "Ok",
                    type: "primary",
                    onClick: (bag) => {
                        this.CopyVersion = "VersionCompany";
                        ClientCopyVersionCompanyPopup.Show();
                        bag.CLOSE_MODAL();
                    },
                },
                {
                    text: "Cancel",
                    onClick: (bag) => {
                        bag.CLOSE_MODAL();
                    },
                },
            ],
            closeBackgroundClick: true,
            portalElement: document.querySelector("body"),
            portalOverflowHidden: true,
            textAlign: "center",
            theme: "white",
            onOpen: (bag) => {
                console.log("Modal Opened");
                console.log(bag.PROPERTIES);
            },
            onClose: (bag) => {
                console.log("Modal Closed");
                console.log(bag);
            },
            opacity: 1,
            autoCloseDuration: 6000,
            draggable: true,
            animationStatus: false,
            closeIcon: false,
            sourceControlWarning: true,

        });
        //var cf = confirm("Confirm copy?");
        //if (cf) {
        //    this.CopyVersion = "VersionCompany";
        //    ClientCopyVersionCompanyPopup.Show();
        //}
    },

    ClientClientDuplicateVersionCompanyButton_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;

        const DNDALERT = new DNDAlert({
            title: "Confirm",
            message:
                "Confirm duplicate?.",
            type: "warning",
            html: false,
            buttons: [
                {
                    text: "Ok",
                    type: "primary",
                    onClick: (bag) => {
                        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

                        var State = RevCost.VersionState;
                        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                            ClientVersionCompanyGrid.PerformCallback('Duplicate|' + State.Key + "|" + verCompanyID);
                        });
                        bag.CLOSE_MODAL();
                    },
                },
                {
                    text: "Cancel",
                    onClick: (bag) => {
                        bag.CLOSE_MODAL();
                    },
                },
            ],
            closeBackgroundClick: true,
            portalElement: document.querySelector("body"),
            portalOverflowHidden: true,
            textAlign: "center",
            theme: "white",
            onOpen: (bag) => {
                console.log("Modal Opened");
                console.log(bag.PROPERTIES);
            },
            onClose: (bag) => {
                console.log("Modal Closed");
                console.log(bag);
            },
            opacity: 1,
            autoCloseDuration: 6000,
            draggable: true,
            animationStatus: false,
            closeIcon: false,
            sourceControlWarning: true,

        });
        //var cf = confirm("Confirm duplicate?");
        //if (cf) {
        //    var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

        //    var State = RevCost.VersionState;
        //    RevCost.DoCallback(ClientVersionCompanyGrid, function () {
        //        ClientVersionCompanyGrid.PerformCallback('Duplicate|' + State.Key + "|" + verCompanyID);
        //    });
        //}
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
                toastr.options.positionClass = "toast-bottom-right";
                toastr.warning("Please select another version to copy.");
                //alert("Please select another version to copy.");
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

    ClientbtnPrintStoreButton_Shown: function (s, e) {
        //RevCost.DoCallback(ClientVersionCopyGrid, function () {
        //    ClientVersionCopyGrid.PerformCallback('LoadAllVersion');
        //});
        null
    },

    ClientbtnPrintStoreButton_CloseUp: function (s, e) {
        //if (this.CopyVersion == "VersionCompany") {
        //    var State = RevCost.VersionState;
        //    RevCost.DoCallback(ClientVersionCompanyGrid, function () {
        //        ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + State.Key);
        //    });
        //}
        //this.CopyVersion = "";
        null
    },

    ClientSelectVersionBaseReport_Click: function (s, e) {
        ClientVersionCompanyPopup.Show();
    },

    ReportClientSelectVersionBaseReport_Click: function (s, e) {
        ReportVersionCompanyPopup.Show();
    },

    // Bao cao
    ClientbtnPrintStoreButton_Click: function (s, e) {
        var State = RevCost.VerCompanyState;
        var Year = VersionYearEditor.GetValue();
        var VerType = rdoVersionType.GetValue();

        ClientRevCostHiddenField.Set("VerCompanyID", State.Key);
        var URL = window.location.protocol + "//" + window.location.host + "/Reports/Report_RevCost_Division.aspx";
        window.open(URL, "_blank");
    },

    // Import RevCost
    ClientImportRevCostButton_Click: function (s, e) {
        var State = RevCost.VerCompanyState;
        var StoreState = RevCost.StoreState;
        ClientRevCostHiddenField.Set("VerCompanyID", State.Key);
        ClientRevCostHiddenField.Set("StoreID", StoreState.Key);
        var URL = window.location.protocol + "//" + window.location.host + "/Imports/ImportQuantiy.aspx";
        window.open(URL, "_blank");
    },
    // Unit
    ClientbtnUnitButton_Click: function (s, e) {
        ClientVersionCompanyUnitPopup.Show();
    },

    ClientUploadUnit_Click: function (s, e) {
        //var VerCompanyID = RevCost.VerCompanyState.Key;
        //ClientRevCostHiddenField.Set("VerCompanyID", VerCompanyID);
        var URL = window.location.protocol + "//" + window.location.host + "/Imports/ImportQuantiy.aspx?Code=UNIT";
        window.open(URL, "_blank");

    },

    ClientVersionCompanyUnitGrid_Shown: function (s, e) {

        var StoreId = RevCost.StoreState.Key;

        var VersionId = RevCost.VersionState.Key;


        RevCost.DoCallback(ClientVersionCompanyUnitGrid, function () {
            ClientVersionCompanyUnitGrid.PerformCallback('LoadCompanyUnit|' + VersionId + '|' + StoreId);
        });
    },

    ClientVersionCompanyUnitGrid_CloseUp: function (s, e) {
        var State = RevCost.VerCompanyState;
        RevCost.DoCallback(ClientVersionCompanyUnitGrid, function () {
            ClientVersionCompanyUnitGrid.PerformCallback('RefreshStore|' + State.Key);
        });
    },


    StoreGridGetRowValues: function (values) {
        var status = values;
        if (status == null || status == 'WORKING' || status == '') {
            ClientAllocateApply.SetEnabled(true);
            ClientStoreDetailTypeOfAmount.SetEnabled(true);
            ClientStoreDetailMonthFrom.SetEnabled(true);
            ClientStoreDetailMonthTo.SetEnabled(true);
            ClientStoreDetailAmount.SetEnabled(true);
            ClientbtnSaveStoreDetail.SetEnabled(true);
        } else {
            ClientAllocateApply.SetEnabled(false);
            ClientStoreDetailTypeOfAmount.SetEnabled(false);
            ClientStoreDetailMonthFrom.SetEnabled(false);
            ClientStoreDetailMonthTo.SetEnabled(false);
            ClientStoreDetailAmount.SetEnabled(false);
            ClientbtnSaveStoreDetail.SetEnabled(false);
        }
    },
    ClientPostButton_Click: function (s, e) {
        //var cf = confirm("Confirm?");
        //if (!cf) return;
        const DNDALERT = new DNDAlert({
            title: "Confirm",
            message:
                "Confirm?.",
            type: "warning",
            html: false,
            buttons: [
                {
                    text: "Ok",
                    type: "primary",
                    onClick: (bag) => {
                        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
                            return;
                        var key = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

                        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                            ClientVersionCompanyGrid.PerformCallback('POST|' + key);
                        });
                        bag.CLOSE_MODAL();
                    },
                },
                {
                    text: "Cancel",
                    onClick: (bag) => {
                        bag.CLOSE_MODAL();
                    },
                },
            ],
            closeBackgroundClick: true,
            portalElement: document.querySelector("body"),
            portalOverflowHidden: true,
            textAlign: "center",
            theme: "white",
            onOpen: (bag) => {
                console.log("Modal Opened");
                console.log(bag.PROPERTIES);
            },
            onClose: (bag) => {
                console.log("Modal Closed");
                console.log(bag);
            },
            opacity: 1,
            autoCloseDuration: 6000,
            draggable: true,
            animationStatus: false,
            closeIcon: false,
            sourceControlWarning: true,

        });
    },
    ClientUnpostButton_Click: function (s, e) {
        const DNDALERT = new DNDAlert({
            title: "Confirm",
            message:
                "Confirm?.",
            type: "warning",
            html: false,
            buttons: [
                {
                    text: "Ok",
                    type: "primary",
                    onClick: (bag) => {
                        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
                            return;
                        var key = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

                        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                            ClientVersionCompanyGrid.PerformCallback('UNPOST|' + key);
                        });
                        bag.CLOSE_MODAL();
                    },
                },
                {
                    text: "Cancel",
                    onClick: (bag) => {
                        bag.CLOSE_MODAL();
                    },
                },
            ],
            closeBackgroundClick: true,
            portalElement: document.querySelector("body"),
            portalOverflowHidden: true,
            textAlign: "center",
            theme: "white",
            onOpen: (bag) => {
                console.log("Modal Opened");
                console.log(bag.PROPERTIES);
            },
            onClose: (bag) => {
                console.log("Modal Closed");
                console.log(bag);
            },
            opacity: 1,
            autoCloseDuration: 6000,
            draggable: true,
            animationStatus: false,
            closeIcon: false,
            sourceControlWarning: true,

        });
    },
    ClientComApproveButton_Click: function (s, e) {
        const DNDALERT = new DNDAlert({
            title: "Confirm",
            message:
                "Confirm?.",
            type: "warning",
            html: false,
            buttons: [
                {
                    text: "Ok",
                    type: "primary",
                    onClick: (bag) => {
                        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
                            return;
                        var key = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

                        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                            ClientVersionCompanyGrid.PerformCallback('APPROVE|' + key);
                        });
                        bag.CLOSE_MODAL();
                    },
                },
                {
                    text: "Cancel",
                    onClick: (bag) => {
                        bag.CLOSE_MODAL();
                    },
                },
            ],
            closeBackgroundClick: true,
            portalElement: document.querySelector("body"),
            portalOverflowHidden: true,
            textAlign: "center",
            theme: "white",
            onOpen: (bag) => {
                console.log("Modal Opened");
                console.log(bag.PROPERTIES);
            },
            onClose: (bag) => {
                console.log("Modal Closed");
                console.log(bag);
            },
            opacity: 1,
            autoCloseDuration: 6000,
            draggable: true,
            animationStatus: false,
            closeIcon: false,
            sourceControlWarning: true,

        });
    },
    ClientComUnapproveButton_Click: function (s, e) {
        const DNDALERT = new DNDAlert({
            title: "Confirm",
            message:
                "Confirm?.",
            type: "warning",
            html: false,
            buttons: [
                {
                    text: "Ok",
                    type: "primary",
                    onClick: (bag) => {
                        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
                            return;
                        var key = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

                        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
                            ClientVersionCompanyGrid.PerformCallback('UNAPPROVE|' + key);
                        });
                        bag.CLOSE_MODAL();
                    },
                },
                {
                    text: "Cancel",
                    onClick: (bag) => {
                        bag.CLOSE_MODAL();
                    },
                },
            ],
            closeBackgroundClick: true,
            portalElement: document.querySelector("body"),
            portalOverflowHidden: true,
            textAlign: "center",
            theme: "white",
            onOpen: (bag) => {
                console.log("Modal Opened");
                console.log(bag.PROPERTIES);
            },
            onClose: (bag) => {
                console.log("Modal Closed");
                console.log(bag);
            },
            opacity: 1,
            autoCloseDuration: 6000,
            draggable: true,
            animationStatus: false,
            closeIcon: false,
            sourceControlWarning: true,

        });
    },

    ClientSaveStore_Click: function (s, e) {
        //if (ClientStoresGrid.batchEditApi.HasChanges()) {
        ClientStoresGrid.UpdateEdit();
        //}
    },

    ClientViewRoe_Click: function (s, e) {

        var VersionId = RevCost.VersionState.Key;

        RevCost.DoCallback(ClientRoeDataGrid, function () {
            ClientRoeDataGrid.PerformCallback('LOAD_ROE|' + VersionId);
        });
        ClientRoePopup.Show();
    },

    ClientExpandAll_Click: function (s, e) {
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('ExpandAll');
        });
    },

    ClientCollapseAll_Click: function (s, e) {
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('CollapseAll');
        });
    },

    ClientCboReviewStatus_ValueChanged: function (s, e) {
        var State = RevCost.VerCompanyState;
        RevCost.DoCallback(ClientStoresGrid, function () {
            ClientStoresGrid.PerformCallback('RefreshStore|' + State.Key);
        });
    },

});

(function () {
    var pageModule = new RevCostPageModule();
    window.RevCost = pageModule;
})();
