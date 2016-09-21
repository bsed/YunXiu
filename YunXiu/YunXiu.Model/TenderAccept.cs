using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 接收的标书
    /// </summary>
   public class TenderAccept:Base
    {
        public int AID { get; set; }

       
        public Bid AcceptBidID { get; set; }

        /// <summary>
        /// 投标商铺
        /// </summary>
        public Store AcceptStore { get; set; }

        /// <summary>
        /// 接收标书
        /// </summary>
        public Tender AcceptTender{ get; set; }
    }
}
