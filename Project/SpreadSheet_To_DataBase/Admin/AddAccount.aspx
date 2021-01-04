<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="SpreadSheet_To_DataBase.Admin.AddAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <strong>Admin page</strong><p>
            User name</p>
        <p>
            <input id="UserInput" type="text" runat ="server"/></p>
        <p>
            E-Mail</p>
        <p>
            <input id="EmailInput" type="text" runat ="server" /></p>
        <p>
            Password (Requirements are 7 characters and 1 number)</p>
        <p>
            <input id="PasswordInput" type="password" runat ="server" /></p>
        <p>
            Re-enter Password</p>
        <p>
            <input id="ReEnterPasswordInput" type="password" runat ="server" /></p>
        <asp:Button ID="AddAccountButton" runat="server" Text="Add account" OnClick="AddAccountButton_Click" />
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
