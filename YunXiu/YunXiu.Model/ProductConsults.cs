using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商品咨询表
    /// </summary>
    public class ProductConsults
    {
        public int ConsultId { get; set; }
        public int Pid { get; set; }

        /// <summary>
        /// 咨询类型
        /// </summary>
        public int ConsultTypeId { get; set; }
        public int State { get; set; }
        /// <summary>
        /// 咨询用户ID
        /// </summary>
        public int ConsultUid { get; set; }

        /// <summary>
        /// 回复用户ID
        /// </summary>
        public int ReplyUid { get; set; }
        public int StoreId { get; set; }
        /// <summary>
        /// 咨询时间
        /// </summary>
        public DateTime ConsultTime { get; set; }

        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime ReplyTime { get; set; }

        /// <summary>
        /// 咨询内容
        /// </summary>
        public string ConsultMessage { get; set; }

        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyMessage { get; set; }

        /// <summary>
        /// 咨询人名称
        /// </summary>
        public string ConsultNickName { get; set; }

        /// <summary>
        /// 回复者名称
        /// </summary>
        public string ReplyNickName { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string PName { get; set; }
        public string PImgID { get; set; }
        public string ConsultIp { get; set; }
        public string ReplyIp { get; set; }
    }
}
