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
        public ActionResult Index(IList<TestXXX> filesx)
        {
            
            HttpFileCollectionBase files = HttpContext.Request.Files;

            foreach (string file in files)
            {
                var fileName = Path.GetFileName(file);
                var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                files[file].SaveAs(path);
            }

            return RedirectToAction("Index");
        }
    }
    public class TestXXX
    {
        public string Name { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}