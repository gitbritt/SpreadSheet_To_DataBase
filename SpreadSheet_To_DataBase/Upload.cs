using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpreadSheet_To_DataBase
{
    public class Upload
    {
        public void upload(int row, string row_str)
        {
            Error_detect error = new Error_detect();
            bool error_result = error.error(row_str, row);

            if(error_result == false)
            {
                //If Errors, Dont' upload
            }
            else
            {
                //If no Error's then Upload data
            }
            
        }
    }
}