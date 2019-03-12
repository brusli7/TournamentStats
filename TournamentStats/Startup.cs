using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TournamentStatas.Startup))]
namespace TournamentStatas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
