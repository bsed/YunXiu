using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 留言板
    /// </summary>
    public class MessageTb:Base
    {

        public int Mid { get; set; }


        public string Title { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string MessageBody { get; set; }

        /// <summary>
        /// 消息发送给用户UID
        /// </summary>
        public int MessageToUId { get; set; }


        

        /// <summary>
        /// 附件
        /// </summary>
        public string Attachment { get; set; }

        /// <summary>
        /// 发件人是否删除标识（1：删除，0：没删除）
        /// </summary>
        public int DeleteFlag { get; set; }

        /// <summary>
        /// 是否为回复的消息（1：是，0：否）
        /// </summary>
        public int IsReply { get; set; }

        /// <summary>
        /// 回复的消息MID
        /// </summary>
        public int PMid { get; set; }


        public int CreateUid { get; set; }

        public int LastUpdateUId { get; set; }

    }
}
