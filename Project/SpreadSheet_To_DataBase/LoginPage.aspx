<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SpreadSheet_To_DataBase.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Login Page</div>
        <p>
            User-Name :
            <input id="Text1" type="text" /></p>
        <p>
            Password :&nbsp;
            <input id="Password1" type="password" /></p>
        <asp:Button ID="Button1" runat="server" Text="Login" />
    </form>
</body>
</html>
