using BLL;
using Model;
using System.Collections.Generic;

namespace RESTfulAPI.WebPages
{
    public partial class Setting : System.Web.UI.Page
    {

        #region Event Handlers

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            #region Session Validation
            UserInfo objUser = (UserInfo)Session["loginUser"];

            if (objUser == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            #endregion

            try
            {
                if (!Page.IsPostBack)
                {
                    IList<SmtpsettingInfo> lstSettingInfo = Admin.Smtpsetting.SelectAll();

                    if (lstSettingInfo.Count > 0)
                    {
                        tbSmtpHost.Text = lstSettingInfo[0].Pmhost;
                        tbSmtpPort.Text = lstSettingInfo[0].Pmport.ToString();
                        tbSmtpUsername.Text = lstSettingInfo[0].Pmusername;
                        tbSmtpPassword.Attributes.Add("value", lstSettingInfo[0].Pmpasswrd);
                        chkbxSecure.Checked = lstSettingInfo[0].Pmsecure;
                    }

                    imgSendEmail.Visible = imgBtnAdd.Visible = objUser.Isadminright;
                }
            }
            catch { throw; }
        }

        protected void imgUpdate_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (tbSmtpHost.Text.Trim(' ').Length == 0)
                    {
                        lbMsgSmtpHost.Text = "Smtp Host should be given";
                        tbSmtpHost.Focus();
                        return;
                    }
                    else lbMsgSmtpHost.Text = "";

                    if (tbSmtpPort.Text.Trim(' ').Length == 0)
                    {
                        lbMsgSmtpPort.Text = "Smtp Port should be given";
                        tbSmtpPort.Focus();
                        return;
                    }
                    else lbMsgSmtpPort.Text = "";

                    if (tbSmtpUsername.Text.Trim(' ').Length == 0)
                    {
                        lbMsgSmtpUsername.Text = "Smtp Username should be given";
                        tbSmtpUsername.Focus();
                        return;
                    }
                    else lbMsgSmtpUsername.Text = "";

                    if (tbSmtpPassword.Text.Length == 0)
                    {
                        lbMsgSmtpPassword.Text = "Smtp Password should be given";
                        tbSmtpPassword.Focus();
                        return;
                    }
                    else lbMsgSmtpPassword.Text = "";

                    SmtpsettingInfo objSmtpInfo = new SmtpsettingInfo();

                    objSmtpInfo.Pmhost = tbSmtpHost.Text.Trim(' ');
                    objSmtpInfo.Pmport = int.Parse(tbSmtpPort.Text.Trim(' '));
                    objSmtpInfo.Pmusername = tbSmtpUsername.Text.Trim(' ');
                    objSmtpInfo.Pmpasswrd = tbSmtpPassword.Text;
                    objSmtpInfo.Pmsecure = chkbxSecure.Checked;
                    objSmtpInfo.Updatedby = ((UserInfo)Session["loginUser"]).Userid;
                    objSmtpInfo.Updateddate = System.DateTime.Now;

                    Admin.Smtpsetting.Update(objSmtpInfo);

                    Response.Redirect("~/WebPages/ListActiveContentRequest.aspx");
                }
                catch
                {
                    throw;
                }
            }
        }

        protected void imgSendEmail_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (EVueSharedClass.SendEmail(tbSmtpUsername.Text.Trim(' '), "EnableVue test email", "EnableVue test email", tbSmtpHost.Text.Trim(' '),
                int.Parse(tbSmtpPort.Text.Trim(' ')), tbSmtpUsername.Text.Trim(' '), tbSmtpPassword.Text, chkbxSecure.Checked))
            {
                lbStatus.ForeColor = System.Drawing.Color.Green;
                lbStatus.Text = "Message sent";
            }
            else
            {
                lbStatus.Text = "Message not sent";
                lbStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion


    }
}