using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRBroadcastSample.Startup))]
namespace SignalRBroadcastSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

            //ConfigureAuth(app);
        }
    }
}
