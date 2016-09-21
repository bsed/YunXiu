using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 提款申请
    /// </summary>
    public class WithdrawalsApply:Base
    {
        public int ID { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public User ApplyUser { get; set; }

        //申请金额
        public decimal ApplyAmount { get; set; }

        /// <summary>
        /// 申请状态
        /// </summary>
        public int ApplyStatus { get; set; }

        /// <summary>
        /// 批准人
        /// </summary>
        public User ApproversUser { get; set; }
    }
}
