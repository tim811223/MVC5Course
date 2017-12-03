using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        public ActionResult Index()
        {
            var data = repo.Get取得所有尚未刪除的商品資料Top10();

            ViewData.Model = data;

            ViewData["PageTitle"] = "商品清單";
            //ViewBag.PageTitle = "商品清單";

            return View();
        }
    }
}