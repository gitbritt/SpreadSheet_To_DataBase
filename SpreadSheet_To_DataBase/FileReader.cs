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



            string row_str = "";    //Row of data
            string cell = "";       //Data within cell

            for (int row = start.Row; row <= end.Row; row++)
            {
                for (int col = start.Column; col <= end.Column; col++)
                {
                    cell = sheet.Cells[row, col].Text;//Get cell data according to row,collumn number

                    row_str = row_str + "," + cell;
                    
                } 
                
                row_str = row_str.Replace(",,,", "");
                //EPPlus puts a bunch of ,,, these in here. Next few lines is cleaning up
                //
                
                    string temp = row_str.Substring(row_str.Length - 2);        //Removes ,, at end. Did it this way so it would not remove the ,, within the data
                if (row > start.Row)
                {
                    if (temp == ",,")
                        row_str = row_str.Substring(0, row_str.Length - 2);

                    if (row_str.Length > 0)
                        row_str = row_str.Substring(1, row_str.Length - 1);
                }
                else
                {
                    row_str = row_str.Replace(",,", "");//the ,, needs to be removed in the header becaue you can't have a blank header
                    if (row_str.Length > 0)
                        row_str = row_str.Substring(1, row_str.Length - 1);
                }

                //End of Clean up
                System.Diagnostics.Debug.WriteLine(row);
                to_csv(file_location, file_name, row_str);//Sends all info to CSV file format
                System.Diagnostics.Debug.WriteLine(row_str);
                row_str = "";
            }



            csv_reader(file_location + file_name + ".csv");//Reads created CSV
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