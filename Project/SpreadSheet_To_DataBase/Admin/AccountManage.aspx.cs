using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;


namespace SpreadSheet_To_DataBase.Admin
{
    public partial class AccountManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var users = Membership.GetAllUsers();
            var Allusers = new List<MembershipUser>();
            foreach (MembershipUser user in users )
            {
                
                Allusers.Add(user);
                
            }
            long list_int = Allusers.LongCount();

            var TableRows = "";
            for(int i = 0; i < list_int ;i++)
            {
                var username = Allusers[i].ToString();
                var email = "";
                var options = "";
                TableRows = TableRows + "<tr><td> " + username +" </td><td> " + email + " </td><td> " + options +" </td></tr>";
                
            }

            TableRows = "<table border='1' style='width: 100 %; ' runat =;server' id ='UserListTable'><tr><td>User name</td><td>E-Mail</td><td>Options</td></tr>" + TableRows + "</tables>";
            UserListDiv.InnerHtml = TableRows;
            
        }
    }
}