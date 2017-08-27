using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRAngularJS
{
    public class Chat : Hub
    {
        public void Send(string message)
        {
            Clients.All.addMessage(message);
        }
    }
}