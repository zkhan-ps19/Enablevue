<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/Main.Master" AutoEventWireup="true"
    CodeBehind="ListActiveContentRequest.aspx.cs" Inherits="RESTfulAPI.WebPages.ListActiveContentRequest" %>

<%@ Register Src="~/WebPages/Controls/CustomPaging.ascx" TagName="CustomPaging" TagPrefix="uc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="title" runat="server">
    EnableVue - Request Management
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script type="text/javascript">
        function selectCheckbox(dplStatus) {
            document.getElementById(dplStatus.id.toString().replace("dplContentStatus", "chkBoxSelect")).checked = true;
        }
    </script>
    <asp:HiddenField runat="server" ID="hdFieldTotalRecord" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdFieldQuery" ClientIDMode="Static" Value="" />
    <div id="Headers">
        <div id="Headers-title">
            <b>Content Request List</b></div>
        <div id="Filters-Controls" style="float: right; width: 340px; height: 25px; margin-top: 10px;">
            <div class="Filters-ControlsSub">
                Content Type
                <asp:DropDownList runat="server" ID="dplContentType" AutoPostBack="True" OnSelectedIndexChanged="dplContentType_SelectedIndexChanged"
                    Width="160px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem Value="A">Article</asp:ListItem>
                    <asp:ListItem Value="B">Blog</asp:ListItem>
                    <asp:ListItem Value="MCB">Marketing Copy Branded</asp:ListItem>
                    <asp:ListItem Value="MCU">Marketing Copy Unbranded</asp:ListItem>
                    <asp:ListItem Value="SC">Supplemental Content</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="Filters-ControlsSub">
                Content Status
                <asp:DropDownList runat="server" ID="dplContentStatus" AutoPostBack="True" OnSelectedIndexChanged="dplContentStatus_SelectedIndexChanged"
                    Width="160px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem Value="130">Content Write Complete</asp:ListItem>
                    <asp:ListItem Value="140">Content Edit Complete</asp:ListItem>
                    <asp:ListItem Value="150">Content Ready</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div style="margin-top: 8px; clear: both;">
        <uc1:CustomPaging ID="CustPaging" runat="server" TotalRecordText="Total Request(s):"
            OnChangePageClick="ChangePage" ClientIDMode="Static" />
    </div>
    <asp:Repeater ID="rptContentRequest" runat="server" OnItemDataBound="rptContentRequest_ItemDataBound">
        <HeaderTemplate>
            <div id="DataTable">
                <div id="DataRowTitle">
                    <div class="Title_Col" style="width: 4%">
                        <input id="chkAll" runat="server" type="checkbox" onclick="SelectAllCheckboxes(this,'rptContentRequest')" />
                    </div>
                    <div class="Title_Col" style="width: 13%">
                        Availability</div>
                    <div class="Title_Col" style="width: 10%">
                        CR Id</div>
                    <div class="Title_Col" style="width: 19%">
                        CR Name</div>
                    <div class="Title_Col" style="width: 19%">
                        Customer</div>
                    <div class="Title_Col" style="width: 14%">
                        Content Type</div>
                    <div class="Title_Col" style="width: 19%">
                        Content Status</div>
                </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="DataRow">
                <div class="Data_Col" style="width: 4%">
                    <asp:CheckBox runat="server" ID="chkBoxSelect" />
                    <asp:HiddenField runat="server" ID="hdFieldCRequestId" Value='<%# Eval("ContentRequestId") %>' />
                </div>
                <div class="Data_Col" style="width: 13%">
                    <asp:ImageButton ID="imgBtnStatus" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/info.png"
                        Height="24px" Width="24px" />
                </div>
                <div class="Data_Col" style="width: 10%; word-wrap: break-word">
                    <asp:Label ID="lbRequestCode" runat="server" Text='<%# Eval("RequestCode") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 19%; word-wrap: break-word">
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Name") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 19%">
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Customername") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 14%">
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Contenttypename") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 19%">
                    <asp:DropDownList runat="server" ID="dplContentStatus" Width="140px" onchange="javascript:selectCheckbox(this)">
                        <asp:ListItem Value="130">Content Write Complete</asp:ListItem>
                        <asp:ListItem Value="140">Content Edit Complete</asp:ListItem>
                        <asp:ListItem Value="150">Content Ready</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="DataRowAlt">
                <div class="Data_Col" style="width: 4%">
                    <asp:CheckBox runat="server" ID="chkBoxSelect" />
                    <asp:HiddenField runat="server" ID="hdFieldCRequestId" Value='<%# Eval("ContentRequestId") %>' />
                </div>
                <div class="Data_Col" style="width: 13%">
                    <asp:ImageButton ID="imgBtnStatus" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/info.png"
                        Height="24px" Width="24px" />
                </div>
                <div class="Data_Col" style="width: 10%; word-wrap: break-word">
                    <asp:Label ID="lbRequestCode" runat="server" Text='<%# Eval("RequestCode") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 19%; word-wrap: break-word">
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Name") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 19%">
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Customername") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 14%">
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Contenttypename") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 19%">
                    <asp:DropDownList runat="server" ID="dplContentStatus" Width="140px" onchange="javascript:selectCheckbox(this)">
                        <asp:ListItem Value="130">Content Write Complete</asp:ListItem>
                        <asp:ListItem Value="140">Content Edit Complete</asp:ListItem>
                        <asp:ListItem Value="150">Content Ready</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <div id="Controls">
        <div style="float: left">
            <asp:ImageButton ID="imgBtnExport" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/btn-Export.png"
                ClientIDMode="Static" OnClick="imgBtnExport_Click" />
        </div>
        <div style="float: right">
            <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/btn-Update.png"
                ClientIDMode="Static" OnClick="imgBtnUpdate_Click" />
        </div>
        <div style="float: right; margin-right: 5px;">
            <asp:ImageButton ID="imgBtnBack" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/btn-Back.png"
                ClientIDMode="Static" OnClick="imgBtnBack_Click" />
        </div>
        <asp:Label ID="lbStatus" EnableViewState="False" CssClass="statusMessage" runat="server"
            ClientIDMode="Static"></asp:Label>
    </div>
</asp:Content>
