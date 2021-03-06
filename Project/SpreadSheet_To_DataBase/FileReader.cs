﻿using System;
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
            int new_row = 0;
            while((row_str = file.ReadLine())!= null && string.IsNullOrWhiteSpace(row_str) != true)
            {
                    upload.upload(new_row, row, row_str, file_name);
                    row++;
                    new_row++;
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
            string header_str = ExcelAddress.GetAddressCol(1);
            
            

            for (int row = start.Row; row <= end.Row; row++)
            {

                for (int col = start.Column; col <= end.Column; col++)
                {

                    cell = sheet.Cells[row, col].Text;//Get cell data according to row,collumn number
                    if(cell != "" && !string.IsNullOrEmpty(cell))
                        row_str = row_str + cell + ",";
                    
                    
                }

                row_str = row_str.TrimEnd(',');
                
                to_csv(file_location, file_name, row_str);//Sends all info to CSV file format
                
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
            

            if(String.IsNullOrWhiteSpace(row_str) == false)
                File.AppendAllText(csv_file, row_str);
            
        }
    }
}