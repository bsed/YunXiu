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

    public class SMS_BLL
    {
        SMS_DAL dal = new SMS_DAL();

        public bool Send(SMS sms)
        {
            var result = false;
            result = dal.Send(sms);
            return result;
        }
    }
}
