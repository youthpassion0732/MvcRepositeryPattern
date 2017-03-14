using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Web.Startup))]
namespace MVC_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
