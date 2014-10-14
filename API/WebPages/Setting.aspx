<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/Main.Master" AutoEventWireup="true"
    Theme="Label" CodeBehind="Setting.aspx.cs" Inherits="RESTfulAPI.WebPages.Setting" %>

<asp:Content ID="Content3" ContentPlaceHolderID="title" runat="server">
    EnableVue - User Management
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="Headers">
        <div id="Headers-title">
            <b>
                <asp:Label ID="lbTitle" runat="server" ClientIDMode="Static" Text="Setting" /></b></div>
        <div id="Headers-Controls">
        </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="Label" align="right" style="height: 25px; width: 21%;">
                Smtp Host:
            </td>
            <td style="width: 1%">
                <asp:Label ID="Label19" runat="server" SkinID="FieldMandatoryMessage" ClientIDMode="Static"></asp:Label>
            </td>
            <td align="left" style="width: 25%">
                <asp:TextBox ID="tbSmtpHost" runat="server" Width="200px" MaxLength="20" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:RequiredFieldValidator ID="vldReqUName" runat="server" ControlToValidate="tbSmtpHost"
                    Display="Dynamic" ErrorMessage="Smtp Host should be given" SetFocusOnError="True"
                    ValidationGroup="vldGrpSaveMN" CssClass="RequiredMessage"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:Label ID="lbMsgSmtpHost" runat="server" CssClass="RequiredMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label" align="right" style="width: 10%; height: 25px; white-space: nowrap">
                Smtp Port:
            </td>
            <td style="width: 1%">
                <asp:Label ID="Label18" runat="server" SkinID="FieldMandatoryMessage" ClientIDMode="Static"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="tbSmtpPort" runat="server" Width="200px" MaxLength="30" CausesValidation="True"
                    ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:RequiredFieldValidator ID="vldReqFName" runat="server" ControlToValidate="tbSmtpPort"
                    Display="Dynamic" ErrorMessage="Smtp Port should be given" SetFocusOnError="True"
                    ValidationGroup="vldGrpSaveMN" CssClass="RequiredMessage"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:Label ID="lbMsgSmtpPort" runat="server" CssClass="RequiredMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label" align="right" style="height: 25px">
                Smtp Username:
            </td>
            <td>
                <asp:Label ID="Label22" runat="server" SkinID="FieldMandatoryMessage" ClientIDMode="Static"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="tbSmtpUsername" runat="server" Width="200px" MaxLength="50" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:RequiredFieldValidator ID="vldReqEmail" runat="server" ControlToValidate="tbSmtpUsername"
                    Display="Dynamic" ErrorMessage="Smtp Username should be given" SetFocusOnError="True"
                    ValidationGroup="vldGrpSaveMN" CssClass="RequiredMessage"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbSmtpUsername"
                    CssClass="RequiredMessage" Display="Dynamic" ErrorMessage="Invalid Smtp Username"
                    SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="vldGrpSaveMN"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:Label ID="lbMsgSmtpUsername" runat="server" CssClass="RequiredMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Label" style="height: 25px">
                Smtp Password:
            </td>
            <td>
                <asp:Label ID="Label23" runat="server" SkinID="FieldMandatoryMessage" ClientIDMode="Static"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="tbSmtpPassword" runat="server" CausesValidation="True" MaxLength="30"
                    TextMode="Password" Width="200px" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbSmtpPassword"
                    Display="Dynamic" ErrorMessage="Smtp Password should be given" SetFocusOnError="True"
                    ValidationGroup="vldGrpSaveMN" CssClass="RequiredMessage"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td align="left" colspan="4">
                <asp:Label ID="lbMsgSmtpPassword" runat="server" CssClass="RequiredMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 3px">
            </td>
        </tr>
        <tr>
            <td align="right" class="Label" style="height: 25px">
                Smtp Secure:
            </td>
            <td>
            </td>
            <td align="left">
                <asp:CheckBox ID="chkbxSecure" runat="server" CssClass="simpleCheckbox" ClientIDMode="Static" />
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 3px">
                &nbsp;
            </td>
        </tr>
    </table>
    <div id="Controls">
        <div style="float: left">
            <asp:ImageButton ID="imgSendEmail" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/btn-SendTestEmail.png"
                ValidationGroup="vldGrpSaveMN" ClientIDMode="Static" OnClick="imgSendEmail_Click" />
            <asp:ImageButton ID="imgBtnAdd" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/btn-save.png"
                OnClick="imgUpdate_Click" ValidationGroup="vldGrpSaveMN" ClientIDMode="Static" />
            <asp:ImageButton ID="imgBtnCancel" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/btn-Cancel.png"
                PostBackUrl="~/WebPages/ListActiveContentRequest.aspx" ClientIDMode="Static" />
            <asp:Label ID="lbStatus" runat="server" CssClass="RequiredMessage"></asp:Label>
        </div>
    </div>
</asp:Content>
