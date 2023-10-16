using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Summary description for UserFriendlyException
/// </summary>
public class UserFriendlyMessage
{
    public enum MessageType
    {
        ERROR,
        WARN,
        INFO,
        SUCCESS
    }

    public UserFriendlyMessage(string message, string userName, MessageType messageType)
    {
        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        var connectionIds = NotificationHub._users.Where(c => c.Value == userName);

        foreach (KeyValuePair<string, string> connections in connectionIds)
        {
            switch (messageType)
            {
                case MessageType.ERROR:
                    hubContext.Clients.Client(connections.Key).notify(userName, "ERROR|" + message);
                    break;
                case MessageType.WARN:
                    hubContext.Clients.Client(connections.Key).notify(userName, "WARN|" + message);
                    break;
                case MessageType.INFO:
                    hubContext.Clients.Client(connections.Key).notify(userName, "INFO|" + message);
                    break;
                case MessageType.SUCCESS:
                    hubContext.Clients.Client(connections.Key).notify(userName, "SUCCESS|" + message);
                    break;
            }

        }
    }

}