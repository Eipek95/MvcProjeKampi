using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MySkillsController : Controller
    {
        // GET: MySkills
        MySkillsManager sm = new MySkillsManager(new EfMySkillsDal());
        public ActionResult Index()
        {
            var skillvalues = sm.GetList();
            return View(skillvalues);
        }
    }
}