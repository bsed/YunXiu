using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class Order : Base
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OSN { get; set; } = "";
        /// <summary>
        /// 购买用户
        /// </summary>
        public User BuyUser { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderState { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int BuyNumber { get; set; } = 0;

        /// <summary>
        /// 订单提交时单价
        /// </summary>
        public decimal BuyUnitPrice { get; set; } = 0;

        /// <summary>
        /// 购买产品
        /// </summary>
        public Product BuyProduct { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public ReceiptAddress ReceiptAddress { get; set; }

        
    }

}
