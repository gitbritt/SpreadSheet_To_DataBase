<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="SpreadSheet_To_DataBase.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            Admin Page</div>
        <p>
            <strong>Create User</strong></p>
        <p>
            User-name : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Password :
            <input id="Password1" type="password" /></p>
        <p>
            Re-enter password :
            <input id="Password2" type="password" /></p>
    </form>
</body>
</html>
