using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FunClub.Startup))]
namespace FunClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
