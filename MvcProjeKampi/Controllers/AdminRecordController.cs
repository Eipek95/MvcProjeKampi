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
    public class AdminRecordController : Controller
    {
        AdminRecordManager arm = new AdminRecordManager(new EfAdminRecordDal());
        // GET: AdminRecord
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var encrypedUsername = crypto.Compute(p.AdminUserName);
            var encrypedPassword = crypto.Compute(p.AdminPassword);
            p.AdminUserName = encrypedUsername;
            p.AdminPassword = encrypedPassword;
            p.UsernameSalt = crypto.Salt;
            p.PasswordSalt = crypto.Salt;
            arm.AdminAddBL(p);
            return RedirectToAction("Index", "Login");
          
        }
    }
}