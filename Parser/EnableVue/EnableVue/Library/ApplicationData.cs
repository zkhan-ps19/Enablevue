using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EnableVue;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using System.Configuration;


namespace Library
{

    #region Application Data
    /// <summary>
    ///  This Object is to be used as main setting information for Service
    /// </summary>

    public static class ApplicationData
    {
        #region removed ver 1.0 Variables/Class
        //public class ApplicationData
        //{
        //    public bool isLoggedIn = false;
        //    public bool folderpathWokring = false;
        //    public bool webUrlWorking = false;
        //}
        #endregion

        class WebAPI_URL
        {
            /*
             http://shahid/RESTfulAWS/apihome/version/
             http://shahid/RESTfulAWS/apihome/login/
             http://shahid/RESTfulAWS/apihome/sendemail/ 
             http://shahid/RESTfulAWS/apihome/content/ 
             */

            public string version;
            public string login;
            public string email;
            public string content;

        }



        #region Local Variables

        //        public static  System.Windows.Forms.Application app;
        public static string API_Version = "1.0";
        public static Setting serviceSettings;
        public static UserToken serviceToken;
        private static WebAPI_URL webURL;

        #region [ver 1.1] new Local Variables

        private static bool _is_FolderPath_correct;

        public static bool Is_FolderPath_correct()
        {
            check_FolderPath();
            return ApplicationData._is_FolderPath_correct;
        }


        public static bool is_WebURL_working;
        public static bool is_Loggedin;

        #endregion

        #endregion


        public static void performCompleteProcess_LoadandCheck()
        {

            serviceSettings = DBCallsManager.getMainSettings();
            LoadURL_Information();
            serviceToken = DBCallsManager.getlastUsedTokenOrUserData();

            check_FolderPath();
            check_WebURL();
            Verify_Login();

        }

        public static void performSettingsProcess_LoadandCheck()
        {
            serviceSettings = DBCallsManager.getMainSettings();
            LoadURL_Information();
            check_FolderPath();
            check_WebURL();
        }

        public static void performSettingProcess_WebURL_LoadandCheck()
        {
            serviceSettings = DBCallsManager.getMainSettings();
            LoadURL_Information();
            check_WebURL();
        }

        public static void performSettingProcess_FolderPath_LoadandCheck()
        {
            serviceSettings = DBCallsManager.getMainSettings();
            // LoadURL_Information();
            check_FolderPath();
        }


        public static void performTokenProcess_LoadandCheck()
        {
            serviceToken = DBCallsManager.getlastUsedTokenOrUserData();
            Verify_Login();

        }

        public static bool CheckAllFlags()
        {
            return (Is_FolderPath_correct() && is_WebURL_working && is_Loggedin);
        }

        #region [ver 1.0] <Removed> Perform different loading each check individualy

        //public static void LoadData(ApplicationData objData, int performchecks = 0)
        //{

        //    if (performchecks == 0) // do complete process
        //    {
        //        performCompleteProcess(objData);
        //    }
        //    else if (performchecks == 1)
        //    {
        //        performSettingsProcess(objData);
        //    }
        //    else if (performchecks == 2)
        //    {
        //        performTokenProcess(objData);
        //    }

        //}

        //private static void performCompleteProcess(ApplicationData appData)
        //{

        //    serviceSettings = DBCallsManager.getMainSettings();
        //    LoadURL_Information();
        //    serviceToken = DBCallsManager.getlastUsedTokenOrUserData();

        //    appData.folderpathWokring = checkFolderPath();
        //    appData.webUrlWorking = checkURLpath();
        //    appData.isLoggedIn = VerifyLogin();

        //}

        //private static void performSettingsProcess(ApplicationData appData)
        //{
        //    serviceSettings = DBCallsManager.getMainSettings();
        //    LoadURL_Information();


        //    appData.webUrlWorking = checkURLpath();
        //    appData.folderpathWokring = checkFolderPath();

        //}

        //private static void performTokenProcess(ApplicationData appData)
        //{
        //    serviceToken = DBCallsManager.getlastUsedTokenOrUserData();
        //    appData.isLoggedIn = VerifyLogin();

        //}

        #endregion

        #region  Load URL parts + Verfying states of Variables

        private static void LoadURL_Information()
        {
            if (serviceSettings == null) return;
            string Url = serviceSettings.weburl;

            if (Url.Contains("apihome"))
            {
                Url = Url.Substring(0, Url.IndexOf("apihome"));
            }
            if (!Url.EndsWith("/"))
            {
                Url += "/";
            }

            webURL = new WebAPI_URL();
            webURL.version = Url + "apihome/version/";
            webURL.login = Url + "apihome/login/";
            webURL.email = Url + "apihome/sendemail/";
            webURL.content = Url + "apihome/content/";
        }


        private static void check_FolderPath()
        {
            try
            {
                if (System.IO.Directory.Exists(serviceSettings.folderpath))
                {
                    _is_FolderPath_correct = true;
                    return;
                }
            }
            catch (Exception ex)
            {

            }
            // if(fold_path)
            _is_FolderPath_correct = false;
        }

        private static void check_WebURL()
        {
            try
            {
                string response = Execute_HttpWebRequest(webURL.version, "GET");
                if (response.Contains("1.0"))
                {
                    is_WebURL_working = true;
                    return;
                }

                UtilityClass.WriteLog_DBandEvent("[URL Version Error] Response From Server : " + response);
            }
            catch (Exception ex)
            {


                UtilityClass.WriteLog_DBandEvent("[URL Exception] Message : " + ex.Message
                                    + Environment.NewLine + " StackTrace : " + ex.StackTrace);
            }
            is_WebURL_working = false;
        }

        private static void Verify_Login()
        {
            try
            {
                var t = "http://schemas.datacontract.org/2004/07/RESTfulAPI";
                string xml = " <User xmlns=\"" + t + "\">"
                                    + "<Password>" + serviceToken.password + "</Password>"
                                    + "<UserName>" + serviceToken.username + "</UserName>"
                               + "</User>";


                string response = Execute_HttpWebRequest(webURL.login, "POST", xml);
                if (!response.ToLower().Contains("username/password"))
                {
                    response = response.Replace("</string>", "");
                    string token = response.Substring(response.LastIndexOf(">") + 1);
                    DBCallsManager.UpdateToken(token);
                    is_Loggedin = true;
                    return;
                }
                else
                {
                    UtilityClass.WriteLog_DBandEvent("[Login Issue ] XMLMessage : " + response);
                    is_Loggedin = false;
                    return;
                }

            }
            catch (Exception ex)
            {
                UtilityClass.WriteLog_DBandEvent("[Login Exception] Message : " + ex.Message
                                + Environment.NewLine + " StackTrace : " + ex.StackTrace);
            }
            is_Loggedin = false;
        }

        #endregion

        #region Public methods for use of other Functions

        public static string UploadContent(string xmlObject)
        {
            return Execute_HttpWebRequest(webURL.content, "POST", xmlObject, true);
        }

        public static string Execute_HttpWebRequest(string uri, string Method, string xmlObject = "", bool includeHeader = false)
        {

            HttpWebRequest req = WebRequest.Create(uri.Trim()) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = Method.ToUpper();
            if (includeHeader)
            {
                req.Headers.Add("evue_token", serviceToken.token);
            }
            if (("POST,PUT").Split(',').Contains(Method.ToUpper()))
            {
                // Console.WriteLine("Enter XML FilePath:");
                // string FilePath = Console.ReadLine();


                byte[] buffer = Encoding.ASCII.GetBytes(xmlObject);
                req.ContentLength = buffer.Length;
                req.ContentType = "text/xml";
                Stream PostData = req.GetRequestStream();
                PostData.Write(buffer, 0, buffer.Length);
                PostData.Close();

            }

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;


            Encoding enc = System.Text.Encoding.GetEncoding(1252);
            StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);
            //resp.GetResponseStream() StreamReader ls = new StreamReader(
            return loResponseStream.ReadToEnd();
        }

        public static bool SendMailData(string subject, string Body)
        {
            try
            {

                string pcName = System.Environment.MachineName;

                string xml = "<Email xmlns=\"http://schemas.datacontract.org/2004/07/RESTfulAPI\">"
                                + "<Body>" + HttpUtility.HtmlEncode(Body) + "</Body>"
                                + "<Subject>" + subject + "[" + pcName + "]</Subject></Email>";

                string response = Execute_HttpWebRequest(webURL.email, "POST", xml, true);
                if (!response.ToLower().Contains("not sent"))
                {
                    return true;
                }
                UtilityClass.WriteLog_DBandEvent("[URL Mail Error ] Response From Server : " + response);
            }
            catch (Exception ex)
            {
                UtilityClass.WriteLog_DBandEvent("[URL Exception] Message : " + ex.Message
                                + Environment.NewLine + " StackTrace : " + ex.StackTrace);
            }
            return false;
        }

        public static void sendExceptionEmail(Exception ex, string message = "Exception in Desktop Application")
        {
            string body = "<div style=\"width: 450px; height: 100px; padding: 1px 1px 6px 40px;\">"
                + "<h3>" + message + "</h3>"
                + "<h5>Exception Details</h5>"
                + "<table border=\"1\" >"
                + "<tr>"
                + "<td><b>Message</b></td>" + "<td>" + ex.Message + "</td>"
                + "</tr>"
                + "<tr>"
                + "<td><b>Stack Trace</b></td>" + "<td>" + ex.StackTrace + "</td>"
                + "</tr>"
                + "<tr>"
                + "<td><b>Inner Exception</b></td>" + "<td>" + ex.InnerException + "</td>"
                + "</tr>"
                + "</table>";



            sendAppConfigMail(body);
        }
        /*     public static void sendMail(string body)
             {

                 sendAppConfigMail(body);


            
                  * 
                  * 
                 //  InsertSimple_DBLog("EnableVueApp " + body);

                 // return;
                 MailMessage mail = new MailMessage("enablevue.application@gmail.com", "hsiddique@powersoft19.com");
                 mail.From = new MailAddress("enablevue.application@gmail.com", "EV Application");


                 string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                 string name = Path.GetFileName(codeBase);

                 //mail.Subject = "Error in ev  " + name + " [" + pcName + "]";
                 //mail.Body = " \n\r  file path " + codeBase + body;
                 string pcName = System.Environment.MachineName;
                 mail.Subject = "Message from Application [" + pcName + "]";
                 mail.Body = "Application Directory : " + codeBase + System.Environment.NewLine + " Message :" + System.Environment.NewLine + body;


                 NetworkCredential cred = new NetworkCredential("enablevue.application@gmail.com", "serviceapp");
                 //create the smtp client...these settings are for gmail 
                 SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                 smtp.UseDefaultCredentials = false;
                 smtp.EnableSsl = true;

                 //credentials (username, pass of sending account) assigned here 
                 smtp.Credentials = cred;
                 smtp.Port = 587;

                 //let her rip 
                 smtp.Send(mail);
             
            
                  * 
                  * 
                  * 
             
             }*/

        public static void sendAppConfigMail(string body)
        {
            string mailto = System.Configuration.ConfigurationManager.AppSettings["SendMailTo"];
            string smtpPassword = System.Configuration.ConfigurationManager.AppSettings["smtpPassword"];

            MailMessage mail = new MailMessage();
            mail.To.Add(mailto);

            string pcName = System.Environment.MachineName;

            mail.Subject = "[EnableVue Desktop App] Application message [" + pcName + "]";
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();

            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(mail.From.Address, smtpPassword);

            //let her rip 
            smtp.Send(mail);
        }
        #endregion

    }

    #endregion

}
