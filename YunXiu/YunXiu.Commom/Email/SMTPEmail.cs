using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Commom.Email
{
    public class SMTPEmail
    {
        /// <summary>
        /// 发送者
        /// </summary>
        public string MailFrom { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        public List<string> MailTo{ get; set; }

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
        /// 发件人密码
        /// </summary>
        public string MailPwd { get; set; }

        /// <summary>
        /// SMTP邮件服务器
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 正文是否是html格式
        /// </summary>
        public bool IsbodyHtml { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public string[] attachmentsPath { get; set; }

        public Dictionary<string, byte[]> Attachments { get; set; }

        public bool Send()
        {
            //使用指定的邮件地址初始化MailAddress实例
            MailAddress maddr = new MailAddress(MailFrom);
            //初始化MailMessage实例
            MailMessage myMail = new MailMessage();


            //向收件人地址集合添加邮件地址
            if (MailTo != null)
            {
                for (int i = 0; i < MailTo.Count; i++)
                {
                    myMail.To.Add(MailTo[i]);
                }
            }

            //向抄送收件人地址集合添加邮件地址
            if (MailCc != null)
            {
                for (int i = 0; i < MailCc.Count; i++)
                {
                    myMail.CC.Add(MailCc[i]);
                }
            }
            //发件人地址
            myMail.From = maddr;

            //电子邮件的标题
            myMail.Subject = MailSubject;

            //电子邮件的主题内容使用的编码
            myMail.SubjectEncoding = Encoding.UTF8;

            //电子邮件正文
            myMail.Body = MailBody;

            //电子邮件正文的编码
            myMail.BodyEncoding = Encoding.Default;

            myMail.Priority = MailPriority.High;

            myMail.IsBodyHtml = IsbodyHtml;

            //在有附件的情况下添加附件
            try
            {
                if (Attachments.Count != 0)
                {
                    Attachment attachFile = null;
                    foreach (var dic in Attachments)
                    {
                        attachFile = new Attachment(CommomClass.BytesToStream(dic.Value), dic.Key);
                        myMail.Attachments.Add(attachFile);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("在添加附件时有错误:" + err);
            }

            SmtpClient smtp = new SmtpClient();
            //指定发件人的邮件地址和密码以验证发件人身份
            smtp.Credentials = new System.Net.NetworkCredential(MailFrom, MailPwd);


            //设置SMTP邮件服务器
            smtp.Host = Host;

            try
            {
                //将邮件发送到SMTP邮件服务器
                smtp.Send(myMail);
                return true;

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }

        }
    }
}
