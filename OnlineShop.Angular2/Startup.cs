using Microsoft.Owin;
using OnlineShop.Angular2;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace OnlineShop.Angular2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
