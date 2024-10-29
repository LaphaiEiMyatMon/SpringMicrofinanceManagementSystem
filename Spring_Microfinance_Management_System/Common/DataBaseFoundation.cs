namespace Spring_Microfinance_Management_System.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using Spring_Microfinance_Management_System.Common;

    public class DataBaseFoundation
    {
        
        public static DbConnection GetConnection()
        {
            return GetConnection(string.Empty);
        }

        
        public static DbConnection GetConnection(string sqlConnectionSettingName)
        {
            return SqlClientUtility.CreateSqlConnectionWithOpen(sqlConnectionSettingName);
        }

        #region GetTransaction

        
        public static DbTransaction GetTransaction(
            DbConnection connection)
        {
            return GetTransaction(connection, IsolationLevel.ReadCommitted);
        }

        
        public static DbTransaction GetTransaction(
            DbConnection connection,
            IsolationLevel isolationLevel)
        {
            var tran = connection.BeginTransaction(isolationLevel);
            return tran;
        }

        
        public static DbTransaction GetLocalTransaction(
            DbConnection connection)
        {
            return GetLocalTransaction(connection, IsolationLevel.ReadCommitted);
        }

        
        public static DbTransaction GetLocalTransaction(
            DbConnection connection,
            IsolationLevel isolationLevel)
        {
            var tran = ((SqlConnection)connection).BeginTransaction(isolationLevel, Guid.NewGuid().ToString().Substring(0, 32));
            return tran;
        }

        #endregion

        #region ExecuteNonQuery

        
        public static int ExecuteNonQuery(
            DbConnection connection,
            string sql)
        {
            return DataBaseFoundation.ExecuteNonQuery(connection, sql, new QueryParamList(), null);
        }

        
        public static int ExecuteNonQuery(
            DbConnection connection,
            string sql,
            QueryParamList queryParam)
        {
            return ExecuteNonQuery(connection, sql, queryParam, null);
        }

        
        public static int ExecuteNonQuery(
            DbConnection connection,
            string sql,
            QueryParamList queryParam,
            DbTransaction transaction)
        {
            var command = DataBaseFoundation.CreateCommand(connection, sql, queryParam, transaction);

            return command.ExecuteNonQuery();
        }

        #endregion

        #region ExecuteScalar

        
        public static object ExecuteScalar(
            DbConnection connection,
            string sql)
        {
            return DataBaseFoundation.ExecuteScalar(connection, sql, new QueryParamList(), null);
        }

        
        public static object ExecuteScalar(
            DbConnection connection,
            string sql,
            QueryParamList queryParam)
        {
            return DataBaseFoundation.ExecuteScalar(connection, sql, queryParam, null);
        }

        
        public static object ExecuteScalar(
            DbConnection connection,
            string sql,
            DbTransaction transaction)
        {
            return DataBaseFoundation.ExecuteScalar(connection, sql, new QueryParamList(), transaction);
        }

        
        public static object ExecuteScalar(
            DbConnection connection,
            string sql,
            QueryParamList queryParam,
            DbTransaction transaction)
        {
            var command = DataBaseFoundation.CreateCommand(connection, sql, queryParam, transaction);

            return command.ExecuteScalar();
        }

        #endregion

        #region ExecuteAdapter

        
        public static DataTable ExecuteAdapter(string connectionString, string sql)
        {
            return DataBaseFoundation.ExecuteAdapter(connectionString, sql, new QueryParamList());
        }

        
        public static DataTable ExecuteAdapter(
            string connectionString,
            string sql,
            QueryParamList queryParam)
        {
            using (DbConnection connection = DataBaseFoundation.GetConnection(connectionString))
            {
                return DataBaseFoundation.ExecuteAdapter(connection, sql, queryParam);
            }
        }

        
        public static DataTable ExecuteAdapter(
            DbConnection connection,
            string sql)
        {
            return DataBaseFoundation.ExecuteAdapter(connection, sql, new QueryParamList(), null);
        }

        
        public static DataTable ExecuteAdapter(
            DbConnection connection,
            string sql,
            DbTransaction transaction)
        {
            return DataBaseFoundation.ExecuteAdapter(connection, sql, new QueryParamList(), transaction);
        }

        
        public static DataTable ExecuteAdapter(
            DbConnection connection,
            string sql,
            QueryParamList queryParam)
        {
            return DataBaseFoundation.ExecuteAdapter(connection, sql, queryParam, null);
        }

        
        public static DataTable ExecuteAdapter(
            DbConnection connection,
            string sql,
            QueryParamList queryParam,
            DbTransaction transaction)
        {
            var command = DataBaseFoundation.CreateCommand(connection, sql, queryParam, transaction);
            var table = new DataTable("table");
            var adapter = new SqlDataAdapter((SqlCommand)command);

            adapter.Fill(table);
            adapter.Dispose();
            adapter = null;

            command.Dispose();

            return table;
        }

        #endregion

        #region ExecuteReader

        
        public static DbDataReader ExecuteReader(DbConnection connection, string sql)
        {
            return DataBaseFoundation.ExecuteReader(connection, sql, new QueryParamList());
        }

        
        public static DbDataReader ExecuteReader(
            DbConnection connection,
            string sql,
            QueryParamList queryParam)
        {
            return ExecuteReader(connection, sql, queryParam, null);
        }

        
        public static DbDataReader ExecuteReader(
            DbConnection connection,
            string sql,
            QueryParamList queryParam,
            DbTransaction transaction)
        {
            // コマンド作成
            var command = DataBaseFoundation.CreateCommand(connection, sql, queryParam, transaction);

            return command.ExecuteReader();
        }

        #endregion

        #region AddWhereParameter

        
        public static void AddWhereParameter(
            string fieldName,
            object paramValue,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            AddWhereParameter(fieldName, paramValue, "=", whereSql, whereParam);
        }

        public static void AddWhereParameterNotEqual(
            string fieldName,
            object paramValue,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            AddWhereParameter(fieldName, paramValue, "!=", whereSql, whereParam);
        }
        public static void AddWhereLessThanOrEqualParameter(
          string fieldName,
          object paramValue,
          StringBuilder whereSql,
          Dictionary<string, object> whereParam)
        {
            AddWhereParameter(fieldName, paramValue, "<=", whereSql, whereParam);
        }
        public static void AddWhereGreatThanOrEqualParameter(
        string fieldName,
        object paramValue,
        StringBuilder whereSql,
        Dictionary<string, object> whereParam)
        {
            AddWhereParameter(fieldName, paramValue, ">=", whereSql, whereParam);
        }
        
        public static void AddWhereParameter(
            string fieldName,
            object paramValue,
            string conditionString,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            string atparam = "@" + fieldName.Replace("[", string.Empty).Replace("]", string.Empty).Replace(".", "_");
            whereParam[atparam] = paramValue;

            if (whereSql.Length > 0)
            {
                whereSql.Append(" AND ");
            }

            whereSql.AppendFormat(" {0} {1} {2} ", fieldName, conditionString, atparam);
            whereSql.AppendLine();
        }

        
        public static void AddWhereFromParameter(
            string fieldName,
            object paramValue,
            string conditionString,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            DataBaseFoundation.AddWhereParameterWithParameterAppendName(
                fieldName,
                "_From",
                paramValue,
                conditionString,
                whereSql,
                whereParam);
        }

        
        public static void AddWhereToParameter(
            string fieldName,
            object paramValue,
            string conditionString,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            DataBaseFoundation.AddWhereParameterWithParameterAppendName(
                fieldName,
                "_To",
                paramValue,
                conditionString,
                whereSql,
                whereParam);
        }

        
        public static void AddWhereParameterWithParameterAppendName(
            string fieldName,
            string paramAppendName,
            object paramValue,
            string conditionString,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            string atparam = "@" + fieldName.Replace("[", string.Empty).Replace("]", string.Empty).Replace(".", "_") + paramAppendName;
            whereParam[atparam] = paramValue;

            if (whereSql.Length > 0)
            {
                whereSql.Append(" AND ");
            }

            whereSql.AppendFormat(" {0} {1} {2} ", fieldName, conditionString, atparam);
            whereSql.AppendLine();
        }

        
        public static void AddWhereLikeParameter(
            string fieldName,
            object paramValue,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            string atparam = "@" + fieldName.Replace("[", string.Empty).Replace("]", string.Empty).Replace(".", "_");
            whereParam[atparam] = paramValue;

            if (whereSql.Length > 0)
            {
                whereSql.Append(" AND ");
            }

            whereSql.AppendFormat(" {0} LIKE {1} ", fieldName, atparam);
            whereSql.AppendLine();
        }

        
        public static void AddWhereBetweenParameter(
            string fieldName,
            object paramValueFrom,
            object paramValueTo,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            string atparamFrom = "@" + fieldName.Replace("[", string.Empty).Replace("]", string.Empty).Replace(".", "_") + "_From";
            string atparamTo = "@" + fieldName.Replace("[", string.Empty).Replace("]", string.Empty).Replace(".", "_") + "_To";
            whereParam[atparamFrom] = paramValueFrom;
            whereParam[atparamTo] = paramValueTo;

            if (whereSql.Length > 0)
            {
                whereSql.Append(" AND ");
            }

            whereSql.AppendFormat(" {0} BETWEEN {1} AND {2} ", fieldName, atparamFrom, atparamTo);
            whereSql.AppendLine();
        }

        
        public static void AddWhereBetweenReverseParameter(
            object paramValue,
            string fieldNameFrom,
            string fieldNameTo,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            string atparam = "@" + fieldNameFrom.Replace("[", string.Empty).Replace("]", string.Empty).Replace(".", "_") + "_" + fieldNameTo.Replace("[", string.Empty).Replace("]", string.Empty).Replace(".", "_");
            whereParam[atparam] = paramValue;

            if (whereSql.Length > 0)
            {
                whereSql.Append(" AND ");
            }

            whereSql.AppendFormat(" {0} BETWEEN {1} AND {2} ", atparam, fieldNameFrom, fieldNameTo);
            whereSql.AppendLine();
        }

        
        public static void AddWhereInParameter(
            string fieldName,
            object[] paramValues,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            AddWhereInParameter(fieldName, paramValues, false, whereSql, whereParam);
        }

        
        public static void AddWhereInParameter(
            string fieldName,
            object[] paramValues,
            bool notCondition,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            string atparamBase = "@" + fieldName.Replace("[", string.Empty).Replace("]", string.Empty).Replace(".", "_");
            StringBuilder atparams = new StringBuilder();

            int i = 0;
            foreach (var obj in paramValues)
            {
                string atparam = atparamBase + i.ToString();
                whereParam[atparam] = obj;

                if (atparams.Length == 0)
                {
                    atparams.Append("(");
                }
                else
                {
                    atparams.Append(", ");
                }

                atparams.Append(atparam);

                i++;
            }

            if (atparams.Length > 0)
            {
                atparams.Append(")");
            }

            if (whereSql.Length > 0)
            {
                whereSql.Append(" AND ");
            }

            string notConditionString = string.Empty;
            if (notCondition)
            {
                notConditionString = "NOT";
            }

            whereSql.AppendFormat(" {0} {1} IN {2}", fieldName, notConditionString, atparams.ToString());
            whereSql.AppendLine();
        }

        
        public static void AddWhereInReverseParameter(
            string paramName,
            object paramValue,
            string[] fieldNames,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            AddWhereInReverseParameter(paramName, paramValue, fieldNames, false, whereSql, whereParam);
        }

        
        public static void AddWhereInReverseParameter(
            string paramName,
            object paramValue,
            string[] fieldNames,
            bool notCondition,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            whereParam[paramName] = paramValue;

            if (whereSql.Length > 0)
            {
                whereSql.Append(" AND ");
            }

            string notConditionString = string.Empty;
            if (notCondition)
            {
                notConditionString = "NOT";
            }

            whereSql.AppendFormat(" {0} {1} IN ({2})", paramName, notConditionString, string.Join(",", fieldNames));
            whereSql.AppendLine();
        }

        
        public static void AddWhereParameter(List<W2uiSearchCondition> w2uiSearchConditionList,
            StringBuilder whereSql,
            Dictionary<string, object> whereParam)
        {
            foreach (var v in w2uiSearchConditionList)
            {
                switch (v.Operator)
                {
                    case "is":
                        AddWhereParameter(v.Field, v.Value, whereSql, whereParam);
                        break;

                    case "between":
                        AddWhereBetweenParameter(v.Field, v.Values[0], v.Values[1], whereSql, whereParam);
                        break;

                    case "begins":
                        AddWhereLikeParameter(v.Field, $"{v.Value}%", whereSql, whereParam);
                        break;

                    case "contains":
                        AddWhereLikeParameter(v.Field, $"%{v.Value}%", whereSql, whereParam);
                        break;

                    case "ends":
                        AddWhereLikeParameter(v.Field, $"%{v.Value}", whereSql, whereParam);
                        break;

                    case "in":
                        AddWhereInParameter(v.Field, v.Values, whereSql, whereParam);
                        break;

                    case "not in":
                        AddWhereInParameter(v.Field, v.Values, true, whereSql, whereParam);
                        break;
                }
            }
        }

        
        public static string GetLimitOffsetOrder(List<W2uiSearchSortCondtion> sort, int offset, int limit)
        {
            if (sort == null)
            {
                throw new ArgumentNullException("sort", "sort must be not null");
            }

            if (sort.Count == 0)
            {
                throw new ArgumentOutOfRangeException("sort", "sort must be contain a value");
            }

            var order = new List<string>();
            foreach (var e in sort)
            {
                order.Add($"{e.Field} {e.Direction}");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}", string.Join(",", order));
            sb.AppendLine();
            sb.AppendFormat("OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", offset, limit);
            sb.AppendLine();
            return sb.ToString();
        }

        #endregion

        
        [SuppressMessage("Microsoft.Security", "CA2100", Justification = "内部メソッドであるため")]
        private static DbCommand CreateCommand(
            DbConnection connection,
            string sql,
            QueryParamList queryParam,
            DbTransaction transaction)
        {
            var command = default(SqlCommand);


            if (transaction == null)
            {
                command = new SqlCommand(sql, (SqlConnection)connection);
            }
            else
            {
                command = new SqlCommand(sql, (SqlConnection)connection, (SqlTransaction)transaction);
            }

            command.ApplySettings();

            foreach (DbParameter param in queryParam)
            {
                command.Parameters.Add(param);
            }

            return command;
        }
    }

    
    public class QueryParamList :
        List<DbParameter>
    {
        
        public QueryParamList()
        {
            // no-op
        }

        
        public QueryParamList(Dictionary<string, object> dic)
        {
            foreach (var key in dic.Keys)
            {
                string k = key;
                object value = dic[key];

                this.Add(key, value);
            }
        }

       
        public override string ToString()
        {
            if (this.Count == 0)
            {
                return base.ToString();
            }

            var str = new StringBuilder("QueryParameters { ");
            for (int i = 0; i <= this.Count - 1; i++)
            {
                str.Append("{ " + this[i].ParameterName + " = " + this[i].Value.ToString() + " }, ");
            }

            return str.ToString();
        }

        
        public void Add(string paramString, object value)
        {
            SqlParameter param = new SqlParameter(paramString, this.NothingToDBNull(value));
            base.Add(param);
        }

        
        public object NothingToDBNull(object param)
        {
            if (param == null)
            {
                return DBNull.Value;
            }
            else
            {
                return param;
            }
        }
    }
}
