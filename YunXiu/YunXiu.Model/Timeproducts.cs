using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 定时商品表
    /// </summary>
    public class Timeproducts
    {
        public int recordid { get; set; }

        public int pid { get; set; }

        public int storeid { get; set; }

        /// <summary>
        /// 上架状态(0：无需上架，1：等待执行上架操作，2已执行上架操作)
        /// 什么鬼
        /// </summary>
        public int onsalestate { get; set; }

        /// <summary>
        /// 下架状态（0：无需下架，1：等待执行下架，2：已执行下架操作）
        /// 什么鬼
        /// </summary>
        public int outsalestate { get; set; }
        
        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime onsaletime { get; set; }


        public DateTime outsaletime { get; set; }
    }
}
