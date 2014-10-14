using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace RESTfulAPI.WebPages
{
    public partial class ListUsers : System.Web.UI.Page
    {
        #region Variables
        public bool isAdminRights = false;
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

            try
            {
                if (!Page.IsPostBack)
                {
                    isAdminRights = ((UserInfo)Session["loginUser"]).Isadminright;

                    rptUser.DataSource = Admin.User.SelectAllWhere("IsDeleted = '0'", "UserName", 1, 10);
                    rptUser.DataBind();

                    if (rptUser.Items.Count > 0)
                    {
                        hdFieldTotalRecord.Value = Admin.User.CountAllWhere("IsDeleted = '0'").ToString();
                        CustPaging.Paging(1, 10, int.Parse(hdFieldTotalRecord.Value));
                    }
                    else
                    {
                        CustPaging.Visible = false;
                        lbStatus.Text = "No Information Entered Yet";
                    }

                    imgBtnAdd.Visible = isAdminRights;
                }
            }
            catch (Exception exc)
            {
                lbStatus.Text = exc.Message;
            }
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

            rptUser.DataSource = Admin.User.SelectAllWhere("IsDeleted = '0'", "UserName", pageNumber, 10);
            rptUser.DataBind();
        }

        #endregion

        #endregion
    }
}