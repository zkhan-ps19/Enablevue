using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using BLL;
using Model;

namespace RESTfulAPI.WebPages
{
    public partial class Login : System.Web.UI.Page
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            tbUserId.Focus();
            tbPassword.Attributes.Add("value", "admin");
        }

        protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string strUser = tbUserId.Text.Trim(' ');

                    IList<UserInfo> lstUsers = Admin.User.SelectAllWhere("UserName = '" + strUser + "' and Password = '" + tbPassword.Text.Trim(' ') + "'", "");

                    if (lstUsers.Count > 0)
                    {
                        Session["loginUser"] = lstUsers[0];

                        Response.Redirect("ListActiveContentRequest.aspx", true);
                    }
                    else lbStatus.Text = "Incorrect UserName/Password.";
                }
                catch
                {
                    throw;
                }
            }
        }

        #endregion
    }
}