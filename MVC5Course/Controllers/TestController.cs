using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class TestController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        public ActionResult Index()
        {
            var data = from p in db.Product
                       select p;

            return View(data.Take(10));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product data)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(data);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var item = db.Product.Find(id);
            return View(item);
        }
    }
}