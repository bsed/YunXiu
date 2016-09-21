using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 登陆失败日志表
    /// </summary>
    public class Loginfaillogs
    {
        public int id {get;set;}

        public int loginip {get;set;}

        /// <summary>
        /// 失败次数
        /// </summary>
        public int failtimes {get;set;}

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime lastlogintime { get; set; }

        
    }
}
