using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Helpers;
using System.Windows.Forms;

namespace SpreadSheet_To_DataBase.Admin
{
    public partial class AddAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void AddAccountButton_Click(object sender, EventArgs e)
        {

            try
            { MembershipUser users = Membership.CreateUser(UserInput.Value.ToString(), PasswordInput.Value.ToString());
                
            }
            catch (Exception E)
            {
                var error = E.Message.ToString();
                MessageBox.Show(error);

            }
        }
    }
}