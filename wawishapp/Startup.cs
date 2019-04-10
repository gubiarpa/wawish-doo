using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wawishapp.Startup))]
namespace wawishapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
