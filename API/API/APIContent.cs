using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using BLL;
using Model;

namespace RESTfulAPI
{
    /// <summary>
    /// Basically this code is developed for HTTP GET, PUT, POST & DELETE operation.
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class APIContent : IAPIContent
    {
        XElement IAPIContent.GetContentbyid(string requestCode)
        {
            ContentrequestInfo cReqInfo = Admin.ContentRequest.SelectByRequestCode(requestCode);
            string strReponse = string.Empty;

            if (cReqInfo != null)
            {
                if (cReqInfo.Requeststatuscode == 150)
                {
                    IList<ContentInfo> lstContInfo = Admin.Content.SelectAllWhereCustom("ContentRequestId =" + cReqInfo.Contentrequestid, "ContentId desc");

                    if (lstContInfo.Count > 0)
                    {
                        strReponse = "<contentRequest><contentType code=\"" + cReqInfo.Contenttypecode + "\">" + cReqInfo.Contenttypename + "</contentType><requestStatus code=\"" +
                            cReqInfo.Requeststatuscode + "\">" + cReqInfo.Requeststatus + "</requestStatus><title>" + lstContInfo[0].Title + "</title><source><![CDATA[" +
                            lstContInfo[0].Source + "]]> </source><category>" + lstContInfo[0].Category + "</category><content><![CDATA[" + lstContInfo[0].Contentdetail +
                            "]]></content><author id=\"" + lstContInfo[0].Authorid + "\">" + lstContInfo[0].AuthorFullname + "</author></contentRequest>";

                        return XElement.Parse(strReponse);
                    }
                }

                strReponse = "<contentRequest><contentType code=\"" + cReqInfo.Contenttypecode + "\">" + cReqInfo.Contenttypename + "</contentType><requestStatus code=\"" +
                            cReqInfo.Requeststatuscode + "\">" + cReqInfo.Requeststatus +
                            "</requestStatus><title></title><source><![CDATA[]]> </source><category></category><content><![CDATA[]]></content><author id=\"\"></author></contentRequest>";
            }
            else
                strReponse = "<contentRequest><errors><error>Invalid request code</error></errors></contentRequest>";

            return XElement.Parse(strReponse);
        }

        string IAPIContent.CreateContent(Content objContent)
        {
            try
            {
                IList<ContentrequestInfo> lstContentReqInfo;

                if (objContent.SubscriptionId.Contains("_"))
                {
                    string strName = objContent.SubscriptionId;

                    strName = strName.Substring(0, strName.IndexOf("_"));

                    lstContentReqInfo = Admin.ContentRequest.SelectAllWhere("Name Like '" + strName + "[_]%[_]" +
                        objContent.SubscriptionId.Substring(objContent.SubscriptionId.LastIndexOf("_") + 1) + "' and IsEnabled = '1'", "");
                }
                else lstContentReqInfo = Admin.ContentRequest.SelectAllWhere("SubscriptionId = " + objContent.SubscriptionId + " and IsEnabled = '1' ", "");

                if (lstContentReqInfo.Count > 0)
                {
                    objContent.Category = HttpContext.Current.Server.HtmlDecode(objContent.Category);
                    objContent.Contentdetail = HttpContext.Current.Server.HtmlDecode(objContent.Contentdetail);
                    objContent.Source = HttpContext.Current.Server.HtmlDecode(objContent.Source);
                    objContent.Title = HttpContext.Current.Server.HtmlDecode(objContent.Title);

                    if (objContent.AuthorName.Trim(' ').Length == 0)
                        objContent.AuthorName = "EnableVue";

                    Admin.Content.Insert(objContent, lstContentReqInfo[0].Contentrequestid);

                    return "201";
                }

                return "404 - SubscriptionId not found";
            }
            catch (System.Exception e)
            {
                return "401 - " + e.Message;
            }
        }

        void IAPIContent.UpdateContent(string requestCode, XElement data)
        {
            ContentrequestInfo cReqInfo = Admin.ContentRequest.SelectByRequestCode(requestCode);

            if (cReqInfo != null)
            {
                XmlDocument xmlRequest = new XmlDocument();
                xmlRequest.LoadXml(data.ToString());

                XmlNodeList xnList = xmlRequest.SelectNodes("/statusUpdate");

                string strCode = xnList[0]["status"].Attributes["code"].Value;
                string strStatus = xnList[0]["status"].InnerText;

                if (Admin.Content.CountAllWhere("ContentRequestId =" + cReqInfo.Contentrequestid) == 0)
                    throw new System.Exception("Content does not exists");
                else if (Admin.ContentStatus.CountAllWhere("ContentStatusCode = " + strCode) == 0)
                    throw new System.Exception("Invalid status code");
                else
                {
                    if (strCode == ((int)Admin.eContentStatus.ContentFailed).ToString()
                        || strCode == ((int)Admin.eContentStatus.ContentRejected).ToString()
                        || strCode == ((int)Admin.eContentStatus.ValidationFailed).ToString())

                        Admin.ContentRequest.UpdateAllWhere("RequestStatusCode = 130, ContentStatusCode = " + strCode, "Contentrequestid = " + cReqInfo.Contentrequestid);
                    else
                        Admin.ContentRequest.UpdateAllWhere("ContentStatusCode = " + strCode, "Contentrequestid = " + cReqInfo.Contentrequestid);

                    sendStatusEmail("Content Request '" + cReqInfo.Requestcode + "' content status change", "Content Request '" + cReqInfo.Requestcode + "' content status has been changed to " + strStatus + ".<br><br>Regards,<br>EnableVue");
                }

                //Delete all the previous content status errors
                Admin.ContentStatusError.DeleteAllByFKContentrequestid(cReqInfo.Contentrequestid);

                xnList = xmlRequest.SelectNodes("/statusUpdate/errors/error");

                if (xnList.Count > 0)
                {
                    ContentstatuserrorInfo objCSErrorInfo;

                    foreach (XmlNode xnError in xnList)
                    {
                        try
                        {
                            objCSErrorInfo = new ContentstatuserrorInfo();

                            objCSErrorInfo.Contentrequestid = cReqInfo.Contentrequestid;
                            objCSErrorInfo.Errorcode = xnError.Attributes["code"].Value;
                            objCSErrorInfo.Description = xnError.InnerText;

                            Admin.ContentStatusError.Insert(objCSErrorInfo);
                        }
                        catch (System.Exception)
                        { }
                    }
                }
            }
            else
            {
                throw new System.Exception("Invalid request code");
            }
        }

        private void sendStatusEmail(string subject, string message)
        {
            IList<UserInfo> lstUsers = Admin.User.SelectAllWhere("IsDefault='1'", "");

            if (lstUsers.Count > 0)
            {
                EVueSharedClass.SendEmail(lstUsers[0].Email, subject, message);
            }
        }
    }
}