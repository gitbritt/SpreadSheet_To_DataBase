using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OfficeOpenXml;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace SpreadSheet_To_DataBase
{
    public class Error_detect : System.Web.UI.Page
    {
        /// <summary>
        /// Error detection function
        /// Checks to make sure that there is the same columns per row according to database
        /// </summary>
        
        protected static int header_count = 0;
        protected static List<string> header_name = new List<string>();
        protected static List<string> isnull = new List<string>();
        protected static List<string> datatype = new List<string>();

        public bool error(string row_str, int row, string file_name)
        {
            
                WebForm1 Edit_Html = new WebForm1();
                bool error_bool = false;

                string error_message = "";
                int Col_count = row_str.Split(',').Length;
                string header = "No error \n";
                string[] cells = row_str.Split(',');

                SqlConnection conn = WebForm1.conn;

            try
            {
                if (row == 0)
                {

                    header = row_str;
                    header_count = Col_count;

                }
                //Below is the list of errors the program is searching for

                //number of Columns and headers dont' match up in the local file

                if (header_count != Col_count && row != 0)
                {

                    error_bool = true;
                    error_message = "Either there is a header with no data, or a Column with no header. Please make sure each column has just one header, and double check the headers are correct.\n";
                    header_count = Col_count;
                }

                //If on Database side, if database does not allow null then check to verify local file has same number of rows.
                string ifnullStr = "select COLUMN_NAME , IS_NULLABLE, DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where (TABLE_SCHEMA + '.' + TABLE_NAME) = '" + WebForm1.selected_table + "'";

                SqlCommand ifnull = new SqlCommand(ifnullStr, conn);
                SqlDataReader reader_ = ifnull.ExecuteReader();

                int Col_Num = 0;
                while (reader_.Read() && row == 0)//Get if it's null or not and put it into a list
                {
                    isnull.Add(reader_["IS_NULLABLE"].ToString());
                    header_name.Add(reader_["COLUMN_NAME"].ToString());
                    datatype.Add(reader_["DATA_TYPE"].ToString());
                    Col_Num++;

                }
                reader_.Close();
                if (row == 0 && Col_count == Col_Num)//Checks to see if the Column name on the local file (Header) is the same on the database
                {
                    for (int i = 0; i < Col_Num; i++)
                    {
                        
                        if (cells[i] != header_name[i])//If header on file is not the same as the Database header, give error
                        {
                            error_bool = true;
                            error_message = "Error with Column \"" + cells[i] + "\". The name needs to be the same name as the column in the database. Make sure that there are no extra spaces at the end.\n";

                        }

                    }
                }
                else if (row == 0)
                {
                    error_bool = true;
                    error_message = "Wrong Nuber of Columns in the file. The error's below are stating the indivudal rows.\n";
                }


                


                error_message = error_message + " \n Row number : " + row;
            }
            catch (Exception ex)
            {
                error_message = ex.Message.ToString();
                error_bool = true;
            }

            

            Logs log_error = new Logs();
            if(error_bool == true)
            {
                log_error.failed_uploads(row_str, file_name, error_message);
            }
            

            Edit_Html.SendToForm(error_message, error_bool);
            error_message = "";
            
            return error_bool;
        }

    }
}