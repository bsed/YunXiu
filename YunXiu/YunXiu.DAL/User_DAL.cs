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
            throw new NotImplementedException();
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

        public User GetUserByID(string guid)
        {
            throw new NotImplementedException();
        }

        public bool CreateUser(string guid)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO [User](client_guid) VALUES(@client_guid)";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@client_guid", guid);
                result = DapperHelper.Execute(sql, pars);
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
