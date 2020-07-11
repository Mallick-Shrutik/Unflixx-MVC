using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Unflixx.Controllers
{
    [AllowAnonymous] //to bypass global authorization
    public class HomeController : Controller
    {
        //Output Caching is a performance optimizer for the Application level
        //only use this when performance test proves this is complex and causes slow loading
        //this is caching of the whole HTML output
        //[OutputCache(Duration = 50,Location = OutputCacheLocation.Server, VaryByParam ="*")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}