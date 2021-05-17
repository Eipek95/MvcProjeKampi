using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        public ActionResult Index()
        {
            ViewBag.numberOfCategories = cm.GetList().Count();
           ViewBag.numberofLetterAinAuthorName = hm.GetList().Where(x => x.WriterID == x.Writer.WriterID).Count(x=>x.Writer.WriterName.ToUpper().Contains("A"));
            ViewBag.numberOfTrue = cm.GetList().Count(x => x.CategoryStatus);
            ViewBag.numberOfFalse = cm.GetList().Count(x => !(x.CategoryStatus));
            ViewBag.numberOfSoftwareHeadings = hm.GetList().Count(x => x.Category.CategoryName == "Yazılım");
            ViewBag.numberOfHeading = cm.GetList().Where(x => x.CategoryID == (hm.GetList().GroupBy(h => h.CategoryID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();
            return View();
        }
    }
}