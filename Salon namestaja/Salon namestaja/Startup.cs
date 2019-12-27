using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Salon_namestaja.Startup))]
namespace Salon_namestaja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
