using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRMVC.Startup))]

namespace SignalRMVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}