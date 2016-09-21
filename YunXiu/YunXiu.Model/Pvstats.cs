using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// PV统计表
    /// </summary>
    public class Pvstats
    {
        public int recordid { get; set; }

        public int storeid { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string category { get; set; }

        /// <summary>
        /// 分类值
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int count { get; set; }
    }
}
