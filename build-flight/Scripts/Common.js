var PendingCallbacks = {};
var loadingPanelTimer;
var State = { View: "List" };

function ChangeState(view, command, key) {
    var prev = State;
    var current = { View: view, Command: command, Key: key };

    State = current;
}

function DoCallback(sender, callback) {
    if (sender.InCallback()) {
        PendingCallbacks[sender.name] = callback;
        sender.EndCallback.RemoveHandler(DoEndCallback);
        sender.EndCallback.AddHandler(DoEndCallback);
    } else {
        callback();
    }
}

function DoEndCallback(s, e) {
    var pendingCallback = PendingCallbacks[s.name];
    if (pendingCallback) {
        pendingCallback();
        delete PendingCallbacks[s.name];
    }
}

function ShowLoadingPanel(element) {
    loadingPanelTimer = window.setTimeout(function () {
        ClientLoadingPanel.ShowInElement(element);
    }, 500);
}

function HideLoadingPanel() {
    if (loadingPanelTimer > -1) {
        window.clearTimeout(loadingPanelTimer);
        loadingPanelTimer = -1;
    }
    ClientLoadingPanel.Hide();
}

function PostponeAction(action, canExecute) {
    var f = function () {
        if (!canExecute())
            window.setTimeout(f, 50);
        else
            action();
    };
    f();
}