using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;
using Dapper;

namespace YunXiu.DAL
{
    public class Store_DAL : IStore
    {
        public bool AddStore(Store store)
        {
            var result = false;
            try
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO Store([StoreID],[StoreManagerID],[State],[Name],[RegionID],[StorerID],[CategoryID],[Logo],[Mobile],[Phone],[QQ],[DePoint],[SePoint],");
                sql.Append("[ShPoint],[Honesties],[ValidityDate],[Theme],[Announcement],[Description],[StoreMoney],[CreateDate],[CreateUserID]) ");
                sql.Append("VALUES(@StoreID,@StoreManagerID,@State,@Name,@RegionID,@StorerID,@CategoryID,@Logo,@Mobile,@Phone,@QQ,@DePoint,@SePoint,");
                sql.Append("@ShPoint,@Honesties,@ValidityDate,@Theme,@Announcement,@Description,@StoreMoney,GEEDATE(),@CreateUserID) ");
                DynamicParameters pars = new DynamicParameters(store);
                pars.Add("@StoreManagerID", store.StoreManager.UID);
                pars.Add("@CategoryID", store.Category.CateID);
                pars.Add("@StoreManager", store.StoreManager.UID);
                result = DapperHelper.Execute<Store>(sql.ToString(), pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteStore(int sID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM Store WHERE [StoreID]={0}", sID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public decimal GetStoreAmount(int sID)
        {
            decimal amount = 0;
            try
            {
                var sql = string.Format("SELECT [StoreMoney] FROM Store WHERE [StoreID]={0}");
                amount = DapperHelper.QuerySingle<decimal>(sql);
            }
            catch (Exception ex)
            { }
            return amount;
        }

        public bool UpdateStore(Store store)
        {
            var result = false;
            try
            {
                var sql = new StringBuilder();
                sql.Append("UPDATE Store SET [StoreManagerID]=@StoreManagerID,[State]=@State,[Name]=@Name,[CategoryID]=@CategoryID,[Logo]=@Logo,[Mobile]=@Mobile,[Phone]=@Phone,[QQ]=@QQ,[DePoint]=@DePoint,[SePoint]=@SePoint");
                sql.Append("[ShPoint]=@ShPoint,[Honesties]=@Honesties,[ValidityDate]=@ValidityDate,[Theme]=@Theme,[Announcement]=@Announcement,[Description]=@Description,[LastUpdateDate]=GETDATE() WHERE [StoreID]=@StoreID");
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@StoreManagerID", store.StoreManager.UID);
                pars.Add("@CategoryID", store.Category.CateID);
                result = DapperHelper.Execute<Store>(sql.ToString(), pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
