using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.IO.Compression;



namespace SpreadSheet_To_DataBase
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string path = "";
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

                
                SqlCommand get_tables = new SqlCommand("SELECT TABLE_SCHEMA + '.' + TABLE_NAME as Table_name FROM INFORMATION_SCHEMA.TABLES", conn);
                SqlDataReader reader = get_tables.ExecuteReader();
                Select_Table.Items.Clear();
                int i = 0;
                while (reader.Read())
                {
                    Select_Table.Items.Add(reader["Table_name"].ToString());
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
                SqlCommand sql_preview_headers_cmd = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_SCHEMA + '.' + TABLE_NAME) = '" + Select_Table.Text + "'", conn);
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

        protected string uniqu_file_name(string file_name)
        {
            
            DirectoryInfo main = new DirectoryInfo(path);
            bool found = true;
            string name = null;
            int random_number = 0;
            Random random = new Random();
            random_number = random.Next(0, 100000);
            FileInfo[] filedir;

            while (found == true)
            {
                filedir = main.GetFiles("*" + random_number.ToString() + "*.*");
                foreach (FileInfo file_found in filedir)
                {
                    name = file_found.FullName;
                }
                int length = name.Length;
                if (length > 0)
                    found = true;
                else
                {
                    found = false;
                    file_name = file_name + "_" + (random_number.ToString());
                }
            }
            System.Diagnostics.Debug.WriteLine(file_name);
            
            return file_name;
        }

        protected void Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (file_name != null)
                {
                    FileReader read_files = new FileReader();
                    string type = Browse_file.FileName;
                    type = type.Substring(type.IndexOf('.') + 1);//Determins the file type as xlsx or csv
                    
                    string location = read_files.determine_file_location(type).ToString();



                    //Creates folder location /user_uploads/(csv and xlsx)
                    //Taken from https://stackoverflow.com/questions/9065598/if-a-folder-does-not-exist-create-it
                    string subPath = location; // your code goes here
                    bool exists = System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(subPath));
                    if (!exists)
                        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(subPath));


                    path = Server.MapPath(location);


                    Server.MachineName.ToString();
                    string filelocation = Server.MapPath(location + Browse_file.FileName);
                    //filelocation = uniqu_file_name(filelocation);
                    Browse_file.SaveAs(filelocation);
                    File_status.InnerHtml = "successfully uploaded : " + Browse_file.FileName;

                    //File reader
                    if (type == "csv")
                    {
                        System.Diagnostics.Debug.WriteLine("File : CSV");
                        read_files.csv_reader(filelocation);
                    }
                    else if (type == "xlsx")
                    {
                        System.Diagnostics.Debug.WriteLine("File : XLSX");
                        read_files.xlsx_reader(Server.MapPath(location), Browse_file.FileName);//Sends location of the file on server and file name
                    }
                    //Cleans up Files
                    File.Delete(filelocation);
                    File.Delete(filelocation + ".csv");
                }
            }
            catch
            {
                File_status.InnerHtml = "Error. Please try again.";
            }
        }

        protected void Preview_local_file_Click(object sender, EventArgs e)
        {

        }

        public void html_error_list(string error, bool error_bool)
        {
            if (error_bool == true)
            {
                System.Diagnostics.Debug.WriteLine(error);
                //Error_list.InnerText = error;
            }
        }
    }
}