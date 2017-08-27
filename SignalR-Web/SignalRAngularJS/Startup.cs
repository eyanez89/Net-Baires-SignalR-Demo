using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRAngularJS.Startup))]
namespace SignalRAngularJS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}