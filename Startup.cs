using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoParcial3.Startup))]
namespace ProyectoParcial3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
