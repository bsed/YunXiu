using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.Commom;
using Dapper;

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
                result = DapperHelper.Execute(sql,pars);
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
            throw new NotImplementedException();
        }
    }
}
