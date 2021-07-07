using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RVAS_Stripovi.Startup))]
namespace RVAS_Stripovi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
