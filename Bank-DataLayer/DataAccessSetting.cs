using System;
using System.Configuration;

namespace Bank_DataLayer
{
    static class clsDataAccessSetting
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

    }
}
