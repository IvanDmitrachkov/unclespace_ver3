using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(unclespace_ver3.Startup))]
namespace unclespace_ver3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
