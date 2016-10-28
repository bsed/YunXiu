using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.DAL;
using YunXiu.Model;

namespace YunXiu.BLL
{
    public class Email_BLL : IEmail
    {
        Email_DAL dal = new Email_DAL();
        public bool Send(Email email)
        {
            return dal.Send(email);
        }
    }
}
