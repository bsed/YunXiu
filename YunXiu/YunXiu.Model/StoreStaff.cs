using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class StoreStaff : Base
    {
        public int ID { get; set; }

        /// <summary>
        /// 店铺
        /// </summary>
        public Store Store { get; set; }

        /// <summary>
        /// 店铺员工名
        /// </summary>
        public string StaffName { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 是否接收发货信息
        /// </summary>
        public bool IsReceiveDelivery { get; set; }
    }
}
