using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReservarSalaoFestas.Startup))]
namespace ReservarSalaoFestas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
