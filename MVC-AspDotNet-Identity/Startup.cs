using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_AspDotNet_Identity.Startup))]
namespace MVC_AspDotNet_Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
