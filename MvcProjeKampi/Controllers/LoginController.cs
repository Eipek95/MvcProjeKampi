using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.HashAlgorithms;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        LoginManager lm = new LoginManager(new EfLoginDal());
        [HttpGet]
        public ActionResult Index()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            
            if (new LoginCheck().IsLoginSuccess(p))
            {
                FormsAuthentication.SetAuthCookie(p.AdminUserName, false);
                Session["AdminUserName"] = p.AdminUserName;
                return RedirectToAction("NewMessage","Message");
            }
            else
            {
                return RedirectToAction("Index");
            }
         
        }
    }
}