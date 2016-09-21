using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class Logistics_BLL : ILogistics
    {
        Logistics_DAL dal = new Logistics_DAL();
        public Logistics QueryLogisticsInfo(string orderCode, string shipperCode, string logisticCode)
        {
            return dal.QueryLogisticsInfo(orderCode, shipperCode, logisticCode);
        }
    }
}
