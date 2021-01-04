<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="SpreadSheet_To_DataBase.Admin.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>Admin Page<br />
            </strong>
        </div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/AddAccount.aspx">Add Account</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/AccountManage.aspx">Account Manage</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/DatabaseSettings.aspx">Database Settings</asp:HyperLink>
    </form>
</body>
</html>
