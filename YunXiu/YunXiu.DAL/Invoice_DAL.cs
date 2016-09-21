using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;

namespace YunXiu.DAL
{
    public class Invoice_DAL : IInvoice
    {
        public bool CreateInvoice(Invoice invoice)
        {
            var result = false;
            try
            {
                var nowDate = DateTime.Now;
                var sql = new StringBuilder();
                sql.Append("INSERT INTO Invoice([OID],[StoreID],[ShipperCode],[LogisticCode],[CreateDate],[CreateUserID],[LastUpdateDate],[LastUpdateUserID]) ");
                sql.Append("VALUES(@OID,@StoreID,@ShipperCode,@LogisticCode,@CreateDate,@CreateUserID,@LastUpdateDate,@LastUpdateUserID) ");

                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@OID", invoice.Order != null ? invoice.Order.OID : 0));
                pars.Add(new SqlParameter("@StoreID", invoice.Store != null ? invoice.Store.StoreID : 0));
                pars.Add(new SqlParameter("@ShipperCode", invoice.ShipperCode));
                pars.Add(new SqlParameter("@LogisticCode", invoice.LogisticCode));
                pars.Add(new SqlParameter("@CreateDate", nowDate));
                pars.Add(new SqlParameter("@CreateUserID", invoice.CreateUser != null ? invoice.CreateUser.UID : 0));
                pars.Add(new SqlParameter("@LastUpdateDate", nowDate));
                pars.Add(new SqlParameter("@LastUpdateUserID", invoice.LastUpdateUser != null ? invoice.LastUpdateUser.UID : 0));

                result = SQLHelper.ExcuteSQL(sql.ToString(), pars.ToArray()) > 0;

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteInvoice(int id)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM Invoice WHERE ID={0}", id);
                result = SQLHelper.ExcuteSQL(sql) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public Invoice GetInvoiceByOrder(int oID)
        {
            Invoice invoice = null;
            try
            {
                var sql = string.Format("SELECT [ID],[OID],[StoreID],[ShipperCode],[LogisticCode],[CreateDate],[CreateUserID],[LastUpdateDate],[LastUpdateUserID] WHERE [OID] = {0}", oID);
                var dt = SQLHelper.GetTable(sql);
                if (dt.Rows.Count > 0)
                {
                    invoice = new Invoice
                    {
                        ID = Convert.ToInt32(dt.Rows[0]["ID"]),
                        Order = new Order
                        {
                            OID = Convert.IsDBNull(dt.Rows[0]["OID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["OID"])
                        },
                        Store = new Store
                        {
                            StoreID = Convert.IsDBNull(dt.Rows[0]["StoreID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["StoreID"])
                        },
                        ShipperCode = Convert.IsDBNull(dt.Rows[0]["OID"]) ? "" : Convert.ToString(dt.Rows[0]["OID"]),
                        LogisticCode = Convert.IsDBNull(dt.Rows[0]["LogisticCode"]) ? "" : Convert.ToString(dt.Rows[0]["LogisticCode"]),
                        CreateDate = Convert.IsDBNull(dt.Rows[0]["CreateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[0]["CreateDate"]),
                        CreateUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[0]["CreateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["CreateUserID"])
                        },
                        LastUpdateDate = Convert.IsDBNull(dt.Rows[0]["LastUpdateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[0]["LastUpdateDate"]),
                        LastUpdateUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[0]["LastUpdateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["LastUpdateUserID"])
                        }
                    };
                }
            }
            catch (Exception ex)
            {

            }
            return invoice;
        }

        public List<Invoice> GetInvoiceByStore(int storeID)
        {
            List<Invoice> list = new List<Invoice>();
            try
            {
                var sql = string.Format("SELECT [ID],[OID],[StoreID],[ShipperCode],[LogisticCode],[CreateDate],[CreateUserID],[LastUpdateDate],[LastUpdateUserID] WHERE [OID] = {0}");
                var dt = SQLHelper.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var invoice = new Invoice
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                        Order = new Order
                        {
                            OID = Convert.IsDBNull(dt.Rows[i]["OID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["OID"])
                        },
                        Store = new Store
                        {
                            StoreID = Convert.IsDBNull(dt.Rows[i]["StoreID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["StoreID"])
                        },
                        ShipperCode = Convert.IsDBNull(dt.Rows[i]["OID"]) ? "" : Convert.ToString(dt.Rows[i]["OID"]),
                        LogisticCode = Convert.IsDBNull(dt.Rows[i]["LogisticCode"]) ? "" : Convert.ToString(dt.Rows[i]["LogisticCode"]),
                        CreateDate = Convert.IsDBNull(dt.Rows[i]["CreateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[i]["CreateDate"]),
                        CreateUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[i]["CreateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["CreateUserID"])
                        },
                        LastUpdateDate = Convert.IsDBNull(dt.Rows[i]["LastUpdateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[i]["LastUpdateDate"]),
                        LastUpdateUser = new User
                        {
                            UID = Convert.IsDBNull(dt.Rows[i]["LastUpdateUserID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["LastUpdateUserID"])
                        }
                    };
                    list.Add(invoice);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool UpdateInvoice(Invoice invoice)
        {
            var result = false;
            try
            {

                var sql = "UPDATE Invoice SET [OID]=@OID,[ShipperCode]=@ShipperCode,[LogisticCode]=@LogisticCode,[LastUpdateDate]=@LastUpdateDate,[LastUpdateUserID]=@LastUpdateUserID";

                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@OID", invoice.ID));
                pars.Add(new SqlParameter("@ShipperCode", invoice.ShipperCode));
                pars.Add(new SqlParameter("@LogisticCode", invoice.LogisticCode));
                pars.Add(new SqlParameter("@LastUpdateDate", DateTime.Now));
                pars.Add(new SqlParameter("@LastUpdateUserID", invoice.LastUpdateUser != null ? invoice.LastUpdateUser.UID : 0));

                result = SQLHelper.ExcuteSQL(sql, pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
