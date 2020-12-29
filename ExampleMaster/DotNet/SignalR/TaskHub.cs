using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DotNet.SignalR
{
    [HubName("TaskHub")]
    public class TaskHub : Hub
    {
        public void Announce(string userID)
        {
            Groups.Add(Context.ConnectionId, userID);
        }

        public static void TaskUpdate(string msg)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TaskHub>();
            hubContext.Clients.All.taskUpdate(msg);
        }

        public static void TaskUpdateUserId(string msg, string userID)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TaskHub>();
            hubContext.Clients.Group(userID).taskUpdate(msg);
        }
    }
}