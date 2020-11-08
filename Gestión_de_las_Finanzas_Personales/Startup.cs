using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gestión_de_las_Finanzas_Personales.Startup))]
namespace Gestión_de_las_Finanzas_Personales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
