using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TDLC.UI.Startup))]
namespace TDLC.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
