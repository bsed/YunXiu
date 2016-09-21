using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;
using System.Data.SqlClient;

namespace YunXiu.DAL
{
    public class StoreStaff_DAL : IStoreStaff
    {
        public bool AddStoreStaff(StoreStaff storeStaff)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStoreStaff(int staffID)
        {
            var result = false;
            try
            { }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<StoreStaff> GetReceiveDeliveryStaff(int storeID)
        {
            List<StoreStaff> list = new List<StoreStaff>();
            try
            {
                var sql = "SELECT [ID],[StoreID],[StaffName],[Phone],[IsReceiveDelivery] FROM StoreStaff WEHER [StoreID]=@StoreID AND [IsReceiveDelivery]=1";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@StoreID", storeID));
                var dt = SQLHelper.GetTable(sql, pars.ToArray());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new StoreStaff
                    {
                        ID = Convert.IsDBNull(dt.Rows[i]["ID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ID"]),
                        Store = new Store
                        {
                            StoreID = Convert.IsDBNull(dt.Rows[i]["StoreID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["StoreID"]),
                        },
                        StaffName = Convert.IsDBNull(dt.Rows[i]["StaffName"]) ? "" : Convert.ToString(dt.Rows[i]["StaffName"]),
                        Phone = Convert.IsDBNull(dt.Rows[i]["Phone"]) ? "" : Convert.ToString(dt.Rows[i]["Phone"]),
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<StoreStaff> GetStoreStaff()
        {
            var list = new List<StoreStaff>();
            try
            {
                var sql = "SELECT [ID],[StaffName],[Phone],[IsReceiveDelivery] FROM StoreStaff ";
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<StoreStaff> GetStoreStaff(int storeID)
        {
            List<StoreStaff> list = new List<StoreStaff>();
            try
            {
                var sql = "SELECT [ID],[StoreID],[StaffName],[Phone],[IsReceiveDelivery] FROM StoreStaff WEHER [StoreID]=@StoreID";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@StoreID", storeID));
                var dt = SQLHelper.GetTable(sql, pars.ToArray());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new StoreStaff
                    {
                        ID = Convert.IsDBNull(dt.Rows[i]["ID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ID"]),
                        Store = new Store
                        {
                            StoreID = Convert.IsDBNull(dt.Rows[i]["StoreID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["StoreID"]),
                        },
                        StaffName = Convert.IsDBNull(dt.Rows[i]["StaffName"]) ? "" : Convert.ToString(dt.Rows[i]["StaffName"]),
                        Phone = Convert.IsDBNull(dt.Rows[i]["Phone"]) ? "" : Convert.ToString(dt.Rows[i]["Phone"]),
                        IsReceiveDelivery = Convert.IsDBNull(dt.Rows[i]["IsReceiveDelivery"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsReceiveDelivery"])
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool UpdateStoreStaff(StoreStaff storeStaff)
        {
            throw new NotImplementedException();
        }
    }
}
