using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web;

namespace SpreadSheet_To_DataBase
{
    public class Logs
    {
        //This Class is deticated for record keeping and log purposes
        public void successful_upload(string row_str, string file_name)
        {
            ///////Gives logs for successful uploads
            ///
            var path = System.Web.HttpContext.Current.Server.MapPath("/logs/Error_Free/");
            
            string user_ip = HttpContext.Current.Request.UserHostAddress.ToString();
            string username = Environment.UserName;
            string date = DateTime.Now.ToString("yyyy_MM_dd");
            string time = DateTime.Now.ToString();

            

            row_str =  "Successfully uploaded : " +row_str + ", " + username + ", " + time + ", " + user_ip +  Environment.NewLine;
            
            string txt_file = path + file_name + username + "_" + date + ".txt";

            if (row_str != "" || string.IsNullOrEmpty(row_str) == true || string.IsNullOrWhiteSpace(row_str) == true)
            {
                File.AppendAllText(txt_file, row_str);
            }


        }

        public void failed_uploads(string row_str, string file_name, string error_message)
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("/logs/Error_not_free/");

            string user_ip = HttpContext.Current.Request.UserHostAddress.ToString();
            string username = Environment.UserName;
            string date = DateTime.Now.ToString("yyyy_MM_dd");
            string time = DateTime.Now.ToString();

            row_str = "Row upload failed : " + row_str + ", " + username + ", " + time + ", " + user_ip + Environment.NewLine;
            string breaker = "\n-----------------------------------------------\n";
            string txt_file = path + file_name + username + "_" + date + ".txt";
            

            if (row_str != "" || string.IsNullOrEmpty(row_str) == true || string.IsNullOrWhiteSpace(row_str) == true)
                File.AppendAllText(txt_file, row_str + error_message + breaker);
        }

    }
}