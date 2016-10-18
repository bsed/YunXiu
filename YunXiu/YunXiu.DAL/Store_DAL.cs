using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;
using Dapper;
using System.Data;

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
                pars.Add("@CategoryID", store.Category.CateId);
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

        public List<Store> GetStore()
        {
            List<Store> list = null;
            try
            {
                var sql = new StringBuilder(); ;
                sql.Append("SELECT c.[CateID],c.[Sort],c.[Name],s.[StoreID],s.[StoreManagerID],s.[State],s.[Name],s.[RegionID],s.[StorerID],s.[Logo],s.[Mobile],s.[Phone],s.[QQ],s.[DePoint],s.[SePoint],s.[ShPoint],");
                sql.Append("s.[Honesties],s.[ValidityDate],s.[Theme],s.[Announcement],s.[Description],s.[StoreMoney],s.[CreateDate] FROM Store s ");
                sql.Append("LEFT JOIN Category c ON s.[CategoryID] = c.[CateID] ");
                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<Store, Category, Store>(sql.ToString(),
                        (s,c)=> 
                        {
                            s.Category = c;
                            return s;
                        },
                        null,
                        null,
                        true,
                        "Name,CateID",
                        null,
                        null).ToList();
                }
            }
            catch (Exception ex) { }
            return list;
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

        public Store GetStoreByID(int sID)
        {
            Store store = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT c.[CateID],c.[Sort],c.[Name],s.[StoreID],s.[StoreManagerID],s.[State],s.[Name],s.[RegionID],s.[StorerID],s.[Logo],s.[Mobile],s.[Phone],s.[QQ],s.[DePoint],s.[SePoint],s.[ShPoint],");
                sql.Append("s.[Honesties],s.[ValidityDate],s.[Theme],s.[Announcement],s.[Description],s.[StoreMoney],s.[CreateDate] FROM Store s ");
                sql.Append("LEFT JOIN Category c ON s.[CategoryID] = c.[CateID] ");
                sql.Append(string.Format("WHERE s.[StoreID]={0}",sID));

                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    store = conn.Query<Store, Category, Store>(sql.ToString(),
                        (s, c) =>
                        {
                            s.Category = c;
                            return s;
                        },
                        null,
                        null,
                        true,
                        "CateID,StoreID",
                        null,
                        null).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return store;
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
                pars.Add("@CategoryID", store.Category.CateId);
                result = DapperHelper.Execute<Store>(sql.ToString(), pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
