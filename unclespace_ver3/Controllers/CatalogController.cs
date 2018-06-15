using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using unclespace_ver3.Models;

namespace unclespace_ver3.Controllers
{
    public class CatalogController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products;
            List<ProductVsImage> purchases = new List<ProductVsImage>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                products = db.Products.Include(p => p.Category).ToList();
            }

            foreach (var p in products)
            {
                purchases.Add(new ProductVsImage(p));
            }

            return View(purchases);
        }
    }
}