using System.Web;
using System.Web.Mvc;

namespace Unflixx
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());//this is a global authorization 
            filters.Add(new RequireHttpsAttribute()); //will not allow access from http and grant access to https requests only
        }
    }
}
