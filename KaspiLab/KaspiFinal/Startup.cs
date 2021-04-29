using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KaspiFinal.Startup))]
namespace KaspiFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
