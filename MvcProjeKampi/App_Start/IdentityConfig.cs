using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(MvcProjeKampi.App_Start.IdentityConfig))]

namespace MvcProjeKampi.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Login/Index/"),
                ExpireTimeSpan = TimeSpan.FromMinutes(30),
                CookieHttpOnly=true,
                CookieName=".MvcProje.Security.Cookie"
            });
        }
    }
}
