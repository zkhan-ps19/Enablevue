<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/Main.Master" AutoEventWireup="true"
    CodeBehind="ListUsers.aspx.cs" Inherits="RESTfulAPI.WebPages.ListUsers" %>

<%@ Register Src="~/WebPages/Controls/CustomPaging.ascx" TagName="CustomPaging" TagPrefix="uc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="title" runat="server">
    EnableVue - User Management
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:HiddenField runat="server" ID="hdFieldTotalRecord" ClientIDMode="Static" />
    <div id="Headers">
        <div id="Headers-title">
            <b>User List</b></div>
        <div id="Headers-Controls">
        </div>
    </div>
    <div>
        <uc1:CustomPaging ID="CustPaging" runat="server" TotalRecordText="Total User(s):"
            OnChangePageClick="ChangePage" ClientIDMode="Static" />
    </div>
    <asp:Repeater ID="rptUser" runat="server" ClientIDMode="Static">
        <HeaderTemplate>
            <div id="DataTable">
                <div id="DataRowTitle">
                    <div class="Title_Col" style="width: 24%">
                        User Name
                    </div>
                    <div class="Title_Col" style="width: 30%">
                        Full Name
                    </div>
                    <div class="Title_Col" style="width: 15%">
                        Rights
                    </div>
                    <div class="Title_Col" style="width: 15%">
                        Status
                    </div>
                    <div class="Title_Col" style="width: 15%">
                        Edit/Delete
                    </div>
                </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="DataRow">
                <div class="Data_Col" style="width: 24%">
                    <asp:Label ID="lbUserName" runat="server" Text='<%# Eval("UserName") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 30%">
                    <asp:Label EnableViewState="false" ID="lbFullName" runat="server" Text='<%# Eval("FirstName") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 15%">
                    <asp:Label EnableViewState="false" ID="Label2" runat="server" Text='<%# bool.Parse(Eval("Isadminright").ToString())?"Admin":"User" %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 15%">
                    <asp:Label EnableViewState="false" ID="Label1" runat="server" Text='<%# bool.Parse(Eval("Isenabled").ToString())?"Active":"Un-Active" %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 15%">
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/edite.png"
                        Visible='<%# isAdminRights %>' ToolTip="Edit User Information" PostBackUrl='<%# "~/WebPages/AddUser.aspx?uId=" + Eval("UserId").ToString() + "#Config-page1" %>' />&nbsp;&nbsp;&nbsp;<asp:ImageButton
                            ID="imgBtnDelete" ToolTip="Delete User" runat="server" ImageAlign="AbsMiddle"
                            OnClientClick='<%# "javascript:return Delele_Click(" + Eval("UserId").ToString() + ");" %>'
                            Visible='<%# isAdminRights %>' ImageUrl="~/WebPages/Images/delete.png" />
                </div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="DataRowAlt">
                <div class="Data_Col" style="width: 24%">
                    <asp:Label ID="lbUserName" runat="server" Text='<%# Eval("UserName") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 30%">
                    <asp:Label EnableViewState="false" ID="lbFullName" runat="server" Text='<%# Eval("FirstName") %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 15%">
                    <asp:Label EnableViewState="false" ID="Label2" runat="server" Text='<%# bool.Parse(Eval("Isadminright").ToString())?"Admin":"User" %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 15%">
                    <asp:Label EnableViewState="false" ID="Label1" runat="server" Text='<%# bool.Parse(Eval("Isenabled").ToString())?"Active":"Un-Active" %>'> </asp:Label>
                </div>
                <div class="Data_Col" style="width: 15%">
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/edite.png"
                        Visible='<%# isAdminRights %>' ToolTip="Edit User Information" PostBackUrl='<%# "~/WebPages/AddUser.aspx?uId=" + Eval("UserId").ToString() + "#Config-page1" %>' />&nbsp;&nbsp;&nbsp;<asp:ImageButton
                            ID="imgBtnDelete" ToolTip="Delete User" runat="server" ImageAlign="AbsMiddle"
                            OnClientClick='<%# "javascript:return Delele_Click(" + Eval("UserId").ToString() + ");" %>'
                            Visible='<%# isAdminRights %>' ImageUrl="~/WebPages/Images/delete.png" />
                </div>
            </div>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="lbStatus" EnableViewState="False" CssClass="statusMessage" runat="server"
        ClientIDMode="Static"></asp:Label>
    <div id="Controls">
        <div style="float: left">
            <asp:ImageButton ID="imgBtnAdd" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/WebPages/Images/btn-adduser.png"
                PostBackUrl="~/WebPages/AddUser.aspx" ClientIDMode="Static" />
        </div>
    </div>
    <script type="text/javascript">
        var xmlHttp = FactoryXMLHttpRequest();
        function FactoryXMLHttpRequest() {
            if (window.XMLHttpRequest) {
                return new XMLHttpRequest();
            } else if (window.ActiveXObject) {
                var msxmls = new Array('Microsoft.XMLHTTP', 'Msxml2.XMLHTTP');
                try {
                    for (var i = 0; i < msxmls.length; i++)
                        return new ActiveXObject(msxmls[i]);
                } catch (e) { }
            }
        }
        function Delele_Click(uId) {
            if (confirm('Are you sure you want to delete user?')) {
                xmlHttp.open('Get', "DeleteUser_AJaxCall.aspx?uId=" + uId, true);
                xmlHttp.onreadystatechange = DeleteUser;
                xmlHttp.send(null);
            }

            return false;
        }
        function DeleteUser() {
            if (xmlHttp.readyState == 1) "";
            else if (xmlHttp.readyState == 4) {
                if (xmlHttp.responseText == "-1") {
                    window.location.href = "Login.aspx";
                } else if (xmlHttp.responseText == "1") {
                    //alert("User deleted successfully.");
                    window.location.href = "ListUsers.aspx";
                }
                else alert("User can not be deleted while it is in use" + xmlHttp.responseText);
            }
        }
        function ResetMenu() {
            document.getElementById("Config").className = "button SelectedButton";
            document.getElementById("Dashboard").className = "button";
            document.getElementById("MenuTabConfigSubMenu").style.display = "";
            document.getElementById("Config-page1").style.backgroundColor = "#fff";
        }
    </script>
</asp:Content>
