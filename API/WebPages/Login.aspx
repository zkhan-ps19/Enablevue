<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RESTfulAPI.WebPages.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EnableVue Login [Version 0.0.0.7]</title>
    <link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function OpenNewWindow(url) {
            var arg3 = ",width=600,height=400,left=10,top=10,toolbar=no,directories=no,status=no,linemenubar=no,scrollbars=no,resizable=no,titlebar=no,location=no";
            window.open(url, "", arg3);
        }
    </script>
</head>
<body>
    <form id="formLogin" runat="server">
    <div id="page">
        <div id="logo-img">
            <img src="Images/logo.png" width="131" height="92"></div>
        <div id="login-Box">
            <div id="login-title">
                Login
            </div>
            <div id="login-message">
                <asp:Label ID="lbStatus" runat="server" CssClass="errorMessage"></asp:Label>
            </div>
            <div id="bgInput">
                <div id="UserNameTitle">
                    UserName:
                    <asp:TextBox ID="tbUserId" runat="server" Width="150px" Text="admin" Style="border: 0px solid black;
                        background-color: transparent;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="vld_req_tb_user_id" runat="server" ErrorMessage="UserName should be given"
                        ControlToValidate="tbUserId" Display="None" SetFocusOnError="True" ValidationGroup="vld_login"></asp:RequiredFieldValidator>
                </div>
                <div id="PasswordTitle">
                    Password:
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="password" Width="150px" Style="border: 0px solid black;
                        background-color: transparent;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="vld_req_tb_password" runat="server" ErrorMessage="Password should be given"
                        ControlToValidate="tbPassword" Display="None" SetFocusOnError="True" ValidationGroup="vld_login"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div id="bgBtn">
                <asp:ImageButton ID="imgBtnLogin" runat="server" ImageUrl="Images/btn-login.png"
                    OnClick="imgBtnLogin_Click" ValidationGroup="vld_login" Style="width: 300px;
                    height: 27px; background-image: url(Images/btn-login.png); background-color: transparent;
                    border-color: transparent; background-repeat: no-repeat" />
                <asp:ValidationSummary ID="vld_summary" runat="server" ShowMessageBox="True" ShowSummary="False"
                    ValidationGroup="vld_login" />
                <div id="FP-title" align="right">
                    <a href="#" class="loginLinks" onclick="OpenNewWindow('ForgotPassword.aspx');">Forgot
                        your password?</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
