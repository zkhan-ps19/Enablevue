<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/Main.Master" AutoEventWireup="true"
    CodeBehind="GetContent.aspx.cs" Inherits="RESTfulAPI.WebPages.GetContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    EnableVue - Request's Content
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div id="Headers">
        <div id="Headers-title">
            <b>Request's Content</b></div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="text-align: left">
        <tr>
            <td class="Label" align="right" style="height: 25px; width: 15%;">
                CR Id:
            </td>
            <td style="width: 1%">
            </td>
            <td align="left" style="width: 40%">
                <asp:Label runat="server" ID="lbCRId" ClientIDMode="Static" CssClass="simpleTextLabel"></asp:Label>
            </td>
            <td class="Label" align="right" style="height: 25px; width: 15%;">
                CR Name:
            </td>
            <td style="width: 1%">
            </td>
            <td align="left" style="width: 28%">
                <asp:Label runat="server" ID="lbCRName" ClientIDMode="Static" CssClass="simpleTextLabel"></asp:Label>
            </td>
        </tr>
    </table>
    <hr style="width: 85%;" />
    <table width="96%" border="0" cellpadding="0" cellspacing="0" style="text-align: left">
        <tr>
            <td class="Label" align="right" style="height: 25px; width: 15%;">
                Author:
            </td>
            <td style="width: 1%">
            </td>
            <td align="left" style="width: 84%">
                <asp:Label runat="server" ID="lbAuthor" ClientIDMode="Static" CssClass="simpleTextLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label" align="right" style="height: 25px;">
                Title:
            </td>
            <td>
            </td>
            <td align="left">
                <asp:Label runat="server" ID="lbTitle" ClientIDMode="Static" CssClass="simpleTextLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label" align="right" style="height: 25px; vertical-align: top; padding-top: 5px;">
                Detail:
            </td>
            <td>
            </td>
            <td align="left" style="word-wrap: break-word; width: 84%;">
                <asp:Label runat="server" ID="lbDetail" ClientIDMode="Static" CssClass="simpleTextLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label" align="right" style="height: 25px;">
                Source:
            </td>
            <td>
            </td>
            <td align="left">
                <asp:Label runat="server" ID="lbSource" ClientIDMode="Static" CssClass="simpleTextLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Label" align="right" style="height: 25px;">
                Category:
            </td>
            <td>
            </td>
            <td align="left">
                <asp:Label runat="server" ID="lbCategory" ClientIDMode="Static" CssClass="simpleTextLabel"></asp:Label>
            </td>
        </tr>
    </table>
    <hr style="width: 85%;" />
    <asp:Panel runat="server" ID="pnlError" Visible="false">
        <table width="96%" border="0" cellpadding="0" cellspacing="0" style="text-align: left">
            <tr>
                <td class="Label" align="right" style="height: 25px; width: 15%;">
                    Content Status:
                </td>
                <td style="width: 1%">
                </td>
                <td align="left" style="width: 84%">
                    <asp:Label runat="server" ID="lbStatus" ClientIDMode="Static" CssClass="simpleTextLabel"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Label" align="right" style="height: 25px; vertical-align: top;">
                    Error(s):
                </td>
                <td>
                </td>
                <td align="left" style="padding-top: 5px;">
                    <asp:Repeater ID="rptError" runat="server" ClientIDMode="Static">
                        <HeaderTemplate>
                            <table width="95%" border="0" cellpadding="0" cellspacing="0">
                                <tr class="DataRowTitle1">
                                    <td class="TitleCol12" style="width: 25%">
                                        Error Code
                                    </td>
                                    <td class="TitleCol12" style="width: 75%">
                                        Description
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="DataRow1" style="height: 25px;">
                                <td class="DataCol" align="center" style="padding-left:3px">
                                    <asp:Label ID="lbCode" runat="server" Text='<%# Eval("ErrorCode") %>'> </asp:Label>
                                </td>
                                <td class="DataCol" align="left" style="padding-left:3px">
                                    <asp:Label ID="lbDesc" runat="server" Text='<%# Eval("Description") %>'> </asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="DataRowAlt1" style="height: 25px;">
                                <td class="DataCol" align="center" style="padding-left:3px">
                                    <asp:Label ID="lbCode" runat="server" Text='<%# Eval("ErrorCode") %>'> </asp:Label>
                                </td>
                                <td class="DataCol" align="left" style="padding-left:3px">
                                    <asp:Label ID="lbDesc" runat="server" Text='<%# Eval("Description") %>'> </asp:Label>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <div id="Controls">
        <div style="float: left">
            <asp:ImageButton ID="imgBtnDownload" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/btn-Download.png"
                ClientIDMode="Static" OnClick="imgBtnDownload_Click" />
        </div>
        <div style="float: right">
            <image onclick="javascript:history.go(-1);" src="Images/btn-Back.png" style="cursor: pointer"></image>
        </div>
    </div>
</asp:Content>
