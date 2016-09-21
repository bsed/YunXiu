using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 店铺操作记录表
    /// </summary>
    public class Storeadminlogs
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public int logid { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int uid { get; set; }

        /// <summary>
        /// 操作用户名称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int storeid { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string storename { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        public string operation { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }


        public string ip { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime operatetime { get; set; }
    }
}
