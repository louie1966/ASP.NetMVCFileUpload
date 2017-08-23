using ASP.NetMVCFileUpload.HTMLHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ASP.NetMVCFileUpload.Controllers {
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload() {
            var r = new List<ViewDataUploadFilesResult>();

            foreach (string file in Request.Files) {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;
                string savedFileName = Path.Combine(
                   AppDomain.CurrentDomain.BaseDirectory,
                   "UploadDir/",
                   Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName);

                r.Add(new ViewDataUploadFilesResult() {
                    Name = savedFileName,
                    Length = hpf.ContentLength
                });
            }
            return View("Upload", r);
        }
    }
}