using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComputerReparationStore.Startup))]
namespace ComputerReparationStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
