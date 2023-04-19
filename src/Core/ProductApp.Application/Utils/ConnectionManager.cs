using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ProductApp.Application.Utils
{
    public class ConnectionManager
    {
        private static string key = "C1437B6D9F0B65F9A49E1DD43F94D6DF4C89695708B3B915A12D4B4831EE6FC3";

        public static string GetConnectionString()
        {

            var dbEngine = Helper.GetConfigStr("DB_ENGINE", "mssql");

            //var address = AesEncryption.DecryptToAscii(ConfigurationManager.AppSettings["DB_ADDRESS"], key);
            //var name = AesEncryption.DecryptToAscii(ConfigurationManager.AppSettings["DB_NAME"], key);
            //var username = AesEncryption.DecryptToAscii(ConfigurationManager.AppSettings["DB_USERNAME"], key);
            //var password = AesEncryption.DecryptToAscii(ConfigurationManager.AppSettings["DB_PASS"], key);

            var conStr = ConfigurationManager.AppSettings["ConnectionString"];
            //if (conStr == null || conStr.Length < 1)
            //{
            //    if (dbEngine == "postgresql")
            //    {
            //        conStr = $"Server={address};Host={address};Database={name};User Id={username};Password={password};";
            //    }
            //    else
            //    {
            //        //conStr = $"data source={address};initial catalog={name};persist security info=True;user id={username};password={password};MultipleActiveResultSets=True;App=EntityFramework";
            //        conStr = $"data source={address};initial catalog={name};persist security info=True;MultipleActiveResultSets=True;App=EntityFramework";
            //    }
            //}
            return conStr;
        }
    }
}
