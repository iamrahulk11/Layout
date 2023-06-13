using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout.Repository
{
    public class Login : ILogin
    {
        public bool Authenticate(string username, string password, string center)
        {
            return true;
        }
    }
}