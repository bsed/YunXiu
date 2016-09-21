using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 购买申请
    /// </summary>
    public class BuyApply : Base
    {
        public int ID { get; set; }

        /// <summary>
        /// 购买产品
        /// </summary>
        public Product BuyProduct { get; set; }

        /// <summary>
        /// 购买用户
        /// </summary>
        public User BuyUser { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int BuyCount { get; set; }
    }
}
