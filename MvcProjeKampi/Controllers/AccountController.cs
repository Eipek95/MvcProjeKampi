using DataAccessLayer.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            _userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            _roleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Register model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                _userManager.AddToRole(user.Id,"Admin");
                return RedirectToAction("Login", "Account");
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu.Lütfen tekrar deneyiniz");
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl = null)
        {
            return View(new Login()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindAsync(model.UserName, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Bu Kullanıcı ile daha önce hesap oluşturulmamış");
                return View(model);
            }
            /* if (!await _userManager.IsEmailConfirmedAsync(user.Id))
             {
                 ModelState.AddModelError("", "Lütfen hesabınızı email ile onaylayınız");
                 return View(model);
             }
            */
            var authManager = HttpContext.GetOwinContext().Authentication;
            var identityClaims = _userManager.CreateIdentity(user, "ApplicationCookie");//cookie oluşturuldu
            var authProperties = new AuthenticationProperties();
            authProperties.IsPersistent = model.RememberMe;
            authManager.SignIn(authProperties, identityClaims);//sisteme dahil et

            if (!string.IsNullOrEmpty(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
            return RedirectToAction("NewMessage", "Message");
        }
        public ActionResult LogOut(Login model)
        {
            var authManager = HttpContext.GetOwinContext().Authentication;//Oluşturulan Cookie burda sileriz sistemden(Authenticationa ulaşırız)
            authManager.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}