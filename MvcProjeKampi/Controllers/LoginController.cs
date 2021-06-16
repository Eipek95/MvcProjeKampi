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
using EntitiyLayer.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        LoginManager lm = new LoginManager(new EfLoginDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

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
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        public ActionResult WriterLogin(Writer p)
        {
            var writeruserinfo = wm.GetList().FirstOrDefault(x=>x.WriterMail==p.WriterMail&&x.WriterPassword==p.WriterPassword);
            if (writeruserinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(p.WriterMail, false);
                Session["WriterUserName"] = p.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");

            }
            else
            {
                return View("WriterLogin");
            }
            
        }
    }
}