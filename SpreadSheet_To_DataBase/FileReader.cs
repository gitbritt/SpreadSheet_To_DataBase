using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Diagnostics;


namespace SpreadSheet_To_DataBase
{
    public class FileReader
    {
        //File reader class
        //Contains the functions for Excel/CSS/TXT reader fucntions



        public bool determine_file_type(string type)
        {
            //Determins what kind of file it is
            bool type_bool = true;
            
            if(type == ".xlsx")
            {
                type_bool = true;
            }
            else if(type == ".csv" || type == ".txt")
            {
                type_bool = false;
            }
            
            return type_bool;
        }

        public void csv_reader(string file_name, string file_path)
        {
            
            StreamReader file = new StreamReader(file_path);
            string line_read = "";
            while((line_read = file.ReadLine())!= null)
            {
                System.Diagnostics.Debug.WriteLine(line_read);
            }
            file.Close();
        }

        public void xlsx_reader()
        {

        }

    }
}