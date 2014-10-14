using System;
using System.Collections.Generic;
using System.Web.UI;
using BLL;
using Model;

namespace RESTfulAPI.WebPages
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbUsername.Focus();
        }

        protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                IList<UserInfo> lstUsers = Admin.User.SelectAllWhere("UserName = '" + tbUsername.Text.Trim(' ') + "' and IsEnabled = '1' and IsDeleted = '0'", "");

                if (lstUsers.Count > 0)
                {
                    if (!lstUsers[0].IsEmailNull)
                    {
                        string style = "<style> .loginTitleHeading { font-family: Arial, Verdana, Helvetica, sans-serif; font-size: 14pt; font-weight: bold; color: #ffffff; padding: 3px; text-align: center; background-color: #6e765b; height: 31px; border: 1px solid gray; } .textContentLogin { font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 10pt; font-weight: normal; border-top: 1px solid #999999; border-bottom: 1px solid #999999; color: #000000; text-align: left; padding: 5px; text-decoration: none; } .textContentHints { font-family: Arial, Verdana, Helvetica, sans-serif; font-size: 11pt; color: #005aa4; text-align: left; padding: 8px; background-color: #eef1f5; } .textContentHintsText { font-weight: normal; } .textContentHintsTextBold { font-weight: bold; } </style>";
                        string Body = "<body>" + style + " <table width=\"500px\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\"> <tr> <td> </td> </tr> <tr> <td class=\"loginTitleHeading\"> Password Recovery </td> </tr> <tr> <td> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"border: 1px solid #6e765b;\"> <tr> <td class=\"textContentHints\" colspan=\"3\"> <br /> <span class=\"textContentHintsText\">Dear " + lstUsers[0].Firstname + ",</span> <br /> <br /> <span class=\"textContentHintsText\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Your Password for the username \"" + lstUsers[0].Username + "\" is \"" + lstUsers[0].Password + "\". For further details Contact your Administrator.</span> <br /> <br /> <span class=\"textContentHintsText\">Regards,</span><br /> <span class=\"textContentHintsText\">EnableVue Application</span> <br /><br /> </td> </tr> </table> </td> </tr> </table></body>";

                        EVueSharedClass.SendEmail(lstUsers[0].Email, "Password Recovery", Body);

                        lbStatus.ForeColor = System.Drawing.Color.Green;
                        lbStatus.Visible = true;
                        lbStatus.Text = "Email Sent to User \"" + tbUsername.Text.Trim(' ') + "\"";
                    }
                    else
                    {
                        lbStatus.ForeColor = System.Drawing.Color.Red;
                        lbStatus.Visible = true;
                        lbStatus.Text = "Email id of User \"" + tbUsername.Text.Trim(' ') + "\" has not been provided. Contact Administrator for further help.";
                    }

                }
                else
                {
                    lbStatus.Text = "Not a valid User ID.";
                    lbStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}