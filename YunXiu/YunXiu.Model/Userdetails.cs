using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 用户明细表
    /// </summary>
    public class Userdetails
    {
        public int uid { get; set; }

        public DateTime lastvisittime { get; set; }

        public string lastvisitip { get; set; }

        /// <summary>
        /// 最后访问区域ID
        /// </summary>
        public int lastvisitrgid { get; set; }


        public DateTime registertime { get; set; }

        public string registerip { get; set; }

        /// <summary>
        /// 注册区域ID
        /// </summary>
        public int registerrgid { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int gender { get; set; }

        public string realname { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string bday { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string idcard { get; set; }

        /// <summary>
        /// 所在区域
        /// </summary>
        public int regionid { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string address { get; set; }


        /// <summary>
        /// 简介
        /// </summary>
        public string bio { get; set; }

    }
}
