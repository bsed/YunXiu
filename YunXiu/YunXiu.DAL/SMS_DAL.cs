using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Model.Global;

namespace YunXiu.DAL
{
   public class SMS_DAL
    {

        public bool Send(SMS sms)
        {
            var result = false;
            var providerName = GlobalDictionary.GetSMSConfVal("ProviderName");
            ISMS i = (ISMS)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(string.Format("YunXiu.Commom.SMS.{0}", providerName), false);//通过反射创建实例
            result = i.Send(sms.Phones, sms.Content);
            return result;
        }
    }
}
