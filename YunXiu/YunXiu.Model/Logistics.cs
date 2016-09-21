using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 物流
    /// </summary>
    public class Logistics
    {
        public int ID { get; set; }

        public string EBusinessID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }

        /// <summary>
        /// 物流单号
        /// </summary>
        public string LogisticCode { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 物流状态：2-在途中,3-签收,4-问题件
        /// </summary>
        public string State { get; set; }

        public List<Trace> Traces { get; set; }
    }
}
