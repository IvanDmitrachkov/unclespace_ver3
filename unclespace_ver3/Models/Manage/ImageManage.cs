using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace unclespace_ver3.Models.Manage
{
    public static class ImageManage
    {
        public static bool Add(string path, List<HttpPostedFileBase> images)
        {
            try
            {
                if (Directory.Exists(HttpContext.Current.Server.MapPath("~/Images" + path)))
                {
                    Directory.Delete(HttpContext.Current.Server.MapPath("~/Images" + path), true);
                }
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Images" + path));
                int n = 1;
                foreach (var file in images)
                {
                    if (file != null)
                    {
                        string _n = file.FileName.Substring(file.FileName.Length - 4);
                        string name = n.ToString() + _n;
                        file.SaveAs(HttpContext.Current.Server.MapPath("~/Images" + path + name));
                        n++;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(string path)
        {
            try
            {
                if (Directory.Exists(HttpContext.Current.Server.MapPath("~/Images" + path)))
                {
                    Directory.Delete(HttpContext.Current.Server.MapPath("~/Images" + path), true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}