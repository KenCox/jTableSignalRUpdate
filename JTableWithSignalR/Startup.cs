using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JTableWithSignalR.Startup))]
namespace JTableWithSignalR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //here to map to signalR
            app.MapSignalR();
        }
    }
}
