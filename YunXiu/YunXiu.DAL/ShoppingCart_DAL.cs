using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using YunXiu.Commom;
using YunXiu.Model;
using YunXiu.Interface;
using Dapper;

namespace YunXiu.DAL
{
    public class ShoppingCart_DAL : IShoppingCart
    {
        public bool AddProductToShoppingCart(ShoppingCart sc)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO ShoppingCart([UserID],[ProductID],[Number],[CreateDate]) VALUES(@UserID,@ProductID,@Number,GETDATE())";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@UserID", sc.User.UID));
                pars.Add(new SqlParameter("@ProductID", sc.Product.PID));
                pars.Add(new SqlParameter("@Number", sc.Number));
                result = SQLHelper.ExcuteSQL(sql, pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteShoppingCartProduct(int uID,int pID)
        {
            var result = false;
            try
            {            
                var sql = string.Format("DELETE FROM ShoppingCart WHERE [ProductID] ={0} AND [UserID] = {1} ", pID,uID);
                result = SQLHelper.ExcuteSQL(sql) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ShoppingCart> GetShoppingCartByProduct(List<int> pID)
        {
            var list = new List<ShoppingCart>();
            try
            {
                var id = string.Join(",", pID);
                var sql = string.Format("SELECT [SID],[UserID],[ProductID],[CreateDate],[CreateUserID],[LastUpdateDate],[LastUpdateUserID] FROM ShoppingCart WHERE ProductID IN ({0})", id);
                var dt = SQLHelper.GetTable(sql);

                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new ShoppingCart
                    {
                        SID = Convert.ToInt32(dt.Rows[i]["SID"]),
                        User = new User
                        {

                        },
                        Product = new Product
                        {

                        },
                        CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateUser"]),
                        CreateUser = new User
                        {

                        },
                        LastUpdateDate = Convert.ToDateTime(dt.Rows[i]["LastUpdateDate"]),
                        LastUpdateUser = new User { }
                    };
                    list.Add(obj);
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<ShoppingCart> GetShoppingCartByUser(int userID)
        {
            var list = new List<ShoppingCart>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT p.[PID],p.[StoreID],p.[Name],p.[ShopPrice],p.[ImgName],s.[StoreID],s.[Name],sc.[SID],sc.[Number],sc.[CreateDate] FROM ShoppingCart sc ");
                sql.Append("LEFT JOIN Product p ON p.[PID]=sc.[ProductID] ");
                sql.Append("LEFT JOIN Store s ON s.[StoreID]=p.[StoreID] ");
                sql.Append(string.Format("WHERE sc.[UserID]={0}", userID));
                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<Product, Store, ShoppingCart, ShoppingCart>(sql.ToString(),
                        (p, s, sc) =>
                        {
                            p.Store = s;
                            sc.Product = p;
                            return sc;
                        },
                        null,
                        null,
                        true,
                        "PID,StoreID,SID",
                        null
                        , null).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

    }
}
