using MVC5Course.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [LocalOnly]
    public class HomeController : Controller
    {
        [ShareData]
        public ActionResult Index()
        {
            return View();
        }

        [ShareData]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult VT()
        {
            return PartialView();
        }

        public ActionResult MetroIndex()
        {
            return View();
        }

        public ActionResult AjaxHome()
        {
            return View();
        }

        public ActionResult GetTime()
        {
            return Content(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"));
        }

        public ActionResult TestEncode()
        {
            return View();
        }
    }
}