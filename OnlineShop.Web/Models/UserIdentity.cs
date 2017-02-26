using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Models
{
    public class UserIdentity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}