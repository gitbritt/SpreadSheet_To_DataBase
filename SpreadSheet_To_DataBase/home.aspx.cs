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
        



        protected void Page_Load(object sender, EventArgs e)
        {
            //Connect and Open to DB
            conn_string = Dropdown_Tables.ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(conn_string);
            try
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("Select * from [dbo].[Table_1]", conn);
                System.Diagnostics.Debug.WriteLine("F + ");
                conn.Close();
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("F - ");
            }
            //System.Diagnostics.Debug.WriteLine(conn_string);
            
        }

        protected void Submit_button_Click(object sender, EventArgs e)
        {

            if (this.Browse_button.HasFile)
            {
                string table_name = Select_DB_Table.ToString();//Get string name of table selected

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
    }
}
