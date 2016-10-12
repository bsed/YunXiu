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
    public class StoreHome_DAL : IStoreHome
    {
        public bool UpdateStoreHome(StoreHome home)
        {
            var result = false;
            try
            {
                var sql = "UPDATE StoreHome SET [HomeHtml]=@HomeHtml WHERE StoreID=@StoreID";
                DynamicParameters pars = new DynamicParameters(home);
                pars.Add("@StoreID", home.Store.StoreID);
                result = DapperHelper.Execute(sql, pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public StoreHome GetStoreHomeByStore(int sID)
        {
            StoreHome home = null;
            try 
            {
                var sql =string.Format("SELECT [StoreID],[HomeHtml] FROM StoreHome WHERE [StoreID]={0}",sID);
                home = DapperHelper.QuerySingle<StoreHome>(sql);
            }
            catch (Exception ex)
            {

            }
            return home;
        }
    }
}
