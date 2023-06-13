using Layout.Models;
using School.Repositry.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout.Services
{
    public class LoginService: ILoginService
    {       
            public enum DALConnection
            {
                EntityConnection, ADOConnection
            }
            ILoginRepo objRepo = null;

            public LoginService()
            {
                if (objRepo == null)
                {
                    GetDALConnection(DALConnection.EntityConnection);
                }
            }

            public LoginService(DALConnection objDALName)
            {
                if (objRepo == null)
                {
                    GetDALConnection(objDALName);
                }
            }


            internal ILoginRepo GetDALConnection(DALConnection objDALName)
            {
                if (objDALName == DALConnection.EntityConnection)
                {
                    return objRepo = new clsLoginRepo();
                }
                else
                {
                    return objRepo = new clsLoginRepo();
                }

            }   
}
}