using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.ViewModels;

namespace MVC5Course.Controllers
{
    public class ProductsController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Product.Take(10));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.OrderLines = product.OrderLine.ToList();

            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Value = "0", Text = "0" });
            items.Add(new SelectListItem() { Value = "10", Text = "10" });
            items.Add(new SelectListItem() { Value = "20", Text = "20" });
            items.Add(new SelectListItem() { Value = "30", Text = "30" });
            ViewBag.Price = new SelectList(items, "Value", "Text");

            var price_list = (from p in db.Product
                             select new
                             {
                                 Value = p.Price,
                                 Text = p.Price
                             }).Distinct().OrderBy(p => p.Value);

            ViewBag.Price = new SelectList(price_list, "Value", "Text");


            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            var price_list = (from p in db.Product
                              select new
                              {
                                  Value = p.Price,
                                  Text = p.Price
                              }).Distinct().OrderBy(p => p.Value);

            ViewBag.Price = new SelectList(price_list, "Value", "Text");



            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }


            var price_list = (from p in db.Product
                              select new
                              {
                                  Value = p.Price,
                                  Text = p.Price
                              }).Distinct().OrderBy(p => p.Value);

            ViewBag.Price = new SelectList(price_list, "Value", "Text");


            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            var product = db.Product.Find(id);
            
            if (TryUpdateModel(product, new string[] { "ProductId", "Price", "Active", "Stock" }))
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {

            }
            var price_list = (from p in db.Product
                              select new
                              {
                                  Value = p.Price,
                                  Text = p.Price
                              }).Distinct().OrderBy(p => p.Value);

            ViewBag.Price = new SelectList(price_list, "Value", "Text");



            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult List()
        {
            var data = from p in db.Product
                       select new ProductListVM()
                       {
                           ProductId = p.ProductId,
                           ProductName = p.ProductName,
                           Price = p.Price,
                           Stock = p.Stock
                       };
            return View(data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

#if !DEBUG
        [NonAction]
#endif
        public ActionResult Debug()
        {
            return View();
        }
    }
}
