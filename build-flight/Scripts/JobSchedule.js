AutoAmountPageModule = CreateClass(PageModuleBase, {
    constructor: function () {
        this.State = { View: "List" };
    },

    ClientSplitter_PaneResized: function (s, e) {
        if (e.pane.name == "Versions") {
            ClientVersionGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "Jobs") {
            ClientJobGrid.SetHeight(e.pane.GetClientHeight());
        }
        else if (e.pane.name == "JobDetail") {
            ClientJobDetailGrid.SetHeight(e.pane.GetClientHeight());
        }

        
    },

    ClientVersionType_ValueChanged: function (s, e) {
        var versionType = s.GetValue();
        RevCost.DoCallback(ClientVersionGrid, function () {
            ClientVersionGrid.PerformCallback('Reload|' + versionType);
        });
    },

    ClientVersionGrid_FocusedRowChanged: function (s, e) {
        if (!s.IsDataRow(s.GetFocusedRowIndex()))
            return;
        var key = s.GetRowKey(s.GetFocusedRowIndex());

        ClientJobScheduleHiddenField.Set("VersionID", key);

        RevCost.DoCallback(ClientJobGrid, function () {
            ClientJobGrid.PerformCallback('LoadJobs|' + key);
        });

        //RevCost.DoCallback(ClientJobDetailGrid, function () {
        //    ClientJobDetailGrid.PerformCallback('LoadJobDetails|' + 0);
        //});
    },

    ClientJobGrid_EndCallback: function (s, e) {
        if (!ClientJobGrid.IsDataRow(ClientJobGrid.GetFocusedRowIndex()))
            return;
        var key = ClientJobGrid.GetRowKey(ClientJobGrid.GetFocusedRowIndex());
        ClientJobScheduleHiddenField.Set("JobID", key);
        RevCost.DoCallback(ClientJobDetailGrid, function () {
            ClientJobDetailGrid.PerformCallback('LoadJobDetails|' + key);
        });
    },

    ClientSaveButton_Click: function (s, e) {

        if (window.ClientJobTypeEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
            return;

        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var key = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());

        RevCost.DoCallback(ClientJobGrid, function () {
            ClientJobGrid.PerformCallback('CreateJob|' + key);
        });

        ClientEditPopup.Hide();

        toastr.options.positionClass = "toast-bottom-right";
        toastr.success("Tiến trình đã đưa vào queued để chạy.");
    },

    ClientRefreshButtonClick: function (s, e) {
        if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            return;
        var key = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
        RevCost.DoCallback(ClientJobGrid, function () {
            ClientJobGrid.PerformCallback('LoadJobs|' + key);
        });

        RevCost.ClientJobGrid_FocusedRowChanged(null, null);
    },

    ClientJobGrid_FocusedRowChanged: function (s, e) {
        if (!ClientJobGrid.IsDataRow(ClientJobGrid.GetFocusedRowIndex()))
            return;
        var key = ClientJobGrid.GetRowKey(ClientJobGrid.GetFocusedRowIndex());
        ClientJobScheduleHiddenField.Set("JobID", key);
        RevCost.DoCallback(ClientJobDetailGrid, function () {
            ClientJobDetailGrid.PerformCallback('LoadJobDetails|' + key);
        });
    },
    ClientExecuteTypeEditor_ValueChanged: function (s, e) {
        if (s.GetValue() == "Enqueue") {
            ClientExecuteAtEditor.SetEnabled(false);
        }
        else {
            ClientExecuteAtEditor.SetEnabled(true);
        }
    },
    ClientStopJobButtonClick: function (s, e) {
        if (!ClientJobGrid.IsDataRow(ClientJobGrid.GetFocusedRowIndex()))
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
                        var key = ClientJobGrid.GetRowKey(ClientJobGrid.GetFocusedRowIndex());
                        ClientJobScheduleHiddenField.Set("JobID", key);
                        RevCost.DoCallback(ClientJobGrid, function () {
                            ClientJobGrid.PerformCallback('StopJob|' + key);
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

});

(function () {
    var pageModule = new AutoAmountPageModule();
    window.RevCost = pageModule;
})();