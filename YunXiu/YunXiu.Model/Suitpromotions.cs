using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 套装促销活动表
    /// </summary>
    public class Suitpromotions
    {
        public int pmid { get; set; }

        public int storeid { get; set; }

        public DateTime starttime1 { get; set; }

        public DateTime endtime1 { get; set; }

        public DateTime starttime2 { get; set; }

        public DateTime endtime2 { get; set; }

        public DateTime starttime3 { get; set; }

        public DateTime endtime3 { get; set; }

        /// <summary>
        /// 用户最低等级
        /// </summary>
        public int userranklower { get; set; }

        public int state { get; set; }

        public string name { get; set; }


        /// <summary>
        /// 配额上限
        /// </summary>
        public int quotaupper { get; set; }

        /// <summary>
        /// 限购1次
        /// </summary>
        public int onlyonce { get; set; }
    }
}
