using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 用户收货地址表
    /// </summary>
    public class Shipaddresses
    {
        /// <summary>
        /// 收货地址表ID
        /// </summary>
        public int said {get;set;}
        public int uid {get;set;}

        /// <summary>
        /// 地区ID
        /// </summary>
        public int regionid {get;set;}

        /// <summary>
        /// 是否默认
        /// </summary>
        public int isdefault {get;set;}

        /// <summary>
        /// 地址别名
        /// </summary>
        public string alias { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string consignee { get; set; }

        public string mobile { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public string zipcode { get; set; }

        public string address{get;set;}
    }
}
