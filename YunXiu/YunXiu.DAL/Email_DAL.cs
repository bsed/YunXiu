using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Model.Global;
using YunXiu.Commom;

namespace YunXiu.DAL
{
    public class Email_DAL : IEmail
    {
        public bool Send(Email email)
        {
            var result = false;
            YunXiu.Commom.Email.SMTPEmail service = new Commom.Email.SMTPEmail();
            service.Attachments = email.Attachments;
            service.Host = GlobalDictionary.GetEmailConfVal("Host");
            service.IsbodyHtml = email.IsbodyHtml;
            service.MailBody = email.MailBody;
            service.MailCc = email.MailCc;
            service.MailFrom = GlobalDictionary.GetEmailConfVal("MailFrom") ;
            service.MailPwd = GlobalDictionary.GetEmailConfVal("MailPwd");
            service.MailTo = email.MailTo;
            result = service.Send();
            return result;
        }
    }
}
