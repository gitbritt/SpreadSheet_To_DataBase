
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
            bool error_result = error.error(row_str, row, file_name);
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
                catch(SqlException ex)
                {
                    //This is dealing with Errors on Database/SQL side.
                    WebForm1 issue = new WebForm1();
                    Logs log_advaced_errors = new Logs();
                    
                    string message;
                    if (ex.Number == 2627)
                        message = "You have a duplicate unique ID. Please make sure all rows have a unique ID.  More info is below. \n" + ex.Message;
                    else
                        message = "There was an error in processing the data. More details are below. Please contact your administrator for questions.\n" + ex.Message;

                    issue.SendToForm(message, true);
                    log_advaced_errors.failed_uploads(row_str, file_name, message);
                }
            }
            else
            {
                //If no Error's then Upload data
            }
            
        }
    }
}