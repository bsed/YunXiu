using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.Commom;
using Dapper;
using System.Data;

namespace YunXiu.DAL
{
    public class FavoriteStore_DAL : IFavoriteStore
    {
        public bool AddFavoriteStore(FavoriteStore store)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO FavoriteProduct(UID,SID,CreateDate) VALUES(@UID,@SID,GETDATE())";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@UID", store.User.UID);
                pars.Add("@SID", store.User.UID);
                result = DapperHelper.Execute(sql, pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteFavoriteStore(int fID)
        {
            throw new NotImplementedException();
        }

        public List<FavoriteStore> GetFavoriteStore(int uID)
        {
            List<FavoriteStore> list = null;
            var sql = new StringBuilder();
            sql.Append("SELECT fs.[FID],fs.[CreateDate],s.[StoreID],s.[Name],s.[Logo] FROM FavoriteStore fs ");
            sql.Append("LEFT JOIN Store s ON s.[StoreID]= fs.[SID] ");
            sql.Append(string.Format("WHERE fs.[UID]={0}", uID));
            using (IDbConnection conn = DapperHelper.GetDbConnection())
            {
                list = conn.Query<FavoriteStore, Store, FavoriteStore>(sql.ToString(),
                    (fs, s) =>
                    {
                        fs.Store = s;
                        return fs;
                    },
                    null,
                    null,
                    true,
                    "FID,StoreID",
                    null,
                    null).ToList();
            }
            return list;
        }
    }
}
