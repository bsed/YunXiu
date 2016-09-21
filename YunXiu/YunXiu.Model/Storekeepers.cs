using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 店长表
    /// </summary>
    public class Storekeepers
    {
        /// <summary>
        /// 店铺ID
        /// </summary>
        public int storeid { get; set; }
        
        /// <summary>
        /// 类型（0：个人，1：公司）
        /// </summary>
        public int type { get; set; }

        public string name { get; set; }

        /// <summary>
        /// 标识码
        /// </summary>
        public string idcard { get; set; }

        public string address { get; set; }
    }

}
