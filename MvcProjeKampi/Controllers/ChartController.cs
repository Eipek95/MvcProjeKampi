using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryModel> BlogList()
        {
            List<CategoryModel> ct = new List<CategoryModel>();
            ct.Add(new CategoryModel() 
            {
                CategoryName="Yazılım",
                CategoryCount=10
            });
            ct.Add(new CategoryModel()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new CategoryModel()
            {
                CategoryName = "Kitap",
                CategoryCount = 7
            });
            return ct;
        }
    }
}