using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OfficeOpenXml;
using System.IO;
using System.Data.SqlClient;


namespace SpreadSheet_To_DataBase
{
    public class Error_detect : System.Web.UI.Page
    {
        /// <summary>
        /// Error detection function
        /// Checks to make sure that there is the same columns per row according to database
        /// </summary>
        
        protected static int header_count = 0;
        
        public bool error(string row_str, int row)
        {
            WebForm1 Edit_Html = new WebForm1();
            bool error_bool = false;
            string error_message = "No error's";
            int Col_count = row_str.Split(',').Length;
            string header = "";
            if (row == 0)
            {
                
                header = row_str;
                header_count = Col_count;
                System.Diagnostics.Debug.WriteLine("Header : " + header_count);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Col Count/row : " + Col_count);
            }
            if(header_count != Col_count)
            {
                error_bool = true;
                error_message = "There is some columns without a header name, or to many headers. Please fix this.\n";
                header_count = Col_count;
            }
            
            Edit_Html.html_error_list(error_message, error_bool);//Displays the error messages to the user
            return error_bool;
        }

    }
}