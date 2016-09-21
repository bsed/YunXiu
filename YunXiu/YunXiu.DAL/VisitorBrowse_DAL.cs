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
    public class VisitorBrowse_DAL : IVisitorBrowse
    {
        public bool AddVisitorBrowse(List<VisitorBrowse> list)
        {
            var result = false;
            try
            {
              
            }
            catch (Exception ex)
            {

            }
            return result;
        }


        public int GetPV(DateTime startDate, DateTime endDate)
        {
            var pv = 0;
            try
            {
                var sql = "SELECT COUNT(*) FROM VisitorBrowse WHERE [CreateDate]>=@startDate AND [CreateDate]<=@endDate";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@startDate", startDate));
                pars.Add(new SqlParameter("@endDate", endDate));
                var dt = SQLHelper.GetTable(sql);
                if (dt.Rows.Count > 0)
                {
                    pv = Convert.ToInt32(dt.Rows[0][0]);
                }
            }
            catch (Exception ex)
            { }
            return pv;
        }

        public int GetUV(DateTime startDate, DateTime endDate)
        {
            var uv = 0;
            try
            {
                var sql = "SELECT COUNT(DISTINCT [IP]) FROM VisitorBrowse WHERE CreateDate>='2016-08-09' AND CreateDate<'2016-08-10'";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@startDate", startDate));
                pars.Add(new SqlParameter("@endDate", endDate));
                var dt = SQLHelper.GetTable(sql);
                if (dt.Rows.Count > 0)
                {
                    uv = Convert.ToInt32(dt.Rows[0][0]);
                }
            }
            catch (Exception ex)
            { }
            return uv;
        }
    }
}
