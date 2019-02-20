using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;





namespace SpreadSheet_To_DataBase
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected static SqlConnection conn = new SqlConnection();
        protected static string conn_string;
        protected static string test;
        protected static string file_name = "";
        protected static string file_path = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void Submit_button_Click(object sender, EventArgs e)
        {
             
                if (Browse_file.HasFile)
                {
                try
                {
                    Server.MachineName.ToString();
                    string filelocation = Server.MapPath("/user_uploads/" + Browse_file.FileName);
                    Browse_file.SaveAs(filelocation);
                    File_status.InnerHtml = "successfully uploaded : " + Browse_file.FileName;
                    file_name = Browse_file.FileName;
                    
                }
                catch
                {
                    File_status.InnerHtml = "Error. Please try again.";
                }
                }
                
        }

        protected void GUI_Preview_file()
        {
            
        }

        protected void GUI_Preview_DB(string table_name)
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

            try
            {
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


                while (reader.Read())
                {

                    for (int col_num = 0; col_num < num_columns; col_num++)
                    {
                        
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
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Connection Update", "alert('Connect to Database first');", true);
            }


        }

        protected void Start_Click(object sender, EventArgs e)
        {
            if(file_name != null)
            {
                FileReader read_files = new FileReader();
                string str_file_type = Path.GetExtension("/user_uploads/" + file_name);
                bool file_type = read_files.determine_file_type(str_file_type);
                string file_path = Server.MapPath("/user_uploads/" + file_name);
                

                if (file_type == true)
                    read_files.xlsx_reader();
                else
                    read_files.csv_reader(file_name, file_path);

                File.Delete(file_path);
            }
            //Does nothing if no file submitted
        }
    }
}