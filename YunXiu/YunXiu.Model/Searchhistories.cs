using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 搜索历史表
    /// </summary>
    public class Searchhistories
    {
        public int recordid { get; set; }

        public int uid { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string word { get; set; }

        /// <summary>
        /// 搜索次数
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 最后一次搜索时间
        /// </summary>
        public DateTime LastSearchtime { get; set; }
    }
}
