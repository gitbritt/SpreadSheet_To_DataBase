
using System;
using System.Security;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace SpreadSheet_To_DataBase
{
    public class Upload
    {
        public void upload(int new_row,int row, string row_str, string file_name)
        {
            
            Error_detect error = new Error_detect();
            SqlConnection conn = WebForm1.conn;
            string table_name = WebForm1.selected_table;
            bool error_result = error.error(row_str, row);
            SqlDataAdapter updateSQLcmd = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string sql_row = "";
            if(error_result == false && new_row != 0)
            {
                try
                {
                    
                    sql_row = row_str.Insert(0, "'") + "'";
                    sql_row = sql_row.Replace(",", "','");
                    string insert_sql = "INSERT INTO " + table_name + " VALUES(" + sql_row + ")";
                    SqlCommand insert_sql_cmd = new SqlCommand(insert_sql, conn);
                    updateSQLcmd.SelectCommand = insert_sql_cmd;
                    updateSQLcmd.Fill(ds);

                    Logs log = new Logs();
                    
                    log.successful_upload(row_str, file_name);

                }
                catch(Exception ex)
                {
                    //This catches any advanced, or other unusal erros not covered by the Error detect class.
                    WebForm1 issue = new WebForm1();
                    
                    string message = "There was an error in processing the data. More details are below. Please contact your administrator for questions.\n" + ex.Message;
                    issue.SendToForm(message, true);
                }
            }
            else
            {
                //If no Error's then Upload data
            }
            
        }
    }
}