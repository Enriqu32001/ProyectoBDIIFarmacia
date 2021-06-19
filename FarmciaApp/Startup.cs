using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarmciaApp.Startup))]
namespace FarmciaApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
