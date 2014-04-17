using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassCloudWebRole.Startup))]
namespace ClassCloudWebRole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
