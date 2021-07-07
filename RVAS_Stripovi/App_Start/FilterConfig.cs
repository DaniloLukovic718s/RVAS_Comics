using System.Web;
using System.Web.Mvc;

namespace RVAS_Stripovi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Ne dozvoljava pristup bilo kojoj stranici ukoliko nema neki auth
            filters.Add(new AuthorizeAttribute()); 
        }
    }
}
