using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 套装商品表
    /// </summary>
    public class Suitproducts
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public int recordid { get; set; }

        /// <summary>
        /// 促促销活动ID
        /// </summary>
        public int pmid { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int pid { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public int discount { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public int number { get; set; }
    }
}
