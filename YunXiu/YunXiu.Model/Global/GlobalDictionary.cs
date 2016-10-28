using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model.Global
{
    public class GlobalDictionary
    {
        /// <summary>
        /// 系统配置
        /// </summary>
        public static Dictionary<string, string> SysConfDictionary = new Dictionary<string, string>();

        /// <summary>
        /// 短信配置
        /// </summary>
        public static Dictionary<string, string> SMSConfDic = new Dictionary<string, string>();

        /// <summary>
        /// 邮件配置
        /// </summary>
        public static Dictionary<string, string> EmailConfDic = new Dictionary<string, string>();

        /// <summary>
        /// 获取短信配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSMSConfVal(string key)
        {
            var val = "";
            if (SMSConfDic.ContainsKey(key))
            {
                val = SMSConfDic[key];
            }
            return val;
        }

        /// <summary>
        /// 获取系统配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSysConfVal(string key)
        {
            var val = "";
            if (SysConfDictionary.ContainsKey(key))
            {
                val = SysConfDictionary[key];
            }
            return val;
        }

        /// <summary>
        /// 获取邮件配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetEmailConfVal(string key)
        {
            var val = "";
            if (EmailConfDic.ContainsKey(key))
            {
                val = SysConfDictionary[key];
            }
            return val;
        }
    }
}
