﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace unclespace_ver3.Models
{
    public class ProductManage
    {
        public bool Add(Product product, List<HttpPostedFileBase> images)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (db.Products.FirstOrDefault(m => m.Name == product.Name)!= null)
                {
                    return false;
                }

                product.ImagePath = "/Images/Product/" + product.CategoryId + "/" + product.Name.Replace(" ","_") + "/";
                if (ImageManage.Add(product.ImagePath, images))
                {
                    db.Products.Add(product);
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
                Product product = db.Products.Find(Id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                    ImageManage.Delete(product.ImagePath);
                }
            }
        }

        public async void Change(Product product)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Product _product = await db.Products.FindAsync(product.Id);
                if (_product != null)
                {
                    db.Entry(_product).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
    }
}