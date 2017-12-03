using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using Omu.ValueInjecter;

namespace MVC5Course.Controllers
{
    public class TestController : BaseController
    {
        public ActionResult Index()
        {
            var data = repo.Get取得所有尚未刪除的商品資料Top10();

            return View(data);
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
            var item = repo.Find(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            //var olRepo = RepositoryHelper.GetOrderLineRepository(repo.UnitOfWork);
            //olRepo.Delete(olRepo.All().First(p => p.OrderId == 1));

            //var olRepo = new OrderLineRepository();
            //olRepo.UnitOfWork = repo.UnitOfWork;
            //olRepo.Delete(olRepo.All().First(p => p.OrderId == 1));

            var item = repo.Find(id);
            repo.Delete(item);

            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }


    }
}