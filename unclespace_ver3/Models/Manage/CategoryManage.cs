using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace unclespace_ver3.Models
{
    public class CategoryManage
    {
        public bool Add(Category category, List<HttpPostedFileBase> images)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (db.Categories.FirstOrDefault(m => m.Name == category.Name) != null)
                {
                    return false;
                }

                category.ImagePath = "/Images/Category/" + category.Name +"/";

                if (ImageManage.Add(category.ImagePath, images))
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void Delete(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Category category = db.Categories.Find(Id);
                List<Product> list = db.Products.Where(m => m.CategoryId == Id).ToList();

                foreach (var a in list)
                {
                    ImageManage.Delete(a.ImagePath);
                }

                if (category != null)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    ImageManage.Delete(category.ImagePath);
                }
            }
        }

        public async void Change(Category category)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Category _category = await db.Categories.FindAsync(category.Id);
                if (_category != null)
                {
                    db.Entry(_category).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
    }
}