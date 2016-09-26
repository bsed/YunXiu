using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商品评价表
    /// </summary>
    public class ProductReview
    {
        /// <summary>
        /// 评价ID
        /// </summary>
        public int RID { get; set; }

        /// <summary>
        /// 评价商品
        /// </summary>
        public Product RProduct { get; set; }

        /// <summary>
        /// 评价用户
        /// </summary>
        public User RUser { get; set; }

        /// <summary>
        /// 订单商品记录ID
        /// </summary>
        public Order ROrder { get; set; }


        /// <summary>
        /// 星星数
        /// </summary>
        public int Star { get; set; }

        ///// <summary>
        ///// 质量
        ///// </summary>
        //public int Quality { get; set; }

        /// <summary>
        /// 评价内容
        /// </summary>
        public string RContent { get; set; }

        /// <summary>
        /// 评价时间
        /// </summary>
        public DateTime ReviewTime { get; set; }

        /// <summary>
        /// 父级评论
        /// </summary>
        public int Parent { get; set; }

        /// <summary>
        /// 是否是店家回复
        /// </summary>
        public bool IsStoreReply { get; set; }

        /// <summary>
        /// 点赞数
        /// </summary>
        public int LikeCount { get; set; }

        /// <summary>
        /// 评论类型,1:好评,2:中评,3:差评
        /// </summary>
        public int ReviewType { get; set; }
        ///// <summary>
        ///// 支付积分
        ///// </summary>
        //public int PayCredits { get; set; }

    }
}
