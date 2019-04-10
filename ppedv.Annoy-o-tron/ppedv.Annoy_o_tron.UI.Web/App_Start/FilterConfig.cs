using System.Web;
using System.Web.Mvc;

namespace ppedv.Annoy_o_tron.UI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
