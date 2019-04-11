using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GW.WebUI.Startup))]
namespace GW.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
