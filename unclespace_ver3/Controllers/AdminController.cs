using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using unclespace_ver3.Models;


namespace unclespace_ver3.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index(string action = "")
        {
            ViewBag.action = action;
            ApplicationDbContext db = new ApplicationDbContext();
            var products = db.Products.Include(p=> p.Category).ToList();

            SelectList Cat = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Cat = Cat;

            return View(products);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, List<HttpPostedFileBase> images)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index","Admin", new { action = "Не удалось" });
            }
            ProductManage pm = new ProductManage();
            if (pm.Add(product, images))
            {
                return RedirectToAction("Index", "Admin", new { action = "Добавлено" });
            }
            else return RedirectToAction("Index", "Admin", new { action = "Не удалось" });
        }

        public ActionResult DeleteProduct(int Id)
        {
            ProductManage pm = new ProductManage();
            pm.Delete(Id);
            return RedirectToAction("Index", "Admin", new { action = "Удалено" });
        }

        [HttpPost]
        public ActionResult AddCategory(Category category, List<HttpPostedFileBase> images)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Admin", new { action = "Не удалось" });
            }
            CategoryManage cm = new CategoryManage();
            if (cm.Add(category, images))
            {
                return RedirectToAction("Index", "Admin", new { action = "Добавлено" });
            }
            else return RedirectToAction("Index", "Admin", new { action = "Не удалось" });
        }

        public ActionResult DeleteCategory(int Id)
        {
            CategoryManage cm = new CategoryManage();
            cm.Delete(Id);
            return RedirectToAction("Index", "Admin", new { action = "Удалено" });
        }
    }
}