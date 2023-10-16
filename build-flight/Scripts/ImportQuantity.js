ImportQtyPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
        this.FileHistoryCallback = "";
        this.FileName = "";
    },

    ClientContentSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "FileHistory") {
            ClientFileHistoryGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "DataHistory") {
            ClientDataHistoryGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    FileUploadStart: function (s, e) {
        uploadCompleteFlag = false;
        window.setTimeout("RevCost.ShowPopupProgressingPanel()", 500);
    },

    ShowPopupProgressingPanel: function () {
        if (!uploadCompleteFlag) {
            PopupProgressingPanel.Show();
            pbProgressing.SetPosition(0);
            pnlProgressingInfo.SetContentHtml("");
        }
    },

    UploadingProgressChanged: function (s, e) {
        pbProgressing.SetPosition(e.progress);
        var info = e.currentFileName + "&emsp;[" + RevCost.GetKBytes(e.uploadedContentLength) + " / " + RevCost.GetKBytes(e.totalContentLength) + "] KBytes";
        pnlProgressingInfo.SetContentHtml(info);
    },

    GetKBytes: function (bytes) {
        return Math.floor(bytes / 1024);
    },

    FilesUploadComplete: function (s, e) {
        uploadCompleteFlag = true;
        PopupProgressingPanel.Hide();
        if (e.callbackData == "error") {
            RevCost.ShowMessage(e.errorText);
        }
        else {
            this.FileName = e.callbackData;
            RevCost.DoCallback(ClientSheetListBox, function () {
                ClientSheetListBox.PerformCallback("GetAllSheets|" + e.callbackData);
            });
        }
    },

    ClientUploadDataButton_Click: function (s, e) {
        var fileType = ClientFileType.GetValue();
        var sheetName = ClientSheetListBox.GetValue();
        RevCost.DoCallback(ClientFileHistoryGrid, function () {
            ClientFileHistoryGrid.PerformCallback("ProcessFile|" + this.FileName + "|" + fileType + "|" + sheetName);
        });
    },

    ClientSheetListBox_EndCallback: function (s, e) {
        ClientPopupSelectExcelSheet.Show();
    },

    ClientPopupSelectExcelSheet_Shown: function (s, e) {

    },

    ShowMessage: function (message) {
        window.setTimeout("alert('" + message + "')", 0);
    },

    ClientFilesUploadButton_Click: function (s, e) {
        if (ClientUploadControl.GetText() == "")
            return;
        ClientUploadControl.Upload();
    },

    ClientButtonRefresh_Click: function (s, e) {
        var fileType = ClientFileType.GetValue();
        RevCost.DoCallback(ClientFileHistoryGrid, function () {
            ClientFileHistoryGrid.PerformCallback("LoadHistory|" + fileType);
        });
    },

    ClientFileType_ValueChanged: function (s, e) {
        var fileType = ClientFileType.GetValue();

        RevCost.DoCallback(ClientFileHistoryGrid, function () {
            ClientFileHistoryGrid.PerformCallback("LoadHistory|" + fileType);
        });

        RevCost.DoCallback(ClientDataHistoryGrid, function () {
            ClientDataHistoryGrid.PerformCallback("GenerateCols|" + fileType);
        });

        if (fileType === 'ImpCost') {
            ClientCompany.SetVisible(true);
        }
        else {
            ClientCompany.SetVisible(false);
        }
    },

    ClientFileHistoryGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());
        RevCost.DoCallback(ClientDataHistoryGrid, function () {
            ClientDataHistoryGrid.PerformCallback("LoadDataHistory|" + key);
        });
    },

    ClientFileHistoryGrid_BeginCallback: function (s, e) {
        this.FileHistoryCallback = e.command;
    },

    ClientDataHistoryGrid_CallbackError: function (s, e) {
        alert(e.message);
        e.handled = true;

    },

    ClientFileHistoryGrid_EndCallback: function (s, e) {
        if (this.FileHistoryCallback == "CUSTOMCALLBACK") {
            this.FileHistoryCallback = "";
            if (s.cpCommand == "LoadHistory" || s.cpCommand == "ProcessFile") {
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0)
                    s.SetFocusedRowIndex(0);
            }
            if (s.cpCommand == "Apply") {
                var fileType = ClientFileType.GetValue();

                RevCost.DoCallback(ClientFileHistoryGrid, function () {
                    ClientFileHistoryGrid.PerformCallback("LoadHistory|" + fileType);
                });
            }
            if (s.cpCommand == "ProcessFile") {
                ClientPopupSelectExcelSheet.Hide();
            }
        }
    },

    ClientApplyToVersion_Click: function (s, e) {
        if (!ClientFileHistoryGrid.IsDataRow(ClientFileHistoryGrid.GetFocusedRowIndex()))
            return;

        var fileType = ClientFileType.GetValue();

        if (fileType === 'ImpCost') {
            var companyKey = ClientCompany.GetValue();

            if (companyKey = null || companyKey == undefined) {
                alert("Bạn phải chọn đơn vị trước khi thực hiện chức năng này.");
                return;
            }
        }
        var fileType = ClientFileType.GetValue();
        RevCost.DoCallback(ClientCallback, function () {
            ClientCallback.PerformCallback('HasUseVersion|' + fileType);
        });
        /*  ClientApplyVersionPopup.Show();*/
    },

    ClientDownloadTemplateButton_Click: function (s, e) {
        var value = ClientFileType.GetValue();
        var url = "/Handler/CreateTemplate.ashx?etCode=" + value;
        url = window.location.protocol + "//" + window.location.host + url;
        document.location = url;
    },
    ClientVersionGrid_EndCallback: function (s, e) {

    },

    ClientApplyToVersionButton_Click: function (s, e) {
        if (!ClientFileHistoryGrid.IsDataRow(ClientFileHistoryGrid.GetFocusedRowIndex()))
            return;
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var cf = confirm("Confirm data?");
        if (cf) {
            var historyKey = ClientFileHistoryGrid.GetRowKey(ClientFileHistoryGrid.GetFocusedRowIndex());
            var versionKey = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

            var companyKey = ClientCompany.GetValue();
            //console.log("CompanyKey:" + companyKey);
            var args = "Apply|" + historyKey + "|" + versionKey;
            if (companyKey != null && companyKey !== undefined) {
                args += "|" + companyKey;
            }
            else {
                args += "|0";
            }
            RevCost.DoCallback(ClientFileHistoryGrid, function () {
                ClientFileHistoryGrid.PerformCallback(args);
            });

            ClientApplyVersionPopup.Hide();
        }
    },
    ClientApplyVersionPopup_Shown: function (s, e) {
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('LoadAllVersion');
        });
    },
    ClientApplyVersionPopup_CloseUp: function (s, e) {

    },

    ClientCallback_BeginCallback: function (s, e) {
        console.log(e);
    },
    ClientCallback_CallbackComplete: function (s, e) {
        if (e.result != "FALSE") {
            ClientApplyVersionPopup.Show();
        }
        else {
            var cf = confirm("Confirm apply data?");
            if (cf) {
                var historyKey = ClientFileHistoryGrid.GetRowKey(ClientFileHistoryGrid.GetFocusedRowIndex());
                var args = "Apply|" + historyKey + "|0|0";
                RevCost.DoCallback(ClientFileHistoryGrid, function () {
                    ClientFileHistoryGrid.PerformCallback(args);
                });
            }
        }
    },
    ClientCallback_EndCallback: function (s, e) {

    },

    ClientImportError_Click: function (s, e) {
        ClientImportErrorPopup.Show();
    },

    ClientImportErrorPopup_Shown: function (s, e) {
        if (!ClientFileHistoryGrid.IsDataRow(ClientFileHistoryGrid.GetFocusedRowIndex()))
            return;

        var historyKey = ClientFileHistoryGrid.GetRowKey(ClientFileHistoryGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientImportErrorGrid, function () {
            ClientImportErrorGrid.PerformCallback('LoadErrors|'  +historyKey);
        });
    },

    ClientImportErrorPopup_CloseUp: function (s, e) {

    },
});

(function () {
    var pageModule = new ImportQtyPageModule();
    window.RevCost = pageModule;
})();