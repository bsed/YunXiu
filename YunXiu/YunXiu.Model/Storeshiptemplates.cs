using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 店铺配送模板表
    /// </summary>
    public class Storeshiptemplates
    {
        /// <summary>
        /// 店铺配送模板ID
        /// </summary>
        public int storestid { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int storeid { get; set; }

        /// <summary>
        /// 是否免运费
        /// </summary>
        public int free { get; set; }

        /// <summary>
        /// 计费类型（0：按件收费，1：按重量收费）
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 配送模板名称
        /// </summary>
        public string title { get; set; }
    }
}
