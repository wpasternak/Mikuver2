using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiKuVer2.Frontend.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Willkommen zu MiKuVer2";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
