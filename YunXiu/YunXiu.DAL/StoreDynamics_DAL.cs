using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Commom;
using YunXiu.Model;
using Dapper;
using System.Data;

namespace YunXiu.DAL
{
    public class StoreDynamics_DAL : IStoreDynamics
    {
        public bool AddStoreDynamics(StoreDynamics dynamics)
        {
            var result = false;
            var sql = "INSERT INTO StoreDynamics([StoreID],[Title],[DContent],[CreateDate],[CreateUserID]) VALUES(@StoreID,@Title,@DContent,GETDATE(),@CreateUserID)";
            DynamicParameters pars = new DynamicParameters(dynamics);
            pars.Add("@StoreID", dynamics.Store.StoreID);
            pars.Add("@CreateUserID", dynamics.CreateUser.UID);
            result = DapperHelper.Execute(sql, pars);
            return result;
        }

        public bool DeleteStoreDynamics(int dID)
        {
            var result = false;
            var sql = string.Format("DELETE FROM StoreDynamics WHERE [DID]={0}", dID);
            result = DapperHelper.Execute(sql);
            return result;
        }

        public List<StoreDynamics> GetStoreDynamics(int sID)
        {
            List<StoreDynamics> list = null;
            var sql = new StringBuilder();
            sql.Append("SELECT sd.[DID],sd.[Title],sd.[DContent],sd.[CreateDate],sd.[LastUpdateDate],u.[UID],u.[client_guid],u2.[UID],u2.[client_guid] FROM StoreDynamics sd ");
            sql.Append("LEFT JOIN [User] u ON u.[UID]= sd.[CreateUserID] ");
            sql.Append("LEFT JOIN [User] u2 ON u2.[UID]= sd.[LastUpdateUserID] ");
            sql.Append(string.Format("WHERE sd.[StoreID]={0}", sID));
            using (IDbConnection conn = DapperHelper.GetDbConnection())
            {
                list = conn.Query<StoreDynamics, User, User, StoreDynamics>(sql.ToString(),
                    (sd, u, u2) =>
                    {
                        sd.CreateUser = u;
                        sd.LastUpdateUser = u2;
                        return sd;
                    },
                    null,
                    null,
                    true,
                    "DID,UID,UID",
                    null,
                    null).ToList();
            }
            return list;
        }

        public bool UpdateStoreDynamics(StoreDynamics dynamics)
        {
            var result = false;
            var sql = "UPDATE StoreDynamics SET [Title]=@Title,[DContent]=@DContent,[LastUpdateDate]=GETDATE(),[LastUpdateUserID]=@LastUpdateUserID WHERE [DID]=@DID";
            DynamicParameters pars = new DynamicParameters(dynamics);
            pars.Add("@LastUpdateUserID", dynamics.LastUpdateUser.UID);
            result = DapperHelper.Execute(sql, pars);
            return result;
        }
    }
}
