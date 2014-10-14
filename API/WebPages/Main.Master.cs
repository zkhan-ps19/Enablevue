using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace RESTfulAPI.WebPages
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Session Validation
            UserInfo objUser = (UserInfo)Session["loginUser"];

            if (objUser == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            #endregion

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["search"] != null)
                    tbSearch.Text = Request.QueryString["search"];

                lbUsername.Text = objUser.Firstname + " " + objUser.Lastname;
            }
        }

        protected void imgSearch_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (tbSearch.Text.Trim(' ').Length > 0)
            {
                string urlPath = Request.Url.ToString();

                if (urlPath.Contains("?"))
                    urlPath = urlPath.Substring(0, urlPath.IndexOf("?"));

                Response.Redirect(urlPath + "?search=" + tbSearch.Text.Trim(' '));
            }
            else
            {
                tbSearch.Focus();
            }
        }

        protected void lnkBtnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();

            Session["loginUser"] = null;
            Response.Redirect("Login.aspx", true);
        }

    }
}