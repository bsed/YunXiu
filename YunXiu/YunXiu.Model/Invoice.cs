using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class Invoice : Base
    {
        public int ID { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// 商铺
        /// </summary>
        public Store Store { get; set; }

        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }

        /// <summary>
        /// 物流单号
        /// </summary>
        public string LogisticCode { get; set; }
    }
}
