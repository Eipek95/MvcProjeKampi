﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        public string Email { get; set; }
        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}