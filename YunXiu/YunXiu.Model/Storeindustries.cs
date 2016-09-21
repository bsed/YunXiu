using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 店铺行业表
    /// </summary>
    public class Storeindustries
    {
        /// <summary>
        /// 行业ID
        /// </summary>
        public int storeiid { get; set; }


        public string title { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int displayorder { get; set; }
    }
}
