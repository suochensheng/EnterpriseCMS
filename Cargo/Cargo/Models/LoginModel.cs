using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cargo.Models
{
    public partial class LoginModel : BaseEntityModel
    {
        [AllowHtml]
        public string Email { get; set; }

        //public bool UsernamesEnabled { get; set; }

        //[AllowHtml]
        //public string Username { get; set; }

        [DataType(DataType.Password)]
        [AllowHtml]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool DisplayCaptcha { get; set; }

        public string ReturnUrl { get; set; }
    }
}