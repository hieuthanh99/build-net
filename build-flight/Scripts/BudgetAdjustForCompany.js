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
        this.TransactionHDCallback = "";
        this.BudgetAdjustRoeCallback = "";
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
    },

    ClientContentSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "BudgetAdjustPane") {
            ClientBudgetAdjustGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "BudgetAdjustRoePane") {
            ClientBudgetAdjustRoeGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "BudgetAdjustTransactionHDPane") {
            ClientBudgetAdjustTransactionHDGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "BudgetAdjustTransactionPane") {
            ClientBudgetAdjustTransactionGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientAdjustOriSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "VersionCompanyOriPane") {
            ClientVersionCompanyGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "BudgetOriPane") {
            ClientBudgetGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "CompanyOriPane") {
            ClientCompanyGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientAdjustDesSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "VersionCompanyDesPane") {
            ClientVersionCompanyDesGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "BudgetDesPane") {
            ClientBudgetDesGrid.SetHeight(e.pane.GetClientHeight());
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
        RevCost.DoCallback(ClientBudgetAdjustGrid, function () {
            ClientBudgetAdjustGrid.PerformCallback('LoadBudgetAdjust|' + versionID);
        });
    },

    ClientVersionGrid_BeginCallback: function (s, e) {
        this.VersionCallback = e.command;
    },

    ClientBudgetAdjustRoeGrid_BeginCallback: function (s, e) {
        this.BudgetAdjustRoeCallback = e.command;
    },

    ClientBudgetAdjustRoeGrid_EndCallback: function (s, e){
        if (this.BudgetAdjustRoeCallback == "CUSTOMCALLBACK")
        {
            this.BudgetAdjustRoeCallback = "";
            if (s.cpActive == "Y")
                ClientbtnSelectSubAccount.SetEnabled(true);
            else
                ClientbtnSelectSubAccount.SetEnabled(false);
        }
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
                    RevCost.DoCallback(ClientBudgetAdjustGrid, function () {
                        ClientBudgetAdjustGrid.PerformCallback('LoadBudgetAdjust|' + 0);
                    });
                }
            }
        }
    },

    ClientVersionCompanyGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var verCompanyID = s.GetRowKey(s.GetFocusedRowIndex());
        RevCost.DoCallback(ClientBudgetGrid, function () {
            ClientBudgetGrid.PerformCallback('LoadBudget|' + verCompanyID);
        });
    },

    ClientVersionCompanyGrid_BeginCallback: function (s, e) {
        this.VerCompanyCallback = e.command;
    },

    ClientVersionCompanyGrid_EndCallback: function (s, e) {
        if (this.VerCompanyCallback == "CUSTOMCALLBACK") {
            this.VerCompanyCallback = "";
            if (s.cpCommand == "LoadVerCompany") {
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0)
                    s.SetFocusedRowIndex(0);
                else {
                    RevCost.DoCallback(ClientBudgetGrid, function () {
                        ClientBudgetGrid.PerformCallback('LoadBudget|' + 0);
                    });
                }
            }
        }
    },

    ClientVersionCompanyDesGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var verCompanyID = s.GetRowKey(s.GetFocusedRowIndex());
        RevCost.DoCallback(ClientBudgetDesGrid, function () {
            ClientBudgetDesGrid.PerformCallback('LoadBudget|' + verCompanyID);
        });
    },

    ClientVersionCompanyDesGrid_BeginCallback: function (s, e) {
        this.VerCompanyCallback = e.command;
    },

    ClientVersionCompanyDesGrid_EndCallback: function (s, e) {
        if (this.VerCompanyCallback == "CUSTOMCALLBACK") {
            this.VerCompanyCallback = "";
            if (s.cpCommand == "LoadVerCompany") {
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0)
                    s.SetFocusedRowIndex(0);
                else {
                    RevCost.DoCallback(ClientBudgetOriGrid, function () {
                        ClientBudgetOriGrid.PerformCallback('LoadBudget|' + 0);
                    });
                }
            }
        }
    },
    
    ClientBudgetGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var budgetID = s.GetRowKey(s.GetFocusedRowIndex());
        RevCost.DoCallback(ClientCompanyGrid, function () {
            ClientCompanyGrid.PerformCallback('LoadCompany|' + budgetID);
        });
    },

    ClientBudgetGrid_BeginCallback: function (s, e) {
        this.BudgetCallback = e.command;
    },

    ClientBudgetGrid_EndCallback: function (s, e) {
        if (this.BudgetCallback == "CUSTOMCALLBACK") {
            this.BudgetCallback = "";
            if (s.cpCommand == "LoadBudget") {
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0)
                    s.SetFocusedRowIndex(0);
                else {
                    RevCost.DoCallback(ClientCompanyGrid, function () {
                        ClientCompanyGrid.PerformCallback('LoadCompany|' + 0);
                    });
                }
            }
        }
    },

    ClientBudgetAdjustGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "btnBudgetAdjustFiles") {
            if (!ClientBudgetAdjustGrid.IsDataRow(ClientBudgetAdjustGrid.GetFocusedRowIndex()))
                return;
            var key = ClientBudgetAdjustGrid.GetRowKey(ClientBudgetAdjustGrid.GetFocusedRowIndex());
            
            ClientBudgetAdjustGrid.GetValuesOnCustomCallback("EditForm|" + key, function (values) {
                RevCost.HideLoadingPanel();
                ClientBudgetAdjustFilesPopup.Show();
            });
            RevCost.ShowLoadingPanel(ClientBudgetAdjustGrid.GetMainElement());

            e.processOnServer = false;
        }
    },

    ClientBudgetAdjustGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var BudgetAdjustID = s.GetRowKey(s.GetFocusedRowIndex());

        ClientRevCostHiddenField.Set("BudgetAdjustID", BudgetAdjustID);
        RevCost.ChangeState("List", "", BudgetAdjustID);
        RevCost.DoCallback(ClientBudgetAdjustRoeGrid, function () {
            ClientBudgetAdjustRoeGrid.PerformCallback('LoadBudgetAdjustRoe|' + BudgetAdjustID);
        });

        RevCost.DoCallback(ClientBudgetAdjustTransactionHDGrid, function () {
            ClientBudgetAdjustTransactionHDGrid.PerformCallback('LoadTransactionHD|' + BudgetAdjustID);
        });

        //RevCost.DoCallback(ClientPermissionCallback, function () {
        //    ClientPermissionCallback.PerformCallback('SetPermission|' + BudgetAdjustID);
        //});
    },

    //ClientPermissionCallback_CallbackComplete: function (s, e) {
    //    var status = e.result;
    //    if (status == 'Y')
    //    {
    //        ClientbtnSelectSubAccount.SetEnabled(false);
    //        ClientbtnSelectCompany.SetEnabled(false);
    //    }
    //    else
    //    {
    //        ClientbtnSelectSubAccount.SetEnabled(true);
    //        ClientbtnSelectCompany.SetEnabled(true);
    //    }
            
    //},

    ClientBudgetAdjustTransactionHDGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var TransactionHdID = s.GetRowKey(s.GetFocusedRowIndex());

        RevCost.DoCallback(ClientBudgetAdjustTransactionGrid, function () {
            ClientBudgetAdjustTransactionGrid.PerformCallback('LoadTransaction|' + TransactionHdID);
        });
    },

    ClientBudgetAdjustGrid_BeginCallback: function (s, e) {
        this.BudgetCallback = e.command;
    },

    ClientBudgetAdjustTransactionHDGrid_BeginCallback: function (s, e) {
        this.TransactionHDCallback = e.command;
    },

    ClientBudgetAdjustGrid_Init: function (s, e) {
        s.SetHorizontalScrollPosition(0);
    },

    ClientBudgetAdjustGrid_EndCallback: function (s, e) {
        if (this.BudgetCallback == "CUSTOMCALLBACK") {
            this.BudgetCallback = "";
            if (s.cpCommand == "LoadBudgetAdjust") {
                
                RevCost.HideLoadingPanel();
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0)
                {
                    s.SetFocusedRowIndex(0);
                }
                else {
                    ClientRevCostHiddenField.Set("BudgetAdjustID", 0);
                    RevCost.ChangeState("List", "", 0);

                    RevCost.DoCallback(ClientBudgetAdjustRoeGrid, function () {
                        ClientBudgetAdjustRoeGrid.PerformCallback('LoadBudgetAdjustRoe|' + 0);
                    });

                    RevCost.DoCallback(ClientBudgetAdjustTransactionHDGrid, function () {
                        ClientBudgetAdjustTransactionHDGrid.PerformCallback('LoadTransctionHD|' + 0);
                    });
                }
            }
        }
    },

    ClientBudgetAdjustTransactionHDGrid_EndCallback: function (s, e) {
        if (this.TransactionHDCallback == "CUSTOMCALLBACK") {
            this.TransactionHDCallback = "";
            if (s.cpCommand == "LoadTransactionHD") {
                RevCost.HideLoadingPanel();
                s.SetFocusedRowIndex(-1);
                
                if (s.GetVisibleRowsOnPage() > 0) {
                    s.SetFocusedRowIndex(0);
                }
                else {
                    RevCost.DoCallback(ClientBudgetAdjustTransactionGrid, function () {
                        ClientBudgetAdjustTransactionGrid.PerformCallback('LoadTransaction|' + 0);
                    });
                }
            }
        }
    },

    
    ClientBudgetAdjustOri_Shown: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var versionID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientVersionCompanyGrid, function () {
            ClientVersionCompanyGrid.PerformCallback('LoadVerCompany|' + versionID);
        });
    },

    ClientBudgetAdjustDes_Shown: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var versionID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
        
        RevCost.DoCallback(ClientVersionCompanyDesGrid, function () {
            ClientVersionCompanyDesGrid.PerformCallback('LoadVerCompany|' + versionID);
        });
    },

    ClientBudgetAdjustFilesPopup_Shown: function (s, e) {
        if (!ClientBudgetAdjustGrid.IsDataRow(ClientBudgetAdjustGrid.GetFocusedRowIndex()))
            return;
        var BudgetAdjustID = ClientBudgetAdjustGrid.GetRowKey(ClientBudgetAdjustGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientBudgetAdjustFilesGrid, function () {
            ClientBudgetAdjustFilesGrid.PerformCallback('LoadBudgetAdjustFile|' + BudgetAdjustID);
        });
    },

    ClientUploadBudgetAdjustFile_Click: function () {
        if (ClientBudgetAdjustFilesUC.GetText() == "")
            return;
        ClientBudgetAdjustFilesUC.Upload();
    },

    ClientBudgetAdjustFilesUC_FilesUploadComplete: function (s, e) {
        if (e.callbackData == "error") {
            RevCost.ShowMessage(e.errorText);
        }
        else {
            var State = RevCost.State;
            var budgetID = State.Key;
            RevCost.DoCallback(ClientBudgetAdjustFilesGrid, function () {
                ClientBudgetAdjustFilesGrid.PerformCallback('SaveBudgetAdjustFile|' + budgetID + "|" + e.callbackData);
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

    ClientBudgetAdjustFilesGrid_CustomButtonClick: function (s, e) {
        var budgetAdjustFileID = s.GetRowKey(s.GetFocusedRowIndex());
        if (e.buttonID == "DownloadBudgetAdjustFile") {
            window.location = "../../Handler/DownloadFile.ashx?FileType=BudgetAdjustFile&BudgetAdjustID=" + budgetAdjustFileID;
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

    ClientChangeCompanyButton_Click: function (s, e) {
        alert(ClientRevCostHiddenField.Get("CompanyType"));
        if (ClientRevCostHiddenField.Get("CompanyType") == "D") {
            alert("You do not have permission to perform this action.");
            return;
        }
        ClientCompanyListPopup.Show();
    },

    ClientbtnSelectSubAccount_Click: function (s, e) {
        ClientBudgetAdjustOri.Show();
    },

    ClientbtnSelectCompany_Click: function (s, e) {
        ClientBudgetAdjustDes.Show();
    },

    ClientApplyBudgetOriButton_Click: function (s, e) {
        if (!ClientBudgetAdjustGrid.IsDataRow(ClientBudgetAdjustGrid.GetFocusedRowIndex()))
            return;
        var adjustID = ClientBudgetAdjustGrid.GetRowKey(ClientBudgetAdjustGrid.GetFocusedRowIndex());

        if (!ClientVersionCompanyGrid.IsDataRow(ClientVersionCompanyGrid.GetFocusedRowIndex()))
            return;
        var verCompanyID = ClientVersionCompanyGrid.GetRowKey(ClientVersionCompanyGrid.GetFocusedRowIndex());

        if (!ClientBudgetGrid.IsDataRow(ClientBudgetGrid.GetFocusedRowIndex()))
            return;
        var budgetID = ClientBudgetGrid.GetRowKey(ClientBudgetGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientBudgetAdjustTransactionHDGrid, function () {
            ClientBudgetAdjustTransactionHDGrid.PerformCallback('NewTransactionHD|' + adjustID + '|' + verCompanyID + '|' + budgetID);
        });
    },

    ClientApplyBudgetDesButton_Click: function (s, e) {
        if (!ClientBudgetAdjustGrid.IsDataRow(ClientBudgetAdjustGrid.GetFocusedRowIndex()))
            return;
        var adjustID = ClientBudgetAdjustGrid.GetRowKey(ClientBudgetAdjustGrid.GetFocusedRowIndex());

        if (!ClientVersionCompanyDesGrid.IsDataRow(ClientVersionCompanyDesGrid.GetFocusedRowIndex()))
            return;
        var verCompanyID = ClientVersionCompanyDesGrid.GetRowKey(ClientVersionCompanyDesGrid.GetFocusedRowIndex());

        if (!ClientBudgetAdjustTransactionHDGrid.IsDataRow(ClientBudgetAdjustTransactionHDGrid.GetFocusedRowIndex()))
            return;
        var headerID = ClientBudgetAdjustTransactionHDGrid.GetRowKey(ClientBudgetAdjustTransactionHDGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientBudgetAdjustTransactionGrid, function () {
            ClientBudgetAdjustTransactionGrid.PerformCallback('NewTransaction|' + adjustID + '|' + verCompanyID + '|' + headerID);
        });
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
