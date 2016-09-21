﻿using System;
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
                t = conn.ExecuteScalar<T>(sql);
            }
            return t;
        }

        private static SqlConnection GetConn()
        {
            var connStr = Model.Global.GlobalDictionary.GetSysConfVal("DBCon");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }
    }
}