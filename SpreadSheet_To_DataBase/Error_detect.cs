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
        
        
        
        public bool error(string row_str, int row)
        {
            WebForm1 Edit_Html = new WebForm1();
            bool error_bool = false;
            string error_message = "No Error's \n";
            int Col_count = row_str.Split(',').Length;
            string header = "No error \n";

            

            if (row == 0)
            {
                
                header = row_str;
                header_count = Col_count;
                
            }
            
            if(header_count != Col_count && row != 0)
            {
                error_bool = true;
                error_message = "Either there is a header with no data, or a Column with no header. Please make sure each column has just one header, and double check the headers are correct.\n";
                header_count = Col_count;
            }
            


            Edit_Html.SendToForm(error_message, error_bool);
            return error_bool;
        }

    }
}