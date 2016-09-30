using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace YunXiu.Commom
{
    public class DapperHelper
    {
        public static IDbConnection GetDbConnection()
        {
            IDbConnection conn = GetConn();
            return conn;
        }

        public static bool Execute<T>(string sql, T t)
        {
            var result = false;
            using (IDbConnection conn = GetDbConnection())
            {
                result = conn.Execute(sql, t) > 0;
            }
            return result;
        }

        public static bool Execute<T>(string sql, DynamicParameters pars)
        {
            var result = false;
            using (IDbConnection conn = GetDbConnection())
            {
                result = conn.Execute(sql, pars) > 0;
            }
            return result;
        }

        public static bool Execute(string sql)
        {
            var result = false;
            using (IDbConnection conn = GetDbConnection())
            {
                result = conn.Execute(sql) > 0;
            }
            return result;
        }

        public static int ExecuteProc(string proc, DynamicParameters pars)
        {
            var result = 0;
            using (IDbConnection conn = GetDbConnection())
            {
                result = conn.Execute(proc, pars, null, null, CommandType.StoredProcedure);               
            }
            return result;
        }

        public static List<T> Query<T>(string sql)
        {
            List<T> list = null;
            using (IDbConnection conn = GetDbConnection())
            {
                list = conn.Query<T>(sql).ToList();
            }
            return list;
        }

        public static T QuerySingle<T>(string sql)
        {
            T t = default(T);
            using (IDbConnection conn = GetDbConnection())
            {
                t = conn.Query<T>(sql).SingleOrDefault();
            }
            return t;
        }

        public static T QuerySingle<T>(string sql, T obj)
        {
            T t = default(T);
            using (IDbConnection conn = GetDbConnection())
            {
                t = conn.Query<T>(sql, obj).SingleOrDefault();
            }
            return t;
        }

        public static T QuerySingle<T>(string sql, DynamicParameters pars)
        {
            T t = default(T);
            using (IDbConnection conn = GetDbConnection())
            {
                t = conn.Query<T>(sql, pars).SingleOrDefault();
            }
            return t;
        }

        public static int ExecuteScalar(string sql, DynamicParameters pars)
        {
            var val = 0;
            using (IDbConnection conn = GetDbConnection())
            {
                val = conn.ExecuteScalar<int>(sql, pars);
            }
            return val;
        }

     

        private static SqlConnection GetConn()
        {
            var connStr = Model.Global.GlobalDictionary.GetSysConfVal("DBCon");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public static SqlConnection GetConn(string conStr)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            return conn;
        }
    }
}
