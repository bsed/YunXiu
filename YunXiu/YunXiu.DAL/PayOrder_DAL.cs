using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.Commom;
using System.Data;

namespace YunXiu.DAL
{
    public class PayOrder_DAL : IPayOrder
    {
        public List<PayOrder> GetPayOrder()
        {
            var list = new List<PayOrder>();
            try
            {
                var sql = "SELECT [ID],[BuyUserID],[PayAmount],[TradeStatus],[PayType],[PayOrderNo],[Describe],[CreateUserID],[CreateDate],[LastUpdateDate],[LastUpdateUserID] FROM PayOrder";
                var dt = SQLHelper.GetTable(sql);

                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new PayOrder
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),

                        BuyUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[i]["BuyUserID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["BuyUserID"])
                        },
                        PayAmount = Convert.IsDBNull(dt.Rows[i]["PayAmount"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["PayAmount"]),
                        TradeStatus = Convert.IsDBNull(dt.Rows[i]["TradeStatus"]) ? "" : Convert.ToString(dt.Rows[i]["TradeStatus"]),
                        PayType = Convert.IsDBNull(dt.Rows[i]["PayType"]) ? "" : Convert.ToString(dt.Rows[i]["PayType"]),
                        PayOrderNo = Convert.IsDBNull(dt.Rows[i]["PayOrderNo"]) ? "" : Convert.ToString(dt.Rows[i]["PayOrderNo"]),
                        Describe = Convert.IsDBNull(dt.Rows[i]["Describe"]) ? "" : Convert.ToString(dt.Rows[i]["Describe"]),
                        CreateUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[i]["CreateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["CreateUserID"])
                        },
                        CreateDate = Convert.IsDBNull(dt.Rows[i]["Describe"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[i]["Describe"]),
                        LastUpdateDate = Convert.IsDBNull(dt.Rows[i]["LastUpdateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[i]["LastUpdateDate"]),
                        LastUpdateUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[i]["LastUpdateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["LastUpdateUserID"])
                        }
                    };
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public PayOrder GetPayOrder(int payOrderID)
        {
            PayOrder payOrder = null;
            try
            {
                var sql = "SELECT [ID],[BuyUserID],[PayAmount],[TradeStatus],[PayType],[PayOrderNo],[Describe],[CreateUserID],[CreateDate],[LastUpdateDate],[LastUpdateUserID] FROM PayOrder";
                var dt = SQLHelper.GetTable(sql);

                #region 提取数据
                if (dt.Rows.Count > 0)
                {
                    payOrder = new PayOrder
                    {
                        ID = Convert.ToInt32(dt.Rows[0]["ID"]),
                        BuyUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[0]["BuyUserID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["BuyUserID"])
                        },
                        PayAmount = Convert.IsDBNull(dt.Rows[0]["PayAmount"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["PayAmount"]),
                        TradeStatus = Convert.IsDBNull(dt.Rows[0]["TradeStatus"]) ? "" : Convert.ToString(dt.Rows[0]["TradeStatus"]),
                        PayType = Convert.IsDBNull(dt.Rows[0]["PayType"]) ? "" : Convert.ToString(dt.Rows[0]["PayType"]),
                        PayOrderNo = Convert.IsDBNull(dt.Rows[0]["PayOrderNo"]) ? "" : Convert.ToString(dt.Rows[0]["PayOrderNo"]),
                        Describe = Convert.IsDBNull(dt.Rows[0]["Describe"]) ? "" : Convert.ToString(dt.Rows[0]["Describe"]),
                        CreateUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[0]["CreateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["CreateUserID"])
                        },
                        CreateDate = Convert.IsDBNull(dt.Rows[0]["Describe"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[0]["Describe"]),
                        LastUpdateDate = Convert.IsDBNull(dt.Rows[0]["LastUpdateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[0]["LastUpdateDate"]),
                        LastUpdateUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[0]["LastUpdateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["LastUpdateUserID"])
                        }
                    };
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return payOrder;
        }

        public int CreatePayOrder(PayOrder pay)
        {
            var payOrderID = 0;

            var nowDate = DateTime.Now;
            var sql = new StringBuilder();
            sql.Append("INSERT INTO PayOrder([BuyUserID],[PayAmount],[TradeStatus],[PayType],[PayOrderNo],[Describe],[CreateDate]) ");
            sql.Append("VALUES(@BuyUserID,@PayAmount,@TradeStatus,@PayType,@PayOrderNo,@Describe,@CreateDate)  SELECT @@IDENTITY AS ID");

            var pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@BuyUserID", pay.BuyUser != null ? pay.BuyUser.UID : 0));
            pars.Add(new SqlParameter("@PayAmount", pay.PayAmount));
            pars.Add(new SqlParameter("@TradeStatus", 0));
            pars.Add(new SqlParameter("@PayType", pay.PayType));
            pars.Add(new SqlParameter("@PayOrderNo", pay.PayOrderNo));
            pars.Add(new SqlParameter("@Describe", pay.Describe));
            pars.Add(new SqlParameter("@CreateDate", nowDate));
            #region 事务
            using (SqlConnection conn = SQLHelper.GetConnection())
            {
            
                SqlTransaction myTran = conn.BeginTransaction();
                SqlCommand myCom = new SqlCommand();
                myCom.Connection = conn;
                myCom.Transaction = myTran;
                try
                {
                    myCom.CommandText = sql.ToString();
                    myCom.Parameters.AddRange(pars.ToArray());
                    payOrderID = Convert.ToInt32(myCom.ExecuteScalar());//返回支付订单号
                    if (payOrderID != 0)//订单号不为0则插入订单和支付单关系表
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("ID");
                        dt.Columns.Add("PayOrderID");
                        dt.Columns.Add("OrderID");
                        dt.Columns.Add("CreateDate");
                        dt.Columns.Add("CreateUserID");
                        dt.Columns.Add("LastUpdateDate");
                        dt.Columns.Add("LastUpdateUserID");
                        for (int i = 0; i < pay.Orders.Count; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["PayOrderID"] = pay.ID;
                            dr["OrderID"] = pay.Orders[i].OID;
                            dr["CreateDate"] = nowDate;
                            dt.Rows.Add(dr);
                        }
                        SQLHelper.BulkToDB(dt, "OrderPayOrder");
                        myTran.Commit();//如果都成功就提交
                    }
                    else
                    {
                        myTran.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    myTran.Rollback();
                }
            }
            #endregion
            return payOrderID;
        }

        public bool UdpatePayOrder(PayOrder payOrder)
        {
            var result = false;
            try
            {
                //var sql = "UPDATE PayOrder SET [TradeStatus]=@TradeStatus,[PayOrderNo]=@PayOrderNo WHERE ID=@ID";
                //var pars = new List<SqlParameter>();
                //pars.Add(new SqlParameter("@ID", payOrder.ID));
                //pars.Add(new SqlParameter("@TradeStatus", payOrder.TradeStatus));
                //pars.Add(new SqlParameter("@PayOrderNo", payOrder.PayOrderNo));
                //result = SQLHelper.ExcuteSQL(sql,pars.ToArray()) > 0;
                using (SqlConnection conn = SQLHelper.GetConnection())
                {

                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
