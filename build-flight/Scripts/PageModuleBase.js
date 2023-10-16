function CreateClass(parentClass, properties) {
    var result = function () {
        if (result.preparing)
            return delete (result.preparing);
        if (result.ctor)
            result.ctor.apply(this);
    };

    result.prototype = {};
    if (parentClass) {
        parentClass.preparing = true;
        result.prototype = new parentClass;
        result.base = parentClass;
    }
    if (properties) {
        var ctorName = "constructor";
        for (var name in properties)
            if (name != ctorName)
                result.prototype[name] = properties[name];
        var ctor = properties[ctorName];
        if (ctor)
            result.ctor = ctor;
    }
    return result;
}

PageModuleBase = CreateClass(null, {

    PendingCallbacks: {},

    DoCallback: function (sender, callback) {
        if (sender.InCallback()) {
            RevCost.PendingCallbacks[sender.name] = callback;
            sender.EndCallback.RemoveHandler(RevCost.DoEndCallback);
            sender.EndCallback.AddHandler(RevCost.DoEndCallback);
        } else {
            callback();
        }
    },

    DoEndCallback: function (s, e) {
        var pendingCallback = RevCost.PendingCallbacks[s.name];
        if (pendingCallback) {
            pendingCallback();
            delete RevCost.PendingCallbacks[s.name];
        }
    },

    ChangeState: function (view, command, key) {
        var prev = this.State;
        var current = { View: view, Command: command, Key: key };

        this.State = current;
        this.OnStateChanged();
    },

    OnStateChanged: function () { },

    ChangeVersionState: function (view, command, key) {
        var prev = this.VersionState;
        var current = { View: view, Command: command, Key: key };

        this.VersionState = current;
        this.OnVersionStateChanged();
    },

    OnVersionStateChanged: function () { },

    ChangeVerCompanyState: function (view, command, key) {
        var prev = this.VerCompanyState;
        var current = { View: view, Command: command, Key: key };

        this.VerCompanyState = current;
        this.OnVersionStateChanged();
    },

    OnVerCompanyStateChanged: function () { },

    ChangeStoreState: function (view, command, key) {
        var prev = this.StoreState;
        var current = { View: view, Command: command, Key: key };

        this.StoreState = current;
        this.OnStoreStateChanged();
    },

    OnStoreStateChanged: function () { },

    ShowLoadingPanel: function (element) {
        this.loadingPanelTimer = window.setTimeout(function () {
            ClientLoadingPanel.ShowInElement(element);
        }, 500);
    },

    HideLoadingPanel: function () {
        if (this.loadingPanelTimer > -1) {
            window.clearTimeout(this.loadingPanelTimer);
            this.loadingPanelTimer = -1;
        }
        ClientLoadingPanel.Hide();
    },

    PostponeAction: function (action, canExecute) {
        var f = function () {
            if (!canExecute())
                window.setTimeout(f, 50);
            else
                action();
        };
        f();
    }
});