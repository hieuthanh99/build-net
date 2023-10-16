(function () {
    if (!window.SendMail)
        window.SendMail = {};

    var PendingCallbacks = {};
    var loadingPanelTimer;
    var EmailAddressEditor = "ClientToEditor";

    SendMail.DoCallback = function (sender, callback) {
        if (sender.InCallback()) {
            PendingCallbacks[sender.name] = callback;
            sender.EndCallback.RemoveHandler(DoEndCallback);
            sender.EndCallback.AddHandler(DoEndCallback);
        } else {
            callback();
        }
    },

    SendMail.DoEndCallback = function (s, e) {
        var pendingCallback = PendingCallbacks[s.name];
        if (pendingCallback) {
            pendingCallback();
            delete PendingCallbacks[s.name];
        }
    },

    SendMail.ShowLoadingPanel = function (element) {
        loadingPanelTimer = window.setTimeout(function () {
            ClientLoadingPanel.ShowInElement(element);
        }, 500);
    },

    SendMail.HideLoadingPanel = function () {
        if (loadingPanelTimer > -1) {
            window.clearTimeout(loadingPanelTimer);
            loadingPanelTimer = -1;
        }
        ClientLoadingPanel.Hide();
    },

    SendMail.PostponeAction = function (action, canExecute) {
        var f = function () {
            if (!canExecute())
                window.setTimeout(f, 50);
            else
                action();
        };
        f();
    },

    SendMail.ClientActionMenu_ItemClick = function (s, e) {
        var command = e.item.name;
        switch (command) {
            case "Send":
                ClientActionMenu.GetItemByName("Send").SetEnabled(false);
                ClientActionMenu.GetItemByName("Close").SetEnabled(false);
                //SendMail.ShowLoadingPanel();
                //var args = "SendMail";
                //SendMail.DoCallback(ClientHelpDeskCallback, function () {
                //    ClientHelpDeskCallback.PerformCallback(args);
                //});
                //e.processOnServer = true;
                break;

            case "Close":
                window.close()
                //e.processOnServer = false;
                break;
        }
    },

    ClientHelpDeskCallback_CallbackComplete = function (s, e) {
        ClientActionMenu.GetItemByName("Send").SetEnabled(true);
        ClientActionMenu.GetItemByName("Close").SetEnabled(true);
        //SendMail.HideLoadingPanel();
    },

    SendMail.AddressBookButton_Click = function (s, e) {
        if (s.name == "AddressBookButtonTo")
            EmailAddressEditor = "ClientToEditor";
        else if (s.name == "AddressBookButtonCc")
            EmailAddressEditor = "ClientCcEditor";
        else if (s.name == "AddressBookButtonBcc")
            EmailAddressEditor = "ClientBccEditor";

        ClientAddressBookPopup.Show();
    },

     SendMail.ClientAddressBookPopupCancelButton_Click = function (s, e) {
         ClientAddressBookPopup.Hide();
     },

    SendMail.ClientAddressBookPopupOkButton_Click = function (s, e) {
        ClientAddressBookPopup.Hide();

        var emails;
        if (EmailAddressEditor == "ClientToEditor")
            emails = ClientToEditor.GetText().split(",");
        else if (EmailAddressEditor == "ClientCcEditor")
            emails = ClientCcEditor.GetText().split(",");
        else if (EmailAddressEditor == "ClientBccEditor")
            emails = ClientBccEditor.GetText().split(",");

        for (var i = 0; i < emails.length; i++)
            emails[i] = ASPxClientUtils.Trim(emails[i]);
        for (var i = emails.length - 1; i >= 0; i--) {
            var email = emails[i];
            var item = ClientAddressesList.FindItemByValue(email);
            if (email === "" || ClientAddressesList.FindItemByValue(email))
                emails.splice(i, 1);
        }

        emails = emails.concat(ClientAddressesList.GetSelectedValues());
        if (EmailAddressEditor == "ClientToEditor")
            ClientToEditor.SetText(emails.join(", "));
        else if (EmailAddressEditor == "ClientCcEditor")
            ClientCcEditor.SetText(emails.join(", "));
        else if (EmailAddressEditor == "ClientBccEditor")
            ClientBccEditor.SetText(emails.join(", "));

    },

    SendMail.ClientAddressBookPopup_PopUp = function (s, e) {
        var emails;
        if (EmailAddressEditor == "ClientToEditor")
            emails = ClientToEditor.GetText().split(",");
        else if (EmailAddressEditor == "ClientCcEditor")
            emails = ClientCcEditor.GetText().split(",");
        else if (EmailAddressEditor == "ClientBccEditor")
            emails = ClientBccEditor.GetText().split(",");

        for (var i = 0; i < emails.length; i++)
            emails[i] = ASPxClientUtils.Trim(emails[i]);
        ClientAddressesList.UnselectAll();
        ClientAddressesList.SelectValues(emails);
    }

})();