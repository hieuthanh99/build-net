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

    ClientFileType_ValueChanged: function (s, e) {
        var fileType = ClientFileType.GetValue();
        RevCost.DoCallback(ClientFileHistoryGrid, function () {
            ClientFileHistoryGrid.PerformCallback("LoadHistory|" + fileType);
        });
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

    ClientFileHistoryGrid_EndCallback: function (s, e) {
        if (this.FileHistoryCallback == "CUSTOMCALLBACK") {
            this.FileHistoryCallback = "";
            if (s.cpCommand == "LoadHistory" || s.cpCommand == "ProcessFile") {
                s.SetFocusedRowIndex(-1);
                if (s.GetVisibleRowsOnPage() > 0)
                    s.SetFocusedRowIndex(0);
            }

            if (s.cpCommand == "ProcessFile") {
                ClientPopupSelectExcelSheet.Hide();
            }
        }
    },


    ClientApply_Click: function (s, e) {
        if (!ClientFileHistoryGrid.IsDataRow(ClientFileHistoryGrid.GetFocusedRowIndex()))
            return;
        var cf = confirm("Confirm data?");
        if (cf) {
            var key = ClientFileHistoryGrid.GetRowKey(ClientFileHistoryGrid.GetFocusedRowIndex());
            RevCost.DoCallback(ClientFileHistoryGrid, function () {
                ClientFileHistoryGrid.PerformCallback("Apply|" + key);
            });
        }
    },

    ClientDownloadTemplateButton_Click: function (s, e) {
        var value = ClientFileType.GetValue();
        var area = ClientAreaCode.GetValue();
        var url = "/Handler/CreateRevCostTemplate.ashx?etCode=" + value + "&area=" + area;
        url = window.location.protocol + "//" + window.location.host + url;
        document.location = url;
    },

    ClientApplyVersionPopup_Shown: function (s, e) {
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('LoadVersion');
        });
    },

    ClientApplyVersionPopup_CloseUp: function (s, e) {

    },

    ClientApplyToVersionButton_Click: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex())) {
            alert("Select a Version.");
            return;
        }

        var versionID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

        if (!ClientFileHistoryGrid.IsDataRow(ClientFileHistoryGrid.GetFocusedRowIndex()))
            return;
        var hisId = ClientFileHistoryGrid.GetRowKey(ClientFileHistoryGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientFileHistoryGrid, function () {
            ClientFileHistoryGrid.PerformCallback('ApplyToVersion|' + versionID + '|' + hisId);
        });
    },

    ClientShowVersionButton_Click: function (s, e) {
        if (!ClientFileHistoryGrid.IsDataRow(ClientFileHistoryGrid.GetFocusedRowIndex()))
            return;

        ClientApplyVersionPopup.Show();
    }

});

(function () {
    var pageModule = new ImportQtyPageModule();
    window.RevCost = pageModule;
})();