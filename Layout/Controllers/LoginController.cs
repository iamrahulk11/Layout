using Layout.Common;
using Layout.Repository;
using Layout.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layout.Controllers
{
    [HandleError]
    public class LoginController : Controller
    {            
            //Logger logger = null;
            //clsPagePathService objPagePath = null;
            string _CurSession = ConfigurationManager.AppSettings["currentsession"];
            ILoginService objPQService = null;
            clsCommon objCommmon = null;

        public LoginController()
        {
            if (objPQService == null)
                objPQService = new LoginService(LoginService.DALConnection.EntityConnection);
        }

        //Question and Option Master
        public ActionResult Login()
        {
            try
            {
                //ViewBag.PageHeader = "";
                objCommmon = new global::Layout.Common.clsCommon();
              //  string errMsg = objCommmon.CheckUIDIsValid(Request);
           //ViewBag.PagePath = objPagePath.GetPagePath(Convert.ToString(Session["COMMMEM_ID"]), "", Request.Url.AbsolutePath, _CurSession, "PickQuestion  > Question and Option Master");
                    // ViewBag.CurrDate = DateTime.Now;
                    return View();
                
            }
            catch (Exception ex)
            {
               // logger.Error(ex, "Error on PickQuestion in PickQuestion controller.");
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    }
}