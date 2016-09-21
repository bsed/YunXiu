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
    public class BuyApply_DAL : IBuyApply
    {
        public bool CreateBuyApply(BuyApply apply)
        {
            var result = false;
            try
            {
                var nowDate = DateTime.Now;
                var sql = new StringBuilder();
                sql.Append("INSERT INTO BuyApply([BuyProductID],[BuyUserID],[BuyCount],[CreateDate],[CreateUserID],[LastUpdateUserID],[LastUpdateDate]) ");
                sql.Append("VALUES(@BuyProductID,@BuyUserID,@BuyCount,@CreateDate,@CreateUserID,@LastUpdateUserID,@LastUpdateDate)");
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@BuyProductID", apply.BuyProduct != null ? apply.BuyProduct.PID : 0));
                pars.Add(new SqlParameter("@BuyUserID", apply.BuyUser != null ? apply.BuyUser.UID : 0));
                pars.Add(new SqlParameter("@BuyCount", apply.BuyCount));
                pars.Add(new SqlParameter("@CreateDate", nowDate));
                pars.Add(new SqlParameter("@CreateUserID", apply.CreateUser != null ? apply.CreateUser.UID : 0));
                pars.Add(new SqlParameter("@LastUpdateUserID", apply.LastUpdateUser != null ? apply.LastUpdateUser.UID : 0));
                pars.Add(new SqlParameter("@LastUpdateDate", nowDate));
                result = SQLHelper.ExcuteSQL(sql.ToString(), pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
