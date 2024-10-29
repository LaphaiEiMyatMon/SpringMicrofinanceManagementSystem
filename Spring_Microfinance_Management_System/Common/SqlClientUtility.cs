// =============================================================================
// <summary>
// SqlClient に対するユーティリティークラスです。
// </summary>
// <copyright file="SqlClientUtility.cs" company="Works">
// Copyright(C) Works Co.,Ltd.
// </copyright>
// <author>
// Works
// </author>
// =============================================================================

namespace Spring_Microfinance_Management_System.Common
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

   using Spring_Microfinance_Management_System.Framework.Configuration;

 
    public static class SqlClientUtility
    {
        
        public static SqlConnection CreateSqlConnection()
        {
            return CreateSqlConnection(null);
        }

        
        public static SqlConnection CreateSqlConnection(
            string sqlConnectionSettingName)
        {
            var setting = FrameworkSettings.Default.SqlConnectionSettings.Settings.GetSetting(sqlConnectionSettingName);

            var cn = new SqlConnection(setting.SqlConnectionString);
            

            return cn;
        }

        
        public static SqlConnection CreateSqlConnectionWithOpen()
        {
            return CreateSqlConnectionWithOpen(null);
        }

        
        public static SqlConnection CreateSqlConnectionWithOpen(
            string sqlConnectionSettingName)
        {
            var cn = SqlClientUtility.CreateSqlConnection(
                sqlConnectionSettingName);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            return cn;
        }
    }
}
