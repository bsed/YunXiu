using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.DAL;
using YunXiu.Interface;

namespace YunXiu.BLL
{
    public class VisitorBrowse_BLL : IVisitorBrowse
    {
        VisitorBrowse_DAL dal = new VisitorBrowse_DAL();
        public bool AddVisitorBrowse(List<VisitorBrowse> list)
        {
            return dal.AddVisitorBrowse(list);
        }

        public int GetPV(DateTime startDate, DateTime endDate)
        {
            return dal.GetPV(startDate, endDate);
        }

        public int GetUV(DateTime startDate, DateTime endDate)
        {
            return dal.GetUV(startDate,endDate);
        }
    }
}
