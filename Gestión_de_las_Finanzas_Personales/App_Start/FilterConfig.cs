using System.Web;
using System.Web.Mvc;

namespace Gestión_de_las_Finanzas_Personales
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
