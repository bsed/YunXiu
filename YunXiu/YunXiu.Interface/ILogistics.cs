using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface ILogistics
    {
        Logistics QueryLogisticsInfo(string orderCode,string shipperCode,string logisticCode);
    }
}
