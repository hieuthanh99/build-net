BoardingUnitPricesPageModule = CreateClass(PageModuleBase, {
    constructor: function () {

    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "ACConfigPane") {
            ClientACConfigGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "UnitPricePane") {
            ClientUnitPriceGrid.SetHeight(e.pane.GetClientHeight());
        }

    },

    ClientNormYearGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID", key);
        if (ClientHiddenField.Get("ACConfigID") == null || ClientHiddenField.Get("ACConfigID") == "undefined")
            return;

        RevCost.DoCallback(ClientUnitPriceGrid, function () {
            ClientUnitPriceGrid.PerformCallback('LOAD_UNIT_PRICE|' + key);
        });
    },

    ClientACConfigGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("ACConfigID", key);
        if (ClientHiddenField.Get("NormYearID") == null || ClientHiddenField.Get("NormYearID") == "undefined")
            return;

        RevCost.DoCallback(ClientUnitPriceGrid, function () {
            ClientUnitPriceGrid.PerformCallback("LOAD_UNIT_PRICE|" + key);
        });
    },

    ClientUnitPriceGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "UnitDelete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientUnitPriceGrid, function () {
                    ClientUnitPriceGrid.PerformCallback("DELETE_UNIT_PRICE|" + key);
                });
            }
        }
    },

    ClientSaveDataGridButton_Click: function (s, e) {
        if (ClientUnitPriceGrid.batchEditApi.HasChanges()) {
            ClientUnitPriceGrid.UpdateEdit();
        }
    },

    ClientCancelDataGridButton_Click: function (s, e) {
        if (ClientUnitPriceGrid.batchEditApi.HasChanges()) {
            ClientUnitPriceGrid.CancelEdit();
        }
    },

    ClientUnitPriceGrid_AddNewButtonClick: function (s, e) {
        if (!ClientACConfigGrid.IsDataRow(ClientACConfigGrid.GetFocusedRowIndex()))
            return;

        if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
            return;

        var aACConfigID = ClientACConfigGrid.GetRowKey(ClientACConfigGrid.GetFocusedRowIndex());
        var aNormYearID = ClientNormYearGrid.GetRowKey(ClientNormYearGrid.GetFocusedRowIndex());

        ClientHiddenField.Set("ACConfigID", aACConfigID);
        ClientHiddenField.Set("NormYearID", aNormYearID);

        ClientUnitPriceGrid.AddNewRow();
    },


});

(function () {
    var pageModule = new BoardingUnitPricesPageModule();
    window.RevCost = pageModule;
})();