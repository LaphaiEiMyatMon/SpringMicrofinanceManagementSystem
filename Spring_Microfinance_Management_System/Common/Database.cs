

namespace Spring_Microfinance_Management_System.Models
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Web.Configuration;
    using Spring_Microfinance_Management_System.Common;

    public class DataBase :
        DataBaseFoundation
    {      
        public static DataTable ExecuteAdapter(string sql, QueryParamList queryParam)
        {
            using (DbConnection connection = DataBase.GetConnection())
            {
                return DataBaseFoundation.ExecuteAdapter(connection, sql, queryParam);
            }
        }
        
        public static DataTable ExecuteAdapter(string sql)
        {
            using (DbConnection connection = DataBase.GetConnection())
            {
                return DataBaseFoundation.ExecuteAdapter(connection, sql, new QueryParamList());
            }
        }
       
        public static object ExecuteScalar(string sql)
        {
            return DataBase.ExecuteScalar(sql, new QueryParamList());
        }
      
        public static object ExecuteScalar(string sql, QueryParamList queryParam)
        {
            using (DbConnection connection = DataBase.GetConnection())
            {
                return DataBaseFoundation.ExecuteScalar(connection, sql, queryParam);
            }
        }
    }
}
