using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;
using System.Data;

namespace YunXiu.DAL
{
    public class OrderPayOrder_DAL : IOrderPayOrder
    {
        public bool CreateOrderPayOrder(PayOrder payOrder)
        {
            var result = false;
            try
            {
                var nowDate = DateTime.Now;
                DataTable dt = new DataTable();
                dt.Columns.Add("PayOrderID");
                dt.Columns.Add("OrderID");
                dt.Columns.Add("CreateDate");
                for (int i = 0; i < payOrder.Orders.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["PayOrderID"] = payOrder.ID;
                    dr["OrderID"] = payOrder.Orders[i].OID;
                    dr["CreateDate"] = nowDate;
                    dt.Rows.Add(dr);
                }
                SQLHelper.BulkToDB(dt, "OrderPayOrder");
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Order> GetOrderByPayOrder(int payOrderID)
        {
            var orders = new List<Order>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT o2.[OID],o2.[OSN],o2.[BuyUserID],o2.[OrderState],o2.[BuyProductID],o2.[ReceiptAddressID],o2.[CreateDate],o2.[CreateUserID],o2.[LastUpdateUserID],o2.[LastUpdateDate] FROM OrderPayOrder o ");
                sql.Append("LEFT JOIN Order o2 ON o2.OID =o.OrderID ");
                sql.Append(string.Format("WHERE PayOrderID={0}", payOrderID));

                var dt = SQLHelper.GetTable(sql.ToString());

                #region 提取数据
                for (int i = 0; i > dt.Rows.Count; i++)
                {
                    var order = new Order
                    {
                        OID = Convert.ToInt32(dt.Rows[i]["OID"]),
                        OSN = Convert.IsDBNull(dt.Rows[i]["OSN"]) ? "" : Convert.ToString(dt.Rows[i]["OSN"]),
                    };
                    orders.Add(order);
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return orders;
        }

        public PayOrder GetPayOrderByOrder(int orderID)
        {
            PayOrder payOrder = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT o2.[ID],o2.[SaleUserID],o2.[BuyUserID],o2.[PayAmount],o2.[PayType],o2.[PayOrderNo],o2.[Describe],o2.[CreateUserID],o2.[CreateDate],o2.[LastUpdateDate],o2.[LastUpdateUserID] FROM OrderPayOrder o ");
                sql.Append("LEFT JOIN PayOrder o2 ON o2.OID =o.PayOrderID ");
                sql.Append(string.Format("WHERE OrderID={0}", orderID));
                var dt = SQLHelper.GetTable(sql.ToString());
                if (dt.Rows.Count > 0)
                {
                    payOrder = new PayOrder
                    {
                        ID = Convert.IsDBNull(dt.Rows[0]["ID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["ID"]),
                        PayAmount= Convert.IsDBNull(dt.Rows[0]["PayAmount"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["PayAmount"]),
                    };
                }

            }
            catch (Exception ex)
            {

            }
            return payOrder;
        }
    }
}
