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
using System.IO.Compression;
using System.Text.RegularExpressions;

//using System.IO.Compression;


namespace SpreadSheet_To_DataBase
{
    public class FileReader
    {
        //File reader class
        //Contains the functions for Excel/CSS/TXT reader fucntions
        
        
        protected static string file_name;

        public string determine_file_location(string type)
        {
            
            
            //Determins the location of where the file will be uploaded. under csv folder or xlsx
            string location = "";
            if (type == "xlsx")
            {
                location = "/user_uploads/xlsx/";
            }
            else if (type == "csv" || type == ".txt")
            {
                location = "/user_uploads/csv/";
            }

            return location;
        }

        public void csv_reader(string file_location)
        {
            FileStream csv_file;
            int row = 0;
            string headers = "";
            StreamReader file = new StreamReader(file_location);
            string line_read = "";
            while((line_read = file.ReadLine())!= null)
            {
                if (row == 0)
                    headers = line_read;

                System.Diagnostics.Debug.WriteLine(line_read);
                row++;
            }
            file.Close();
        }

        public void xlsx_reader(string file_location, string file_name)
        {
            string zip_name = file_name + ".zip";
            string zip_location = file_location + zip_name;
            System.IO.File.Move(file_location + file_name, zip_location);
            string zip_ext_dir = file_location + @"temp\" + file_name + @"\";//Path to the xlsx zip file
            
            Directory.CreateDirectory(zip_ext_dir);
            System.Diagnostics.Debug.WriteLine(zip_location);
            System.Diagnostics.Debug.WriteLine(zip_ext_dir);
            ZipFile.ExtractToDirectory(zip_location, zip_ext_dir);

            xml_reader(zip_ext_dir);

            //Clean up files and created folders
            //File.Delete(zip_location);
            //string cmd = "rd /s /q " + zip_ext_dir;
            //System.Diagnostics.Debug.WriteLine(cmd);
            //Process command = new Process();
            //command.StartInfo.FileName = "cmd.exe";
            //command.StartInfo.Arguments = string.Format("/c rd /s /q " + zip_ext_dir);
            //command.Start();


        }

        public void xml_reader(string xml_path)
        {
            string sheet_path = xml_path + @"xl\worksheets\sheet1.xml";
            int row_number = 0;
            int col_number = 0;
            string line = "";
            
            StreamReader sheet = new StreamReader(sheet_path);
            while ((line = sheet.ReadLine())!= null)
            {
                row_number = Regex.Matches(line, "<row").Count;
                col_number = (Regex.Matches(line, "<c r=").Count);
                
            }
            col_number = col_number / row_number;
            System.Diagnostics.Debug.WriteLine("Number of Rows : " + row_number);
            System.Diagnostics.Debug.WriteLine("Number of Columns : " + col_number);
        }

        public void xmsx_csv()
        {
            
        }

    }
}