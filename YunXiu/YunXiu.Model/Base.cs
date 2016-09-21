using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YunXiu.Model
{
    public class Base
    {
        #region 属性
        /// <summary>
        /// 创建日期
        /// </summary>
        public Nullable<DateTime> CreateDate { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public User CreateUser { get; set; }
        /// <summary>
        /// 最后修改用户
        /// </summary>
        public User LastUpdateUser { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public Nullable<DateTime> LastUpdateDate { get; set; }

        #endregion
    }
}
