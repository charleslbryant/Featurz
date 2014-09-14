using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Featurz.Demo.Startup))]
namespace Featurz.Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
