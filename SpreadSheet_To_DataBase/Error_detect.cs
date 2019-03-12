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
        protected static string error_current = "";
        protected static string error_next = error_current;
        
        public bool error(string row_str, int row)
        {
            WebForm1 Edit_Html = new WebForm1();
            bool error_bool = false;
            
            int Col_count = row_str.Split(',').Length;
            string header = "No error \n";
            
            if (row == 0)
            {
                
                header = row_str;
                header_count = Col_count;
                //System.Diagnostics.Debug.WriteLine("Header : " + header_count);
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("Col Count/row : " + Col_count);
            }
            if(header_count != Col_count)
            {
                error_bool = true;
                error_current = error_current + "There is some columns without a header name, or to many headers. Please fix this.\n";
                header_count = Col_count;
            }
            


            Edit_Html.SendToForm(error_current, error_bool);
            return error_bool;
        }

    }
}