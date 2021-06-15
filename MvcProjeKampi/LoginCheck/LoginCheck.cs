using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.HashAlgorithms
{
    public class LoginCheck
    {
        LoginManager lm; 
        public LoginCheck()
        {
            lm= new LoginManager(new EfLoginDal());
        }
        public bool IsLoginSuccess(Admin p)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var user = lm.GetList().Where(x=>x.AdminUserName==crypto.Compute(p.AdminUserName,x.UsernameSalt)).FirstOrDefault();
            if (user != null)
            {
                if (user.AdminPassword==crypto.Compute(p.AdminPassword,user.PasswordSalt))
                {
                    return true;
                }
            }
            return false;
        }
    }
}