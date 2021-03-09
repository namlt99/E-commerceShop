using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _EcommerceShop.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Mời nhập email!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Mời nhập password!")]
        public string password { get; set; }

        public bool remember { get; set; }
    }
}