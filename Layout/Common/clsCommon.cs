using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;



namespace Layout.Common
{
        public class clsCommon
        {
            #region CommonMsg
            public const string UIDNotProvided = "please provide login credentials";
            public const string UIDNotExist = "invalid credential";
            public const string NotValidParentUID = "Please provide valid parent login credential.";
            public const string NotValidStudentUID = "Please provide valid student login credential.";

            public const string recordSave = "record saved successfully";
            public const string recordNotSave = "error while saving record! Please re-try";
            public const string recordNotUpdate = "error while updating record! Please re-try";

            public const string dataExist = "record already exist";
            public const string dataNotExist = "record not exist";

            public const string recordUpdate = "record updated successfully";

            public const string SchoolSISPassportInfoNotAvaialable = "Emirates Id and Passport information not available to update.";
            public const string recordDeleted = "record deleted successfully";

            public const string recordUsedInOthersEntity = "can't be deleted because it is in use by some other records";

            public const string recordDuplicate = "duplicate record ! can't update";

            public const string recordDeleteConfirmation = "are you sure you want to delete this record";
            public const string AssignStudyLeaveSuccess = "Study leave assigned successfully.";
            public const string SendAbsentSMSSuccessMsz = "Absent SMS sent to parent(s)";
            public const string SendAbsentSMSErrorMsz = "Absent SMS not sent..!!";
            public const string notAuthorize = " You are not authorize for this task";
            public const string BlankDataInDefineSENIndicator = "No data has been entered..!!";
            //    public static List<SelectListItem> HoliDayType = new List<SelectListItem>()
            //{
            //    new SelectListItem() {Text="Holiday", Value="Holiday"},
            //    new SelectListItem() { Text="Non-InstructionalDay", Value="Non-InstructionalDay"},
            //    };
            public static readonly string[] HolidayType = { "Holiday", "Non-Instructional Day" };
            public const string ApplicationIssue = "Please contact system administrator";
            #endregion

            public static string SessionId = Convert.ToString(ConfigurationManager.AppSettings["currentsession"]);
            public static string CurSession = Convert.ToString(ConfigurationManager.AppSettings["currentsession"]);
            public static string StudentPassVisaImages = Convert.ToString(ConfigurationManager.AppSettings["StudentPassVisaImages"]);
            public static string StudentPhoto = Convert.ToString(ConfigurationManager.AppSettings["StudentPhoto"]);
            public static string SmsSchoolName = Convert.ToString(ConfigurationManager.AppSettings["smsschoolname"]);


            public class SyllabusMsg
            {
                public const string chapterUpdate = "record updated successfully";
                public const string chapterUpdateWithDuplicateRecord = "Duplicate record ! Can't update Chapter {0}";
                public const string chapterDelete = "record deleted successfully";
                public const string checkChapterDependency = "Chapter cannot be deleted because it is in use by some records";
                public const string chapterDeleteConfirmation = "Are you sure you want to delete this Chapter";

                public const string topicUpdate = "record updated successfully";
                public const string topicUpdateWithDuplicateRecord = "Duplicate record ! Can't update Topic {0}";
                public const string topicDelete = "record deleted successfully";
                public const string checkTopicDependency = "Topic cannot be deleted because it is in use by some records";
                public const string topicDeleteConfirmation = "Are you sure you want to delete this topic";

                public const string subTopicUpdate = "record updated successfully";
                public const string subTopicUpdateWithDuplicateRecord = "Duplicate record ! Can't update Sub Topic {0}";
                public const string subTopicDelete = "record deleted successfully";
                public const string checkSubTopicDependency = "Sub topic cannot be deleted because it is in use by some records";
                public const string subTopicDeleteConfirmation = "Are you sure you want to delete this sub topic";
            }
            public class EmailModel
            {
                public string To { get; set; }
                public string Subject { get; set; }
                public string BodyContent { get; set; }
                public string From { get; set; }
            }

            /// <summary>
            /// The send email.
            /// As parameter pass an object of Email class with following properties 
            /// To : As recipient,
            /// Subject :Subject of email,
            /// BodyContent : Main Content
            /// </summary>
            /// <param name="email"></param>
            /// <returns></returns>
            public static bool SendEMail(EmailModel email)
            {
                bool isMessageSent = false;
               // Logger logger = null;
                string EmailFrom = string.Empty;
                if (string.IsNullOrEmpty(email.From))
                {
                    EmailFrom = ConfigurationManager.AppSettings["Email"].ToString();
                }
                else
                { EmailFrom = email.From; }

                //EmailFrom = ConfigurationManager.AppSettings["AdmissionEmail"];
                try
                {
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("127.0.0.1");
                    //smtp.Host = "127.0.0.1";
                    //smtp.Port = 587;
                    var mail = new System.Net.Mail.MailMessage(EmailFrom, email.To.Trim());
                    mail.Subject = email.Subject;
                    mail.Body = email.BodyContent;
                    mail.IsBodyHtml = true;
                    smtp.Send(mail);
                    isMessageSent = true;
                }
                catch (Exception)
                {
                    isMessageSent = false;
                    //logger.Error(ex, "Error in sending email to" + email.To);
                }
                return isMessageSent;
            }

            public static bool SendEMailViaZoho(EmailModel email)
            {
                bool isMessageSent = false;
                //Logger logger = null;
                try
                {
                    MailMessage mailMsg = new MailMessage();

                    string EmailFrom = string.Empty;
                    if (string.IsNullOrEmpty(email.From))
                        EmailFrom = ConfigurationManager.AppSettings["AdmissionEmail"];
                    else
                        EmailFrom = email.From;
                    // To
                    mailMsg.To.Add(new MailAddress(email.To));
                    //mailMsg.From = new MailAddress("abhishekpandey@iycworld.net", "Abhishek Pandey");
                    mailMsg.From = new MailAddress(EmailFrom);

                    // Subject and multipart/alternative Body
                    mailMsg.Subject = email.Subject;//"Test goodbooks smtp mail service";
                    mailMsg.Body = email.BodyContent;
                    mailMsg.IsBodyHtml = true;
                    // Init SmtpClient and send
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.zoho.com"; // We use gmail as our smtp client
                    smtpClient.Credentials = new NetworkCredential("abcmailtest@zoho.com", "Eduxgen@1", "");
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Send(mailMsg);
                    isMessageSent = true;
                }
                catch (Exception ex)
                {
                    isMessageSent = false;
                  //  logger.Error(ex, "Error in sending email to" + email.To);
                }
                return isMessageSent;
            }

            public static string GetQueryForPaging(string query, int pageSize, int pageIndex)
            {

                string strQuery = string.Empty;
                strQuery = string.Format(@" 
                                        DECLARE	 
                                        @PageNumber INT,
                                        @FirstRow INT,
                                        @LastRow INT,
                                        @Pageindex int,
                                        @PageSize int 
                                        SET @PageSize='{0}'
                                        SET @Pageindex='{1}'
                                        SET  @PageNumber = @Pageindex
                                        SELECT	@FirstRow = ( @PageNumber - 1) * @PageSize + 1,
                                        @LastRow = (@PageNumber - 1) * @PageSize + @PageSize ;
                                        WITH RecordList  AS
                                        ( 
                                          {2}
                                        )
                                        SELECT	*
                                        FROM	 RecordList
                                        WHERE	RowNumber BETWEEN @FirstRow AND @LastRow 
                                        Order By FeesPaidDate,FormNo      
                                    ", pageSize, pageIndex, query);
                return strQuery;

            }

            public static string SendInstantSMS(string _mobileNo, string _MessageText)
            {
                string inputParam = string.Empty;
                string resultmsg = string.Empty;

                string victaMindUserId = ConfigurationManager.AppSettings["SMSUID"].Trim();
                string victaPwd = ConfigurationManager.AppSettings["SMSPWD"].Trim();
                string victasenderid = ConfigurationManager.AppSettings["SMSClientID"].Trim();


                StreamReader sReader = null;
                HttpWebRequest request = null;
                HttpWebResponse response = null;
                try
                {
                    if (!string.IsNullOrEmpty(_mobileNo) && !string.IsNullOrEmpty(_MessageText))
                    {

                        inputParam = string.Format(@"https://apiw.me.synapselive.com/push.aspx?user={0}&pass={1}&senderid={2}&mobile={3}&lang=0&message={4}",
                                     victaMindUserId, victaPwd, victasenderid, _mobileNo.Trim(), _MessageText.Trim());
                        request = (HttpWebRequest)WebRequest.Create(inputParam);
                        response = (HttpWebResponse)request.GetResponse();
                        sReader = new StreamReader(response.GetResponseStream());
                        resultmsg = sReader.ReadToEnd();
                        sReader.Close();
                    }
                }
                catch (Exception exce)
                {
                    // throw exce;
                    EmailModel objEmail = new EmailModel();
                    objEmail.BodyContent = exce.GetBaseException().ToString();
                    objEmail.To = ConfigurationManager.AppSettings["supportTeamEmail"].ToString();
                    objEmail.Subject = "Excepetion during sending SMS at DPS Dubai";
                    SendEMail(objEmail);
                }
                return resultmsg;
            }
        }
    }