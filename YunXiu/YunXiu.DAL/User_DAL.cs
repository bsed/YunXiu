using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Commom;
using YunXiu.Model;
using YunXiu.Interface;
using Dapper;

namespace YunXiu.DAL
{
    public class User_DAL : IUser
    {

        public List<User> GetUser()
        {
            List<User> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT u.[UID],u.[client_guid],u.[UserRID],u.[MallagID],u.[Avatar],u.[PayCredits],u.[RankCredits],u.[LiftBanTime],u.[Salt],u.[UState],u.[CreateDate],s.[StoreID],s.[Name] FROM [User] u ");
                sql.Append("LEFT JOIN [Store] s ON s.[StoreID]=u.[UStoreID] ");

                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<User, Store, User>(sql.ToString(),
                        (u, s) =>
                        {
                            u.UStore = s;
                            return u;
                        },
                        null,
                        null,
                        true,
                        "UID,StoreID",
                        null).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<User> GetMultiUserByID(List<string> guid)
        {
            List<User> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT u.[UID],u.[client_guid],u.[UserRID],u.[MallagID],u.[Avatar],u.[PayCredits],u.[RankCredits],u.[LiftBanTime],u.[Salt],u.[UStoreID],u.[CreateDate] FROM [User] u ");
                sql.Append("LEFT JOIN Store s ON s.[StoreID] =u.[StoreID] ");
                sql.Append("");
                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<User, Store, User>(sql.ToString(),
                        (u, s) =>
                        {
                            u.UStore = s;
                            return u;
                        },
                        null,
                        null,
                        true,
                        "UID",
                        null).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public User GetUserByTFID(string guid)
        {
            User user = null;
            try
            {
                var sql = new StringBuilder(); ;
                sql.Append("SELECT u.[UID],u.[client_guid],u.[UserRID],u.[MallagID],u.[Avatar],u.[PayCredits],u.[RankCredits],u.[LiftBanTime],u.[Salt],u.[UState],u.[CreateDate],s.[StoreID],s.[Name] FROM [User] u ");
                sql.Append("LEFT JOIN [Store] s ON s.[StoreID]=u.[UStoreID] ");
                sql.Append("WHERE [client_guid]=@guid ");
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@guid", guid);

                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    user = conn.Query<User, Store, User>(sql.ToString(),
                        (u, s) =>
                        {
                            u.UStore = s;
                            return u;
                        },
                        pars,
                        null,
                        true,
                        "UID,StoreID",
                        null).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public int CreateUser(string guid)
        {
            var uid = 0;
            try
            {
                var sql = "INSERT INTO [User](client_guid,CreateDate) VALUES(@client_guid,GETDATE()) SELECT @@IDENTITY";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@client_guid", guid);
                uid = DapperHelper.ExecuteScalar(sql, pars);
            }
            catch (Exception ex)
            {
            }
            return uid;
        }

        public User GetUserByID(int uid)
        {
            User user = null;
            try
            {
                var sql = new StringBuilder(); ;
                sql.Append("SELECT u.[UID],u.[client_guid],u.[UserRID],u.[MallagID],u.[Avatar],u.[PayCredits],u.[RankCredits],u.[LiftBanTime],u.[Salt],u.[UState],u.[CreateDate],s.[StoreID],s.[Name] FROM [User] u ");
                sql.Append("LEFT JOIN [Store] s ON s.[StoreID]=u.[UStoreID] ");
                sql.Append("WHERE [UID]=@uid ");
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@uid", uid);

                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    user = conn.Query<User, Store, User>(sql.ToString(),
                        (u, s) =>
                        {
                            u.UStore = s;
                            return u;
                        },
                        pars,
                        null,
                        true,
                        "UID,StoreID",
                        null).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return user;
        }
    }
}
