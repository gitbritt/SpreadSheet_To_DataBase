<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SpreadSheet_To_DataBase.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 312px;
        }
        .auto-style3 {
            width: 727px;
            height: 181px;
        }
        .auto-style4 {
            height: 181px;
        }
        .auto-style5 {
            width: 727px;
            height: 19px;
            text-align: center;
        }
        .auto-style6 {
            height: 19px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Spreadsheet to DataBase</h1>

        </div>
        <p>
            Select Table&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="Select_DB_Table" runat="server" DataSourceID="Dropdown_Tables" DataTextField="TABLE_NAME" DataValueField="TABLE_NAME">
            </asp:DropDownList>
            <asp:SqlDataSource ID="Dropdown_Tables" runat="server" ConnectionString="<%$ ConnectionStrings:TestingDBConnectionString %>" SelectCommand="SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES"></asp:SqlDataSource>
        </p>
        <p>
            <asp:FileUpload  ID="Browse_button" runat="server" OnClick="Browse_button_Click" Text="Browse" />
        </p>
        <p>
                    <asp:Button ID="Submit_button" runat="server" Text="Submit" OnClick="Submit_button_Click" />
                <table class="auto-style1" bgcolor="grey">
                    <tr>
                        <td class="auto-style5">Preview of Local file</td>
                        <td class="auto-style6">Preview of Database table</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">&nbsp;</td>
                        <td class="auto-style4">&nbsp;</td>
                    </tr>
            </table>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Start" runat="server" Text="Start" />
        </p>
    </form>
</body>
</html>
