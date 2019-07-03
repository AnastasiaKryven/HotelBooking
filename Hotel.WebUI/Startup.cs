using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotel.WebUI.Startup))]
namespace Hotel.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
