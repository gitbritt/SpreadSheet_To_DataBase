using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;




namespace SpreadSheet_To_DataBase
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected static SqlConnection conn = new SqlConnection();
        protected static string conn_string;
        protected static string test;

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

        
        void connection_init()
        {

        }


        protected void Connect_button_Click(object sender, EventArgs e)
        {
            string Database_host_str = Database_host.Text;
            string Database_name_str = Database_name.Text;
            string Account_auth_str;
            string Database_username_str = Database_username.Text;
            string Database_password_str = Database_password.Text;
            
            if (account_authorized.Checked)
                Account_auth_str = "true";

            else
                Account_auth_str = "false";

            conn_string = "Data Source =" + Database_host_str + ";" +
                         "Initial Catalog= " + Database_name_str + ";" +
                         "Integrated Security=" + Account_auth_str;

            conn = new SqlConnection();
            conn.ConnectionString = conn_string;
            try
            { 
                conn.Open();
                ClientScript.RegisterStartupScript(this.GetType(), "Connection Update", "alert('Connection successful');", true);
                Select_Table_SelectedIndexChanged(null, null);
                
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Connection Update", "alert('Connection failed');", true);
            }
        }

        

        protected void Select_Table_SelectedIndexChanged(object sender, BulletedListEventArgs e)
        {

                
                SqlCommand get_tables = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", conn);
                SqlDataReader reader = get_tables.ExecuteReader();
                Select_Table.Items.Clear();
                int i = 0;
                while (reader.Read())
                {
                    Select_Table.Items.Add(reader["TABLE_NAME"].ToString());
                    i++;
                }
            
            reader.Close();
            
                
            
        }

        


        protected void Preview_button_Click(object sender, EventArgs e)
        {
            //GIves the user a glimpse idea of what the Local file be compared to on the Database side of things
            //First deals with the SQL code for headers
            //Then displays table that was selected
            SqlCommand sql_preview_headers_cmd = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + Select_Table.Text + "'", conn);
            SqlCommand sql_preview_table = new SqlCommand("SELECT top 1 * FROM " + Select_Table.Text, conn);
            SqlDataReader reader = sql_preview_headers_cmd.ExecuteReader();
            int num_columns = 0;
            string str = "<table border='1'><tr>";
            while (reader.Read())
            {
                num_columns++;
                str = str + "<th>";
                str = str + reader["COLUMN_NAME"].ToString();
                str = str + "</th>";
            }
            reader.Close();

            reader = sql_preview_table.ExecuteReader();
            str = str + "<tr>";
            
            
            while(reader.Read())
            {
                //str = str + reader[col_num];
                for(int col_num = 0; col_num < num_columns; col_num++)
                {
                    System.Diagnostics.Debug.WriteLine(col_num);
                    str = str + "<td>";
                    str = str + reader[col_num];
                    str = str + "</td>";
                }
                
            }

            str = str + "</tr>";
            str = str + "</tr></table>";
            Preview_table.InnerHtml = str;

            reader.Close();




        }

    }
}