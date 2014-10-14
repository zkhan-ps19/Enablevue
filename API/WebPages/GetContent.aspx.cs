using System;
using System.Collections.Generic;
using System.Web.UI;
using BLL;
using Model;

namespace RESTfulAPI.WebPages
{
    public partial class GetContent : System.Web.UI.Page
    {
        int requestId = 0;
        string strType = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Session Validation
            UserInfo objUser = (UserInfo)Session["loginUser"];

            if (objUser == null)
            {
                Response.Redirect("~/WebPages/Login.aspx", true);
            }
            #endregion

            if (Request.QueryString["type"] == "active")
                strType = "ListActiveContentRequest.aspx";
            else strType = "ListArchiveContentRequest.aspx";

            if (Request.QueryString["rId"] != null)
                requestId = int.Parse(Request.QueryString["rId"]);
            else Response.Redirect(strType);

            if (!Page.IsPostBack)
            {
                ContentrequestInfo cReqInfo = Admin.ContentRequest.SelectByPK(requestId);
                IList<ContentInfo> lstContInfo = Admin.Content.SelectAllWhereCustom("ContentRequestId =" + requestId, "ContentId desc");

                if (cReqInfo == null || lstContInfo.Count == 0)
                    Response.Redirect(strType, true);

                lbCRId.Text = cReqInfo.Requestcode;
                lbCRName.Text = cReqInfo.Name;

                lbAuthor.Text = lstContInfo[0].AuthorFullname;
                lbTitle.Text = lstContInfo[0].Title;
                lbSource.Text = lstContInfo[0].Source;
                lbDetail.Text = lstContInfo[0].Contentdetail;
                lbCategory.Text = lstContInfo[0].Category;

                if (cReqInfo.Contentstatuscode == 201 || cReqInfo.Contentstatuscode == 250 || cReqInfo.Contentstatuscode == 260)
                {
                    pnlError.Visible = true;

                    lbStatus.Text = Admin.ContentStatus.SelectByPK(cReqInfo.Contentstatuscode).Contentstatus;

                    IList<ContentstatuserrorInfo> lstErrorInfo = Admin.ContentStatusError.SelectAllByFKContentrequestid(cReqInfo.Contentrequestid);

                    if (lstErrorInfo.Count > 0)
                    {
                        rptError.DataSource = lstErrorInfo;
                        rptError.DataBind();
                    }
                }
            }
        }

        protected void imgBtnDownload_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DownloadContent.aspx?rId=" + requestId, true);
        }
    }
}