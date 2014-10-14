using System;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using System.Net.Mail;
using BLL;


enum ReplaceAsciiChar
{
    AgileEnterKey = 10,
    NimbleEnterkey = 13
}

public class EVueSharedClass
{

    public static Double ScalingValue = 0.0001525;

    public static long isValidNumber(string input)
    {
        try
        {
            long isNumber = 0;
            long.TryParse(input, out isNumber);

            return isNumber;
        }
        catch
        {
            return 0;
        }
    }

    public static bool isValidEmail(string inputEmail)
    {
        try
        {
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}" + "\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\" + ".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
            {
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static bool isValidIPAddress(string inputIPAddress)
    {
        try
        {
            string strRegex = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)(-((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?))?$";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(inputIPAddress))
            {
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    //public static byte[] CheckMSB_order(byte[] array)
    //{
    //    if (BitConverter.IsLittleEndian)
    //        Array.Reverse(array, 0, array.Length);

    //    return array;
    //}

    //public static void SET_ScalingValue(HttpSessionState Session, Double R_ScalingValue)
    //{
    //    if (R_ScalingValue <= 0)
    //    { 
    //        Session["ScalingValue"] = ScalingValue; 
    //    }
    //    else
    //    {
    //        Session["ScalingValue"] = R_ScalingValue;
    //        ScalingValue = R_ScalingValue;
    //    }
    //}

    //public static String CheckMSB_order_StringScaledValue(byte[] array)
    //{
    //    string a = (BitConverter.ToUInt16(CheckMSB_order(array), 0) * ScalingValue).ToString();

    //    return a.Substring(0, a.IndexOf(".") + 2);
    //}

    public static void ExportToCSV(string strFileName, string contents)
    {
        System.Web.HttpResponse objResponse = System.Web.HttpContext.Current.Response;
        objResponse.Clear();
        objResponse.Charset = string.Empty;
        objResponse.ContentType = "application/excel";
        System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);
        objResponse.Write(contents);
        objResponse.End();
        objResponse.Flush();
    }

    public static bool CheckLoginUser(Model.UserInfo objUser)
    {
        string strApp = System.Web.HttpContext.Current.Application["loginUsers"].ToString();
        string[] strAppArray = strApp.Split(',');

        //If Login User are more than 1
        if (strAppArray.Length > 2)
        {
            System.Web.HttpRequest objRequest = System.Web.HttpContext.Current.Request;

            //Iterate array from 0 to Last -1,because is the latest Login User
            for (int i = 0; i < strAppArray.Length - 2; i++)
            {
                //If UserName and Browser are same then clear its session
                if (objUser.Username == strAppArray[i].Substring(0, strAppArray[i].IndexOf("_")) && objRequest.Browser.Browser == strAppArray[i].Substring(strAppArray[i].LastIndexOf("_") + 1))
                {
                    //Application["loginUsers"] = strApp[strApp.Length - 2] + ",";
                    System.Web.HttpContext.Current.Application["loginUsers"] = strApp.Replace(objUser.Username + "_" + objRequest.UserHostAddress + "_" + objRequest.Browser.Browser + ",", "");

                    System.Web.HttpContext.Current.Session.Abandon();
                    System.Web.HttpContext.Current.Session.Clear();

                    System.Web.HttpContext.Current.Session["loginUser"] = null;

                    return false;
                }
            }
        }

        return true;
    }

    public static bool SendEmail(string toEmailAddress, string subject, string body)
    {
        try
        {
            System.Collections.Generic.IList<Model.SmtpsettingInfo> lstSettingInfo = Admin.Smtpsetting.SelectAll();

            if (lstSettingInfo.Count == 0)
                return false;

            MailMessage objMail = new MailMessage(lstSettingInfo[0].Pmusername, toEmailAddress);
            objMail.Priority = MailPriority.High;
            objMail.IsBodyHtml = true;

            objMail.Subject = subject;
            objMail.Body = body;

            SmtpClient client = new SmtpClient();

            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(lstSettingInfo[0].Pmusername, lstSettingInfo[0].Pmpasswrd);
            client.Host = lstSettingInfo[0].Pmhost;
            client.Port = lstSettingInfo[0].Pmport;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = lstSettingInfo[0].Pmsecure;

            client.Send(objMail);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static bool SendEmail(string toEmailAddress, string subject, string body, string host, int port, string userName, string password, bool isSecure)
    {
        try
        {
            MailMessage objMail = new MailMessage(userName, toEmailAddress);
            objMail.Priority = MailPriority.High;
            objMail.IsBodyHtml = true;

            objMail.Subject = subject;
            objMail.Body = body;

            SmtpClient client = new SmtpClient();

            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(userName, password);
            client.Host = host;
            client.Port = port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = isSecure;

            client.Send(objMail);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Send Error Email to given address
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="strTo">
    /// it is optional, send to default address, if address not given
    /// </param>
    /// ''' <param name="strFrom">
    /// it is optional, send from default address, if address not given
    /// </param>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    //public static string SendEmail(string strSubject, string strBody, string strTo = "srasul@powersoft19.com;", string strFrom = "admin@eRM.com")
    //{
    //    string strSMTPSetting = HostSettings.Item("SMTPServer").ToString;

    //    if (!string.IsNullOrEmpty(strSMTPSetting))
    //    {
    //        return Mail.SendMail(strFrom, strTo, "", "", MailPriority.Normal, strSubject, MailFormat.Text, System.Text.Encoding.UTF8, "<b style='font-family:verdana,aria; font-size: 10pt; font-weight:normal;'>" + strBody + "</b>", "",
    //        strSMTPSetting, HostSettings.Item("SMTPAuthentication").ToString, HostSettings.Item("SMTPUsername").ToString, HostSettings.Item("SMTPPassword").ToString, (HostSettings.Item("SMTPEnableSSL").ToString == "N" ? false : true));
    //    }

    //    return "-1";
    //}

    //public static void SendEmail(string strSubject, string strBody, string strTo, string strFrom, string strCc, string strBcc)
    //{
    //    string strSMTPSetting = HostSettings.Item("SMTPServer").ToString;

    //    if (!string.IsNullOrEmpty(strSMTPSetting))
    //    {
    //        string strMessage = Mail.SendMail(strFrom, strTo, strCc, strBcc, MailPriority.Normal, strSubject, MailFormat.Text, System.Text.Encoding.UTF8, strBody, "",
    //        strSMTPSetting, HostSettings.Item("SMTPAuthentication").ToString, HostSettings.Item("SMTPUsername").ToString, HostSettings.Item("SMTPPassword").ToString, (HostSettings.Item("SMTPEnableSSL").ToString == "N" ? false : true));
    //    }
    //}

    //public static string CleanWordHtml(string html)
    //{
    //    StringCollection sc = new StringCollection();
    //    // get rid of unnecessary tag spans (comments and title)
    //    sc.Add("<!--(\\w|\\W)+?-->");
    //    sc.Add("<title>(\\w|\\W)+?</title>");
    //    // Get rid of classes and styles
    //    sc.Add("\\s?class=\\w+");
    //    sc.Add("\\s+style='[^']+'");
    //    // Get rid of unnecessary tags
    //    sc.Add("<(meta|link|/?o:|/?style|/?div|/?st\\d|/?head|/?html|body|/?body|/?span|!\\[)[^>]*?>");
    //    // Get rid of empty paragraph tags
    //    sc.Add("(<[^>]+>)+&nbsp;(</\\w+>)+");
    //    // remove bizarre v: element attached to <img> tag
    //    sc.Add("\\s+v:\\w+=\"[^\"]+\"");
    //    // remove extra lines
    //    sc.Add("(\\n\\r){2,}");
    //    sc.Add(Environment.NewLine);
    //    //html tags
    //    sc.Add("<[^>]*>");

    //    sc.Add("&#160;");
    //    //sc.Add("&nbsp;")

    //    sc.Add("  ");

    //    //remove Bullets
    //    sc.Add("•");

    //    foreach (string s in sc)
    //    {
    //        html = Regex.Replace(html, s, "", RegexOptions.IgnoreCase);
    //    }

    //    return html.Replace("&nbsp;", " ");

    //    //Return html
    //}

    //public static void InsertLog(string actionPerformed, int userPerformedAction, string details, string comments)
    //{
    //    try
    //    {
    //        eRMLogController objLogCtrl = new eRMLogController();
    //        eRMLogInfo objLogInfo = new eRMLogInfo();

    //        objLogInfo.ActionPerformed = actionPerformed;
    //        objLogInfo.Comments = comments;
    //        objLogInfo.Details = details;
    //        objLogInfo.LocalClientTime = DateTime.Now;
    //        objLogInfo.UserPerformedAction = userPerformedAction;

    //        objLogCtrl.InserteRMLog(objLogInfo);
    //    }
    //    catch
    //    {
    //    }
    //}

    //public static void InsertHistory(int ProjectId, int RequirementId, string ReqId, string Version, string Action, int UserId, string Details)
    //{
    //    eRMProject.eRMHistoryController objHistoryCtrl = new eRMProject.eRMHistoryController();
    //    eRMProject.eRMHistoryInfo objHistoryInfo = new eRMProject.eRMHistoryInfo();

    //    objHistoryInfo.ProjectID = ProjectId;
    //    objHistoryInfo.RequirementID = RequirementId;
    //    objHistoryInfo.ReqID = ReqId;
    //    objHistoryInfo.Version = Version;
    //    objHistoryInfo.ActionPerformed = Action;
    //    objHistoryInfo.Detail = Details;
    //    objHistoryInfo.LocalClientTime = DateTime.Now;
    //    objHistoryInfo.UserId = UserId;

    //    objHistoryCtrl.InserteRMHistory(objHistoryInfo);
    //}

    ///// -----------------------------------------------------------------------------
    ///// <summary>
    ///// Is this Application Expire or not
    ///// </summary>
    ///// <remarks>
    ///// </remarks>
    ///// <history>
    ///// </history>
    ///// -----------------------------------------------------------------------------
    //public static bool IsLicenseExpire()
    //{

    //    eRMSettingsController objSettinsCtrl = new eRMSettingsController();
    //    eRMSettingsInfo objSettinInof = objSettinsCtrl.SelectPLMReqSettingsLicense();
    //    DateTime objSdate = new DateTime();
    //    System.Web.SessionState.HttpSessionState objSession = System.Web.HttpContext.Current.Session;

    //    if (DateTime.TryParse(DASEncryption.Decrypt(objSettinInof.StartingDate), objSdate))
    //    {
    //        TimeSpan ts = DateTime.Now.Subtract(objSdate);

    //        if (ts.Days > int.Parse(DASEncryption.Decrypt(objSettinInof.Duration)))
    //        {
    //            objSession("isLicenseExpire") = true;
    //            return true;
    //        }
    //        else
    //        {
    //            objSession("isLicenseExpire") = false;
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        objSession("isLicenseExpire") = true;
    //        return true;
    //    }
    //}

    ///// -----------------------------------------------------------------------------
    ///// <summary>
    ///// Get Remaining Days License Duration
    ///// </summary>
    ///// <remarks>
    ///// </remarks>
    ///// <history>
    ///// </history>
    ///// -----------------------------------------------------------------------------
    //public static int GetLicenseDuration()
    //{
    //    eRMSettingsController objSettinsCtrl = new eRMSettingsController();
    //    eRMSettingsInfo objSettinInof = objSettinsCtrl.SelectPLMReqSettingsLicense();
    //    DateTime objSdate = new DateTime();
    //    System.Web.SessionState.HttpSessionState objSession = System.Web.HttpContext.Current.Session;

    //    if (DateTime.TryParse(DASEncryption.Decrypt(objSettinInof.StartingDate), objSdate))
    //    {
    //        TimeSpan ts = DateTime.Now.Subtract(objSdate);
    //        return int.Parse(DASEncryption.Decrypt(objSettinInof.Duration)) - ts.Days;
    //    }
    //}

    //public static eRMUserManagementInfo SessionValidate(int portalId, string userName, PortalSettings settings)
    //{
    //    System.Web.HttpResponse objResponse = System.Web.HttpContext.Current.Response;
    //    System.Web.HttpRequest objRequest = System.Web.HttpContext.Current.Request;
    //    System.Web.SessionState.HttpSessionState objSession = System.Web.HttpContext.Current.Session;

    //    eRMUserManagementInfo objUserManageInfo = (eRMUserManagementInfo)objSession("loginUser");

    //    if (objUserManageInfo == null)
    //    {
    //        DataCache.ClearUserCache(portalId, userName);
    //        PortalSecurity objPortalSecurity = new PortalSecurity();
    //        objPortalSecurity.SignOut();

    //        string returnUrl = objRequest.RawUrl;
    //        TabController objTabCtrl = new TabController();
    //        objResponse.Redirect("http://" + GetAppUrl() + "/LoginPage/tabid/" + objTabCtrl.GetTabByName("Login Page", 0).TabID + "/Exp/1/Default.aspx?returnurl=" + HttpUtility.UrlEncode(returnUrl), true);
    //    }

    //    return objUserManageInfo;
    //}

    //public static void AddPriority(int projectId, int loginUserId, string name, string desc, DateTime createdDate)
    //{
    //    eRMPriorityController objPrtCtrl = new eRMPriorityController();
    //    eRMPriorityInfo objPrtInfo = new eRMPriorityInfo(-1, name, desc, true, false, createdDate, null, loginUserId, projectId);

    //    objPrtCtrl.InserteRMPriority(objPrtInfo);
    //}

    //public static int AddVotingFormat(int projectId, int loginUserId, string name, DateTime createdDate, string strChoices)
    //{
    //    eRMProject.eRMAnswerStyleController objAnsStyCtrl = new eRMProject.eRMAnswerStyleController();
    //    eRMProject.eRMAnswerStyleInfo objAnsStyInfo = new eRMProject.eRMAnswerStyleInfo(-1, name, createdDate, true, loginUserId, null, projectId);

    //    return objAnsStyCtrl.InserteRMAnswerStyle(objAnsStyInfo, strChoices);
    //}

    //public static void AddVotingChoice(int styleId, string name, bool allowComment)
    //{
    //    eRMProject.eRMSubAnswerStyleController objSubAnsStyCtrl = new eRMProject.eRMSubAnswerStyleController();
    //    eRMProject.eRMSubAnswerStyleInfo objSubAnsStyInfo = new eRMProject.eRMSubAnswerStyleInfo();

    //    objSubAnsStyInfo.Name = name;
    //    objSubAnsStyInfo.AnswerStyleID = styleId;
    //    objSubAnsStyInfo.AllowComment = allowComment;

    //    objSubAnsStyCtrl.InserteRMSubAnswerStyle(objSubAnsStyInfo);
    //}

    //public static void AddProjectTeam(string name, string desc, long projectId, int loginUserId, int user, DateTime createdDate)
    //{
    //    eRMProject.eRMProjectTeamController objTeamCtrl = new eRMProject.eRMProjectTeamController();
    //    objTeamCtrl.InserteRMProjectTeam(new eRMProject.eRMProjectTeamInfo(-1, name, desc, createdDate, DotNetNuke.Common.Utilities.Null.NullDate, loginUserId, projectId), user);
    //}

    //public static string GetRequirementStatus(int ReqId)
    //{
    //    //Dim objReqWFlowDetailCtrl As New eRMProject.eRMReqWorkFlowDetailController
    //    //Dim lstReqWFlowDetailInfo As List(Of eRMProject.eRMReqWorkflowDetailInfo) = objReqWFlowDetailCtrl.SelectAllWhereeRMReqWorkflowDetails("RequirementsID = " & ReqId & " and IsApproved = 0", "StepOrder")

    //    //If lstReqWFlowDetailInfo.Count > 0 Then
    //    //    Return lstReqWFlowDetailInfo(0).StepName
    //    //End If

    //    return null;
    //}

    //public static string GetSearchQuery(string strQuery)
    //{
    //    string strGenQuery = "";

    //    //split query string as space and convert to query for db
    //    string[] strArray = strQuery.Split(' ');
    //    for (int i = 0; i <= strArray.Length - 1; i++)
    //    {
    //        if (i == 0)
    //        {
    //            strGenQuery = "{0} like '%" + strArray(i);
    //        }
    //        else
    //        {
    //            strGenQuery += "%' and {0} like '%" + strArray(i);
    //        }
    //    }

    //    strGenQuery += "%'";

    //    return strGenQuery;
    //}

    ////Private Function PopulateRights(ByVal groupId As Integer, ByVal isLogin As Boolean) As Boolean
    ////    Dim objPageRightsCtrl As New eRMPagesController
    ////    Dim objGroupRightsCtrl As New eRMGroupRightsController
    ////    Dim objGroupRightsInfo As eRMGroupRightsInfo
    ////    Dim rightArray As Integer() = New Integer(6) {}
    ////    Dim viewRightArray As Integer() = New Integer(7) {}

    ////    objGroupRightsInfo = objGroupRightsCtrl.SelectAllWhereeRMGroupRightss("PagesId = " & objPageRightsCtrl.SelectAllWhereeRMPagess("Name = 'Project'", "Name")(0).PagesId & "and GroupId = " & groupId, "GroupId")(0)
    ////    rightArray(0) = objGroupRightsInfo.IsAddPermitted
    ////    viewRightArray(0) = objGroupRightsInfo.IsViewPermitted
    ////    objGroupRightsInfo = objGroupRightsCtrl.SelectAllWhereeRMGroupRightss("PagesId = " & objPageRightsCtrl.SelectAllWhereeRMPagess("Name = 'Requirements Types'", "Name")(0).PagesId & "and GroupId = " & groupId, "GroupId")(0)
    ////    rightArray(1) = objGroupRightsInfo.IsAddPermitted
    ////    viewRightArray(1) = objGroupRightsInfo.IsViewPermitted
    ////    objGroupRightsInfo = objGroupRightsCtrl.SelectAllWhereeRMGroupRightss("PagesId = " & objPageRightsCtrl.SelectAllWhereeRMPagess("Name = 'Module'", "Name")(0).PagesId & "and GroupId = " & groupId, "GroupId")(0)
    ////    rightArray(2) = objGroupRightsInfo.IsAddPermitted
    ////    viewRightArray(2) = objGroupRightsInfo.IsViewPermitted
    ////    objGroupRightsInfo = objGroupRightsCtrl.SelectAllWhereeRMGroupRightss("PagesId = " & objPageRightsCtrl.SelectAllWhereeRMPagess("Name = 'Requirement Management'", "Name")(0).PagesId & "and GroupId = " & groupId, "GroupId")(0)
    ////    rightArray(3) = objGroupRightsInfo.IsAddPermitted
    ////    rightArray(6) = objGroupRightsInfo.IsCollabrate
    ////    viewRightArray(3) = objGroupRightsInfo.IsViewPermitted
    ////    objGroupRightsInfo = objGroupRightsCtrl.SelectAllWhereeRMGroupRightss("PagesId = " & objPageRightsCtrl.SelectAllWhereeRMPagess("Name = 'Group Management'", "Name")(0).PagesId & "and GroupId = " & groupId, "GroupId")(0)
    ////    rightArray(4) = objGroupRightsInfo.IsAddPermitted
    ////    viewRightArray(4) = objGroupRightsInfo.IsViewPermitted
    ////    objGroupRightsInfo = objGroupRightsCtrl.SelectAllWhereeRMGroupRightss("PagesId = " & objPageRightsCtrl.SelectAllWhereeRMPagess("Name = 'User Management'", "Name")(0).PagesId & "and GroupId = " & groupId, "GroupId")(0)
    ////    rightArray(5) = objGroupRightsInfo.IsAddPermitted
    ////    viewRightArray(5) = objGroupRightsInfo.IsViewPermitted

    ////    Dim objSession As System.Web.SessionState.HttpSessionState = System.Web.HttpContext.Current.Session

    ////    objSession("userRights") = rightArray
    ////    objSession("viewRightArray") = viewRightArray

    ////    'if use not have any view rights
    ////    If isLogin Then
    ////        If viewRightArray(0) = False AndAlso viewRightArray(1) = False AndAlso viewRightArray(2) = False AndAlso viewRightArray(3) = False AndAlso viewRightArray(4) = False AndAlso viewRightArray(5) = False AndAlso objGroupRightsCtrl.CountAllWhereeRMGroupRights("PagesId = " & objPageRightsCtrl.SelectAllWhereeRMPagess("Name = 'Document Management'", "Name")(0).PagesId & "and IsViewPermitted = 1 and  GroupId = " & groupId) = 0 AndAlso objGroupRightsCtrl.CountAllWhereeRMGroupRights("PagesId = " & objPageRightsCtrl.SelectAllWhereeRMPagess("Name = 'Version Management'", "Name")(0).PagesId & "and IsViewPermitted = 1 and  GroupId = " & groupId) = 0 AndAlso objGroupRightsCtrl.CountAllWhereeRMGroupRights("PagesId = " & objPageRightsCtrl.SelectAllWhereeRMPagess("Name = 'Change Password'", "Name")(0).PagesId & "and IsViewPermitted = 1 and  GroupId = " & groupId) = 0 Then
    ////            lbSession.Text = "You don't have any rights yet. Please contact administrator for details."
    ////            Return False
    ////        End If
    ////    End If

    ////    Return True
    ////End Function

    //public static string GeneratePassword(int length, int numberOfNonAlphanumericCharacters)
    //{
    //    //Make sure length and numberOfNonAlphanumericCharacters are valid....
    //    if (((length < 1) || (length > 128)))
    //    {
    //        throw new ArgumentException("Membership_password_length_incorrect");
    //    }

    //    if (((numberOfNonAlphanumericCharacters > length) || (numberOfNonAlphanumericCharacters < 0)))
    //    {
    //        throw new ArgumentException("Membership_min_required_non_alphanumeric_characters_incorrect");
    //    }

    //    while (true)
    //    {
    //        int i = 0;
    //        int nonANcount = 0;
    //        byte[] buffer1 = new byte[length];

    //        //chPassword contains the password's characters as it's built up
    //        char[] chPassword = new char[length];

    //        //chPunctionations contains the list of legal non-alphanumeric characters
    //        char[] chPunctuations = "!@@$%^^*()_-+=[{]};:>|./?".ToCharArray();

    //        //Get a cryptographically strong series of bytes
    //        System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
    //        rng.GetBytes(buffer1);

    //        for (i = 0; i <= length - 1; i++)
    //        {
    //            //Convert each byte into its representative character
    //            int rndChr = (buffer1(i) % 87);
    //            if ((rndChr < 10))
    //            {
    //                chPassword(i) = Convert.ToChar(Convert.ToUInt16(48 + rndChr));
    //            }
    //            else
    //            {
    //                if ((rndChr < 36))
    //                {
    //                    chPassword(i) = Convert.ToChar(Convert.ToUInt16((65 + rndChr) - 10));
    //                }
    //                else
    //                {
    //                    if ((rndChr < 62))
    //                    {
    //                        chPassword(i) = Convert.ToChar(Convert.ToUInt16((97 + rndChr) - 36));
    //                    }
    //                    else
    //                    {
    //                        chPassword(i) = chPunctuations(rndChr - 62);
    //                        nonANcount += 1;
    //                    }
    //                }
    //            }
    //        }

    //        if (nonANcount < numberOfNonAlphanumericCharacters)
    //        {
    //            Random rndNumber = new Random();
    //            for (i = 0; i <= (numberOfNonAlphanumericCharacters - nonANcount) - 1; i++)
    //            {
    //                int passwordPos = 0;
    //                do
    //                {
    //                    passwordPos = rndNumber.Next(0, length);
    //                } while (!char.IsLetterOrDigit(chPassword(passwordPos)));
    //                chPassword(passwordPos) = chPunctuations(rndNumber.Next(0, chPunctuations.Length));
    //            }
    //        }

    //        return new string(chPassword);
    //    }
    //}

    //public static string MachineName
    //{
    //    get
    //    {
    //        //Return "shahid"
    //        System.Web.HttpRequest objRequest = System.Web.HttpContext.Current.Request;
    //        return objRequest.ServerVariables("Server_Name");
    //    }
    //}

    //public static object GetAppUrl()
    //{
    //    System.Web.HttpRequest objRequest = System.Web.HttpContext.Current.Request;
    //    return objRequest.ServerVariables("Server_Name") + (objRequest.ApplicationPath == "/" ? "" : objRequest.ApplicationPath);
    //}

    //public static string AppName
    //{
    //    get { return "eRM"; }
    //}

    ////Public Shared Function ReplaceNewLineWithHtmlBR(ByVal stString As String) As String
    ////    If stString.Contains(Chr(ReplaceAsciiChar.AgileEnterKey)) Then
    ////        Return stString.Replace(Chr(ReplaceAsciiChar.AgileEnterKey), "<br>")
    ////    Else
    ////        Return stString.Replace(Chr(ReplaceAsciiChar.NimbleEnterkey), "<br>")
    ////    End If
    ////End Function

    //public static eRMProject.eRMProjectInfo CheckProjectRights(int loginUserId, int loginGroupId, int projectid)
    //{
    //    eRMProject.eRMProjectController objProjectCtrl = new eRMProject.eRMProjectController();
    //    eRMProject.eRMProjectInfo objPrjInfo = objProjectCtrl.CheckProjectSecurityRights(loginUserId, loginGroupId, projectid);

    //    if (objPrjInfo == null)
    //    {
    //        System.Web.HttpResponse objResponse = System.Web.HttpContext.Current.Response;
    //        System.Web.SessionState.HttpSessionState objSession = System.Web.HttpContext.Current.Session;

    //        objResponse.Redirect(objSession("defaultPage").ToString(), true);
    //    }
    //    else
    //    {
    //        return objPrjInfo;
    //    }
    //}

    //public static string ReplaceNewLineWithHtmlBR(string stString)
    //{
    //    //' Create two different encodings.
    //    //Dim ascii As Encoding = Encoding.ASCII
    //    //Dim [unicode] As Encoding = Encoding.Unicode

    //    //' Convert the string into a byte[].
    //    //Dim unicodeBytes As Byte() = [unicode].GetBytes(stString)

    //    //' Perform the conversion from one encoding to the other.
    //    //Dim asciiBytes As Byte() = Encoding.Convert([unicode], ascii, unicodeBytes)

    //    //' Convert the new byte[] into a char[] and then into a string.
    //    //' This is a slightly different approach to converting to illustrate
    //    //' the use of GetCharCount/GetChars.
    //    //Dim asciiChars(ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)) As Char
    //    //ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0)
    //    //Dim asciiString As New String(asciiChars)

    //    if (stString.Contains(Strings.Chr(ReplaceAsciiChar.AgileEnterKey)))
    //    {
    //        return stString.Replace(Strings.Chr(ReplaceAsciiChar.AgileEnterKey), "<br>");
    //        //.Replace("???", Chr(34))
    //    }
    //    else
    //    {
    //        return stString.Replace(Strings.Chr(ReplaceAsciiChar.NimbleEnterkey), "<br>");
    //        //.Replace("???", Chr(34))
    //    }
    //}

    //public static string ReplaceNewLineWithHtmlBRInHistory(string stString)
    //{
    //    if (stString.Contains(ReplaceAsciiChar.AgileEnterKey))
    //    {
    //        return stString.Replace(Strings.Chr(ReplaceAsciiChar.AgileEnterKey), "<br>");
    //    }
    //    else
    //    {
    //        return stString.Replace(Strings.Chr(ReplaceAsciiChar.NimbleEnterkey), "<br>");
    //    }
    //}

    //public static string ConvertDTUserFormat(DateTime dtime, int loginId)
    //{
    //    eRMUserManagementController objUserCtrl = new eRMUserManagementController();
    //    eRMUserManagementInfo objUserInfo = objUserCtrl.SelecteRMUserManagement(loginId);
    //    string timeFormat = string.Empty;
    //    string dateFormat = string.Empty;

    //    if (dateFormat == null | dateFormat.Equals(""))
    //    {
    //        dateFormat = "MM/dd/yyyy";
    //    }

    //    if (timeFormat == null | timeFormat.Equals(""))
    //    {
    //        timeFormat = "hh:mm:ss aaa (10:00:00 AM)";
    //    }

    //    //# get the appropriate part from |timeFormat| string to use
    //    if (timeFormat.Length <= 19)
    //    {
    //        timeFormat = timeFormat.Substring(0, 8);
    //    }
    //    else
    //    {
    //        //# adding |"tt"| so that AM or PM is displayed
    //        timeFormat = timeFormat.Substring(0, 8) + " tt";
    //    }

    //    return dtime.ToString(dateFormat + " " + timeFormat);
    //}

    //public static string ConvertDTUserFormat(DateTime dtime, string timeFormat, string dateFormat)
    //{
    //    if (dtime.ToShortDateString() != "1/1/1900" && dtime.ToShortDateString() != "1/1/0001")
    //    {
    //        if (dateFormat == null | dateFormat.Equals(""))
    //        {
    //            dateFormat = "MM/dd/yyyy";
    //        }

    //        if (timeFormat == null | timeFormat.Equals(""))
    //        {
    //            timeFormat = "hh:mm:ss aaa (10:00:00 AM)";
    //        }

    //        //# get the appropriate part from |timeFormat| string to use
    //        if (timeFormat.Length <= 19)
    //        {
    //            timeFormat = timeFormat.Substring(0, 8);
    //        }
    //        else
    //        {
    //            //# adding |"tt"| so that AM or PM is displayed
    //            timeFormat = timeFormat.Substring(0, 8) + " tt";
    //        }

    //        return dtime.ToString(dateFormat + " " + timeFormat);
    //    }

    //    return "";
    //}

    //public static string ConvertDateUserFormat(DateTime dtime, string dateFormat)
    //{
    //    if (dateFormat == null | dateFormat.Equals(""))
    //    {
    //        dateFormat = "MM/dd/yyyy";
    //    }
    //    return dtime.ToString(dateFormat);
    //}

    //public static string ConvertDateUserFormat(DateTime dtime, int loginId)
    //{
    //    eRMUserManagementController objUserCtrl = new eRMUserManagementController();
    //    eRMUserManagementInfo objUserInfo = objUserCtrl.SelecteRMUserManagement(loginId);
    //    string dateFormat = string.Empty;

    //    if (dateFormat == null | dateFormat.Equals(""))
    //    {
    //        dateFormat = "MM/dd/yyyy";
    //    }

    //    return dtime.ToString(dateFormat);
    //}

    ///// <summary>/// Removes all FONT and SPAN tags, and all Class and Style attributes.
    ///// Designed to get rid of non-standard Microsoft Word HTML tags.
    ///// </summary>
    //public string CleanHtml(string html)
    //{
    //    // '' '' start by completely removing all unwanted tags 
    //    //' ''html = Regex.Replace(html, "<[/]?(font|p|strong|span|xml|del|ins|[ovwxp]:\w+)[^>]*?>", "", RegexOptions.IgnoreCase)

    //    // '' '' then run another pass over the html (twice), removing unwanted attributes 
    //    //' ''html = Regex.Replace(html, "<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", RegexOptions.IgnoreCase)
    //    //' ''html = Regex.Replace(html, "<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", RegexOptions.IgnoreCase)
    //    //' ''Return html

    //    Regex R = new Regex("<[^>]*>");
    //    string strReq = string.Empty;

    //    //If R.Replace(HttpContext.Current.Server.HtmlDecode(html.Trim()), " ").Trim.Length > 0 Then
    //    strReq = R.Replace(HttpContext.Current.Server.HtmlDecode(html.Trim()), string.Empty).Trim();
    //    //        End If

    //    return strReq;
    //}

    //public static void AddUserState(bool isAdd, int UserId, int projectId, int workingLabelId, int level, int type)
    //{
    //    eRMUserStateController objUStateCtrl = new eRMUserStateController();

    //    if (isAdd)
    //    {
    //        objUStateCtrl.InserteRMUserState(new eRMUserStateInfo(-1, workingLabelId, type, level, UserId, projectId));
    //    }
    //    else
    //    {
    //        objUStateCtrl.UpdateAllWhereCustomeRMUserStates("ViewLevel = " + level + ", ViewType = " + type, "UserID = " + UserId + " and ProjectId = " + projectId);
    //    }
    //}

    ///// <summary>
    ///// Sort List In Ascending Order
    ///// </summary>
    ///// <param name="list"></param>
    ///// <remarks></remarks>
    //public static void SortList(object list)
    //{
    //    SortedList sl = new SortedList();

    //    foreach (ListItem li in list.Items)
    //    {
    //        sl.Add(li.Text, li.Value);
    //    }

    //    list.DataSource = sl;
    //    list.DataTextField = "key";
    //    list.DataValueField = "value";
    //    list.DataBind();
    //}

    //public static string DeleteRequirement(int requirementId, int userId, bool isAllVersion)
    //{
    //    try
    //    {
    //        eRMProject.eRMRequirementsController objReqCtrl = new eRMProject.eRMRequirementsController();
    //        string strMessage = objReqCtrl.DeleteAllRequirementByRequirementIdWithUserId(requirementId, userId, isAllVersion);

    //        if (strMessage == "-1")
    //        {
    //            return "Requirement can not deleted correctly, Please contact with admin";
    //        }
    //        else if (strMessage == "Used")
    //        {
    //            return "Requirement is in use and it can not be deleted";
    //            return;
    //        }
    //        else if (strMessage.StartsWith("Used__"))
    //        {
    //            return "Requirement Version(s) '" + strMessage.Substring(strMessage.LastIndexOf("__") + 2) + "' is in used and it can not be deleted";
    //        }
    //        else if (strMessage.EndsWith("&nbsp;"))
    //        {
    //            return "Requirement is linked in Project(s) '" + strMessage + "', it can not be deleted";
    //        }
    //        else if (strMessage != "1")
    //        {
    //            return "Requirement Version(s) '" + strMessage.Substring(strMessage.LastIndexOf("__") + 2) + "' is linked in Project(s) '" + strMessage.Substring(0, strMessage.LastIndexOf("__")) + "', it can not be deleted";
    //        }

    //        return string.Empty;
    //        //Module failed to load
    //    }
    //    catch (Exception exc)
    //    {
    //        throw;
    //    }
    //}

}

//public class DASEncryption
//{
//    private DASEncryption()
//    {
//    }

//    private static string Password = "PassPS19eRM";
//    // Encrypt a byte array into a byte array Imports a key and an IV
//    public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
//    {

//        // Create a MemoryStream that is going to accept the encrypted bytes
//        MemoryStream ms = new MemoryStream();

//        // Create a symmetric algorithm.
//        // We are going to use Rijndael because it is strong and available on all platforms.
//        // You can use other algorithms, to do so substitute the next line with something like
//        //TripleDES alg = TripleDES.Create();
//        Rijndael alg = Rijndael.Create();


//        // Now set the key and the IV.
//        // We need the IV (Initialization Vector) because the algorithm is operating in its default
//        // mode called CBC (Cipher Block Chaining). The IV is XORed with the first block (8 byte)
//        // of the data before it is encrypted, and then each encrypted block is XORed with the
//        // following block of plaintext. This is done to make encryption more secure.
//        // There is also a mode called ECB which does not need an IV, but it is much less secure.
//        alg.Key = Key;
//        alg.IV = IV;


//        // Create a CryptoStream through which we are going to be pumping our data.
//        // CryptoStreamMode.Write means that we are going to be writing data to the stream
//        // and the output will be written in the MemoryStream we have provided.
//        CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

//        // Write the data and make it do the encryption
//        cs.Write(clearData, 0, clearData.Length);

//        // Close the crypto stream (or do FlushFinalBlock).
//        // This will tell it that we have done our encryption and there is no more data coming in,
//        // and it is now a good time to apply the padding and finalize the encryption process.
//        cs.Close();

//        // Now get the encrypted data from the MemoryStream.
//        // Some people make a mistake of Imports GetBuffer() here, which is not the right way.
//        byte[] encryptedData = ms.ToArray();

//        return encryptedData;
//    }


//    // Encrypt a string into a string Imports a password
//    //    Uses Encrypt(byte[], byte[], byte[])
//    public static string Encrypt(string clearText)
//    {
//        // First we need to turn the input string into a byte array.
//        byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);

//        // Then, we need to turn the password into Key and IV
//        // We are Imports salt to make it harder to guess our key Imports a dictionary attack -
//        // trying to guess a password by enumerating all possible words.
//        PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] {
//            0x49,
//            0x76,
//            0x61,
//            0x6e,
//            0x20,
//            0x4d,
//            0x65,
//            0x64,
//            0x76,
//            0x65,
//            0x64,
//            0x65,
//            0x76
//        });

//        // Now get the key/IV and do the encryption Imports the function that accepts byte arrays.
//        // Imports PasswordDeriveBytes object we are first getting 32 bytes for the Key
//        // (the default Rijndael key length is 256bit = 32bytes) and then 16 bytes for the IV.
//        // IV should always be the block size, which is by default 16 bytes (128 bit) for Rijndael.
//        // If you are Imports DES/TripleDES/RC2 the block size is 8 bytes and so should be the IV size.
//        // You can also read KeySize/BlockSize properties off the algorithm to find out the sizes.
//        byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

//        // Now we need to turn the resulting byte array into a string.
//        // A common mistake would be to use an Encoding class for that. It does not work
//        // because not all byte values can be represented by characters.
//        // We are going to be Imports Base64 encoding that is designed exactly for what we are
//        // trying to do.
//        return Convert.ToBase64String(encryptedData);
//    }


//    // Encrypt bytes into bytes Imports a password
//    //    Uses Encrypt(byte[], byte[], byte[])
//    public static byte[] Encrypt(byte[] clearData)
//    {
//        // We need to turn the password into Key and IV.
//        // We are Imports salt to make it harder to guess our key Imports a dictionary attack -
//        // trying to guess a password by enumerating all possible words.
//        PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] {
//            0x49,
//            0x76,
//            0x61,
//            0x6e,
//            0x20,
//            0x4d,
//            0x65,
//            0x64,
//            0x76,
//            0x65,
//            0x64,
//            0x65,
//            0x76
//        });


//        // Now get the key/IV and do the encryption Imports the function that accepts byte arrays.
//        // Imports PasswordDeriveBytes object we are first getting 32 bytes for the Key
//        // (the default Rijndael key length is 256bit = 32bytes) and then 16 bytes for the IV.
//        // IV should always be the block size, which is by default 16 bytes (128 bit) for Rijndael.
//        // If you are Imports DES/TripleDES/RC2 the block size is 8 bytes and so should be the IV size.
//        // You can also read KeySize/BlockSize properties off the algorithm to find out the sizes.
//        return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));
//    }


//    // Encrypt a file into another file Imports a password
//    public static void Encrypt(string fileIn, string fileOut)
//    {
//        // First we are going to open the file streams
//        FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
//        FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

//        // Then we are going to derive a Key and an IV from the Password and create an algorithm
//        PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] {
//            0x49,
//            0x76,
//            0x61,
//            0x6e,
//            0x20,
//            0x4d,
//            0x65,
//            0x64,
//            0x76,
//            0x65,
//            0x64,
//            0x65,
//            0x76
//        });

//        Rijndael alg = Rijndael.Create();
//        alg.Key = pdb.GetBytes(32);
//        alg.IV = pdb.GetBytes(16);

//        // Now create a crypto stream through which we are going to be pumping data.
//        // Our fileOut is going to be receiving the encrypted bytes.

//        CryptoStream cs = new CryptoStream(fsOut, alg.CreateEncryptor(), CryptoStreamMode.Write);


//        // Now will will initialize a buffer and will be processing the input file in chunks.
//        // This is done to avoid reading the whole file (which can be huge) into memory.
//        int bufferLen = 4096;
//        byte[] buffer = new byte[bufferLen];
//        int bytesRead = 0;

//        do
//        {
//            // read a chunk of data from the input file
//            bytesRead = fsIn.Read(buffer, 0, bufferLen);

//            // encrypt it
//            cs.Write(buffer, 0, bytesRead);
//        } while (bytesRead != 0);


//        // close everything
//        cs.Close();
//        // this will also close the unrelying fsOut stream
//        fsIn.Close();
//    }


//    // Decrypt a byte array into a byte array Imports a key and an IV
//    public static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
//    {
//        // Create a MemoryStream that is going to accept the decrypted bytes
//        MemoryStream ms = new MemoryStream();

//        // Create a symmetric algorithm.
//        // We are going to use Rijndael because it is strong and available on all platforms.
//        // You can use other algorithms, to do so substitute the next line with something like
//        //                      TripleDES alg = TripleDES.Create();
//        Rijndael alg = Rijndael.Create();

//        // Now set the key and the IV.
//        // We need the IV (Initialization Vector) because the algorithm is operating in its default
//        // mode called CBC (Cipher Block Chaining). The IV is XORed with the first block (8 byte)
//        // of the data after it is decrypted, and then each decrypted block is XORed with the previous
//        // cipher block. This is done to make encryption more secure.
//        // There is also a mode called ECB which does not need an IV, but it is much less secure.
//        alg.Key = Key;
//        alg.IV = IV;

//        // Create a CryptoStream through which we are going to be pumping our data.
//        // CryptoStreamMode.Write means that we are going to be writing data to the stream
//        // and the output will be written in the MemoryStream we have provided.
//        CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

//        // Write the data and make it do the decryption
//        cs.Write(cipherData, 0, cipherData.Length);

//        // Close the crypto stream (or do FlushFinalBlock).
//        // This will tell it that we have done our decryption and there is no more data coming in,
//        // and it is now a good time to remove the padding and finalize the decryption process.
//        cs.Close();

//        // Now get the decrypted data from the MemoryStream.
//        // Some people make a mistake of Imports GetBuffer() here, which is not the right way.
//        byte[] decryptedData = ms.ToArray();

//        return decryptedData;
//    }


//    // Decrypt a string into a string Imports a password
//    //    Uses Decrypt(byte[], byte[], byte[])
//    public static string Decrypt(string cipherText)
//    {
//        // First we need to turn the input string into a byte array.
//        // We presume that Base64 encoding was used
//        byte[] cipherBytes = Convert.FromBase64String(cipherText);

//        // Then, we need to turn the password into Key and IV
//        // We are Imports salt to make it harder to guess our key Imports a dictionary attack -
//        // trying to guess a password by enumerating all possible words.
//        PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] {
//            0x49,
//            0x76,
//            0x61,
//            0x6e,
//            0x20,
//            0x4d,
//            0x65,
//            0x64,
//            0x76,
//            0x65,
//            0x64,
//            0x65,
//            0x76
//        });


//        // Now get the key/IV and do the decryption Imports the function that accepts byte arrays.
//        // Imports PasswordDeriveBytes object we are first getting 32 bytes for the Key
//        // (the default Rijndael key length is 256bit = 32bytes) and then 16 bytes for the IV.
//        // IV should always be the block size, which is by default 16 bytes (128 bit) for Rijndael.
//        // If you are Imports DES/TripleDES/RC2 the block size is 8 bytes and so should be the IV size.
//        // You can also read KeySize/BlockSize properties off the algorithm to find out the sizes.
//        byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));


//        // Now we need to turn the resulting byte array into a string.
//        // A common mistake would be to use an Encoding class for that. It does not work
//        // because not all byte values can be represented by characters.
//        // We are going to be Imports Base64 encoding that is designed exactly for what we are
//        // trying to do.
//        return System.Text.Encoding.Unicode.GetString(decryptedData);
//    }


//    // Decrypt bytes into bytes Imports a password
//    //    Uses Decrypt(byte[], byte[], byte[])
//    public static byte[] Decrypt(byte[] cipherData)
//    {
//        // We need to turn the password into Key and IV.
//        // We are Imports salt to make it harder to guess our key Imports a dictionary attack -
//        // trying to guess a password by enumerating all possible words.
//        PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] {
//            0x49,
//            0x76,
//            0x61,
//            0x6e,
//            0x20,
//            0x4d,
//            0x65,
//            0x64,
//            0x76,
//            0x65,
//            0x64,
//            0x65,
//            0x76
//        });

//        // Now get the key/IV and do the Decryption Imports the function that accepts byte arrays.
//        // Imports PasswordDeriveBytes object we are first getting 32 bytes for the Key
//        // (the default Rijndael key length is 256bit = 32bytes) and then 16 bytes for the IV.
//        // IV should always be the block size, which is by default 16 bytes (128 bit) for Rijndael.
//        // If you are Imports DES/TripleDES/RC2 the block size is 8 bytes and so should be the IV size.
//        // You can also read KeySize/BlockSize properties off the algorithm to find out the sizes.
//        return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
//    }


//    // Decrypt a file into another file Imports a password
//    public static void Decrypt(string fileIn, string fileOut)
//    {
//        // First we are going to open the file streams
//        FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
//        FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

//        // Then we are going to derive a Key and an IV from the Password and create an algorithm
//        PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] {
//            0x49,
//            0x76,
//            0x61,
//            0x6e,
//            0x20,
//            0x4d,
//            0x65,
//            0x64,
//            0x76,
//            0x65,
//            0x64,
//            0x65,
//            0x76
//        });

//        Rijndael alg = Rijndael.Create();

//        alg.Key = pdb.GetBytes(32);
//        alg.IV = pdb.GetBytes(16);

//        // Now create a crypto stream through which we are going to be pumping data.
//        // Our fileOut is going to be receiving the Decrypted bytes.
//        CryptoStream cs = new CryptoStream(fsOut, alg.CreateDecryptor(), CryptoStreamMode.Write);

//        // Now will will initialize a buffer and will be processing the input file in chunks.
//        // This is done to avoid reading the whole file (which can be huge) into memory.

//        int bufferLen = 4096;
//        byte[] buffer = new byte[bufferLen];
//        int bytesRead = 0;

//        do
//        {
//            // read a chunk of data from the input file
//            bytesRead = fsIn.Read(buffer, 0, bufferLen);

//            // Decrypt it
//            cs.Write(buffer, 0, bytesRead);
//        } while (bytesRead != 0);

//        // close everything
//        cs.Close();
//        // this will also close the unrelying fsOut stream
//        fsIn.Close();
//    }
//}
