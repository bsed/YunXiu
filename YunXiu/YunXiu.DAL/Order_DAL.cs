using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using YunXiu.Model;
using YunXiu.Commom;
using YunXiu.Interface;

namespace YunXiu.DAL
{
    public class Order_DAL : IOrder
    {
        public bool CreateOrder(List<Order> orders)
        {
            var result = false;
            try
            {
                var nowDate = DateTime.Now.ToString("yyyy-MM-dd");
                DataTable dt = new DataTable();
                dt.Columns.Add("OID");
                dt.Columns.Add("OSN");
                dt.Columns.Add("BuyUserID");
                dt.Columns.Add("OrderState");
                dt.Columns.Add("BuyProductID");
                dt.Columns.Add("ReceiptAddressID");
                dt.Columns.Add("BuyNumber");
                dt.Columns.Add("BuyUnitPrice");
                dt.Columns.Add("CreateDate");
                dt.Columns.Add("CreateUserID");
                dt.Columns.Add("LastUpdateUserID");
                dt.Columns.Add("LastUpdateDate");
                for (int i = 0; i < orders.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["OSN"] = orders[i].OSN;
                    dr["BuyUserID"] = orders[i].BuyUser != null ? orders[i].BuyUser.UID : 0;
                    dr["OrderState"] = orders[i].OrderState;
                    dr["BuyProductID"] = orders[i].BuyProduct != null ? orders[i].BuyProduct.PID : 0;
                    dr["ReceiptAddressID"] = orders[i].ReceiptAddress != null ? orders[i].ReceiptAddress.ID : 0;
                    dr["BuyNumber"] = orders[i].BuyNumber;
                    dr["BuyUnitPrice"] = orders[i].BuyUnitPrice;
                    dr["CreateDate"] = nowDate;
                    dr["CreateUserID"] = orders[i].CreateUser != null ? orders[i].CreateUser.UID : 0;
                    dr["LastUpdateUserID"] = orders[i].LastUpdateUser != null ? orders[i].CreateUser.UID : 0;
                    dr["LastUpdateDate"] = nowDate;
                    dt.Rows.Add(dr);
                }
                SQLHelper.BulkToDB(dt, "[Order]");
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public List<Order> GetOrderByUser(int userID)
        {
            var list = new List<Order>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT [OID],[OSN],[BuyUserID],[OrderState],[BuyProductID],[ReceiptAddressID],[CreateDate],[CreateUserID],[LastUpdateUserID],[LastUpdateDate] ");
                sql.Append(string.Format("FROM Order WHERE [BuyUserID] = {0}", userID));
                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Order
                    {
                        OID = Convert.ToInt32(dt.Rows[i]["OID"]),
                        BuyUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[i]["BuyUserID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["BuyUserID"])
                        },
                        OrderState = Convert.IsDBNull(dt.Rows[i]["OrderState"]) ? 0 : Convert.ToInt32(dt.Rows[i]["OrderState"]),
                        BuyProduct = new Product
                        {
                            PID = Convert.IsDBNull(dt.Rows[i]["BuyProductID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["BuyProductID"])
                        },
                        ReceiptAddress = new ReceiptAddress
                        {
                            ID = Convert.IsDBNull(dt.Rows[i]["ReceiptAddressID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ReceiptAddressID"])
                        },
                        CreateDate = Convert.IsDBNull(dt.Rows[i]["CreateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[i]["CreateDate"]),
                        CreateUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[i]["CreateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["CreateUserID"])
                        },
                        LastUpdateUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[i]["LastUpdateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["LastUpdateUserID"])
                        },
                        LastUpdateDate = Convert.IsDBNull(dt.Rows[i]["LastUpdateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[i]["LastUpdateDate"]),
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

        public Order GetOrder(int oID)
        {
            Order order = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT [OID],[OSN],[BuyUserID],[OrderState],[BuyProductID],[ReceiptAddressID],[CreateDate],[CreateUserID],[LastUpdateUserID],[LastUpdateDate] ");
                sql.Append(string.Format("FROM Order WHERE [OID] = {0}", oID));
                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据 

                order = new Order
                {
                    OID = Convert.ToInt32(dt.Rows[0]["OID"]),
                    BuyUser = new User
                    {
                        UID = Convert.IsDBNull(dt.Rows[0]["BuyUserID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["BuyUserID"])
                    },
                    OrderState = Convert.IsDBNull(dt.Rows[0]["OrderState"]) ? 0 : Convert.ToInt32(dt.Rows[0]["OrderState"]),
                    BuyProduct = new Product
                    {
                        PID = Convert.IsDBNull(dt.Rows[0]["BuyProductID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["BuyProductID"])
                    },
                    ReceiptAddress = new ReceiptAddress
                    {
                        ID = Convert.IsDBNull(dt.Rows[0]["ReceiptAddressID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["ReceiptAddressID"])
                    },
                    CreateDate = Convert.IsDBNull(dt.Rows[0]["CreateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[0]["CreateDate"]),
                    CreateUser = new User
                    {
                        UID = Convert.IsDBNull(dt.Rows[0]["CreateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["CreateUserID"])
                    },
                    LastUpdateUser = new User
                    {
                        UID = Convert.IsDBNull(dt.Rows[0]["LastUpdateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["LastUpdateUserID"])
                    },
                    LastUpdateDate = Convert.IsDBNull(dt.Rows[0]["LastUpdateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[0]["LastUpdateDate"]),
                };
                #endregion
            }
            catch (Exception ex)
            {

            }
            return order;
        }

        public bool UpdateOrder(Order order)
        {
            var result = false;
            try
            {
                var sql = "UPDATE Order SET [OrderState]=@OrderState,[LastUpdateUserID]=@LastUpdateUserID,[LastUpdateDate]=@LastUpdateDate";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@OrderState", order.OrderState));
                pars.Add(new SqlParameter("@LastUpdateUserID", order.LastUpdateUser != null ? order.LastUpdateUser.UID : 0));
                pars.Add(new SqlParameter("@LastUpdateDate", DateTime.Now));
                result = SQLHelper.ExcuteSQL(sql, pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
