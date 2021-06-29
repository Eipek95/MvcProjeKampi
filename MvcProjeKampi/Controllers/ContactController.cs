using BusinessLayer.Concrete;
using BusinessLayer.ValidationRıles;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        DraftManager dm = new DraftManager(new EfDraftDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];
            var draftCount = dm.GetList().Count();
            var contactCount = mm.GetListInbox(p).Count();
            var contactCount2 = mm.GetListSendbox(p).Count();
            var contactCount3 = cm.GetList().Count();
            var contactFalseCount = cm.GetList().Where(x => x.ContactReadStatus == false).Count();
            var contactTrueCount = cm.GetList().Where(x => x.ContactReadStatus == true).Count();
            var messageFalseCount = mm.GetListInbox(p).Where(x => x.MessageReadStatus == false).Count();
            var messageTrueCount = mm.GetListInbox(p).Where(x => x.MessageReadStatus == true).Count();
            ViewBag.draft = draftCount;
            ViewBag.adminInbox = contactCount;
            ViewBag.adminSendbox = contactCount2;
            ViewBag.Inbox = contactCount3;
            ViewBag.CFalseCount = contactFalseCount;
            ViewBag.CTrueCount = contactTrueCount;
            ViewBag.MFalseCount = messageFalseCount;
            ViewBag.MTrueCount = messageTrueCount;
            return PartialView();
        }
        public ActionResult UpdateContractReadStatus(int id)
        {
            var HeadingValue = cm.GetByID(id);
            HeadingValue.ContactReadStatus = true;
            cm.ContactUpdate(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}