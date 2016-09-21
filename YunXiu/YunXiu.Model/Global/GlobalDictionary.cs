using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model.Global
{
    public class GlobalDictionary
    {
        public static Dictionary<string, string> SysConfDictionary = new Dictionary<string, string>();

        public static Dictionary<string, string> SMSConfDic = new Dictionary<string, string>();

        public static string GetSMSConfVal(string key)
        {
            var val = "";
            if (SMSConfDic.ContainsKey(key))
            {
                val = SMSConfDic[key];
            }
            return val;
        }

        public static string GetSysConfVal(string key)
        {
            var val = "";
            if (SysConfDictionary.ContainsKey(key))
            {
                val = SysConfDictionary[key];
            }
            return val;
        }
    }
}
