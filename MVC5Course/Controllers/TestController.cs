using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using Omu.ValueInjecter;

namespace MVC5Course.Controllers
{
    public class TestController : Controller
    {
        ProductRepository repo = RepositoryHelper.GetProductRepository();

        public ActionResult Index()
        {
            var data = repo.All().Where(p => p.IsDeleted == false);

            return View(data.Take(10));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product data)
        {
            if (ModelState.IsValid)
            {
                repo.Add(data);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var item = repo.Find(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, Product data)
        {
            if (ModelState.IsValid)
            {
                var item = repo.Find(id);

                item.ProductName = data.ProductName;
                item.Price = data.Price;
                item.Stock = data.Stock;
                item.Active = data.Active;

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Details(int id)
        {
            return View(repo.Find(id));
        }

        public ActionResult Delete(int id)
        {
            var item = repo.Find(id);

            //db.OrderLine.RemoveRange(item.OrderLine.ToList());
            //db.Product.Remove(item);

            item.IsDeleted = true;

            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }


    }
}