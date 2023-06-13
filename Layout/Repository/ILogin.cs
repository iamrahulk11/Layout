using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layout.Repository
{
    public interface ILogin
    {
        bool Authenticate(string username, string password, string center);
    }
}
