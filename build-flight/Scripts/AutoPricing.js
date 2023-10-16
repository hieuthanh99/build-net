AutoAmountPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "AutoPricing") {
            ClientAutoPricingGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "AutoPricingDetail") {
            ClientAutoPricingDetailGrid.SetHeight(e.pane.GetClientHeight());
        }

    },

    ClientVersionEditor_ValueChanged: function (s, e) {
        RevCost.DoCallback(ClientAutoPricingDetailGrid, function () {
            ClientAutoPricingDetailGrid.PerformCallback('LoadAutoPricingDetail|' + 0);
        });

        RevCost.DoCallback(ClientAutoPricingGrid, function () {
            ClientAutoPricingGrid.PerformCallback('LoadData');
        });
    },

    ClientAutoPricingGrid_EndCallback: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientAutoPricingHiddenField.Set("AutoPricingID", key);

        RevCost.DoCallback(ClientAutoPricingDetailGrid, function () {
            ClientAutoPricingDetailGrid.PerformCallback('LoadAutoPricingDetail|' + key);
        });
    },

    ClientAutoPricingGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientAutoPricingHiddenField.Set("AutoPricingID", key);

        RevCost.DoCallback(ClientAutoPricingDetailGrid, function () {
            ClientAutoPricingDetailGrid.PerformCallback('LoadAutoPricingDetail|' + key);
        });
    },


    ClientRefreshButtonClick: function (s, e) {
        RevCost.DoCallback(ClientAutoPricingGrid, function () {
            ClientAutoPricingGrid.PerformCallback('LoadData');
        });
    },

    ClientAutoPricingGrid_AddNewButtonClick: function (s, e) {
        ClientAutoPricingGrid.AddNewRow();
    },

    ClientAutoPricingGrid_CustomButtonClick: function (s, e) {
        if (e.buttonID == "btnDelete") {
            var cf = confirm("Bạn chắc chắn muốn xóa bản ghi này?");
            if (cf) {
                if (!s.IsDataRow(s.GetFocusedRowIndex()))
                    return;
                var key = s.GetRowKey(s.GetFocusedRowIndex());

                DoCallback(ClientAutoPricingGrid, function () {
                    ClientAutoPricingGrid.PerformCallback('DELETE|' + key);
                });
            }
        }
    },

    RefreshButton_Click: function (s, e) {
        var cf = confirm("Data will be changed. Confirm?");
        if (cf) {
            if (!ClientAutoPricingGrid.IsDataRow(ClientAutoPricingGrid.GetFocusedRowIndex()))
                return;
            var key = ClientAutoPricingGrid.GetRowKey(ClientAutoPricingGrid.GetFocusedRowIndex());

            RevCost.DoCallback(ClientAutoPricingDetailGrid, function () {
                ClientAutoPricingDetailGrid.PerformCallback('RefreshDetail|' + key);
            });
        }
    },
    ClientCopyButton_Click: function (s, e) {
        RevCost.DoCallback(ClientCopyVersionEditor, function () {
            ClientCopyVersionEditor.PerformCallback();
        });
        ClientEditPopup.Show();
    },

    ClientAplyCopyButton_Click: function (s, e) {
        RevCost.DoCallback(ClientAutoPricingGrid, function () {
            ClientAutoPricingGrid.PerformCallback('CopyData');
        });

        ClientEditPopup.Hide();
    },

    ClientCalUnitButton_Click: function (s, e) {
        //if (!ClientAutoPricingGrid.IsDataRow(ClientAutoPricingGrid.GetFocusedRowIndex()))
        //    return;
        //var key = ClientAutoPricingGrid.GetRowKey(ClientAutoPricingGrid.GetFocusedRowIndex());

        //RevCost.DoCallback(ClientAutoPricingGrid, function () {
        //    ClientAutoPricingGrid.PerformCallback('CalUnit|' + key);
        //});

        var keys = [];
        keys = ClientAutoPricingGrid.GetSelectedKeysOnPage();

        if (keys.length > 0) {
            var cf = confirm("Run auto pricing?");
            if (cf) {
                var args = "CalUnit|" + keys.join("|")
                RevCost.DoCallback(ClientAutoPricingGrid, function () {
                    ClientAutoPricingGrid.PerformCallback(args);
                });
            }
        }
        else {
            alert("Please select a row.");
        }


    },

});

(function () {
    var pageModule = new AutoAmountPageModule();
    window.RevCost = pageModule;
})();