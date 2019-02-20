<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SpreadSheet_To_DataBase.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style7 {
            margin-left: 160px;
        }
        .auto-style8 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color:powderblue;">
            <h1 class="auto-style8">&nbsp;</h1>
            <h1 class="auto-style8">Spreadsheet to DataBase</h1>
            <p class="auto-style8">Database Type :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Microsoft SQL Server</asp:ListItem>
                    <asp:ListItem>MySQL</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p class="auto-style8">Database Host :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Database_host" runat="server">DESKTOP-J6OG7OA</asp:TextBox>
            </p>
            <p class="auto-style8">Database Name :&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Database_name" runat="server">TestingDB</asp:TextBox>
            </p>
            <p class="auto-style8">Microsfot Login : <asp:CheckBox ID="account_authorized" runat="server" Checked="True" Text="true" />
            </p>
            <p class="auto-style8">If you are not using a Microsoft account for the DB, please use username + password</p>
            <p class="auto-style8">username :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Database_username" runat="server"></asp:TextBox>
            </p>
            <p class="auto-style8">Password :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Database_password" runat="server"></asp:TextBox>
            </p>
            <p class="auto-style7">
                <asp:Button ID="Connect_button" runat="server" OnClick="Connect_button_Click" Text="Connect to Database"  UseSubmitBehavior="false" />
            </p>
            <p>&nbsp;</p>
            
        </div>
        <p class="auto-style8">
            Select Table&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="Select_Table" runat="server" OnClick ="Select_Table_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
        <p class="auto-style8">
            <asp:FileUpload ID="Browse_file" runat="server" />
            <asp:Button ID="Submit_button" runat="server" Text="Submit" OnClick="Submit_button_Click" />
            <asp:Button ID="Preview_button" runat="server" Text="Preview" OnClick="Preview_button_Click" UseSubmitBehavior="False" />
        </p>
        <p class="auto-style8" id="File_status" runat ="server">
            File Status : </p>
        <p class="auto-style8">
            Database Preview</p>
        <div class="auto-style8" runat="server" id ="Preview_table"></div>
        <p>
            <asp:Button ID="Start" runat="server" Text="Start" OnClick="Start_Click" />
        </p>
    </form>
</body>
</html>
