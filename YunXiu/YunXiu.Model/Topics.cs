using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 专题
    /// </summary>
    public class Topics
    {

        public int topicid { get; set; }

        public DateTime starttime { get; set; }

        public DateTime endtime { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public int isshow { get; set; }

        /// <summary>
        /// 专题编号
        /// </summary>
        public string sn { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 头部HTML
        /// </summary>
        public string headhtml { get; set; }

        /// <summary>
        /// 主体HTML
        /// </summary>
        public string bodyhtml { get; set; }
    }
}
