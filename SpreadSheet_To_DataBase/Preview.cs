//The Preview class allows the program to give a snap shot of the DB data and the table data for the user to see
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace SpreadSheet_To_DataBase
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        public class Preview
        {
            public void file_preview()
            {

            }

            public void db_preview(string table_name)
            {
                int rows = 2;
                
            }
        }
    }
}