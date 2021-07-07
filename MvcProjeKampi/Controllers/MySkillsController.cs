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
    [AllowAnonymous]
    public class MySkillsController : Controller
    {
        // GET: MySkills
        MySkillsManager sm = new MySkillsManager(new EfMySkillsDal());
        public ActionResult Index()
        {
            var skillvalues = sm.GetList();
            return View(skillvalues);
        }
        [HttpGet]
        public ActionResult ListSkill()
        {
            var skillvalues = sm.GetList();
            return View(skillvalues);
        }
        [HttpGet]
        public ActionResult AddSkills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkills(MySkills p)
        {
            sm.MySkillsAddBL(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var skillvalue = sm.GetByID(id);
            return View(skillvalue);
        }
        [HttpPost]
        public ActionResult EditSkill(MySkills p)
        {
            sm.MySkillsUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var SkillValue = sm.GetByID(id);
            sm.MySkillsDelete(SkillValue);
            return RedirectToAction("Index");
        }
    }
}