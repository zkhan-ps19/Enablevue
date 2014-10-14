<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="RESTfulAPI.WebPages.ForgotPassword" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Password Recovery</title>
    <link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formLogin" runat="server">
    <div id="page">
        <div id="logo-img">
            <img src="Images/logo.png" width="131" height="92"></div>
        <div id="fgPassword-Box">
            <div id="fgPassword-title">
                Forgot Password
            </div>
            <div id="login-message">
                <asp:Label ID="lbStatus" runat="server" CssClass="errorMessage"></asp:Label>
            </div>
            <div id="fgPasswordInput">
                <div id="UserNameTitle">
                    UserName:
                    <asp:RequiredFieldValidator ID="vld_req_tb_user_id" runat="server" ErrorMessage="Username should be given"
                        ControlToValidate="tbUsername" Display="None" SetFocusOnError="True" ValidationGroup="vld_login"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbUsername" runat="server" Width="150px"></asp:TextBox>
                </div>
            </div>
            <div id="bgBtn" style="text-align: center;">
                <asp:ImageButton ID="imgBtnSubmit" runat="server" ImageUrl="~/WebPages/Images/btn-submit.png"
                    ValidationGroup="vld_login" Style="height: 27px; background-image: url(Images/btn-submit.png);
                    background-color: transparent; border-color: transparent; background-repeat: no-repeat"
                    OnClick="imgBtnSubmit_Click" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="vld_login" />
            </div>
            <div style="font-family: Arial; font-size: 14px; text-align: left; margin: 5px;">
                Based upon the provided &quot;Username&quot; password shall be emailed to the respective
                user's email address.
            </div>
    </div>
    </form>
    <br />
</body>
</html>
