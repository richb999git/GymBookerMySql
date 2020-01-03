using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GymBooker1.Startup))]
namespace GymBooker1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
