CreateTemplatePageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
    },

    ClientContentSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "TemplatePane") {
            ClientTemplateGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientTableName_ValueChanged: function (s, e) {
        var value = s.GetValue();
        RevCost.DoCallback(ClientTemplateGrid, function () {
            ClientTemplateGrid.PerformCallback('LoadData|' + value);
        });
    },

    ClientRecreate_Click: function (s, e) {
        var value = ClientTableName.GetValue();
        RevCost.DoCallback(ClientTemplateGrid, function () {
            ClientTemplateGrid.PerformCallback('ReCreate|' + value);
        });
    },

    ClientCreate_Click: function (s, e) {
        var value = ClientTableName.GetValue();
        RevCost.DoCallback(ClientTemplateGrid, function () {
            ClientTemplateGrid.PerformCallback('CreateTemplate|' + value);
        });
    },

    ClientTemplateGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "Delete") {
            var cf = confirm("Confirm delete?");
            if (!cf)
                return;
            RevCost.DoCallback(ClientTemplateGrid, function () {
                ClientTemplateGrid.PerformCallback('Delete|' + key);
            });
        }
        else if (e.buttonID == "Up") {
            RevCost.DoCallback(ClientTemplateGrid, function () {
                ClientTemplateGrid.PerformCallback('Up|' + key);
            });
        }
        else if (e.buttonID == "Down") {
            RevCost.DoCallback(ClientTemplateGrid, function () {
                ClientTemplateGrid.PerformCallback('Down|' + key);
            });
        }
    },

    ClientSaveTemplate_Click: function (s, e) {
        if (ClientTemplateGrid.batchEditApi.HasChanges()) {
            ClientTemplateGrid.UpdateEdit();
        }
    },

    ClientUpdateSeq_Click: function (s, e) {
        var value = ClientTableName.GetValue();
        RevCost.DoCallback(ClientTemplateGrid, function () {
            ClientTemplateGrid.PerformCallback('ReorderSeq|' + value);
        });
    },

    ClientCreateTemplateFile_Click: function (s, e) {
        var value = ClientTableName.GetValue();
        var url = "/Handler/CreateTemplate.ashx?etCode=" + value;
        url = window.location.protocol + "//" + window.location.host + url;
        document.location = url;
    },

    ClientNewTemplateTable_ButtonClick: function (s, e) {
        if (e.buttonIndex == 0) {
            ClientETCodeEditor.SetValue("");
            ClientNameEditor.SetValue("");
            ClientTableNameEditor.SetValue(null);
            ClientFileTypeEditor.SetValue(null);
            ClientUseVersionEditor.SetValue(true);
            //ClientTransferTypeEditor.SetEnabled(false);
            ClientTransferTypeEditor.SetValue("REPLACE");
            ClientEditPopup.Show();
        }
    },

    ClientUseVersionEditor_CheckedChanged: function (s, e) {
        //let valueChecked = s.GetValue();
        //if (valueChecked) {
        //    ClientTransferTypeEditor.SetEnabled(false);
        //    ClientTransferTypeEditor.SetValue("REPLACE");
        //}
        //else
        //    ClientTransferTypeEditor.SetEnabled(true);
    },

    ClientNewTemplateTable_EndCallback: function (s, e) {
        ClientEditPopup.Hide();
        s.SetValue(ClientETCodeEditor.GetValue());
    },

    ClientSaveButton_Click: function (s, e) {
        if (window.ClientETCodeEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
            return;
        DoCallback(ClientTableName, function () {
            ClientTableName.PerformCallback('SAVE');
        });
    }

});

(function () {
    var pageModule = new CreateTemplatePageModule();
    window.RevCost = pageModule;
})();