RevCostPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.VersionState = { View: "List" };
        this.VerCompanyState = { View: "List" };
        this.State = { View: "List" };
        this.IsPageload = true;
        this.CopyVersion = "";
        this.VersionCallback = "";
        this.VerCompanyCallback = "";
        this.BudgetCallback = "";
        this.BudgetDetailCallback = "";
    },

    OnPageInit: function (s, e) {
        if (RevCost.IsPageload) {
            RevCost.IsPageload = false;
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
        if (e.pane.name == "Budget") {
            ClientBudgetGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "BudgetDetail") {
            ClientBudgetDetailGrid.SetHeight(e.pane.GetClientHeight());
        }
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

        RevCost.DoCallback(ClientBudgetGrid, function () {
            ClientBudgetGrid.PerformCallback('ShowHideColumn|' + value);
        });

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

    rdReport_Init: function (s, e) {
        dedFromDate.SetEnabled(false);
        dedToDate.SetEnabled(false);
    },

    rdReport_SelectedIndexChanged: function (s, e) {
        if (rdReport.GetValue() == "2")
        {
            dedFromDate.SetEnabled(true);
            dedToDate.SetEnabled(true);
        }
        else
        {
            dedFromDate.SetEnabled(false);
            dedToDate.SetEnabled(false);
        }
    },

    btnPrintReport_Click: function (s, e) {
        
        if (rdReport.GetValue() == "2" && (dedFromDate.GetValue() == null || dedToDate.GetValue() == null))
        {
            alert('Bạn chưa nhập giai đoạn !!!');
        }
        else
        {
            ClientReportViewer.Refresh();
        }
    },

    ClientVersionCompanyGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var verCompanyID = s.GetRowKey(s.GetFocusedRowIndex());

        ClientRevCostHiddenField.Set("VerCompanyID", verCompanyID);
        RevCost.ChangeVerCompanyState("List", "", verCompanyID);
        RevCost.DoCallback(ClientBudgetGrid, function () {
            ClientBudgetGrid.PerformCallback('LoadBudget|' + verCompanyID);
        });
    },

    ClientVersionCompanyGrid_BeginCallback: function (s, e) {
        this.VerCompanyCallback = e.command;
    },

    ClientVersionCompanyGrid_EndCallback: function (s, e) {
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
                    RevCost.DoCallback(ClientBudgetGrid, function () {
                        ClientBudgetGrid.PerformCallback('LoadBudget|' + 0);
                    });
                }
            }
        }
    },

    ClientVersionCompanyGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "btnVersionFiles") {
            if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
                return;
            var key = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

            ClientVersionCompanyGrid.GetValuesOnCustomCallback("EditForm|" + key, function (values) {
                RevCost.HideLoadingPanel();
                ClientVersionCompanyFilesPopup.Show();
            });
            RevCost.ShowLoadingPanel(ClientVersionCompanyGrid.GetMainElement());

            e.processOnServer = false;
        }
    },

    ClientBudgetGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "btnUpdateBudget") {

        }
        else if (e.buttonID == "btnBudgetFiles") {
            if (!ClientBudgetGrid.IsDataRow(ClientBudgetGrid.GetFocusedRowIndex()))
                return;
            var key = ClientBudgetGrid.GetRowKey(ClientBudgetGrid.GetFocusedRowIndex());
            
            ClientBudgetGrid.GetValuesOnCustomCallback("EditForm|" + key, function (values) {
                RevCost.HideLoadingPanel();
                ClientBudgetFilesPopup.Show();
            });
            RevCost.ShowLoadingPanel(ClientBudgetGrid.GetMainElement());

            e.processOnServer = false;
        }
    },
    ClientBudgetGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var BudgetID = s.GetRowKey(s.GetFocusedRowIndex());

        ClientRevCostHiddenField.Set("BudgetID", BudgetID);
        RevCost.ChangeState("List", "", BudgetID);
        RevCost.DoCallback(ClientBudgetDetailGrid, function () {
            ClientBudgetDetailGrid.PerformCallback('LoadBudgetDetail|' + BudgetID);
        });

        //RevCost.DoCallback(ClientStoreFilesGrid, function () {
        //    ClientStoreFilesGrid.PerformCallback('LoadStoreFiles|' + storeID);
        //});

    },

    ClientBudgetGrid_BeginCallback: function (s, e) {
        this.BudgetCallback = e.command;
    },

    ClientBudgetGrid_Init: function (s, e) {
        s.SetHorizontalScrollPosition(0);
    },

    ClientBudgetGrid_EndCallback: function (s, e) {

        if (s.cpCommand == "LoadBudget") {
            ClientlbTitle.SetValue(s.cpTitle);
        }

        if (this.BudgetCallback == "CUSTOMCALLBACK") {
            this.BudgetCallback = "";
            if (s.cpCommand == "LoadBudget") {
                RevCost.HideLoadingPanel();
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0)
                {
                    s.SetFocusedRowIndex(0);
                }
                else {
                    ClientRevCostHiddenField.Set("BudgetID", 0);
                    RevCost.ChangeState("List", "", 0);
                    RevCost.DoCallback(ClientBudgetDetailGrid, function () {
                        ClientBudgetDetailGrid.PerformCallback('LoadBudgetDetail|' + 0);
                    });
                }
            }
        }
    },

    ClientBudgetDetailGrid_EndCallback: function (s, e) {
        if (s.cpRet != null) {
            ClientmmNote.SetValue(s.cpRet.NOTE);
            ClienttxtCreatedBy.SetValue(s.cpRet.CREATED_BY);
            ClienttxtUpdatedBy.SetValue(s.cpRet.UPDATED_BY);
            ClienttxtCreatedDate.SetValue(s.cpRet.CREATED_DATE);
            ClienttxtUpdatedDate.SetValue(s.cpRet.UPDATED_DATE);
        }
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

    ClientBudgetFilesPopup_Shown: function (s, e) {
        if (!ClientBudgetGrid.IsDataRow(ClientBudgetGrid.GetFocusedRowIndex()))
            return;
        var BudgetID = ClientBudgetGrid.GetRowKey(ClientBudgetGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientBudgetFilesGrid, function () {
            ClientBudgetFilesGrid.PerformCallback('LoadBudgetFile|' + BudgetID);
        });
    },

    ClientUploadVerCompanyFile_Click: function () {
        if (ClientVerCompanyFilesUC.GetText() == "")
            return;
        ClientVerCompanyFilesUC.Upload();
    },

    ClientUploadBudgetFile_Click: function () {
        if (ClientBudgetFilesUC.GetText() == "")
            return;
        ClientBudgetFilesUC.Upload();
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

    ClientBudgetFilesUC_FilesUploadComplete: function (s, e) {
        if (e.callbackData == "error") {
            RevCost.ShowMessage(e.errorText);
        }
        else {
            var State = RevCost.State;
            var budgetID = State.Key;
            RevCost.DoCallback(ClientBudgetFilesGrid, function () {
                ClientBudgetFilesGrid.PerformCallback('SaveBudgetFile|' + budgetID + "|" + e.callbackData);
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

    ClientBudgetFilesGrid_CustomButtonClick: function (s, e) {
        var budgetFileID = s.GetRowKey(s.GetFocusedRowIndex());
        if (e.buttonID == "DownloadBudgetFile") {
            window.location = "../../Handler/DownloadFile.ashx?FileType=BudgetFile&BudgetID=" + budgetFileID;
            e.processOnServer = false;
        }
    },

    ClientApplyVersionCompanyFilesButton_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;
        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

        var State = RevCost.VersionState;
        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('SaveVerCompanyFile|' + State.Key + "|" + verCompanyID);
        });

    },

    ClientApplyBudgetFilesButton_Click: function (s, e) {
        if (!ClientBudgetFilesGrid.IsDataRow(ClientBudgetFilesGrid.GetFocusedRowIndex()))
            return;
        var BudgetID = ClientBudgetFilesGrid.GetRowKey(ClientBudgetFilesGrid.GetFocusedRowIndex());

        var State = RevCost.VersionState;
        RevCost.DoCallback(ClientBudgetFilesGrid, function () {
            ClientBudgetFilesGrid.PerformCallback('SaveBudgetFile|' + State.Key + "|" + verCompanyID);
        });

    },

    ClientChangeCompanyButton_Click: function (s, e) {
        //if (ClientRevCostHiddenField.Get("CompanyType") == "D") {
        //    alert("You do not have permission to perform this action.");
        //    return;
        //}
        ClientCompanyListPopup.Show();
    },

    ClientbtnGetDataBudget_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;
        
        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientBudgetGrid, function () {
            ClientBudgetGrid.PerformCallback('GetDataBudget|' + verCompanyID);
        });
    },

    ClientbtnUpdateRevCostAll_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;

        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientBudgetGrid, function () {
            ClientBudgetGrid.PerformCallback('UpdateRevCostDataAll|' + verCompanyID);
        });
    },

    ClientbtnUpdateRevCost1Sub_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;
        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

        if (!ClientBudgetGrid.IsDataRow(ClientBudgetGrid.GetFocusedRowIndex()))
            return;
        var budgetID = ClientBudgetGrid.GetRowKey(ClientBudgetGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientBudgetGrid, function () {
            ClientBudgetGrid.PerformCallback('UpdateRevCost1Sub|' + verCompanyID + '|' + budgetID);
        });
    },

    ClientbtnGetAllFieldsFor1Sub_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;
        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

        if (!ClientBudgetGrid.IsDataRow(ClientBudgetGrid.GetFocusedRowIndex()))
            return;
        var budgetID = ClientBudgetGrid.GetRowKey(ClientBudgetGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientBudgetGrid, function () {
            ClientBudgetGrid.PerformCallback('GetAllFieldFor1Sub|' + verCompanyID + '|' + budgetID);
        });
    },

    ClientbtnCalculate_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;

        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientBudgetGrid, function () {
            ClientBudgetGrid.PerformCallback('Calculate|' + verCompanyID);
        });
    },

    ClientbtnPrint_Click: function (s, e) {
        ClientReportPopup.Show();
    },

    ClientbtnShowReport_Click: function (s, e) {
        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;
        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());
        
        RevCost.DoCallback(ClientBudgetGrid, function () {
            ClientBudgetGrid.PerformCallback('ShowReport|' + verCompanyID);
        });

    },

    ClientbtnSave_Click: function(s, e){
        if (!ClientBudgetGrid.IsDataRow(ClientBudgetGrid.GetFocusedRowIndex()))
            return;

        var BudgetID = ClientBudgetGrid.GetRowKey(ClientBudgetGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientBudgetGrid, function () {
            ClientBudgetGrid.PerformCallback('UpdateNote|' + BudgetID);
        })
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
        RevCost.DoCallback(ClientBudgetGrid, function () {
            ClientBudgetGrid.PerformCallback('RefreshStore|' + State.Key);
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
