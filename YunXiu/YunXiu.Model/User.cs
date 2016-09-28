using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace YunXiu.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User : Base
    {
        #region 属性

        /// <summary>
        /// 用户id
        /// </summary>
        public int UID { get; set; }

        /// <summary>
        /// 基本用户信息
        /// </summary>
        public TFUser TFUser { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户等级id
        /// </summary>
        public int UserRID { get; set; }

        /// <summary>
        /// 商城管理员组id
        /// </summary>
        public int MallaGID { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 支付积分
        /// </summary>
        public int PayCredits { get; set; }

        /// <summary>
        /// 等级积分
        /// </summary>
        public int RankCredits { get; set; }

        /// <summary>
        /// 是否验证邮箱
        /// </summary>
        public bool IsVerifyEmail { get; set; }

        /// <summary>
        /// 是否验证手机
        /// </summary>
        public bool IsVerifyMobile { get; set; }

        /// <summary>
        /// 解禁时间
        /// </summary>
        public DateTime LiftBanTime { get; set; }

        /// <summary>
        /// 盐值
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? AccountClientGuid { get; set; }

        /// <summary>
        /// 用户管理商铺
        /// </summary>
        public Store UStore { get; set; }
        #endregion
    }
}
