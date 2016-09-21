using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class ReceiptAddress:Base
    {
        public int ID { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Addr { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// 联系人名字
        /// </summary>
        public string ConsigneeName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ConsigneePhone { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public int Region { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public int Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public int City { get; set; }
        /// <summary>
        /// 城区
        /// </summary>
        public int District { get; set; }
        /// <summary>
        /// 街道
        /// </summary>
        public int Street { get; set; }
        /// <summary>
        /// 是否为默认收货地址
        /// </summary>
        public bool IsDefault { get; set; }

    }
}
