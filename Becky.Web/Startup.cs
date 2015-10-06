using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Becky.Web.Startup))]
namespace Becky.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
