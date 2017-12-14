using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GitHubUsersWeb.Startup))]
namespace GitHubUsersWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
