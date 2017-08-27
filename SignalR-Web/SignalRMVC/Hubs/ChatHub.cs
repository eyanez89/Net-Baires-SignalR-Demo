using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRMVC.Hubs
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        public void SendMessage(string sender, string msg, string from)
        {
            Clients.All.receiveMessage(sender, msg, from);
        }
    }
}