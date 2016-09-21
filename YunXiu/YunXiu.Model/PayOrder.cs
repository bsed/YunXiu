using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class PayOrder : Base
    {
        public int ID { get; set; }

        public List<Order> Orders { get; set; }

        public User BuyUser { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PayAmount { get; set; } = 0;

        /// <summary>
        /// 交易状态
        /// </summary>
        public string TradeStatus { get; set; } = "";

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayType { get; set; } = "";

        /// <summary>
        /// 支付订单号
        /// </summary>
        public string PayOrderNo { get; set; } = "";

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; } = "";

    }
}
