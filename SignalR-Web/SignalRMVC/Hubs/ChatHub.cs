using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRMVC.Hubs
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendMessage(string sender, string msg)
        {
            Clients.All.receiveMessage(sender, msg);
        }
    }
}