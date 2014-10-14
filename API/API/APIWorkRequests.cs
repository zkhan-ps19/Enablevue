using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Xml;
using System.Xml.Linq;
using BLL;
using Model;

namespace RESTfulAPI
{
    //<summary>
    //Basically this code is developed for HTTP GET, PUT, POST & DELETE operation.
    //</summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class APIWorkRequests : IAPIWorkRequests
    {

        #region IAPIWorkRequests Members

        XElement IAPIWorkRequests.CreateWorkRequest(XElement data)
        {
            string strResponse = "<workResponse><contentResponses>";

            XmlDocument xmlRequest = new XmlDocument();
            xmlRequest.LoadXml(data.ToString());
            XmlNodeList xnList = xmlRequest.SelectNodes("/workRequest/workRequesterData");

            IList<WorkrequestInfo> lstWReqInfo = Admin.WorkRequest.SelectAllWhere("Name = '" + xnList[0]["name"].InnerText + "'", "");

            if (lstWReqInfo.Count > 0)
            {
                xnList = xmlRequest.SelectNodes("/workRequest/contentRequests/contentRequest");
                ContentrequestInfo cReqInfo = null;

                IList<ContenttypeInfo> lstCTypeInfo = Admin.ContentType.SelectAll();
                IList<RequesttypeInfo> lstRTypeInfo = Admin.RequestType.SelectAll();

                string strContentError = string.Empty;

                foreach (XmlNode xnContentRequest in xnList)
                {
                    cReqInfo = new ContentrequestInfo();

                    if (xnContentRequest.Attributes["id"] == null)
                    {
                        strContentError += "<error code=\"\">Missing request id</error>";
                    }
                    else
                    {
                        cReqInfo.Requestcode = xnContentRequest.Attributes["id"].Value;

                        if (Admin.ContentRequest.CountAllWhere("RequestCode='" + cReqInfo.Requestcode + "' and IsEnabled = '1'") > 0)
                            strContentError += "<error code=\"\">Invalid request id, already in used</error>";
                    }

                    if (xnContentRequest["name"] == null)
                    {
                        strContentError += "<error code=\"\">Missing request name</error>";
                    }
                    else
                    {
                        cReqInfo.Name = xnContentRequest["name"].InnerText;

                        if (Admin.ContentRequest.CountAllWhere("Name='" + cReqInfo.Name + "' and IsEnabled = '1'") > 0)
                            strContentError += "<error code=\"\">Invalid name, already in used</error>";
                    }

                    if (xnContentRequest["customer"] == null || xnContentRequest["customer"].Attributes["id"] == null ||
                        xnContentRequest["customer"].InnerText.Length == 0)
                    {
                        strContentError += "<error code=\"\">Missing customer</error>";
                    }
                    else
                    {
                        cReqInfo.Customerid = int.Parse(xnContentRequest["customer"].Attributes["id"].Value);
                        cReqInfo.Customername = xnContentRequest["customer"].InnerText;
                    }

                    if (xnContentRequest["contentType"] == null || xnContentRequest["contentType"].Attributes["code"] == null ||
                        xnContentRequest["contentType"].InnerText.Length == 0)
                    {
                        strContentError += "<error code=\"\">Missing contentType</error>";
                    }
                    else
                    {
                        cReqInfo.Contenttypecode = xnContentRequest["contentType"].Attributes["code"].Value;
                        cReqInfo.Contenttypename = xnContentRequest["contentType"].InnerText;

                        if ((from objCTypeInfo in lstCTypeInfo
                             where objCTypeInfo.Contenttype == cReqInfo.Contenttypename
                             select objCTypeInfo).Count() == 0)
                        {
                            strContentError = "<error code=\"\">Invalid contentType</error>";
                        }
                    }

                    if (xnContentRequest["requestType"] == null || xnContentRequest["requestType"].Attributes["code"] == null ||
                        xnContentRequest["requestType"].InnerText.Length == 0)
                    {
                        strContentError += "<error code=\"\">Missing requestType</error>";
                    }
                    else
                    {
                        cReqInfo.Requesttypecode = xnContentRequest["requestType"].Attributes["code"].Value;
                        cReqInfo.Requesttypename = xnContentRequest["requestType"].InnerText;

                        if ((from objRTypeInfo in lstRTypeInfo
                             where objRTypeInfo.Requesttype == cReqInfo.Requesttypename
                             select objRTypeInfo).Count() == 0)
                        {
                            strContentError += "<error code=\"\">Invalid requestType</error>";
                        }
                    }

                    if (xnContentRequest["dueDate"] == null || xnContentRequest["dueDate"].Attributes["timezone"] == null ||
                        xnContentRequest["dueDate"].Attributes["format"] == null || xnContentRequest["dueDate"].InnerText.Length == 0)
                    {
                        strContentError += "<error code=\"\">Missing dueDate</error>";
                    }
                    else
                    {
                        cReqInfo.Datetimezone = xnContentRequest["dueDate"].Attributes["timezone"].Value;
                        cReqInfo.Dateformat = xnContentRequest["dueDate"].Attributes["format"].Value;
                        cReqInfo.Duedate = DateTime.Parse(xnContentRequest["dueDate"].InnerText);
                    }

                    if (xnContentRequest["directionalContent"] == null)
                    {
                        strContentError += "<error code=\"\">Missing directionalContent</error>";
                    }
                    else
                        cReqInfo.Directionalcontent = xnContentRequest["directionalContent"].InnerText;

                    if (xnContentRequest["subscription"] == null || xnContentRequest["subscription"].Attributes["id"] == null)
                    {
                        strContentError += "<error code=\"\">Missing subscription</error>";
                    }
                    else
                    {
                        cReqInfo.Subscriptionid = int.Parse(xnContentRequest["subscription"].Attributes["id"].Value);

                        if (!xnContentRequest["subscription"].IsEmpty)
                            cReqInfo.Subscription = xnContentRequest["subscription"].InnerText;
                        else cReqInfo.IsSubscriptionNull = true;
                    }

                    if (xnContentRequest["minWordCount"] != null && xnContentRequest["minWordCount"].InnerText.Length > 0)
                        cReqInfo.Minwordcount = int.Parse(xnContentRequest["minWordCount"].InnerText);
                    else cReqInfo.IsMinwordcountNull = true;

                    if (xnContentRequest["maxWordCount"] != null && xnContentRequest["maxWordCount"].InnerText.Length > 0)
                        cReqInfo.Maxwordcount = int.Parse(xnContentRequest["maxWordCount"].InnerText);
                    else cReqInfo.IsMaxwordcountNull = true;

                    if (xnContentRequest["suggestedAuthor"] != null && xnContentRequest["suggestedAuthor"].Attributes["id"] != null &&
                        xnContentRequest["suggestedAuthor"].InnerText.Length != 0)
                    {
                        cReqInfo.SuggestedauthorNickname = xnContentRequest["suggestedAuthor"].Attributes["id"].Value;
                        cReqInfo.suggestedauthorFullname = xnContentRequest["suggestedAuthor"].InnerText;
                    }

                    //Pages
                    XmlNodeList xnPageList = xnContentRequest.SelectNodes("pages/page");

                    IList<ContentrequestpageInfo> lstCRPageInfo = null;

                    if (xnPageList.Count > 0)
                    {
                        lstCRPageInfo = new List<ContentrequestpageInfo>();
                        ContentrequestpageInfo objCRPageInfo;

                        foreach (XmlNode xnPage in xnPageList)
                        {
                            objCRPageInfo = new ContentrequestpageInfo();

                            if (xnPage.Attributes["id"] == null || xnPage.Attributes["id"].Value.Length == 0)
                            {
                                strContentError += "<error code=\"\">Missing page id</error>";
                            }
                            else objCRPageInfo.Id = int.Parse(xnPage.Attributes["id"].Value);

                            if (xnPage["contentRequired"] == null || xnPage["contentRequired"].InnerText.Length == 0)
                            {
                                strContentError += "<error code=\"\">Missing page contentRequired</error>";
                            }
                            else objCRPageInfo.Iscontentrequired = bool.Parse(xnPage["contentRequired"].InnerText);

                            if (xnPage["pageTitle"] == null || xnPage["pageTitle"].InnerText.Length == 0)
                            {
                                strContentError += "<error code=\"\">Missing page title</error>";
                            }
                            else objCRPageInfo.Pagetitle = xnPage["pageTitle"].InnerText;

                            if (xnPage["pageUrl"] == null || xnPage["pageUrl"].InnerText.Length == 0)
                            {
                                strContentError += "<error code=\"\">Missing page url</error>";
                            }
                            else objCRPageInfo.Pageurl = xnPage["pageUrl"].InnerText;

                            if (xnPage["pageInstructions"] != null)
                                objCRPageInfo.Pageinstruction = xnPage["pageInstructions"].InnerText;

                            lstCRPageInfo.Add(objCRPageInfo);
                        }//pages loop
                    }//page count if

                    IList<ContentrequestchangeInfo> lstCRChangeInfo = null;

                    //Is Request is change request
                    if (xnContentRequest["requestChangeReasons"] != null)
                    {
                        strContentError = strContentError.Replace("<error code=\"\">Invalid request id, already in used</error>", "")
                                .Replace("<error code=\"\">Invalid name, already in used</error>", "");

                        if (strContentError.Length == 0)
                        {
                            //ChangeReason
                            XmlNodeList xnChangeList = xnContentRequest.SelectNodes("requestChangeReasons/changeReason");

                            if (xnChangeList.Count > 0)
                            {
                                lstCRChangeInfo = new List<ContentrequestchangeInfo>();
                                ContentrequestchangeInfo objCRChangeInfo;

                                foreach (XmlNode xnChange in xnChangeList)
                                {
                                    objCRChangeInfo = new ContentrequestchangeInfo();

                                    objCRChangeInfo.Requestchange = xnChange.InnerText;
                                    objCRChangeInfo.Requestchangecode = xnChange.Attributes["code"].Value;

                                    lstCRChangeInfo.Add(objCRChangeInfo);
                                }
                            }
                        }
                    }//requestChangeReasons != null

                    //if error occurred
                    if (strContentError.Length == 0)
                    {
                        cReqInfo.Workrequestid = lstWReqInfo[0].Id;
                        cReqInfo.Requeststatuscode = 130;

                        string strDirectionalcontent = cReqInfo.Directionalcontent;
                        int startIndex, endIndex;

                        IList<ContentrequestcategoryInfo> lstCRCategoryInfo = null;

                        if (strDirectionalcontent.Contains("Blog URL:"))
                        {
                            if (strDirectionalcontent.Contains("Practice Area:"))
                            {
                                startIndex = strDirectionalcontent.IndexOf("Blog URL:");
                                endIndex = strDirectionalcontent.IndexOf("Practice Area:");

                                cReqInfo.Dcblogurl = CleanData(strDirectionalcontent.Substring(startIndex + 9, endIndex - (startIndex + 9)));

                                strDirectionalcontent = strDirectionalcontent.Remove(0, endIndex);

                                if (strDirectionalcontent.Contains("Geography:"))
                                {
                                    startIndex = strDirectionalcontent.IndexOf("Practice Area:");
                                    endIndex = strDirectionalcontent.IndexOf("Geography:");

                                    cReqInfo.Dcpracticearea = CleanData(strDirectionalcontent.Substring(startIndex + 15, endIndex - (startIndex + 15)));

                                    strDirectionalcontent = strDirectionalcontent.Remove(0, endIndex);

                                    startIndex = strDirectionalcontent.IndexOf("Geography:");
                                    endIndex = strDirectionalcontent.IndexOf("Category:");

                                    cReqInfo.Dcgeography = CleanData(strDirectionalcontent.Substring(startIndex + 10, endIndex - (startIndex + 10)));

                                    strDirectionalcontent = strDirectionalcontent.Remove(0, endIndex);

                                    lstCRCategoryInfo = new List<ContentrequestcategoryInfo>();
                                    ContentrequestcategoryInfo objCRCategoryInfo;
                                    String strCategory = string.Empty;

                                    while (strDirectionalcontent.Contains("Category:"))
                                    {
                                        objCRCategoryInfo = new ContentrequestcategoryInfo();

                                        startIndex = strDirectionalcontent.IndexOf("Category:");
                                        endIndex = strDirectionalcontent.IndexOf("Category:", 9);

                                        if (endIndex != -1)
                                        {
                                            strCategory = strDirectionalcontent.Substring(startIndex, endIndex);
                                            strDirectionalcontent = strDirectionalcontent.Remove(startIndex, endIndex);
                                        }
                                        else
                                        {
                                            if (strDirectionalcontent.Contains("Instructions for Writer:"))
                                            {
                                                endIndex = strDirectionalcontent.IndexOf("Instructions for Writer:");
                                                strCategory = strDirectionalcontent.Substring(startIndex, endIndex);

                                                strDirectionalcontent = strDirectionalcontent.Remove(startIndex, endIndex);
                                            }
                                            else
                                            {
                                                strCategory = strDirectionalcontent;
                                                strDirectionalcontent = strDirectionalcontent.Remove(startIndex);
                                            }
                                        }

                                        startIndex = strCategory.IndexOf("Category:");

                                        String strTarget = "Primary Target URL:";

                                        endIndex = strCategory.IndexOf(strTarget);

                                        if (endIndex == -1)
                                        {
                                            strTarget = "Secondary Target URL:";
                                            endIndex = strCategory.IndexOf(strTarget);
                                        }

                                        if (endIndex == -1)
                                        {
                                            strTarget = "Target URL:";
                                            endIndex = strCategory.IndexOf(strTarget);
                                        }

                                        objCRCategoryInfo.Category = CleanData(strCategory.Substring(startIndex + 9, endIndex - (startIndex + 9)));

                                        strCategory = strCategory.Remove(0, endIndex);

                                        startIndex = strCategory.IndexOf(strTarget);

                                        strTarget = "Primary Anchor text:";

                                        endIndex = strCategory.IndexOf(strTarget);

                                        if (endIndex == -1)
                                        {
                                            strTarget = "Secondary Anchor text:";
                                            endIndex = strCategory.IndexOf(strTarget);
                                        }

                                        if (endIndex == -1)
                                        {
                                            strTarget = "Anchor text:";
                                            endIndex = strCategory.IndexOf(strTarget);
                                        }

                                        objCRCategoryInfo.Categoryprimaryurl = CleanData(strCategory.Substring(startIndex + strTarget.Length, endIndex - (startIndex + strTarget.Length)));

                                        strCategory = strCategory.Remove(0, endIndex);

                                        startIndex = strCategory.IndexOf(strTarget);
                                        endIndex = strCategory.IndexOf("Keyword text:");

                                        objCRCategoryInfo.Categoryanchortext = CleanData(strCategory.Substring(startIndex + strTarget.Length, endIndex - (startIndex + strTarget.Length)));

                                        strCategory = strCategory.Remove(0, endIndex);

                                        startIndex = strCategory.IndexOf("Keyword text:");

                                        objCRCategoryInfo.Categorypreferredkeyword = strCategory.Substring(startIndex + 13);

                                        lstCRCategoryInfo.Add(objCRCategoryInfo);
                                    }

                                    if (strDirectionalcontent.Contains("Instructions for Writer:"))
                                    {
                                        startIndex = strDirectionalcontent.IndexOf("Instructions for Writer:");

                                        cReqInfo.Dcinsforwriter = CleanData(strDirectionalcontent.Substring(startIndex + 25));

                                        if (cReqInfo.Dcinsforwriter.Length == 0)
                                            cReqInfo.IsDcinsforwriterNull = true;
                                    }
                                    else
                                    {
                                        cReqInfo.IsDcinsforwriterNull = true;
                                    }

                                }
                            }//practice area
                        }//blog url                        

                        //Insert Request data in db
                        cReqInfo.Contentrequestid = Admin.ContentRequest.InsertCustom(cReqInfo);

                        //Is Request is change request
                        if (lstCRChangeInfo != null)
                        {
                            Admin.ContentRequest.UpdateAllWhere("IsEnabled = '0'", "RequestCode = '" + cReqInfo.Requestcode
                                + "' and ContentRequestId <> " + cReqInfo.Contentrequestid);

                            foreach (ContentrequestchangeInfo objCRChangeInfo in lstCRChangeInfo)
                            {
                                objCRChangeInfo.Contentrequestid = cReqInfo.Contentrequestid;

                                Admin.ContentRequestChange.Insert(objCRChangeInfo);
                            }
                        }

                        if (lstCRCategoryInfo != null)
                        {
                            foreach (ContentrequestcategoryInfo objCRCategoryInfo in lstCRCategoryInfo)
                            {
                                objCRCategoryInfo.Contentrequestid = cReqInfo.Contentrequestid;

                                Admin.ContentRequestCategory.Insert(objCRCategoryInfo);
                            }
                        }

                        if (lstCRPageInfo != null)
                        {
                            foreach (ContentrequestpageInfo objCRPageInfo in lstCRPageInfo)
                            {
                                objCRPageInfo.Contentrequestid = cReqInfo.Contentrequestid;

                                Admin.ContentRequestPage.Insert(objCRPageInfo);
                            }
                        }

                        lstCRCategoryInfo = null;
                        lstCRPageInfo = null;

                        //Response
                        strResponse += "<contentResponse id=\"" + cReqInfo.Requestcode + "\"><name>" + cReqInfo.Name +
                             "</name><vendorRequestId>VendorId-1</vendorRequestId><requestStatus code=\"110\">REQUEST RECEIVED</requestStatus></contentResponse>";
                    }
                    else
                    {
                        //Response
                        strResponse += "<contentResponse id=\"" + cReqInfo.Requestcode + "\"><name>" + cReqInfo.Name +
                             "</name><vendorRequestId>VendorId-1</vendorRequestId><requestStatus code=\"120\">REQUEST IN ERROR</requestStatus><errors>"
                             + strContentError + "</errors></contentResponse>";

                        strContentError = string.Empty;
                    }
                }//contentRequest loop

                //Response
                strResponse += "</contentResponses></workResponse>";
            }//key if
            else
            {
                //Response
                strResponse = "<workResponse>Invalid work request Id/name.</workResponse>";
            }

            return XElement.Parse(strResponse);
        }

        private String CleanData(String strData)
        {
            return strData.Replace("\r", "").Replace("\n", "").Replace("\t", "");
        }

        #endregion
    }
}