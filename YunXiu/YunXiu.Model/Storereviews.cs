using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 店铺评价表
    /// </summary>
    public class Storereviews
    {

        public int reviewid {get;set;}

        /// <summary>
        /// 订单ID
        /// </summary>
        public int oid {get;set;}

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int storeid {get;set;}

        /// <summary>
        /// 商品描述 星星数
        /// </summary>
        public int descriptionstar {get;set;}

        /// <summary>
        /// 服务评价星星数
        /// </summary>
        public int servicestar {get;set;}

        /// <summary>
        /// 配送评价 星星数
        /// </summary>
        public int shipstar {get;set;}

        /// <summary>
        /// 用户ID
        /// </summary>
        public int uid {get;set;}

        /// <summary>
        /// 评价时间
        /// </summary>
        public DateTime reviewtime {get;set;}


        public string ip{get;set;}
    }
}
