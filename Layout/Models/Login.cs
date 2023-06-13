using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout.Models
{
    public class Login
    {
        public string Userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<string> center { get; set; }
    }
}