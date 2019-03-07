using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadFileMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            HttpPostedFileBase file = HttpContext.Request.Files[0];
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            file.SaveAs(path);

            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult Index(IEnumerable<HttpPostedFileBase> files)
        //{


        //    foreach (var file in files)
        //    {
        //        if (file.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(file.FileName);
        //            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        //            file.SaveAs(path);
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}
        //[HttpPost]
        //public ActionResult Index(IEnumerable<KeyValuePair<string,FileInfo>> files)
        //{

        //    if (files.Count() > 0)
        //    {
        //        foreach (var file in files)
        //        {
        //            //if (file.ContentLength > 0)
        //            //{
        //            //    var fileName = Path.GetFileName(file.FileName);
        //            //    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        //            //    file.SaveAs(path);
        //            //}
        //        }
        //    }
        //    //if (context.Request.Files.Count > 0)
        //    //{
        //    //    HttpFileCollection files = context.Request.Files;
        //    //    foreach (string key in files)
        //    //    {
        //    //        HttpPostedFile file = files[key];
        //    //        string fileName = file.FileName;
        //    //        fileName = context.Server.MapPath("~/uploads/" + fileName);
        //    //        file.SaveAs(fileName);
        //    //    }
        //    //}
        //    //context.Response.ContentType = "text/plain";
        //    //context.Response.Write("File(s) uploaded successfully!");
        //    return RedirectToAction("Index");
        //}
    }
}