using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using unclespace_ver3.Models;
using System.IO;

namespace unclespace_ver3.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var products = db.Products.Include(p => p.Category).ToList();
            var categories = db.Categories.ToList();
            ViewBag.list = categories;

            SelectList Cat = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Cat = Cat;

            return View(products);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, List<HttpPostedFileBase> images)
        {
            if (!ModelState.IsValid)
            {
                using(StreamWriter sw = new StreamWriter(@"D:\test.txt", true, System.Text.Encoding.Default))
                {
                }
                return RedirectToAction("Index", "Home");
            }

            ProductManage pm = new ProductManage();
            if (pm.Add(product, images))
            {
                return RedirectToAction("Index", "Admin");
            }
            else return RedirectToAction("Index", "Admin");
        }

        public ActionResult DeleteProduct(int Id)
        {
            ProductManage pm = new ProductManage();
            pm.Delete(Id);
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public ActionResult AddCategory(Category category, List<HttpPostedFileBase> images)
        {
            CategoryManage cm = new CategoryManage();
            if (cm.Add(category, images))
            {
                return RedirectToAction("Index", "Admin");
            }
            else return RedirectToAction("Index", "Admin");
        }

        public ActionResult DeleteCategory(int Id)
        {
            CategoryManage cm = new CategoryManage();
            cm.Delete(Id);
            return RedirectToAction("Index", "Admin");
        }
    }
}