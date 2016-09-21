using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using YunXiu.Interface;
using YunXiu.Commom;
using YunXiu.Model;

namespace YunXiu.DAL
{
    public class ProductStorage_DAL : IProductStorage
    {
        public bool AddProductStorage(ProductStorage productStorage)
        {
            var result = false;
            try
            {
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@productID", productStorage.Product.PID));
                pars.Add(new SqlParameter("@number", productStorage.Number));
                pars.Add(new SqlParameter("@userID", productStorage.CreateUser.UID));
                result = SQLHelper.ExcuteProc("[AddProductStorage]", pars.ToArray()) == 1;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
