using Microsoft.Owin;
using OnlineShop.Web;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace OnlineShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
