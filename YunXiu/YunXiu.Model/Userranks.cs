using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 用户等级表
    /// </summary>
    public class UserRanks
    {
        #region 属性

        /// <summary>
        /// 用户等级id
        /// </summary>
        public int UserRid { get; set; }

        /// <summary>
        /// 是否为系统等级
        /// </summary>
        public int System { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 积分下限
        /// </summary>
        public int CreditsLower { get; set; }

        /// <summary>
        /// 积分上限
        /// </summary>
        public int CreditsUpper { get; set; }

        /// <summary>
        /// 限制天数
        /// </summary>
        public int LimitDays { get; set; }
        #endregion
    }
}
