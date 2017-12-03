using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViewTest()
        {
            return PartialView("Index");
        }

        public ActionResult ContentTest()
        {
            // 這樣寫會導致維護性降低，不太方便管理!
            return Content("<script>alert('OK');location.href='/';</script>");
        }

        public ActionResult ContentTest_Better()
        {
            return PartialView("JsAlertRedirect", "新增成功");
        }

    }
}