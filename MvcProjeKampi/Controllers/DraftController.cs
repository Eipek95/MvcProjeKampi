using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DraftController : Controller
    {
        // GET: Draft
        DraftManager dm = new DraftManager(new EfDraftDal());
        public ActionResult Index()
        {
            return View(dm.GetList());
        }
        [HttpPost]
        public ActionResult AddDraft(Draft p)
        {
            
            dm.DraftAddBL(p);
            return RedirectToAction("Index");
            
        }
        public ActionResult GetDraftMessageDetails(int id)
        {
            var values = dm.GetByID(id);
            return View(values);
        }
    }
}