using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace SpreadSheet_To_DataBase
{
    public class Logs
    {
        //This Class is deticated for record keeping and log purposes
        public void successful_upload(string row_str, string file_name)
        {
            //Gives logs for successful uploads
            var path = System.Web.HttpContext.Current.Server.MapPath("/logs/Error_Free/");
            System.Diagnostics.Debug.WriteLine(file_name);
            row_str = row_str + ", " + Environment.UserName + ", " + Environment.UserDomainName + ", " + DateTime.Now + ", " + Environment.NewLine;
            string csv_file = path + file_name + ".txt";
            if (!File.Exists(csv_file))
            {
                File.Create(csv_file).Close();
            }
            if (row_str != "" || string.IsNullOrEmpty(row_str) == true || string.IsNullOrWhiteSpace(row_str) == true)
                File.AppendAllText(csv_file, row_str);


        }

        public void failed_uploads(string row_str, string file_name)
        {

        }

    }
}