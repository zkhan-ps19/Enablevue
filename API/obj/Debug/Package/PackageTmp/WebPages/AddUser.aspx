<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/Main.Master" AutoEventWireup="true"
    Theme="Label" CodeBehind="AddUser.aspx.cs" Inherits="RESTfulAPI.WebPages.AddUser" %>

<asp:Content ID="Content3" ContentPlaceHolderID="title" runat="server">
    EnableVue - User Management
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="Headers">
        <div id="Headers-title">
            <b>
                <asp:Label ID="lbTitle" runat="server" ClientIDMode="Static" Text="Add User" /></b></div>
        <div id="Headers-Controls">
        </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="Label" align="right" style="height: 25px; width: 21%;">
                User Name:
            </td>
            <td style="width: 1%">
                <asp:Label ID="Label19" runat="server" SkinID="FieldMandatoryMessage" ClientIDMode="Static">*</asp:Label>
            </td>
            <td align="left" style="width: 25%">
                <asp:TextBox ID="tbUName" runat="server" Width="150px" MaxLength="20" ClientIDMode="Static"></asp:TextBox>
            </td>
            <td align="right" class="Label" style="width: 17%">
                Enable:
            </td>
            <td style="width: 1%">
            </td>
            <td align="left" style="width: 30%" colspan="">
                <asp:CheckBox ID="chkbxStatus" runat="server" CssClass="simpleCheckbox" ClientIDMode="Static" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:RequiredFieldValidator ID="vldReqUName" runat="server" ControlToValidate="tbUName"
                    Display="Dynamic" ErrorMessage="User Name should be given" SetFocusOnError="True"
                    ValidationGroup="vldGrpSaveMN" CssClass="RequiredMessage"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:Label ID="lbMsgUser" runat="server" CssClass="RequiredMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label" align="right" style="width: 10%; height: 25px; white-space: nowrap">
                First Name:
            </td>
            <td style="width: 1%">
                <asp:Label ID="Label18" runat="server" SkinID="FieldMandatoryMessage" ClientIDMode="Static"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="tbFName" runat="server" Width="150px" MaxLength="30" CausesValidation="True"
                    ClientIDMode="Static"></asp:TextBox>
            </td>
            <td align="right" class="Label">
                Last Name:
            </td>
            <td>
            </td>
            <td align="left">
                <asp:TextBox ID="tbLName" runat="server" CausesValidation="True" MaxLength="30" Width="150px"
                    ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:RequiredFieldValidator ID="vldReqFName" runat="server" ControlToValidate="tbFName"
                    Display="Dynamic" ErrorMessage="First Name should be given" SetFocusOnError="True"
                    ValidationGroup="vldGrpSaveMN" CssClass="RequiredMessage"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:Label ID="lbMsgFirst" runat="server" CssClass="RequiredMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label" align="right" style="height: 25px">
                Email:
            </td>
            <td>
                <asp:Label ID="Label22" runat="server" SkinID="FieldMandatoryMessage" ClientIDMode="Static"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="tbEmail" runat="server" Width="150px" MaxLength="50" ClientIDMode="Static"></asp:TextBox>
            </td>
            <td align="right" class="Label">
                Phone:
            </td>
            <td>
            </td>
            <td align="left">
                <asp:TextBox ID="tbPhone" runat="server" CausesValidation="True" MaxLength="30" Width="150px"
                    ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:RequiredFieldValidator ID="vldReqEmail" runat="server" ControlToValidate="tbEmail"
                    Display="Dynamic" ErrorMessage="Email Address should be given" SetFocusOnError="True"
                    ValidationGroup="vldGrpSaveMN" CssClass="RequiredMessage"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbEmail"
                    CssClass="RequiredMessage" Display="Dynamic" ErrorMessage="Invalid Email Address"
                    SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="vldGrpSaveMN"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:Label ID="lbMsgEmail" runat="server" CssClass="RequiredMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Label" style="height: 25px">
                Address:
            </td>
            <td>
            </td>
            <td align="left">
                <asp:TextBox ID="tbAddress" runat="server" CausesValidation="True" MaxLength="30"
                    Width="150px" ClientIDMode="Static"></asp:TextBox>
            </td>
            <td align="right" class="Label" style="height: 25px">
                City:
            </td>
            <td>
            </td>
            <td align="left">
                <asp:TextBox ID="tbCity" runat="server" Width="150px" MaxLength="15" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 3px">
            </td>
        </tr>
        <tr>
            <td align="right" class="Label" style="height: 25px">
                Country:
            </td>
            <td>
            </td>
            <td align="left">
                <asp:DropDownList ID="dplCountry" runat="server" Width="160px" ClientIDMode="Static"
                    AutoPostBack="True" OnSelectedIndexChanged="dplCountry_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="Label" align="right" style="height: 25px">
                State:
            </td>
            <td>
            </td>
            <td align="left">
                <asp:DropDownList ID="dplState" runat="server" Width="160px" ClientIDMode="Static">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 3px">
            </td>
        </tr>
        <tr>
            <td align="right" class="Label" style="height: 25px">
                Password:
            </td>
            <td>
                <asp:Label ID="Label20" runat="server" SkinID="FieldMandatoryMessage" ClientIDMode="Static"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="150px" MaxLength="15"
                    ClientIDMode="Static"></asp:TextBox>
            </td>
            <td align="right" class="Label">
                Admin Rights:
            </td>
            <td>
            </td>
            <td align="left" colspan="2">
                <asp:CheckBox ID="chkbxAdminRights" runat="server" CssClass="simpleCheckbox" ClientIDMode="Static" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="vldReqPassword" runat="server" ControlToValidate="tbPassword"
                                Display="Dynamic" ErrorMessage="Password should be given" SetFocusOnError="True"
                                ValidationGroup="vldGrpSaveMN" CssClass="RequiredMessage"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbMsgNew" runat="server" CssClass="RequiredMessage"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" class="Label" style="height: 25px">
                Confirm Password:
            </td>
            <td>
                <asp:Label ID="Label21" runat="server" SkinID="FieldMandatoryMessage" ClientIDMode="Static"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="tbCPassword" runat="server" TextMode="Password" Width="150px" MaxLength="15"
                    ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td colspan="4">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="vldReqCPassword" runat="server" ControlToValidate="tbCPassword"
                                Display="Dynamic" ErrorMessage="Confirm Password should be given" SetFocusOnError="True"
                                ValidationGroup="vldGrpSaveMN" CssClass="RequiredMessage"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:CompareValidator ID="vldCPassword" runat="server" ControlToCompare="tbCPassword"
                                ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="Both Passwords should be same"
                                ValidationGroup="vldGrpSaveMN" CssClass="RequiredMessage"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbMsgConf" runat="server" CssClass="RequiredMessage"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="Controls">
        <div style="float: left">
            <asp:ImageButton ID="imgBtnAdd" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/btn-save.png"
                OnClick="imgUpdate_Click" ValidationGroup="vldGrpSaveMN" ClientIDMode="Static" />
            <asp:ImageButton ID="imgBtnCancel" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/btn-Cancel.png"
                PostBackUrl="~/WebPages/ListUsers.aspx" ClientIDMode="Static" />
            <asp:Label ID="lbStatus" runat="server" CssClass="RequiredMessage"></asp:Label>
        </div>
    </div>
</asp:Content>
