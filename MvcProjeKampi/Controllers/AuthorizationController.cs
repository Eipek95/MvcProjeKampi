using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminRecordManager adminRecordManager = new AdminRecordManager(new EfAdminRecordDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            var records = adminRecordManager.GetList();
            return View(records);
        }
    }
}