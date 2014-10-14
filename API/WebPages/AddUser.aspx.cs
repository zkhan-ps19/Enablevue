using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace RESTfulAPI.WebPages
{
    public partial class AddUser : System.Web.UI.Page
    {
        #region Private Members
        private int userId = 0;
        #endregion

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

            if (Request.QueryString["uId"] != null)
            {
                userId = int.Parse(Request.QueryString["uId"]);
            }

            try
            {
                if (!Page.IsPostBack)
                {
                    if (!((UserInfo)Session["loginUser"]).Isadminright)
                        Response.Redirect("ListUsers.aspx#Config-page1", true);

                    if (userId > 0)//isEdit
                    {
                        UserInfo objUserInfo = Admin.User.SelectByPK(userId);

                        if (objUserInfo == null)
                            Response.Redirect("ListUsers.aspx", true);

                        lbTitle.Text = "Edit User [" + objUserInfo.Username + "]";

                        PopulateEdit(objUserInfo);
                    }
                    else
                    {
                        PopulateEdit(null);
                    }

                    tbUName.Focus();
                }
            }
            catch (Exception exc) { throw; }
        }

        protected void dplCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dplCountry.SelectedIndex > 0)
            {
                dplState.DataSource = Admin.CountryState.SelectAllByFKCountryid(int.Parse(dplCountry.SelectedValue));
                dplState.DataTextField = "Name";
                dplState.DataValueField = "StateId";
                dplState.DataBind();

                dplState.Items.Insert(0, new ListItem("------ Select State ------", string.Empty));
            }
            else
                dplState.Items.Clear();
        }

        protected void imgUpdate_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (tbFName.Text.Trim(' ').Length == 0)
                    {
                        lbMsgFirst.Text = "First Name should be given";
                        tbFName.Focus();
                        return;
                    }
                    else lbMsgFirst.Text = "";

                    if (tbUName.Text.Trim(' ').Length == 0)
                    {
                        lbMsgUser.Text = "User Name should be given";
                        tbUName.Focus();
                        return;
                    }
                    else lbMsgUser.Text = "";

                    if (tbPassword.Text.Length == 0)
                    {
                        lbMsgNew.Text = "Password should be given";
                        tbPassword.Focus();
                        return;
                    }
                    else lbMsgNew.Text = "";

                    if (tbCPassword.Text.Length == 0)
                    {
                        lbMsgConf.Text = "Confirm Password should be given";
                        tbCPassword.Focus();
                        return;
                    }
                    else lbMsgConf.Text = "";

                    if (tbPassword.Text != tbCPassword.Text)
                    {
                        lbMsgConf.Text = "The passwords you typed do not match. Type the password in both text boxes";
                        tbCPassword.Focus();
                        return;
                    }
                    else lbMsgConf.Text = "";

                    if (EVueSharedClass.isValidEmail(tbEmail.Text.Trim(' ')) == false)
                    {
                        lbMsgEmail.Text = "Invalid Email Address";
                        tbEmail.Focus();
                        return;
                    }
                    else lbMsgEmail.Text = "";

                    UserInfo objUserInfo = new UserInfo();

                    objUserInfo.Username = tbUName.Text.Trim(' ');
                    objUserInfo.Firstname = tbFName.Text.Trim(' ');
                    objUserInfo.Lastname = tbLName.Text.Trim(' ');
                    objUserInfo.Email = tbEmail.Text.Trim(' ');
                    objUserInfo.Phone = tbPhone.Text.Trim(' ');
                    objUserInfo.Address = tbAddress.Text.Trim(' ');
                    objUserInfo.City = tbCity.Text.Trim(' ');
                    objUserInfo.Isenabled = chkbxStatus.Checked;
                    objUserInfo.Isdeleted = false;
                    objUserInfo.Isdefault = false;
                    objUserInfo.Updatedby = ((UserInfo)Session["loginUser"]).Userid;
                    objUserInfo.Password = tbPassword.Text;
                    objUserInfo.Isadminright = chkbxAdminRights.Checked;

                    if (dplCountry.SelectedIndex > 0)
                        objUserInfo.Countryid = int.Parse(dplCountry.SelectedValue);

                    if (dplState.SelectedIndex > 0)
                        objUserInfo.Stateid = int.Parse(dplState.SelectedValue);

                    string strQuery = string.Empty;

                    if (userId > 0)//edit user
                    {
                        objUserInfo.Updateddate = DateTime.Now;
                        objUserInfo.Userid = userId;

                        Admin.User.Update(objUserInfo);

                        if (objUserInfo.Userid == objUserInfo.Updatedby)
                            Session["loginUser"] = objUserInfo;
                    }
                    else//add new user
                    {
                        objUserInfo.Createddate = DateTime.Now;

                        Admin.User.Insert(objUserInfo);
                    }

                    Response.Redirect("~/WebPages/ListUsers.aspx");
                }
                catch (Exception exc)
                {
                    if (exc is System.Data.SqlClient.SqlException == true)
                    {
                        lbStatus.Text = exc.Message;
                        lbMsgUser.Text = "User Name already exists";
                    }
                }
            }
        }

        #endregion

        #region Methods

        private void PopulateEdit(UserInfo objUserInfo)
        {
            try
            {
                dplCountry.DataSource = Admin.Country.SelectAll();
                dplCountry.DataTextField = "Name";
                dplCountry.DataValueField = "CountryId";
                dplCountry.DataBind();

                if (objUserInfo != null)
                {
                    tbUName.Text = objUserInfo.Username;
                    chkbxStatus.Checked = objUserInfo.Isenabled;
                    tbFName.Text = objUserInfo.Firstname;
                    tbLName.Text = objUserInfo.Lastname;
                    tbEmail.Text = objUserInfo.Email;
                    tbPhone.Text = objUserInfo.Phone;
                    tbAddress.Text = objUserInfo.Address;
                    tbCity.Text = objUserInfo.City;

                    if (objUserInfo.Countryid > 0)
                    {
                        dplCountry.SelectedValue = objUserInfo.Countryid.ToString();
                        dplCountry_SelectedIndexChanged(null, null);
                    }

                    if (objUserInfo.Stateid > 0)
                        dplState.SelectedValue = objUserInfo.Stateid.ToString();

                    tbPassword.Attributes.Add("value", objUserInfo.Password);
                    tbCPassword.Attributes.Add("value", objUserInfo.Password);

                    chkbxAdminRights.Checked = objUserInfo.Isadminright;
                }

                dplCountry.Items.Insert(0, new ListItem("------ Select Country ------", string.Empty));
            }
            catch (Exception exc) { }
        }

        #endregion
    }
}