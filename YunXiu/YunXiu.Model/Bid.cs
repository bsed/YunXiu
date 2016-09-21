using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 竞标
    /// </summary>
    public class Bid : Base
    {
        public int ID { get; set; }

        public Store BStore { get; set; }

        /// <summary>
        /// 标书
        /// </summary>
        public Tender Tender { get; set; }

        public decimal BidPrice { get; set; }

        /// <summary>
        /// 竞标书
        /// </summary>
        public string BigBook { get; set; }
    }
}
