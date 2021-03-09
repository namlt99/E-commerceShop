using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EcommerceShop.Common
{
    [Serializable]
    public class UserLogin
    {
        
        public long UserId { get; set; }
        public string Name { get; set; }
    }
}