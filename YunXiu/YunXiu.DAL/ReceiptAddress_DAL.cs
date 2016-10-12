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
                sql.Append("SELECT [ID],[Addr],[ZipCode],[ConsigneeName],[ConsigneePhone],[Region],[Province],[City],[District],[Street],");
                sql.Append(string.Format("[IsDefault],[CreateDate] FROM ReceiptAddress WHERE UserID={0}", userID));
                list = DapperHelper.Query<ReceiptAddress>(sql.ToString());
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
