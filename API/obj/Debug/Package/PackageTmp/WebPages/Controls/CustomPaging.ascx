<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomPaging.ascx.cs" Inherits="RESTfulAPI.WebPages.Controls.CustomPaging" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left" style="width: 70%; height: 30px; padding-left: 10px;">
            <asp:LinkButton ID="FirstLink" runat="server" CssClass="CommandButtonExt" 
                Text="<< First" onclick="ChangePage"></asp:LinkButton><asp:LinkButton
                ID="PreviousLink" runat="server" CssClass="CommandButtonExt" 
                Text="< Previous" onclick="ChangePage"></asp:LinkButton><asp:DropDownList
                    ID="JumpPage" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ChangePage">
                </asp:DropDownList>
            <asp:Label ID="lbTotalPages" runat="server" CssClass="simpleTextExt"></asp:Label><asp:LinkButton
                ID="NextLink" runat="server" CssClass="CommandButtonExt" Text="Next >" 
                onclick="ChangePage"></asp:LinkButton><asp:LinkButton
                    ID="LastLink" runat="server" CssClass="CommandButtonExt" 
                Text="Last >>" onclick="ChangePage"></asp:LinkButton>
        </td>
        <td align="right" style="width: 30%; padding-right: 10px;">
            <asp:Label ID="lbRecords" runat="server" CssClass="CommandButtonExt">Total Record(s):</asp:Label><asp:Label
                ID="lbTotalRecords" runat="server" CssClass="CommandButtonExt"></asp:Label>
        </td>
    </tr>
</table>
