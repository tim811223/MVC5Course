using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBBatchUpdateVM
    {
        public int ProductId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
    }
    public class MBController : BaseController
    {
        public ActionResult Index()
        {
            var data = repo.Get取得所有尚未刪除的商品資料Top10();
            ViewData.Model = data;
            ViewBag.PageTitle = "商品清單";
            return View();
        }

        [HttpPost]
        [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
        public ActionResult Index(MBBatchUpdateVM[] batch)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in batch)
                {
                    var one = repo.Find(item.ProductId);
                    
                    one.Price = item.Price;
                    one.Active = item.Active;
                    one.Stock = item.Stock;
                }
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            var data = repo.Get取得所有尚未刪除的商品資料Top10();
            ViewData.Model = data;
            ViewBag.PageTitle = "商品清單";
            return View();
        }
    }
}