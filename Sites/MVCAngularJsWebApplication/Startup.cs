using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAngularJsWebApplication.Startup))]
namespace MVCAngularJsWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
