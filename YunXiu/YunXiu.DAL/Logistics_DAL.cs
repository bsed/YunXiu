using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;

namespace YunXiu.DAL
{
    public class Logistics_DAL : ILogistics
    {
        public Logistics QueryLogisticsInfo(string orderCode, string shipperCode, string logisticCode)
        {
            Logistics l = null;
            try
            {
                KdApi kd = new KdApi();
                l = JsonConvert.DeserializeObject<Logistics>(kd.getOrderTracesByJson());
            }
            catch (Exception ex)
            {

            }
            return l;
        }
    }
}
