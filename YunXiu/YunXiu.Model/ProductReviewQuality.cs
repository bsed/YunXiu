using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商品评价质量表
    /// </summary>
    public class ProductReviewQuality
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int Uid { get; set; }

        /// <summary>
        /// 投票时间
        /// </summary>
        public DateTime VoteTime { get; set; }
    }
}
