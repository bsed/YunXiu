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
    public class StoreNavigation_DAL : IStoreNavigation
    {
        public bool AddStoreNavigation(StoreNavigation navigation)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO StoreNavigation([StoreID],[NName],[NLink],[Sort],[IsShow],[IsOpenNew],[CreateDate]) VALUES(@StoreID,@NName,@NLink,@Sort,@IsShow,@IsOpenNew,GETDATE())";
                DynamicParameters pars = new DynamicParameters(navigation);
                pars.Add("@StoreID",navigation.Store.StoreID);
                result = DapperHelper.Execute(sql,pars);
            }
            catch (Exception ex)
            { }
            return result;
        }

        public bool DeleteStoreNavigation(int nID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM StoreNavigation WHERE [NID]={0}",nID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<StoreNavigation> GetStoreNavigation(int sID)
        {
            List<StoreNavigation> list = null;
            try
            {
                var sql = "SELECT [NName],[NLink],[Sort],[IsShow],[IsOpenNew] FROM StoreNavigation WHERE NID={0}";
                list = DapperHelper.Query<StoreNavigation>(sql);
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool UpdateStoreNavigation(StoreNavigation navigation)
        {
            var result = false;
            try
            {
                var sql = "UPDATE StoreNavigation SET [NName]=@NName,[NLink]=@NLink,[Sort]=@Sort,[IsShow]=@IsShow,[IsOpenNew]=@IsOpenNew WHERE [NID]=@NID";
                result = DapperHelper.Execute(sql,navigation);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
