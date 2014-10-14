using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace RESTfulAPI.WebPages
{
    public partial class ListArchiveContentRequest : System.Web.UI.Page
    {
        #region Variables
        private string strSearch;
        #endregion

        #region "Event Handlers"

        private void Page_Load(System.Object sender, System.EventArgs e)
        {

            #region Session Validation
            UserInfo objUser = (UserInfo)Session["loginUser"];

            if (objUser == null)
            {
                Response.Redirect("~/WebPages/Login.aspx", true);
            }
            #endregion

            if (Request.QueryString["search"] != null)
            {
                strSearch = Request.QueryString["search"];
                imgBtnBack.Visible = true;
            }
            else
            {
                strSearch = string.Empty;
                imgBtnBack.Visible = false;
            }

            try
            {
                if (!Page.IsPostBack)
                    PopulateList();
            }
            catch (Exception exc)
            {
                lbStatus.Text = exc.Message;
            }
        }

        protected void dplContentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateList();
        }

        protected void dplContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateList();
        }

        protected void rptContentRequest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int contentStatusCode = int.Parse(DataBinder.GetPropertyValue(e.Item.DataItem, "Contentstatuscode").ToString());

                //if content received
                if (int.Parse(DataBinder.GetPropertyValue(e.Item.DataItem, "CreatedBy").ToString()) > 0)
                {
                    ImageButton imgBtn = (ImageButton)e.Item.FindControl("imgBtnStatus");

                    if (contentStatusCode == 201 || contentStatusCode == 250 || contentStatusCode == 260)
                    {
                        imgBtn.ImageUrl = "~/WebPages/Images/failed.png";
                    }
                    else
                    {
                        imgBtn.ImageUrl = "~/WebPages/Images/success.png";
                    }

                    ((DropDownList)e.Item.FindControl("dplContentStatus")).SelectedValue = DataBinder.GetPropertyValue(e.Item.DataItem, "RequestStatusCode").ToString();

                    imgBtn.ToolTip = DataBinder.GetPropertyValue(e.Item.DataItem, "Requeststatus").ToString();
                    imgBtn.PostBackUrl = "GetContent.aspx?rId=" + DataBinder.GetPropertyValue(e.Item.DataItem, "ContentRequestId").ToString() + "&type=archive";
                }
                else
                {
                    ((DropDownList)e.Item.FindControl("dplContentStatus")).Enabled = false;

                    ImageButton imgBtn = (ImageButton)e.Item.FindControl("imgBtnStatus");
                    imgBtn.Enabled = false;
                    imgBtn.Style.Add("cursor", "text");
                }
            }
        }

        protected void imgBtnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            string strRequestCode;
            DropDownList dplContentStatus;
            CheckBox chkBox;
            lbStatus.Text = "";

            string strSectretKey = WebConfigurationManager.AppSettings["fl_sec_token"].ToString();
            string strFLUrl = WebConfigurationManager.AppSettings["fl_url"].ToString();

            for (int i = 0; i <= rptContentRequest.Items.Count - 1; i++)
            {
                chkBox = ((CheckBox)rptContentRequest.Items[i].FindControl("chkBoxSelect"));

                if (chkBox.Checked)
                {
                    strRequestCode = ((Label)rptContentRequest.Items[i].FindControl("lbRequestCode")).Text;
                    dplContentStatus = ((DropDownList)rptContentRequest.Items[i].FindControl("dplContentStatus"));

                    HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(strFLUrl + strRequestCode + "");

                    objRequest.KeepAlive = false;
                    objRequest.Method = "PUT";
                    objRequest.ContentType = "text/xml";
                    objRequest.Headers.Add("fl_sec_token", strSectretKey);

                    string strContent = "<flm:message id=\"1\" product=\"VRM.Vendor.RequestStatus\" type=\"EnableVue\" xmlns:flm=\"http://www.findlaw.com/ns/eventmessage/1.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                        "<flm:header><flm:action value=\"notify\"/><flm:notify-failure type=\"email\" value=\"NK.email@thomsonreuters.com\"/></flm:header>" +
                        "<flm:payload status=\"complete\"><statusUpdate><status code=\"" + dplContentStatus.SelectedValue + "\">" + dplContentStatus.SelectedItem.Text
                        + "</status><requestId>" + strRequestCode + "</requestId><vendorRequestId>1234</vendorRequestId></statusUpdate></flm:payload></flm:message>";

                    byte[] buffer = Encoding.ASCII.GetBytes(strContent);
                    objRequest.ContentLength = buffer.Length;

                    Stream PostData = objRequest.GetRequestStream();
                    PostData.Write(buffer, 0, buffer.Length);
                    PostData.Close();

                    try
                    {
                        strContent = ((HttpWebResponse)objRequest.GetResponse()).StatusCode.ToString();
                    }
                    catch (Exception ex)
                    {
                        lbStatus.ForeColor = System.Drawing.Color.Red;
                        lbStatus.Text = ex.Message;
                        return;
                    }

                    if (strContent != "OK")
                        lbStatus.Text += "CR Id \"" + strRequestCode + "\" status not updated.<br>";
                    else
                    {
                        lbStatus.Text += "CR Id \"" + strRequestCode + "\" status updated successfully.<br>";

                        //update status in db
                        Admin.ContentRequest.UpdateAllWhere("RequestStatusCode = " + dplContentStatus.SelectedValue, "ContentRequestId = " +
                            ((HiddenField)rptContentRequest.Items[i].FindControl("hdFieldCRequestId")).Value);

                        chkBox.Checked = false;
                    }
                }
            }

            if (lbStatus.Text.Length == 0)
            {
                lbStatus.ForeColor = System.Drawing.Color.Red;
                lbStatus.Text = "Please select at-least one content request.";
            }
        }

        protected void imgBtnExport_Click(object sender, ImageClickEventArgs e)
        {
            string strConRequestId = string.Empty;
            CheckBox chkBox;

            for (int i = 0; i <= rptContentRequest.Items.Count - 1; i++)
            {
                chkBox = ((CheckBox)rptContentRequest.Items[i].FindControl("chkBoxSelect"));

                if (chkBox.Checked)
                {
                    strConRequestId += "," + ((HiddenField)rptContentRequest.Items[i].FindControl("hdFieldCRequestId")).Value;
                    chkBox.Checked = false;
                }
            }

            if (strConRequestId.Length > 0)
            {
                IList<ContentrequestInfo> lstCReqInfo = Admin.ContentRequest.SelectContentRequestById("ContentRequestId In (" + strConRequestId.Substring(1) + ")");

                StringBuilder strExport = new StringBuilder();

                strExport.Append("Request Name,Request ID,Fulfillment Code,Fulfillment Type,New/Changed,Firm Name,Subscription ID,Posts Per Week,Date Due,Practice Area,Geography,Blog URL," +
                    "Instructions for Writer,Category 1,Category 1 Primary URL,Category 1 Preferred Anchor Text,Category 1 Preferred Keywords,Category 2,Category 2 Primary URL," +
                    "Category 2 Preferred Anchor Text,Category 2 Preferred Keywords,Category 3,Category 3 Primary URL,Category 3 Preferred Anchor Text,Category 3 Preferred Keywords," +
                    "Category 4,Category 4 Primary URL,Category 4 Preferred Anchor Text,Category 4 Preferred Keywords,Category 5,Category 5 Primary URL,Category 5 Preferred Anchor Text," +
                    "Category 5 Preferred Keywords,Category 6,Category 6 Primary URL,Category 6 Preferred Anchor Text,Category 6 Preferred Keywords");

                strExport.Append(Environment.NewLine);

                for (int i = 0; i < lstCReqInfo.Count; i++)
                {
                    strExport.Append(SharedClass.handleCsvComma(lstCReqInfo[i].Name) + "," + SharedClass.handleCsvComma(lstCReqInfo[i].Requestcode) + ",,,," + SharedClass.handleCsvComma(lstCReqInfo[i].Contenttypename) + "," + lstCReqInfo[i].Subscriptionid + ",," +
                        lstCReqInfo[i].Duedate + "," + SharedClass.handleCsvComma(lstCReqInfo[i].Dcpracticearea) + "," + SharedClass.handleCsvComma(lstCReqInfo[i].Dcgeography) + "," + SharedClass.handleCsvComma(lstCReqInfo[i].Dcblogurl) + "," + SharedClass.handleCsvComma(lstCReqInfo[i].Dcinsforwriter.Replace("\r\n", "")) + ",");

                    IList<ContentrequestcategoryInfo> lstCReqCategoryInfo = Admin.ContentRequestCategory.SelectAllByFKContentrequestid(lstCReqInfo[i].Contentrequestid);

                    for (int j = 0; j < lstCReqCategoryInfo.Count; j++)
                    {
                        strExport.Append(SharedClass.handleCsvComma(lstCReqCategoryInfo[j].Category) + "," + SharedClass.handleCsvComma(lstCReqCategoryInfo[j].Categoryprimaryurl) + "," + SharedClass.handleCsvComma(lstCReqCategoryInfo[j].Categoryanchortext.Replace("\r\n", "")) + "," + SharedClass.handleCsvComma(lstCReqCategoryInfo[j].Categorypreferredkeyword.Replace("\r\n", "")) + ",");
                    }

                    strExport.Append(Environment.NewLine);
                }

                EVueSharedClass.ExportToCSV("export.csv", strExport.ToString());
            }
            else
            {
                lbStatus.ForeColor = System.Drawing.Color.Red;
                lbStatus.Text = "Please select at-least one content request.";
            }
        }

        protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ListArchiveContentRequest.aspx", true);
        }

        #region "Paging"

        /// <summary>
        /// Custom Paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        protected void ChangePage(object sender, EventArgs e)
        {
            int pageNumber;

            if (sender.ToString() == "System.Web.UI.WebControls.LinkButton")
                pageNumber = int.Parse(((LinkButton)sender).CommandArgument);
            else pageNumber = ((DropDownList)sender).SelectedIndex + 1;

            CustPaging.Paging(pageNumber, 10, int.Parse(hdFieldTotalRecord.Value));

            rptContentRequest.DataSource = Admin.ContentRequest.SelectAllWhere(ViewState["strQuery"].ToString(), strSearch, "", pageNumber, 10);
            rptContentRequest.DataBind();
        }

        #endregion

        #endregion

        #region "Methods"

        private void PopulateList()
        {
            string strQuery = "IsEnabled = '1' AND ContentStatusCode = 300";

            if (dplContentStatus.SelectedIndex != 0)
            {
                strQuery += " and RequestStatusCode = " + dplContentStatus.SelectedValue;
            }

            if (dplContentType.SelectedIndex != 0)
            {
                strQuery += " and ContentTypeCode = '" + dplContentType.SelectedValue + "'";
            }

            if (strSearch.Length > 0)
            {
                strQuery += " and (RequestCode Like '%" + strSearch + "%' or cReq.Name Like '%" + strSearch + "%' or cust.Name Like '%" + strSearch + "%')";
            }

            rptContentRequest.DataSource = Admin.ContentRequest.SelectAllWhere(strQuery, strSearch, "", 1, 10);
            rptContentRequest.DataBind();

            ViewState["strQuery"] = strQuery;

            if (rptContentRequest.Items.Count > 0)
            {
                rptContentRequest.Visible = true;
                CustPaging.Visible = true;

                //imgBtnUpdate.Visible = imgBtnExport.Visible = ((UserInfo)Session["loginUser"]).Isadminright;

                hdFieldTotalRecord.Value = Admin.ContentRequest.CountAllWhereCustom(strQuery).ToString();
                CustPaging.Paging(1, 10, int.Parse(hdFieldTotalRecord.Value));
                imgBtnExport.Visible = true;
            }
            else
            {
                rptContentRequest.Visible = false;
                CustPaging.Visible = false;

                imgBtnExport.Visible = false;
                //imgBtnUpdate.Visible = false;

                lbStatus.Text = "No Information Entered Yet";
            }
        }

        #endregion

    }
}