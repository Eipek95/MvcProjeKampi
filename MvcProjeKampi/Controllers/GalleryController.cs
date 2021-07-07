using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());
        Context context = new Context();
        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(ImageFile p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string path = "/AdminLTE-3.0.4/images/" + fileName ;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.ImagePath = "/AdminLTE-3.0.4/images/" + fileName ;
                ifm.ImageAddBL(p);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}