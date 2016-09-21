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
    public class ReceiptAddress_DAL : IReceiptAddress
    {
        public bool AddReceiptAddress(ReceiptAddress receiptAddress)
        {
            var result = false;
            try
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO ReceiptAddress([User],[Addr],[ZipCode],[ConsigneeName],[ConsigneePhone],[Region],[Province],");
                sql.Append("[City],[District],[Street],[IsDefault],[CreateDate],[CreateUser],[LastUpdateUser],[LastUpdateDate])  ");
                sql.Append("VALUES(@User,@Addr,@ZipCode,@ConsigneeName,@ConsigneePhone,@Region,@Province,@City,@District,@Street,@IsDefault,@CreateDate,@CreateUser,@LastUpdateUser,@LastUpdateDate)");
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@User", receiptAddress.User != null ? receiptAddress.User.UID : 0));
                pars.Add(new SqlParameter("@Addr", receiptAddress.Addr));
                pars.Add(new SqlParameter("@ZipCode", receiptAddress.ZipCode));
                pars.Add(new SqlParameter("@ConsigneeName", receiptAddress.ConsigneeName));
                pars.Add(new SqlParameter("@ConsigneePhone", receiptAddress.ConsigneePhone));
                pars.Add(new SqlParameter("@Region", receiptAddress.Region));
                pars.Add(new SqlParameter("@Province", receiptAddress.Province));
                pars.Add(new SqlParameter("@District", receiptAddress.District));
                pars.Add(new SqlParameter("@Street", receiptAddress.Street));
                pars.Add(new SqlParameter("@IsDefault", receiptAddress.IsDefault));
                pars.Add(new SqlParameter("@CreateDate", receiptAddress.CreateDate));
                pars.Add(new SqlParameter("@CreateUser", receiptAddress.CreateUser.UID));
                pars.Add(new SqlParameter("@LastUpdateDate", receiptAddress.LastUpdateDate));
                result = SQLHelper.ExcuteSQL(sql.ToString(), pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteReceiptAddress(int id)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM ReceiptAddress WHERE ID={0}", id);
                result = SQLHelper.ExcuteSQL(sql) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ReceiptAddress> GetReceiptAddress(int userID)
        {
            var list = new List<ReceiptAddress>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT [User],[Addr],[ZipCode],[ConsigneeName],[ConsigneePhone],[Region],[Province],[City],[District],[Street],");
                sql.Append(string.Format("[IsDefault],[CreateDate],[CreateUser] FROM ReceiptAddress WHERE USER={0}", userID));

                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new ReceiptAddress
                    {
                        User = new User { },
                        Addr = Convert.IsDBNull(dt.Rows[i]["Addr"]) ? "" : Convert.ToString(dt.Rows[i]["Addr"]),
                        ZipCode = Convert.IsDBNull(dt.Rows[i]["ZipCode"]) ? "" : Convert.ToString(dt.Rows[i]["ZipCode"]),
                        ConsigneeName = Convert.IsDBNull(dt.Rows[i]["ConsigneeName"]) ? "" : Convert.ToString(dt.Rows[i]["ConsigneeName"]),
                        ConsigneePhone = Convert.IsDBNull(dt.Rows[i]["Addr"]) ? "" : Convert.ToString(dt.Rows[i]["Addr"]),
                        Region = Convert.IsDBNull(dt.Rows[i]["Region"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Region"]),
                        Province = Convert.IsDBNull(dt.Rows[i]["Province"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Province"]),
                        City = Convert.IsDBNull(dt.Rows[i]["City"]) ? 0 : Convert.ToInt32(dt.Rows[i]["City"]),
                        District = Convert.IsDBNull(dt.Rows[i]["District"]) ? 0 : Convert.ToInt32(dt.Rows[i]["District"]),
                        Street = Convert.IsDBNull(dt.Rows[i]["Street"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Street"]),
                        IsDefault = Convert.IsDBNull(dt.Rows[i]["IsDefault"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsDefault"]),
                        CreateDate = Convert.IsDBNull(dt.Rows[i]["CreateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[i]["CreateDate"]),
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

        public bool UpdateReceiptAddress(ReceiptAddress receiptAddress)
        {
            var result = false;
            try
            {
                var sql = new StringBuilder();
                sql.Append("UPDATE ReceiptAddress SET [Addr]=@Addr,[ZipCode]=@ZipCode,[ConsigneeName]=@ConsigneeName,[ConsigneePhone]=@ConsigneePhone,");
                sql.Append("[Region]=@Region,[Province]=@Province,[City]=@City,[District]=@District,[Street]=@Street,[IsDefault]=@IsDefault WHERE ID=@ID");
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@ID", receiptAddress.ID));
                pars.Add(new SqlParameter("@Addr", receiptAddress.Addr));
                pars.Add(new SqlParameter("@ZipCode", receiptAddress.ZipCode));
                pars.Add(new SqlParameter("@ConsigneeName", receiptAddress.ConsigneeName));
                pars.Add(new SqlParameter("@ConsigneePhone", receiptAddress.ConsigneePhone));
                pars.Add(new SqlParameter("@Region", receiptAddress.Region));
                pars.Add(new SqlParameter("@Province", receiptAddress.Province));
                pars.Add(new SqlParameter("@City", receiptAddress.City));
                pars.Add(new SqlParameter("@District", receiptAddress.District));
                pars.Add(new SqlParameter("@Street", receiptAddress.Street));
                pars.Add(new SqlParameter("@IsDefault", receiptAddress.IsDefault));
                result = SQLHelper.ExcuteSQL(sql.ToString(), pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
