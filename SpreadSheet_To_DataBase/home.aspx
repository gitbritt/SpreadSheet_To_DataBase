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
        .auto-style9 {
            width: 508px;
            height: 186px;
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
            <p class="auto-style8">username :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Database_username" runat="server" Enabled="False"></asp:TextBox>
            </p>
            <p class="auto-style8">Password :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Database_password" runat="server" Enabled="False"></asp:TextBox>
            </p>
            <p class="auto-style7">
                <asp:Button ID="Connect_button" runat="server" OnClick="Connect_button_Click" Text="Connect to Database"  UseSubmitBehavior="false" />
            </p>
            <p>&nbsp;</p>
            
        </div>
        <p class="auto-style8">
            Select Table&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="Select_Table" runat="server" OnClick ="Select_Table_SelectedIndexChanged" OnSelectedIndexChanged="Select_Table_SelectedIndexChanged1">
            </asp:DropDownList>
        </p>
        <p class="auto-style8">
            <strong>Warning : For empty cells that are supposed to be empty, put NULL in in the cell to help avoid errers and issues.</strong></p>
        <p class="auto-style8">
            <strong>Also make sure that the data starts on row 1, column 1. It can cause issues if it&#39;s in the middle of the page.</strong></p>
        <p class="auto-style8">
            <asp:FileUpload ID="Browse_file" runat="server" accept=".xlsx,.csv" />
            <asp:Button ID="Preview_db_button" runat="server" Text="Preview Database" OnClick="Preview_button_Click" UseSubmitBehavior="False" />
        </p>
        <p class="auto-style8" id="File_status" runat ="server">
            File Status : </p>
        <p class="auto-style8">
            Database Preview</p>
        <div class="auto-style8" runat="server" id ="Preview_table"></div>
        <p class="auto-style8">
            <asp:Button ID="Start" runat="server" Text="Start" OnClick="Start_Click" />
        </p>
        <p class="auto-style8">
            Error Messages</p>
        <p class="auto-style8" id="testing" runat="server">
            <textarea id="Error_display" runat="server" class="auto-style9" name="S1" value ="Errors: "></textarea></p>
    </form>
    <p runat="server" class="auto-style8">
        &nbsp;</p>
    <p runat="server" class="auto-style8">
        &nbsp;</p>
    <p runat="server" class="auto-style8">
        &nbsp;</p>
    <p runat="server" class="auto-style8">
        &nbsp;</p>
    <p runat="server" class="auto-style8">
        &nbsp;</p>
    <p runat="server" class="auto-style8">
        For help or issues, report them here : <a href="https://github.com/gitbritt/SpreadSheet_To_DataBase/issues">https://github.com/gitbritt/SpreadSheet_To_DataBase/issues</a></p>
</body>
</html>
