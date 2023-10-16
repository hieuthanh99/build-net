BoardingUnitPricesPageModule = CreateClass(PageModuleBase, {
    constructor: function () {

    },

    ClientSplitter_PaneResized: function (s, e) {

        if (e.pane.name == "PageControlPane") {
            ClientPageControl.SetHeight(e.pane.GetClientHeight());
        }
        if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "ACConfigPane") {
            ClientACConfigGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "UnitPricePane") {
            ClientEDNormGrid.SetHeight(e.pane.GetClientHeight());
        }
        if (e.pane.name == "NormYearPane2") {
            ClientNormYearGrid2.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "EDNormPane2") {
            ClientEDNormGrid2.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientPageControl_ActiveTabChanged: function(s, e){
        ClientSplitter.AdjustControl();
        ClientSplitter2.AdjustControl();
    },

    ClientNormYearGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID", key);
        if (ClientHiddenField.Get("ACConfigID") == null || ClientHiddenField.Get("ACConfigID") == "undefined")
            return;

        RevCost.DoCallback(ClientLaborNormGrid, function () {
            ClientLaborNormGrid.PerformCallback('LOAD_UNIT_PRICE|' + key);
        });
    },

    ClientACConfigGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("ACConfigID", key);
        if (ClientHiddenField.Get("NormYearID") == null || ClientHiddenField.Get("NormYearID") == "undefined")
            return;

        RevCost.DoCallback(ClientEDNormGrid, function () {
            ClientEDNormGrid.PerformCallback("LOAD_UNIT_PRICE|" + key);
        });
    },

    ClientEDNormGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "EDNormGridDelete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientEDNormGrid, function () {
                    ClientEDNormGrid.PerformCallback("DELETE_ED_NORM|" + key);
                });
            }
        }
    },

    ClientSaveDataGridButton_Click: function (s, e) {
        if (ClientEDNormGrid.batchEditApi.HasChanges()) {
            ClientEDNormGrid.UpdateEdit();
        }
    },

    ClientCancelDataGridButton_Click: function (s, e) {
        if (ClientEDNormGrid.batchEditApi.HasChanges()) {
            ClientEDNormGrid.CancelEdit();
        }
    },

    ClientEDNormGrid_AddNewButtonClick: function (s, e) {
        if (!ClientACConfigGrid.IsDataRow(ClientACConfigGrid.GetFocusedRowIndex()))
            return;

        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;

        var aACConfigID = ClientACConfigGrid.GetRowKey(ClientACConfigGrid.GetFocusedRowIndex());
        var aNormYearID = ClientNormYearGrid.GetRowKey(ClientNormYearGrid.GetFocusedRowIndex());

        ClientHiddenField.Set("ACConfigID", aACConfigID);
        ClientHiddenField.Set("NormYearID", aNormYearID);

        ClientEDNormGrid.AddNewRow();
    },

    ClientEDNormGrid_EndCallback: function (s, e) {
        ClientSplitter.AdjustControl();
    },


    ClientEDNormGrid2_AddNewButtonClick: function (s, e) {
        if (!ClientNormYearGrid2.IsDataRow(ClientNormYearGrid2.GetFocusedRowIndex()))
            return;

        var aNormYearID = ClientNormYearGrid2.GetRowKey(ClientNormYearGrid2.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID2", aNormYearID);

        ClientEDNormGrid2.AddNewRow();
    },

    ClientEDNormGrid2_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "EDNormGrid2Delete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientEDNormGrid2, function () {
                    ClientEDNormGrid2.PerformCallback("DELETE_ED_NORM|" + key);
                });
            }
        }
    },

    ClientSaveDataGridButton2_Click: function (s, e) {
        if (ClientEDNormGrid2.batchEditApi.HasChanges()) {
            ClientEDNormGrid2.UpdateEdit();
        }
    },

    ClientCancelDataGridButton2_Click: function (s, e) {
        if (ClientEDNormGrid2.batchEditApi.HasChanges()) {
            ClientEDNormGrid2.CancelEdit();
        }
    },

});

(function () {
    var pageModule = new BoardingUnitPricesPageModule();
    window.RevCost = pageModule;
})();