using System.Web;
using System.Web.Mvc;

namespace SpreadSheet_To_DataBase
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
