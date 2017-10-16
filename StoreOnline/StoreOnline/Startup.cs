using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreOnline.Startup))]
namespace StoreOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
