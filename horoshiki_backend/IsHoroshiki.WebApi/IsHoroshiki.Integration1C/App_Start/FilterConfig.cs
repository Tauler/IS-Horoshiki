using System.Web;
using System.Web.Mvc;

namespace IsHoroshiki.Integration1C
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
