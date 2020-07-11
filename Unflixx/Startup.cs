using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Unflixx.Startup))]
namespace Unflixx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
