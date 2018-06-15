using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace unclespace_ver3.Models
{
    public class ProductVsImage
    {
        public Product product;
        public List<string> images = new List<string>();

        public ProductVsImage(Product product)
        {
            this.product = product;
            string[] im = Directory.GetFiles(HttpContext.Current.Server.MapPath(("~"+product.ImagePath)));
            foreach(string s in im)
            {
                int index = s.IndexOf("Images");
                string str = s.Substring(index);
                images.Add("/"+str);
            }
        }

    }
}