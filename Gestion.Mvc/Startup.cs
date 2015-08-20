using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gestion.Mvc.Startup))]
namespace Gestion.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
