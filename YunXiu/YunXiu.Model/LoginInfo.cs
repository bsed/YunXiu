using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        /// -1用户不存在,0为账号或密码错误,1为登录成功
        /// </summary>
        public int LoginState { get; set; }

        public User User { get; set; }
    }
}
