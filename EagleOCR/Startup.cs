using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EagleOCR.Startup))]
namespace EagleOCR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
