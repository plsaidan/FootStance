using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FootStance.WebMVC.Startup))]
namespace FootStance.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
