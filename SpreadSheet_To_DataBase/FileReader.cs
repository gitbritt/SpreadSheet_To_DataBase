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
using System.Xml;
using System.Xml.Linq;
using OfficeOpenXml;
using System.Windows.Forms;


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
            Upload upload = new Upload();

            int row = 0;
            
            StreamReader file = new StreamReader(file_location);
            string row_str = "";
            while((row_str = file.ReadLine())!= null && string.IsNullOrWhiteSpace(row_str) != true)
            {

                upload.upload(row, row_str);
                row++;

            }

            file.Close();
        }

        public void xlsx_reader(string file_location, string file_name)
        {
            
            string xlsx_path = file_location + file_name;
            FileInfo xlsx_file = new FileInfo(xlsx_path);
            ExcelPackage package = new ExcelPackage(xlsx_file);
            ExcelWorksheet sheet = package.Workbook.Worksheets[1];
            var start = sheet.Dimension.Start;
            
            var end = sheet.Dimension.End;
            string row_str = "";
            string cell = "";
            
            for (int row = start.Row; row <= end.Row; row++)
            {
                for (int col = start.Column; col <= end.Column; col++)
                {
                    cell = sheet.Cells[row, col].Text;
                    
                    if (cell != "" || string.IsNullOrWhiteSpace(cell) != true)
                    {
                       row_str = row_str + "," + cell;
                    }
                }
                if(row_str != "" )
                    row_str = row_str.Remove(0, 1);

                to_csv(file_location, file_name, row_str);
                row_str = "";   
            }
            
            csv_reader(file_location + file_name + ".csv");
        }

        public void to_csv(string path, string file_name, string row_str)
        {
            //Converts Excel file to csv files
            //Will be read and processed as a CSV file
            row_str = row_str + Environment.NewLine;
            string csv_file = path + file_name + ".csv";
            if (!File.Exists(csv_file))
            {
                File.Create(csv_file).Close();
            }
            
            File.AppendAllText(csv_file, row_str);
            
        }
        
    }
}