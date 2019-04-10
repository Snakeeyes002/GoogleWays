using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GW.WUI.Startup))]
namespace GW.WUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
