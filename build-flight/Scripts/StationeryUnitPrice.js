StationeryUnitPricePageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.currentColumnName = "";
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "GridNormYearPane") {
            ClientNormYearGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "MasterPane") {
            ClientMasterGrid.SetHeight(e.pane.GetClientHeight());
        }

        if (e.pane.name == "DetailPane") {
            ClientDetailGrid.SetHeight(e.pane.GetClientHeight());
        }
    },

    ClientNormYearGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("NormYearID", key);

        RevCost.DoCallback(ClientMasterGrid, function () {
            ClientMasterGrid.PerformCallback('LOAD_MASTER|' + key);
        });
    },

    ClientMasterGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientHiddenField.Set("UnitPriceID", key);

        RevCost.DoCallback(ClientDetailGrid, function () {
            ClientDetailGrid.PerformCallback('LOAD_DETAIL|' + key);
        });
    },

    ClientMasterGrid_EndCallback: function (s, e) {
        if (s.GetVisibleRowsOnPage() > 0 && s.GetFocusedRowIndex() < 0) {
            s.SetFocusedRowIndex(0);
        }
    },

    ClientDetailGrid_EndCallback: function (s, e) {
        if (s.GetVisibleRowsOnPage() > 0 && s.GetFocusedRowIndex() < 0) {
            s.SetFocusedRowIndex(0);
        }
    },

    ClientMasterGrid_AddNewButtonClick: function (s, e) {
        ClientMasterGrid.AddNewRow();
    },

    ClientDetailGrid_AddNewButtonClick: function (s, e) {
        if (!ClientMasterGrid.IsDataRow(ClientMasterGrid.GetFocusedRowIndex()))
            return;
        var key = ClientMasterGrid.GetRowKey(ClientMasterGrid.GetFocusedRowIndex());

        ClientLOVStationeryGrid.Refresh();
        ClientStationeryPopup.Show();
    },

    ClientMasterGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "MasterGridDelete") {
            var cf = confirm("Dữ liệu chi tiết đơn giá VPP sẽ bị xóa. Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientMasterGrid, function () {
                    ClientMasterGrid.PerformCallback("DELETE_MASTER_ROW|" + key);
                });
            }
        }
    },

    ClientDetailGrid_CustomButtonClick: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        if (e.buttonID == "DetailGridDelete") {
            var cf = confirm("Bạn thực sự muốn xóa bản ghi này không?");
            if (cf) {
                RevCost.DoCallback(ClientDetailGrid, function () {
                    ClientDetailGrid.PerformCallback("DELETE_DETAIL_ROW|" + key);
                });
            }
        }
    },

    ClientSaveDataGridButton_Click: function (s, e) {
        if (ClientMasterGrid.batchEditApi.HasChanges()) {
            ClientMasterGrid.UpdateEdit();
        }

        if (ClientDetailGrid.batchEditApi.HasChanges()) {
            ClientDetailGrid.UpdateEdit();
        }
    },

    ClientCancelDataGridButton_Click: function (s, e) {
        if (ClientMasterGrid.batchEditApi.HasChanges()) {
            ClientMasterGrid.CancelEdit();
        }

        if (ClientDetailGrid.batchEditApi.HasChanges()) {
            ClientDetailGrid.CancelEdit();
        }
    },


    ClientAddStationeryButton_Click: function (s, e) {
        if (!ClientMasterGrid.IsDataRow(ClientMasterGrid.GetFocusedRowIndex()))
            return;
        var aUnitPriceID = ClientMasterGrid.GetRowKey(ClientMasterGrid.GetFocusedRowIndex());

        var keys = [];
        keys = ClientLOVStationeryGrid.GetSelectedKeysOnPage();
        if (keys.length == 0) {
            alert("Bạn phải chọn ít nhất một văn phòng phẩm.");
            return;
        }
        if (keys.length > 0) {
            RevCost.DoCallback(ClientDetailGrid, function () {
                ClientDetailGrid.PerformCallback("ADD_STATIONERY|" + aUnitPriceID + "|" + keys.join("|"));
            });
        }

        ClientLOVStationeryGrid.Refresh();
        ClientStationeryPopup.Hide();
    },

    IsNull: function (value, replace) {
        if (value == null || value == "undefined")
            return replace;

        return value;
    },

    numberWithCommas: function (x) {
        var parts = x.toString().split(".");
        parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        return parts.join(".");
    },

    ClientDetailGrid_EndCallback: function (s, e) {
        ClientSplitter.AdjustControl();
    },

    ClientDetailGrid_OnChangesCanceling: function (s, e) {
        if (s.batchEditApi.HasChanges())
            setTimeout(function () {
                s.Refresh();
            }, 0);
    },


    ClientDetailGrid_OnBatchEditRowDeleting: function (s, e) {

    },

    ClientDetailGrid_OnBatchEditStartEditing: function (s, e) {
        this.currentColumnName = e.focusedColumn.fieldName;
    },

    ClientDetailGrid_OnBeginCallback: function (s, e) {

    },

    CalculateSummary: function (grid, labelSum, rowValues, visibleIndex, columnName, isDeleting) {
        var originalValue = grid.batchEditApi.GetCellValue(visibleIndex, columnName);
        var newValue = rowValues[(grid.GetColumnByField(columnName).index)].value;
        var dif = isDeleting ? -newValue : newValue - originalValue;
        labelSum.SetValue(RevCost.numberWithCommas((parseInt(labelSum.GetValue().split(",").join('')) + dif)));
    },

    ClientDetailGrid_OnBatchEditEndEditing: function (s, e) {
        if (this.currentColumnName != "Quantity" && this.currentColumnName != "UnitPrice")
            return;

        if (this.currentColumnName == "Quantity") {
            var label = ASPxClientControl.GetControlCollection().GetByName('label' + this.currentColumnName);
            RevCost.CalculateSummary(s, label, e.rowValues, e.visibleIndex, this.currentColumnName, false);
        }

        window.setTimeout(function () {
            var rowAmount = 0;
            var rowQuantity = 0;
            var rowUnitPrice = 0;
            for (var key in e.rowValues) {
                if (s.GetColumn(key).fieldName == "Quantity")
                    rowQuantity = e.rowValues[key].value;

                if (s.GetColumn(key).fieldName == "UnitPrice")
                    rowUnitPrice = e.rowValues[key].value;
            }

            var originalValue = s.batchEditApi.GetCellValue(e.visibleIndex, "Amount");
            rowAmount = RevCost.IsNull(rowQuantity, 0) * RevCost.IsNull(rowUnitPrice, 0);

            s.batchEditApi.SetCellValue(e.visibleIndex, "Amount", rowAmount, null, true);

            var dif = rowAmount - originalValue;
            var totalValue = parseFloat(labelAmount.GetValue().split(",").join(''));
            labelAmount.SetValue(RevCost.numberWithCommas(totalValue + dif));
        }, 0);
    },

});

(function () {
    var pageModule = new StationeryUnitPricePageModule();
    window.RevCost = pageModule;
})();