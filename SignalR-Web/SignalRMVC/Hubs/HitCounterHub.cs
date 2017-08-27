using Microsoft.AspNet.SignalR;

namespace SignalRMVC.Hubs
{
    public class HitCounterHub : Hub
    {
        static int _count;

        public void RecordHit()
        {
            _count += 1;

            Clients.All.receiveHit(_count);
        }
        
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalling)
        {
            _count -= 1;

            Clients.All.receiveHit(_count);

            return base.OnDisconnected(stopCalling);
        }
    }
}