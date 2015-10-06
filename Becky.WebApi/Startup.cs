using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Becky.WebApi.Startup))]

namespace Becky.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
