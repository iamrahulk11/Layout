using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Diagnostics;
using static Layout.Common.clsCommon;
using Layout.Manager;
using Layout.DBContext;

namespace School.Repositry.Login
{
    public class clsLoginRepo : ILoginRepo
    {
         DbEnitityContext dbcontext = null;     

        //public string DoLoginFinal(string tempComID, string remoteAddr)
        //{
        //    Trace.WriteLine("30");
        //    try
        //    {
        //        string _result = "";
        //        Trace.WriteLine("31");
        //        if (objMember != null)
        //        {
        //            string _UType = "";
        //            _UType = objMember.CommMem_id.Substring(0, 3).ToUpper();
        //            string strMemberType = "";
        //            string _categoryID = "";
        //            if (_UType == "SKS")
        //            {
        //                strMemberType = "Student";
        //                _categoryID = "4";
        //            }
        //            if (_UType == "SKF")
        //            {
        //                strMemberType = "Faculty";
        //                _categoryID = "2";
        //            }
        //            if (_UType == "SKA")
        //            {
        //                strMemberType = "Alumni";
        //                _categoryID = "5";
        //            }
        //            if (_UType == "SKO")
        //            {
        //                strMemberType = "Admin";
        //                _categoryID = "1";
        //            }
        //            if (_UType == "SKP")
        //            {
        //                strMemberType = "Parent";
        //                _categoryID = "3";
        //            }

        //            string _sql = "Update CommunityMember Set CategoryId = " + _categoryID + " Where Upper(Left(CommMem_Id,3))='" + _UType + "' And IsNull(CategoryId,'')=''";
        //            int i = clsDBManager.ExecuteQuery(_sql);


        //        }






        //        public string ChangeUpdateUserPwd(string tempComID, string oldPWD, string newPWD)
        //{
        //    //try
        //    //{
        //    string _result = "";
        //    string _sql = "Update CommunityMember set mempasswd ='" + newPWD + "' where commMem_Id='" + tempComID + "' ;" +
        //                  " Update SchoolPasswordChangeMaster set LastPwdUpdate = cast('" + DateTime.Now.ToString("dd-MMM-yyyy HH:mm") + "' as datetime) where commMem_id = '" + tempComID + "' ";
        //    //" Update Tbl_PasswordUpdateDetails set PasswordUpdateDate = cast('" + DateTime.Now.ToString("dd-MMM-yyyy HH:mm") + "' as datetime) where commMem_id = '" + tempComID + "' ";
        //    int i = clsDBManager.ExecuteQuery(_sql);

        //    _sql = string.Empty;
        //    _sql = string.Format(@"PR_ChangeUpdateUserPwd_NV '{0}'", tempComID);
        //    clsDBManager.ExecuteQuery(_sql);

        //    Tbl_PasswordUpdateDetails objPwd = new Tbl_PasswordUpdateDetails();
        //    dbcontext = new DBSchoolEntity();
        //    _result = "1";
        //    return _result;

        //}

      

      

        //public DataTable GetEMPIDDetails(string empID)
        //{
        //    string _sql = "Select MemEMail1,FacultyName As MemberName,User_Id,MemPasswd From View_FacultyInformation_NV Where ISNull(IsResigned,'')='' And IsNull(EMPID,'')<>'' And IsNull(MemEMail1,'')<>'' And EMPID='" + empID + "' " +
        //        " UNIon " +
        //        " Select MemEMail1,StaffName As MemberName,User_Id,MemPasswd From View_StaffInformation_NV Where ISNull(IsResigned, '') = '' And IsNull(EMPID,'')<> '' And Category Not In ('Principal', 'Owner') And IsNull(MemEMail1,'')<> '' And EMPID = '" + empID + "'";
        //    DataTable dt = new DataTable();
        //    dt = clsDBManager.GetDataTable(_sql);
        //    return dt;
        //}

        //public string SendMailForStudentParentPWD(string admNO)
        //{
        //    try
        //    {
        //        string _result = "";
        //        _result = "2";
        //        string _sql = "Select A.PrimaryEmailAddress,A.User_Id As SUID,A.MemPasswd As SPWD,B.User_Id As PUID,B.MemPasswd As PPWD From View_StudentInformation_NV As A,View_ParentInformation_NV As B Where A.CommMem_Id=B.StudentCode " +
        //            " And A.Status = 'R' And A.RollNo = '" + admNO + "'";
        //        DataTable dt = new DataTable();
        //        dt = clsConnection.GetDataTable(_sql);
        //        if (dt != null && dt.Rows.Count > 0)
        //        {

        //            string str = "<font color=red><b>Your Recovered User Id and Password is:</b><br /></font>";
        //            str = str + "<table align=center width = 50% border=1>";
        //            str = str + "<tr align=center><th>&nbsp;</th><th>USER ID</th>			<th>PASSWORD</th></tr>";
        //            str = str + "<tr align=center><td style='font-weight:bold'>STUDENT</td><td>" + Convert.ToString(dt.Rows[0]["SUID"]) + "</td><td>" + Convert.ToString(dt.Rows[0]["SPWD"]) + "</td></tr>";
        //            str = str + "<tr align=center><td style='font-weight:bold'>PARENT</td><td>" + Convert.ToString(dt.Rows[0]["PUID"]) + "</td><td>" + Convert.ToString(dt.Rows[0]["PPWD"]) + "</td></tr></table>";

        //            if (dt.Rows[0]["PrimaryEmailAddress"] != null && Convert.ToString(dt.Rows[0]["PrimaryEmailAddress"]) != "")
        //            {

        //                EmailModel email = new EmailModel();
        //                email.To = Convert.ToString(dt.Rows[0]["PrimaryEmailAddress"]);
        //                email.Subject = System.Configuration.ConfigurationManager.AppSettings["MainTitle"].ToString() + " DPS UserID and Password Recovery";
        //                email.BodyContent = str;
        //                bool IsEmailSent = false;
        //                email.From = System.Configuration.ConfigurationManager.AppSettings["Email"].ToString();
        //                // Below line of code will be uncommnet when final release 
        //                IsEmailSent = SendEMail(email);
        //                if (!IsEmailSent)
        //                {
        //                    _result = "0";
        //                }
        //                else
        //                {
        //                    _result = "1";
        //                }

        //            }
        //            else
        //            {
        //                _result = "2";
        //            }

        //        }
        //        return _result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        ////public string SendMailForFacultyStaffPWD(string empID)
        ////{
        ////    try
        ////    {
        ////        string _result = "";
        ////        _result = "2";
        ////        string _sql = "Select MemEMail1,FacultyName As MemberName,User_Id,MemPasswd From View_FacultyInformation_NV Where ISNull(IsResigned,'')='' And IsNull(EMPID,'')<>'' And IsNull(MemEMail1,'')<>'' And EMPID='" + empID + "' " +
        ////        " UNIon " +
        ////        " Select MemEMail1,StaffName As MemberName,User_Id,MemPasswd From View_StaffInformation_NV Where ISNull(IsResigned, '') = '' And IsNull(EMPID,'')<> '' And Category Not In ('Principal', 'Owner') And IsNull(MemEMail1,'')<> '' And EMPID = '" + empID + "'";
        ////        DataTable dt = new DataTable();
        ////        dt = clsConnection.GetDataTable(_sql);
        ////        if (dt != null && dt.Rows.Count > 0)
        ////        {

        ////            string str = "<font color=red><b>Your Recovered User Id and Password is:</b><br /></font>";
        ////            str = str + "<table align=center width = 50% border=1>";
        ////            str = str + "<tr align=center><th>&nbsp;</th><th>USER ID</th>			<th>PASSWORD</th></tr>";
        ////            str = str + "<tr align=center><td style='font-weight:bold'>Faculty/Staff</td><td>" + dt.Rows[0]["User_Id"] + "</td><td>" + dt.Rows[0]["MemPasswd"] + " </td></tr>";


        ////            if (dt.Rows[0]["MemEMail1"] != null && Convert.ToString(dt.Rows[0]["MemEMail1"]) != "")
        ////            {

        ////                EmailModel email = new EmailModel();
        ////                email.To = Convert.ToString(dt.Rows[0]["MemEMail1"]);
        ////                email.Subject = System.Configuration.ConfigurationManager.AppSettings["MainTitle"].ToString() + " DPS UserID and Password Recovery";
        ////                email.BodyContent = str;
        ////                bool IsEmailSent = false;
        ////                email.From = System.Configuration.ConfigurationManager.AppSettings["Email"].ToString();
        ////                // Below line of code will be uncommnet when final release 
        ////                IsEmailSent = SendEMail(email);
        ////                if (!IsEmailSent)
        ////                {
        ////                    _result = "0";
        ////                }
        ////                else
        ////                {
        ////                    _result = "1";
        ////                }

        ////            }
        ////            else
        ////            {
        ////                _result = "2";
        ////            }

        ////        }
        ////        return _result;
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return ex.Message;
        ////    }
        ////}


        //public List<clsSchoolAdminModal> getSchoolAdminList()
        //{
        //    //try
        //    //{
        //    List<clsSchoolAdminModal> obj = new List<clsSchoolAdminModal>();
        //    dbcontext = new DBSchoolEntity();
        //    obj = (from sa in dbcontext.SchoolAdmins
        //           select new clsSchoolAdminModal
        //           {
        //               admincode = sa.admincode,
        //               category = sa.category,
        //               DateOfJoining = sa.DateOfJoining,
        //               othdtl = sa.othdtl
        //           }).ToList();
        //    return obj;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //}

        #region Get Attendance mark Status

        /// <summary>
        /// Created By Alok Kumar Sharma 
        /// </summary>
        /// <param name="session">2018-2019</param>
        /// <param name="commMem_Id">"sko0000007"</param>
        /// <returns></returns>
        //public string GetAttendanceStatus(string session, string commMem_Id)
        //{
        //    string strQuery = string.Empty;
        //    string returnAttendanceStatus = string.Empty;
        //    try
        //    {
        //        return ShowImportantInformation(session, commMem_Id);
        //        /*
        //        strQuery = string.Format(@"PR_Attendancenotmarked_NV  '{0}','{1}'", commMem_Id, session);
        //        var result = clsDBManager.GetDataTable(strQuery);
        //        if (result.Rows.Count > 0)
        //        {
        //            returnAttendanceStatus = result.Rows[0]["AttendanceStatus"].ToString();
        //        }
        //        */
        //    }
        //    catch (Exception exc)
        //    {
        //        throw exc;
        //    }
        //    //return returnAttendanceStatus;
        //}
        //#endregion

        //#region  Show Important Information 
        //public string ShowImportantInformation(string session, string commMem_Id)
        //{
        //    StringBuilder strB = new StringBuilder();
        //    string strQuery = string.Empty;
        //    bool IsFound = false;
        //    string attendanceStatus = string.Empty;
        //    string eventComming7Days = string.Empty;
        //    string imageStatusOnHomePage = string.Empty;
        //    string highestLoginWeeklyMonthly = string.Empty;
        //    try
        //    {
        //        strB.AppendLine("<table>");
        //        strB.AppendLine(" <tr>");
        //        strB.AppendLine("<td style='border:solid thin' class='a-center' colspan='5'>");

        //        #region Attendance Not Mark
        //        strQuery = string.Format(@"PR_Attendancenotmarked_NV  '{0}','{1}'", commMem_Id, session);
        //        var result = clsDBManager.GetDataTable(strQuery);
        //        if (result.Rows.Count > 0)
        //        {

        //            attendanceStatus = result.Rows[0]["AttendanceStatus"].ToString();
        //        }
        //        if (!string.IsNullOrEmpty(attendanceStatus))
        //        {
        //            IsFound = true;
        //            strB.AppendLine("<table class='table table-border table-condensed table-striped table-hover'>");
        //            strB.AppendLine("<thead>");
        //            strB.AppendLine(" <tr style='background-color:silver;'>");
        //            strB.AppendLine(" <th style='border:solid thin; vertical-align:middle;text-align:center;'colspan='5' class='text-center'>Attendance not marked</th>");
        //            strB.AppendLine(" </tr>");
        //            strB.AppendLine("</thead>");
        //            strB.AppendLine("<tr>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center' colspan='5'> Attendance not marked for following Class(es) - <br/>" + attendanceStatus + "</td>");
        //            strB.AppendLine("</tr>");
        //            strB.AppendLine("</table>");
        //        }
        //        #endregion

        //        #region Coming Event in Next 7 Days
        //        strQuery = string.Format(@"PR_GetEventCommingIn7Days_NV  '{0}'", commMem_Id);
        //        var eventResult = clsDBManager.GetDataTable(strQuery);
        //        if (eventResult.Rows.Count > 0)
        //        {

        //            eventComming7Days = eventResult.Rows[0]["CommingEventsIn7Days"].ToString();
        //        }
        //        if (!string.IsNullOrEmpty(eventComming7Days))
        //        {
        //            IsFound = true;
        //            strB.AppendLine("<table class='table table-border table-condensed table-striped table-hover'>");
        //            strB.AppendLine("<thead>");
        //            strB.AppendLine(" <tr style='background-color:silver;'>");
        //            //strB.AppendLine(" <th style='border:solid thin; vertical-align:middle;text-align:center;'colspan='5' class='text-center'>Coming Event in Next 7 Days</th>");
        //            strB.AppendLine(" <th style='border:solid thin; vertical-align:middle;text-align:center;'colspan='5' class='text-center'>Please put a popup or news</th>");
        //            strB.AppendLine(" </tr>");
        //            strB.AppendLine("</thead>");


        //            strB.AppendLine("<tr>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center' colspan='5'> Upcoming events : <br/>" + eventComming7Days + "</td>");
        //            strB.AppendLine("</tr>");
        //            strB.AppendLine("</table>");
        //        }
        //        #endregion

        //        #region  Image News not uploaded on Home Page

        //        strQuery = string.Format(@"PR_GetImageStatusForHomePage  '{0}'", commMem_Id);
        //        var imageResult = clsDBManager.GetDataTable(strQuery);
        //        if (imageResult.Rows.Count > 0)
        //        {

        //            imageStatusOnHomePage = imageResult.Rows[0]["ImageOnHomePage"].ToString();
        //        }
        //        if (!string.IsNullOrEmpty(imageStatusOnHomePage))
        //        {
        //            IsFound = true;
        //            strB.AppendLine("<table class='table table-border table-condensed table-striped table-hover'>");
        //            strB.AppendLine("<thead>");
        //            strB.AppendLine(" <tr style='background-color:silver;'>");
        //            strB.AppendLine(" <th style='border:solid thin; vertical-align:middle;text-align:center;'colspan='5' class='text-center'>Image and news not uploaded</th>");
        //            strB.AppendLine(" </tr>");
        //            strB.AppendLine("</thead>");
        //            strB.AppendLine("<tr>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center' colspan='5'> " + imageStatusOnHomePage + "</td>");
        //            strB.AppendLine("</tr>");
        //            strB.AppendLine("</table>");
        //        }
        //        #endregion

        //        #region Highest Login Weekly Monthly
        //        strQuery = string.Format(@"PR_GetHighestLoginInMonth_NV  '{0}'", commMem_Id);
        //        var weeklyLoginResult = clsDBManager.GetDataTable(strQuery);
        //        if (weeklyLoginResult.Rows.Count > 0)
        //        {

        //            highestLoginWeeklyMonthly = weeklyLoginResult.Rows[0]["HighestLoginInMonth"].ToString();
        //        }
        //        if (!string.IsNullOrEmpty(highestLoginWeeklyMonthly))
        //        {
        //            IsFound = true;
        //            strB.AppendLine("<table class='table table-border table-condensed table-striped table-hover'>");
        //            strB.AppendLine("<thead>");
        //            strB.AppendLine(" <tr style='background-color:silver;'>");
        //            strB.AppendLine(" <th style='border:solid thin; vertical-align:middle;text-align:center;'colspan='5' class='text-center'>Highest no. of login in the week</th>");
        //            strB.AppendLine(" </tr>");
        //            strB.AppendLine("</thead>");
        //            strB.AppendLine("<tr>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center' colspan='5'> " + highestLoginWeeklyMonthly + "</td>");
        //            strB.AppendLine("</tr>");
        //            strB.AppendLine("</table>");
        //        }
        //        #endregion

        //        strB.AppendLine(" </td>");
        //        strB.AppendLine(" </tr>");
        //        strB.AppendLine("</table>");
        //    }
        //    catch (Exception exc)
        //    {
        //        throw exc;
        //    }
        //    if (IsFound)
        //        return strB.ToString();
        //    else
        //        return "";//"recordnotfound";
        //}
        //#endregion

        //#region  Show Reminder 
        //public string ShowReminderInformation(string session, string commMem_Id, string memberId)
        //{
        //    StringBuilder strB = new StringBuilder();
        //    string strQuery = string.Empty;
        //    string attendanceStatus = string.Empty;
        //    string eventComming7Days = string.Empty;
        //    string imageStatusOnHomePage = string.Empty;
        //    string highestLoginWeeklyMonthly = string.Empty;
        //    try
        //    {
        //        strB.AppendLine("<table>");
        //        strB.AppendLine(" <tr>");
        //        strB.AppendLine("<td style='border:solid thin' class='text-center' colspan='5'>");
        //        #region Div Header Name -> Reminder 

        //        #region Expiry of Passport EmiratId
        //        strQuery = string.Format(@"PR_GetExpiryPassportEmirateIds_NV  '{0}'", commMem_Id);
        //        var documentExpiryStatusResult = clsDBManager.GetDataTable(strQuery);
        //        if (documentExpiryStatusResult.Rows.Count > 0)
        //        {

        //            strB.AppendLine("<table class='table table-border table-condensed table-striped table-hover'>");
        //            strB.AppendLine("<thead>");
        //            strB.AppendLine(" <tr style='background-color:silver;'>");
        //            strB.AppendLine(" <th style='border:solid thin; vertical-align:middle;text-align:center;'colspan='5' class='text-center'>Expiry of Passport or Emirates Id </th>");
        //            strB.AppendLine(" </tr>");
        //            strB.AppendLine("</thead>");
        //            strB.AppendLine("<tr>");

        //            strB.AppendLine("<td style='border:solid thin' class='a-center' colspan='5'> Your Visa/Passport/Emirates Id is about to expire. Please renew.");
        //            strB.AppendLine("</td>");
        //            strB.AppendLine("</tr>");

        //            strB.AppendLine("<tr>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center text-nowrap'>Passport </td>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center text-nowrap'> Visa</td>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center text-nowrap'>");
        //            strB.AppendLine(" EmiratesID </td>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center  text-nowrap'>");
        //            strB.AppendLine(" Sponsor Passport Expiry Date </td>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center text-nowrap'>");
        //            strB.AppendLine(" Sponsor Visa Expiry Date </td>");
        //            strB.AppendLine("</tr>");


        //            strB.AppendLine("<tr>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center text-nowrap'>" + documentExpiryStatusResult.Rows[0]["ExpiryDate"].ToString());
        //            strB.AppendLine("</td>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center text-nowrap'>" + documentExpiryStatusResult.Rows[0]["VisaExpiryDate"].ToString());
        //            strB.AppendLine("</td>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center text-nowrap'>" + documentExpiryStatusResult.Rows[0]["EmiratesIDExpiry"].ToString());
        //            strB.AppendLine("</td>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center  text-nowrap'>" + documentExpiryStatusResult.Rows[0]["SponsorPassportExpiryDate"].ToString());
        //            strB.AppendLine("</td>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center text-nowrap'>" + documentExpiryStatusResult.Rows[0]["SponsorVisaExpiryDate"].ToString());
        //            strB.AppendLine("</td>");
        //            strB.AppendLine("</tr>");

        //            strB.AppendLine("</table>");
        //        }
        //        #endregion

        //        #region Library Book Return

        //        strQuery = string.Format(@" Select Top 1 IssuedTo From BookIssueMaster Where IssuedTo='{0}'
        //                                    And ReturnDate<GETDATE() And BookIssueId Not In (
        //                                    Select A.BookIssueId From BookIssueMaster As A, BookIssuedReturn As B 
        //                                    Where A.BookIssueId = B.BookIssueId And A.IssuedTo = '{0}')",
        //                                    memberId);
        //        /*
        //         memberId = "4629";
        //         strQuery = string.Format(@" Select Top 1 IssuedTo From BookIssueMaster Where IssuedTo='{0}'", memberId);
        //         */
        //        var dtLibrary = clsDBManager.GetDataTable(strQuery);
        //        if (dtLibrary.Rows.Count > 0)
        //        {

        //            strB.AppendLine("<table class='table table-border table-condensed table-striped table-hover'>");
        //            strB.AppendLine("<thead>");
        //            strB.AppendLine(" <tr style='background-color:silver;'>");
        //            strB.AppendLine(" <th style='border:solid thin; vertical-align:middle;text-align:center;'colspan='5' class='text-center'>Library Book Return</th>");
        //            strB.AppendLine(" </tr>");
        //            strB.AppendLine("</thead>");
        //            strB.AppendLine("<tr>");
        //            strB.AppendLine("<td style='border:solid thin' class='a-center' colspan='5'>Issue period is over. Please return Books.</td>");
        //            strB.AppendLine("</tr>");
        //            strB.AppendLine("</table>");
        //        }
        //        #endregion

        //        #endregion
        //        strB.AppendLine(" </td>");
        //        strB.AppendLine(" </tr>");
        //        strB.AppendLine("</table>");
        //    }
        //    catch (Exception exc)
        //    {

        //        throw exc;
        //    }
        //    return strB.ToString();
        //}
        //#endregion

        //#region Password Criteria
        //public List<clsTbl_PasswordCriteriaModal> GetPasswordCriteria()
        //{
        //    try
        //    {
        //        List<clsTbl_PasswordCriteriaModal> obj = new List<clsTbl_PasswordCriteriaModal>();
        //        dbcontext = new DBSchoolEntity();


        //        obj = clsDBManager.LoadObjectList<clsTbl_PasswordCriteriaModal>("Select * from Tbl_PasswordCriteria");
        //        /*
        //        obj = (from pobj in dbcontext.Tbl_PasswordCriteria
        //               select new clsTbl_PasswordCriteriaModal
        //               {
        //                   CategoryName = pobj.CategoryName,
        //                   Id = pobj.Id,
        //                   CreatedDate = pobj.CreatedDate,
        //                   OneLowerCaseLetter = pobj.OneLowerCaseLetter,
        //                   OneNumericDigit = pobj.OneNumericDigit,
        //                   OneSpecialCharacter = pobj.OneSpecialCharacter,
        //                   OneUpperCaseLetter = pobj.OneUpperCaseLetter,
        //                   PasswordResetDays = pobj.PasswordResetDays,
        //                   PMaxLength = pobj.PMaxLength,
        //                   PMinLength = pobj.PMinLength,
        //                   UpdatedDate = pobj.UpdatedDate
        //               }).ToList();
        //               */
        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string SaveUpdatePasswordCriteriaByCategory(clsTbl_PasswordCriteriaModal objCriteria, string strCategory)
        //{
        //    try
        //    {
        //        Tbl_PasswordCriteria obj = new Tbl_PasswordCriteria();
        //        dbcontext = new DBSchoolEntity();

        //        string strQuery = string.Format(@"PR_SaveCriteriaByCategory_NV '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'", strCategory,
        //                                        objCriteria.OneLowerCaseLetter,
        //                                        objCriteria.OneNumericDigit,
        //                                        objCriteria.OneSpecialCharacter,
        //                                        objCriteria.OneUpperCaseLetter,
        //                                        objCriteria.PasswordResetDays,
        //                                        objCriteria.PMaxLength,
        //                                        objCriteria.PMinLength);
        //        clsDBManager.ExecuteQuery(strQuery);
        //        /*

        //        obj = dbcontext.Tbl_PasswordCriteria.Where(w => w.CategoryName == strCategory).FirstOrDefault();
        //        if (obj == null)
        //        {
        //            obj = new Tbl_PasswordCriteria();
        //            obj.CategoryName = strCategory;
        //            obj.CreatedDate = DateTime.Now;
        //            obj.OneLowerCaseLetter = objCriteria.OneLowerCaseLetter;
        //            obj.OneNumericDigit = objCriteria.OneNumericDigit;
        //            obj.OneSpecialCharacter = objCriteria.OneSpecialCharacter;
        //            obj.OneUpperCaseLetter = objCriteria.OneUpperCaseLetter;
        //            obj.PasswordResetDays = objCriteria.PasswordResetDays;
        //            obj.PMaxLength = objCriteria.PMaxLength;
        //            obj.PMinLength = objCriteria.PMinLength;
        //            dbcontext.Tbl_PasswordCriteria.Add(obj);
        //            dbcontext.SaveChanges();
        //        }
        //        else
        //        {
        //            obj.CategoryName = strCategory;
        //            obj.UpdatedDate = DateTime.Now;
        //            obj.OneLowerCaseLetter = objCriteria.OneLowerCaseLetter;
        //            obj.OneNumericDigit = objCriteria.OneNumericDigit;
        //            obj.OneSpecialCharacter = objCriteria.OneSpecialCharacter;
        //            obj.OneUpperCaseLetter = objCriteria.OneUpperCaseLetter;
        //            obj.PasswordResetDays = objCriteria.PasswordResetDays;
        //            obj.PMaxLength = objCriteria.PMaxLength;
        //            obj.PMinLength = objCriteria.PMinLength;
        //            //dbcontext.Tbl_PasswordCriteria.Add(obj);
        //            dbcontext.SaveChanges();
        //        }
        //        */
        //        return "1";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        //public clsTbl_PasswordCriteriaModal GetPasswordCriteriaByCommMemID(string comMemID)
        //{
        //    clsTbl_PasswordCriteriaModal obj = new clsTbl_PasswordCriteriaModal();
        //    List<clsTbl_PasswordCriteriaModal> objCriteria = new List<clsTbl_PasswordCriteriaModal>();
        //    try
        //    {
        //        objCriteria = GetPasswordCriteria();
        //        if (comMemID.Substring(0, 3).ToUpper() == "SKS")
        //        {
        //            obj = objCriteria.Where(w => w.CategoryName.ToUpper() == "STUDENT").FirstOrDefault();
        //        }
        //        else if (comMemID.Substring(0, 3).ToUpper() == "SKP")
        //        {
        //            obj = objCriteria.Where(w => w.CategoryName.ToUpper() == "PARENT").FirstOrDefault();
        //        }
        //        else if (comMemID.Substring(0, 3).ToUpper() == "SKF")
        //        {
        //            obj = objCriteria.Where(w => w.CategoryName.ToUpper() == "FACULTY").FirstOrDefault();
        //        }

        //        else if (comMemID.Substring(0, 3).ToUpper() == "SKO")
        //        {
        //            bool IsSKOMember = false;
        //            List<clsSchoolAdminModal> objAdmin = new List<clsSchoolAdminModal>();
        //            objAdmin = getSchoolAdminList().Where(w => !string.IsNullOrEmpty(w.category) && w.category.ToUpper() == "OWNER" && w.admincode == comMemID).ToList();
        //            if (objAdmin != null && objAdmin.Count > 0)
        //            {
        //                IsSKOMember = true;

        //                obj = objCriteria.Where(w => w.CategoryName.ToUpper() == "ADMINISTRATOR").FirstOrDefault();
        //            }
        //            else
        //            {
        //                List<clsSchoolAdminModal> objPrincipal = new List<clsSchoolAdminModal>();
        //                objPrincipal = getSchoolAdminList().Where(w => !string.IsNullOrEmpty(w.category) && w.category.ToUpper() == "PRINCIPAL" && w.admincode == comMemID).ToList();
        //                if (objPrincipal != null && objPrincipal.Count > 0)
        //                {
        //                    IsSKOMember = true;
        //                    obj = objCriteria.Where(w => w.CategoryName.ToUpper() == "PRINCIPAL").FirstOrDefault();
        //                }
        //            }
        //            if (!IsSKOMember)
        //            {
        //                objAdmin = getSchoolAdminList().Where(w => !string.IsNullOrEmpty(w.category) && (w.category.ToUpper() == "HEAD MISTRESS" || w.category.ToUpper() == "PROVC" || w.category.ToUpper() == "GENERAL") && w.admincode == comMemID).ToList();
        //                if (objAdmin != null && objAdmin.Count > 0)
        //                {
        //                    obj = objCriteria.Where(w => w.CategoryName.ToUpper() == "ADMINISTRATOR").FirstOrDefault();
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return obj;
        //}

        //public clsTbl_PasswordUpdateDetailsModal GetPasswordUpdateDateByCommMemID(string commMemID)
        //{
        //    string strQuery = string.Empty;
        //    try
        //    {
        //        clsTbl_PasswordUpdateDetailsModal obj = new clsTbl_PasswordUpdateDetailsModal();

        //        strQuery = string.Format(@"Select CommMem_id ,PasswordUpdateDate from Tbl_PasswordUpdateDetails where CommMem_id ='{0}' ", commMemID);
        //        obj = clsDBManager.LoadObjectList<clsTbl_PasswordUpdateDetailsModal>(strQuery).FirstOrDefault();
        //        /*

        //        dbcontext = new DBSchoolEntity();
        //        obj = (from tbl in dbcontext.Tbl_PasswordUpdateDetails
        //               select new clsTbl_PasswordUpdateDetailsModal
        //               {
        //                   CommMem_id = tbl.CommMem_id,
        //                   PasswordUpdateDate = tbl.PasswordUpdateDate
        //               }).Where(w => w.CommMem_id == commMemID).FirstOrDefault();
        //        */

        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public clsTbl_PasswordSpecoialCharactersModal GetPasswordSpecialCharacterByCategory(string categoryName)
        //{
        //    try
        //    {
        //        clsTbl_PasswordSpecoialCharactersModal obj = new clsTbl_PasswordSpecoialCharactersModal();
        //        dbcontext = new DBSchoolEntity();


        //        obj = clsDBManager.LoadObjectList<clsTbl_PasswordSpecoialCharactersModal>(string.Format(@"Select * from Tbl_PasswordSpecoialCharacters where CategoryName='{0}'", categoryName)).FirstOrDefault();
        //        /*
        //        obj = (from sch in dbcontext.Tbl_PasswordSpecoialCharacters.Where(w => w.CategoryName == categoryName)
        //               select new clsTbl_PasswordSpecoialCharactersModal
        //               {
        //                   AutoID = sch.AutoID,
        //                   CategoryName = sch.CategoryName,
        //                   CreatedDate = sch.CreatedDate,
        //                   SpecialCharacters = sch.SpecialCharacters,
        //                   UpdatedDate = sch.UpdatedDate
        //               }).FirstOrDefault();
        //               */
        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string SavePasswordSpecoialCharactersByCategory(clsTbl_PasswordSpecoialCharactersModal objCriteria, string strCategory)
        //{
        //    string strQuery = string.Empty;
        //    try
        //    {
        //        Tbl_PasswordSpecoialCharacters obj = new Tbl_PasswordSpecoialCharacters();
        //        strQuery = string.Format(@"PR_SaveSpecoialCharactersByCategory_NV  '{0}','{1}'",obj.CategoryName,obj.SpecialCharacters);
        //        clsDBManager.ExecuteQuery(strQuery);
        //        //dbcontext = new DBSchoolEntity();
        //        //obj = dbcontext.Tbl_PasswordSpecoialCharacters.Where(w => w.CategoryName == strCategory).FirstOrDefault();
        //        //if (obj == null)
        //        //{
        //        //    obj = new Tbl_PasswordSpecoialCharacters();
        //        //    obj.CategoryName = strCategory;
        //        //    obj.CreatedDate = DateTime.Now;
        //        //    obj.SpecialCharacters = objCriteria.SpecialCharacters;
        //        //    dbcontext.Tbl_PasswordSpecoialCharacters.Add(obj);
        //        //    dbcontext.SaveChanges();
        //        //}
        //        //else
        //        //{
        //        //    obj.CategoryName = strCategory;
        //        //    obj.UpdatedDate = DateTime.Now;
        //        //    obj.CategoryName = strCategory;
        //        //    obj.SpecialCharacters = objCriteria.SpecialCharacters;
        //        //    dbcontext.SaveChanges();
        //        //}

        //        return "1";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}


        //public clsSendOTPMsgToMember GetSendOTPToMember(string _commMem_Id)
        //{
        //    string strQuery = string.Empty;
        //    clsSendOTPMsgToMember objSendOTP = new clsSendOTPMsgToMember();
        //    try
        //    {
        //        strQuery = string.Format(@"PR_OTPDisplay_NV '{0}'", _commMem_Id);
        //        var _result = clsDBManager.LoadObjectList<clsSendOTPMsgToMember>(strQuery);
        //        if (_result != null)
        //        {
        //            objSendOTP = _result.FirstOrDefault();
        //        }

        //    }
        //    catch (Exception exce)
        //    {
        //        throw exce;
        //    }
        //    return objSendOTP;
        //}


        //public List<clsTbl_UserLoginSystemInformationModal> GetUserSystemInformationDetailByMemberID(long memID)
        //{
        //    Trace.WriteLine("15");
        //    string strQuery = string.Empty;

        //    try
        //    {
        //        List<clsTbl_UserLoginSystemInformationModal> obj = new List<clsTbl_UserLoginSystemInformationModal>();

        //        strQuery = string.Format(@"Select AutoId,MemberID,Browser,BVersion,UserPlatForm,DeviceIP,Logindate,LoginEmailID,
        //                                    IsVerified from Tbl_UserLoginSystemInformation where MemberID='{0}'", memID);
        //        obj = clsDBManager.LoadObjectList<clsTbl_UserLoginSystemInformationModal>(strQuery);





        //        #region Commented code due to exception every time 
        //        //The entity type Tbl_UserLoginSystemInformation is not part of the model for the current context.
        //        /*
        //              dbcontext = new DBSchoolEntity();
        //              obj = (from uInfo in dbcontext.Tbl_UserLoginSystemInformation
        //                     select new clsTbl_UserLoginSystemInformationModal
        //                     {
        //                         AutoId = uInfo.AutoId,
        //                         Browser = uInfo.Browser,
        //                         BVersion = uInfo.BVersion,
        //                         DeviceIP = uInfo.DeviceIP,
        //                         IsVerified = uInfo.IsVerified,
        //                         Logindate = uInfo.Logindate,
        //                         LoginEmailID = uInfo.LoginEmailID,
        //                         MemberID = uInfo.MemberID,
        //                         UserPlatForm = uInfo.UserPlatForm
        //                     }).Where(w => w.MemberID == memID).ToList();
        //                     */
        //        #endregion
        //        Trace.WriteLine("16");
        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine(ex.Message);
        //        throw ex;
        //    }
        //}

        //public string SaveUpdateUserSystemInformation(clsTbl_UserLoginSystemInformationModal obj)
        //{
        //    string strQuery = string.Empty;
        //    try
        //    {
        //        string _result = "";
        //        strQuery = string.Format(@"PR_SaveUserLoginSystem_NV  '{0}','{1}','{2}','{3}','{4}','{5}','{6}'",
        //                                obj.MemberID, obj.Browser, obj.BVersion, obj.UserPlatForm, obj.DeviceIP, obj.LoginEmailID, obj.IsVerified);
        //        clsDBManager.ExecuteQuery(strQuery);
        //        _result = "success";
        //        /*
        //        Tbl_UserLoginSystemInformation objUser = new Tbl_UserLoginSystemInformation();
        //        objUser = dbcontext.Tbl_UserLoginSystemInformation.Where(w => w.MemberID == obj.MemberID && w.UserPlatForm == obj.UserPlatForm && w.DeviceIP == obj.DeviceIP).FirstOrDefault();
        //        if (objUser == null)
        //        {
        //            objUser = new Tbl_UserLoginSystemInformation();
        //            objUser.Browser = obj.Browser;
        //            objUser.BVersion = obj.BVersion;
        //            objUser.DeviceIP = obj.DeviceIP;
        //            objUser.IsVerified = obj.IsVerified;
        //            objUser.Logindate = obj.Logindate;
        //            objUser.LoginEmailID = objUser.LoginEmailID;
        //            objUser.MemberID = obj.MemberID;
        //            objUser.UserPlatForm = obj.UserPlatForm;
        //            dbcontext.Tbl_UserLoginSystemInformation.Add(objUser);
        //            dbcontext.SaveChanges();
        //        }
        //        else
        //        {
        //            objUser.Browser = obj.Browser;
        //            objUser.BVersion = obj.BVersion;
        //            objUser.DeviceIP = obj.DeviceIP;
        //            objUser.IsVerified = obj.IsVerified;
        //            objUser.Logindate = obj.Logindate;
        //            objUser.LoginEmailID = objUser.LoginEmailID;
        //            objUser.MemberID = obj.MemberID;
        //            objUser.UserPlatForm = obj.UserPlatForm;
        //            //dbcontext.Tbl_UserLoginSystemInformation.Add(objUser);
        //            dbcontext.SaveChanges();
        //        }
        //        */

        //        return _result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        //public string GetUserEmailID(string comMemID)
        //{
        //    Trace.WriteLine("10");
        //    //try
        //    //{
        //    string EMailID = "";
        //    string _sql = "";
        //    if (comMemID.Substring(0, 3).ToUpper() == "SKS")
        //    {
        //        _sql = string.Format(@"
        //                            (Select top 1 IsNull(MemEMail1,'') As EmailID From View_ParentInformation_NV Where ISNULL(MemEmail1,'')<>''and  StudentCode='{0}')
        //                            Union 
        //                            Select Top 1 IsNull(PrimaryEMailAddress,'') As EmailID From View_StudentInformation_NV Where CommMem_id='{0}'And IsNull(PrimaryEMailAddress,'')<>'' 
        //                            ", comMemID);
        //    }
        //    else if (comMemID.Substring(0, 3).ToUpper() == "SKP")
        //    {
        //        _sql = string.Format(@"
        //                                Select top 1 MemEmail1 as EmailID  From View_ParentInformation_NV Where ISNULL(MemEmail1,'')<>'' and  CommMem_ID='{0}'
        //                                Union 
        //                                Select Top 1 IsNull(PrimaryEMailAddress,'') As EmailID From View_StudentInformation_NV Where PRTID='{0}' 
        //                                And IsNull(PrimaryEMailAddress,'')<>'' ", comMemID);
        //    }
        //    else if (comMemID.Substring(0, 3).ToUpper() == "SKF")
        //    {
        //        _sql = "select distinct top 1 EmailID from (Select MemEmail1 as EmailID,CommMem_ID From View_StaffInformation_NV Where IsNull(MemEmail1,'')<>'' " +
        //            " union " +
        //            " Select MemEmail1 as EmailID,CommMem_ID From View_FacultyInformation_NV Where IsNull(MemEmail1, '') <> '') as X where CommMem_ID = '" + comMemID + "'";
        //    }
        //    else if (comMemID.Substring(0, 3).ToUpper() == "SKO")
        //    {
        //        _sql = "Select MemEmail1 as EmailID From communitymember Where IsNull(MemEmail1,'')<>''and CommMem_ID='" + comMemID + "'";
        //    }
        //    EMailID = Convert.ToString(clsDBManager.GetScalarValue(_sql));
        //    Trace.WriteLine("11");
        //    return EMailID;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return ex.Message;
        //    //}
        //}

        //public clsTbl_UserLoginOTPDtailsModal GetUserOTPDetailsByMemberID(long memberID)
        //{
        //    string strQuery = string.Empty;
        //    try
        //    {
        //        clsTbl_UserLoginOTPDtailsModal obj = new clsTbl_UserLoginOTPDtailsModal();
        //        string _sql = "SELECT LEFT(CAST(RAND()*1000000000+999999 AS bigint),6) as OTP";
        //        string otpVal = Convert.ToString(clsDBManager.GetScalarValue(_sql));

        //        strQuery = string.Format(@"Select top 1 AutoID,MemberID,OTP,OTPGeneratedDate,OTPUpdatedDate from Tbl_UserLoginOTPDtails
        //                                    where MemberID='{0}' order by OTPGeneratedDate desc ", memberID);
        //        var reader = clsDBManager.GetDataReader(strQuery);
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                // update 
        //                strQuery = string.Format(@"Update Tbl_UserLoginOTPDtails set OTP='{1}' ,OTPGeneratedDate=GetDate() 
        //                                            where MemberID='{0}'", memberID, otpVal);
        //            }
        //        }
        //        else
        //        {
        //            // Insert new record 
        //            strQuery = string.Format(@"Insert Into Tbl_UserLoginOTPDtails (MemberID,OTP,OTPGeneratedDate,OTPUpdatedDate) 
        //                                    values('{0}','{1}',GetDate(),GetDate())", memberID, otpVal);
        //        }
        //        clsDBManager.ExecuteQuery(strQuery);

        //        strQuery = string.Format(@"Select top 1 AutoID,MemberID,OTP,OTPGeneratedDate,OTPUpdatedDate from Tbl_UserLoginOTPDtails
        //                                    where MemberID='{0}' order by OTPGeneratedDate desc ", memberID);
        //        var _OtpDetails = clsDBManager.LoadObjectList<Tbl_UserLoginOTPDtails>(strQuery);
        //        Tbl_UserLoginOTPDtails objOTP = new Tbl_UserLoginOTPDtails();
        //        if (_OtpDetails != null)
        //        {
        //            objOTP = _OtpDetails.FirstOrDefault();
        //            obj.OTP = objOTP.OTP;
        //        }
        //        #region Due to exception every build or publish 
        //        /*
        //        dbcontext = new DBSchoolEntity();
        //        objOTP = dbcontext.Tbl_UserLoginOTPDtails.Where(w => w.MemberID == memberID).FirstOrDefault();
        //        if (objOTP == null)
        //        {
        //            objOTP = new Tbl_UserLoginOTPDtails();
        //            objOTP.MemberID = memberID;
        //            objOTP.OTP = otpVal;
        //            objOTP.OTPGeneratedDate = DateTime.Now;
        //            dbcontext.Tbl_UserLoginOTPDtails.Add(objOTP);
        //            dbcontext.SaveChanges();
        //        }
        //        else
        //        {
        //            objOTP.OTP = otpVal;
        //            objOTP.OTPGeneratedDate = DateTime.Now;
        //            dbcontext.SaveChanges();
        //        }

        //        obj = (from otp in dbcontext.Tbl_UserLoginOTPDtails.Where(w => w.MemberID == memberID)
        //               select new clsTbl_UserLoginOTPDtailsModal
        //               {
        //                   AutoID = otp.AutoID,
        //                   MemberID = otp.MemberID,
        //                   OTP = otp.OTP,
        //                   OTPGeneratedDate = otp.OTPGeneratedDate
        //               }).FirstOrDefault();
        //               */
        //        #endregion

        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string SubmitOTP(string strOTP, long memberID)
        //{
        //    string strQuery = string.Empty;
        //    try
        //    {
        //        string _result = "";
        //        Tbl_UserLoginOTPDtails objOTP = new Tbl_UserLoginOTPDtails();

        //        strQuery = string.Format(@"Select top 1 AutoID,MemberID,OTP,OTPGeneratedDate,OTPUpdatedDate from 
        //                    Tbl_UserLoginOTPDtails where MemberID='{0}' order by OTPGeneratedDate desc", memberID);
        //        var obj = clsDBManager.LoadObjectList<Tbl_UserLoginOTPDtails>(strQuery);
        //        if (obj != null)
        //        {
        //            objOTP = obj.FirstOrDefault();
        //        }

        //        //dbcontext = new DBSchoolEntity();
        //        //objOTP = dbcontext.Tbl_UserLoginOTPDtails.Where(w => w.MemberID == memberID).FirstOrDefault();

        //        if (objOTP != null)
        //        {
        //            if (objOTP.OTP == strOTP)
        //            {
        //                if (objOTP.OTPGeneratedDate <= Convert.ToDateTime(objOTP.OTPGeneratedDate).AddMinutes(60))
        //                {

        //                    // update 
        //                    strQuery = string.Format(@"Update Tbl_UserLoginOTPDtails set  OTPUpdatedDate=GetDate() 
        //                                            where MemberID='{0}'", memberID);

        //                    //objOTP.OTPUpdatedDate = DateTime.Now;
        //                    //dbcontext.SaveChanges();
        //                    _result = "1";//otp updated
        //                }

        //                else
        //                {
        //                    _result = "3";//OTP has expired
        //                }
        //            }
        //            else
        //            {
        //                _result = "2";//wrong otp
        //            }
        //        }
        //        else
        //        {
        //            _result = "0"; //no record
        //        }
        //        return _result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
        //#endregion
        #endregion
    }

}
