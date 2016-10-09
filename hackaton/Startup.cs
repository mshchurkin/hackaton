using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hackaton.Startup))]
namespace hackaton
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
