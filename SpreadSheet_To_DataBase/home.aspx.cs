using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



namespace SpreadSheet_To_DataBase
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string conn_string;
        SqlConnection conn;
        int connection;




        protected void Page_Load(object sender, EventArgs e)
        {

            

        }

        protected void Submit_button_Click(object sender, EventArgs e)
        {

            if (this.Browse_button.HasFile)
            {
                string table_name = Select_Table.ToString();//Get string name of table selected

                GUI_Preview_DB(table_name);
            }
        }

        protected void GUI_Preview_file()
        {

        }

        protected void GUI_Preview_DB(string table_name)
        {

        }

        protected void Browse_button_Click(object sender, EventArgs e)
        {

        }

        protected void Connect_button_Click(object sender, EventArgs e)
        {
            //Connect to DB when clicked
            string Database_host_str = Database_host.Text;
            string Database_name_str = Database_name.Text;
            string Account_auth_str;
            string Database_username_str = Database_username.Text;
            string Database_password_str = Database_password.Text;

            //account_authorized.CheckedChanged("test", true);
            if (account_authorized.Checked)
                Account_auth_str = "true";
            else
                Account_auth_str = "false";

            conn_string = "Data Source =" + Database_host_str + ";" +
                          "Initial Catalog= " + Database_name_str + ";" +
                          "Integrated Security=" + Account_auth_str;
            conn = new SqlConnection(conn_string);

            try
            {
                conn.Open();

                ClientScript.RegisterStartupScript(this.GetType(), "Connection Update", "alert('Connection successful');", true);
                connection = 1;
                Select_Table_SelectedIndexChanged(null, null);
            }
            catch
            {
                connection = 0;
                ClientScript.RegisterStartupScript(this.GetType(), "Connection Update", "alert('Connection failed');", true);
            }
            conn.Close();
        }

        protected void Select_Table_SelectedIndexChanged(object sender, BulletedListEventArgs e)
        {
            
            if (connection == 1 )//Populates the Table dropdown
            {
                
                SqlCommand get_tables = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", conn);
                SqlDataReader reader = get_tables.ExecuteReader();
                Select_Table.Items.Clear();
                int i = 0;
                while (reader.Read())
                {
                    
                    Select_Table.Items.Insert(0, new ListItem(reader["TABLE_NAME"].ToString(), i.ToString()));
                    i++;

                }
                reader.Close();
                System.Diagnostics.Debug.WriteLine("test");
            }
            else
            {
                
                string selected_table = Request.Form[Select_Table.UniqueID];
                System.Diagnostics.Debug.WriteLine(selected_table);

            }
        }
    }
}