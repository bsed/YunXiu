using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Commom;
using YunXiu.Interface;
using YunXiu.Model;
using Dapper;
using System.Data;

namespace YunXiu.DAL
{
    public class FavoriteProduct_DAL : IFavoriteProduct
    {
        public bool AddFavoriteProduct(FavoriteProduct fProduct)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO FavoriteProducts([FUserID],[FProductID],[CreateDate]) VALUES(@FUserID,@FProductID,GETDATE())";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@FUserID", fProduct.FUser.UID);
                pars.Add("@FProductID", fProduct.FProduct.PID);
                result = DapperHelper.Execute(sql, pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteFavoriteProduct(int fID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM FavoriteProducts WHERE [FID]={0}", fID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex) { }
            return result;
        }

        public List<Product> GetFavoriteProduct(int uID)
        {
            List<Product> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT p.[PID],p.[SkugID],p.[Name],p.[ShopPrice],p.[MarketPrice],p.[CostPrice],p.[ImgName] FROM FavoriteProducts f ");
                sql.Append("LEFT JOIN Product p ON f.[FProductID]= p.[PID] ");
                sql.Append(string.Format("WHERE [FUserID]={0}",uID));

                list = DapperHelper.Query<Product>(sql.ToString());
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
