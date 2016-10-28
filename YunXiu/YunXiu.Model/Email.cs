using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class Email
    {
        /// <summary>
        /// 收件人
        /// </summary>
        public List<string> MailTo { get; set; }

        /// <summary>
        /// 抄送
        /// </summary>
        public List<string> MailCc { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string MailSubject { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string MailBody { get; set; }

        /// <summary>
        /// 正文是否是html格式
        /// </summary>
        public bool IsbodyHtml { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public Dictionary<string, byte[]> Attachments { get; set; }
    }
}
