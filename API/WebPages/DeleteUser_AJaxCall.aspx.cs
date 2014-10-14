using System;
using Model;

namespace RESTfulAPI.WebPages
{
    public partial class DeleteUser_AJaxCall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Session Validation
            UserInfo objUser = (UserInfo)Session["loginUser"];

            if (objUser == null)
            {
                Response.Redirect("Login.aspx", true);

                Response.Write("-1");
            }
            #endregion

            try
            {
                //Check User Login
                //if (EVueSharedClass.CheckLoginUser(objUser) == false)
                //{
                //    Response.Write("-1");
                //}
                //else
                //{
                    BLL.Admin.User.Delete(int.Parse(Request.QueryString["uId"]));
                    Response.Write("1");
                //}
            }
            catch(Exception ex)
            {
                Response.Write("111" + ex.Message );
            }

            Response.Flush();
            Response.End();
        }
    }
}