using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using YunXiu.Commom;
using YunXiu.Model;
using YunXiu.Interface;

namespace YunXiu.DAL
{
    public class ShoppingCart_DAL : IShoppingCart
    {
        public bool AddProductToShoppingCart(int userID, int productID, int number)
        {
            var result = false;
            try
            {
                var nowDate = DateTime.Now;
                var sql = "INSERT INTO ShoppingCart([UserID],[ProductID],[Number],[CreateDate],[CreateUserID],[LastUpdateDate],[LastUpdateUserID]) VALUES(@UserID,@ProductID,@Number,@CreateDate,@CreateUserID,@LastUpdateDate,@LastUpdateUserID)";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@UserID", userID));
                pars.Add(new SqlParameter("@ProductID", productID));
                pars.Add(new SqlParameter("@Number", number));
                pars.Add(new SqlParameter("@CreateDate", nowDate));
                pars.Add(new SqlParameter("@CreateUserID", userID));
                pars.Add(new SqlParameter("@LastUpdateDate", nowDate));
                pars.Add(new SqlParameter("@LastUpdateUserID", userID));
                result = SQLHelper.ExcuteSQL(sql, pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteShoppingCartProduct(List<int> pID)
        {
            var result = false;
            try
            {
                var id = Utilities.ListToListStr(pID);
                var sql = string.Format("DELETE FROM ShoppingCart WHERE ProductID IN ({0})", id);
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
                var id = Utilities.ListToListStr(pID);
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
                var sql = string.Format("SELECT [SID],[UserID],[ProductID],[Number],[CreateDate],[CreateUserID],[LastUpdateDate],[LastUpdateUserID] FROM ShoppingCart WHERE User={0}", userID);
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
                        Number = Convert.IsDBNull(dt.Rows[i]["Number"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Number"]),
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

    }
}
