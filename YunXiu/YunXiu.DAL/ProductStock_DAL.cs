using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.Commom;

namespace YunXiu.DAL
{
    public class ProductStock_DAL : IProductStock
    {
        public List<ProductStock> GetProductStock()
        {
            var list = new List<ProductStock>();
            try
            {
                var sql = "SELECT [ID],[ProductID],[Number],[Limit],[CreateDate],[CreateUserID],[LastUpdateUserID],[LastUpdateDate] FROM ProductStock";
                var dt = SQLHelper.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new ProductStock
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                        Product = new Product
                        {
                            PID = Convert.IsDBNull(dt.Rows[i]["ProductID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ProductID"])
                        },
                        Number = Convert.IsDBNull(dt.Rows[i]["Number"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Number"]),
                        Limit = Convert.IsDBNull(dt.Rows[i]["Limit"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Limit"]),
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public ProductStock GetProductStock(int pID)
        {
            ProductStock productStock = null;
            try
            {
                var sql = "SELECT [ID],[ProductID],[Number],[Limit],[CreateDate],[CreateUserID],[LastUpdateUserID],[LastUpdateDate] FROM ProductStock";
                var dt = SQLHelper.GetTable(sql);

                productStock = new ProductStock
                {
                    ID = Convert.ToInt32(dt.Rows[0]["ID"]),
                    Product = new Product
                    {
                        PID = Convert.IsDBNull(dt.Rows[0]["ProductID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["ProductID"])
                    },
                    Number = Convert.IsDBNull(dt.Rows[0]["Number"]) ? 0 : Convert.ToInt32(dt.Rows[0]["Number"]),
                    Limit = Convert.IsDBNull(dt.Rows[0]["Limit"]) ? 0 : Convert.ToInt32(dt.Rows[0]["Limit"]),
                };
            }
            catch (Exception ex)
            {

            }
            return productStock;
        }

        /// <summary>
        /// 修改库存
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="productID"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public Dictionary<int, bool> UdpateStock(int userID, Dictionary<int, int> dic)
        {
            Dictionary<int, bool> result = new Dictionary<int, bool>();
            //try
            //{
            //    foreach (var d in dic)
            //    {
            //        var procName = "";
            //        var isOut = Utilities.IntIsNegative(d.Value);//是否是出库
            //        if (isOut) procName = "ProductOutStore";
            //        else procName = "ProductAddStore";
            //        var pars = new List<SqlParameter>();
            //        pars.Add(new SqlParameter("@productID", d.Key));
            //        pars.Add(new SqlParameter("@number", d.Value));
            //        pars.Add(new SqlParameter("@userID", userID));
            //        var isUpdate = SQLHelper.ExcuteProc(procName, pars.ToArray()) == 1;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            return result;
        }
    }
}
