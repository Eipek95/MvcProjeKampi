using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAddBL(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        [Route("About/UpdateAboutStatus/{id}/{status}")]
        public ActionResult UpdateAboutStatus(int id,bool status)
        {

            var AboutValue = abm.GetByID(id);
            if (AboutValue.AboutStatus==status)
            {
                if (AboutValue.AboutStatus)
                {
                    return View(AboutValue);
                }
                else
                {
                    return View();
                }
            }
            else 
            {
                AboutValue.AboutStatus =status;
                if (AboutValue.AboutStatus)
                {
                    abm.AboutUpdate(AboutValue);
                    return View(AboutValue);
                }
                else
                {
                    return View();
                }
            }
        }

    }
}