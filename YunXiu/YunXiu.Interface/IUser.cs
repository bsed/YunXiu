using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IUser
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="Item">用户类</param>
        /// <returns></returns>
        int InsertUser(User Item);


        /// <summary>
        /// 根据UID取得用户
        /// </summary>
        /// <param name="Uid">用户ID</param>
        /// <returns></returns>
        User GetUserByUid(int Uid);


        /// <summary>
        /// 根据Account_ClientGuid取得用户信息
        /// </summary>
        /// <param name="Account_ClientGuid"></param>
        /// <returns></returns>
        User GetPartUserByAccountID(Guid Account_ClientGuid);


        /// <summary>
        /// 根据用户ID取得用户部分信息
        /// </summary>
        /// <param name="Uid">用户ID</param>
        /// <returns></returns>
        Userdetails GetUserDetailsByUid(int Uid);


        /// <summary>
        /// 更新用户等级
        /// </summary>
        /// <param name="Uid">用户ID</param>
        /// <param name="UserRid">用户等级ID</param>
        /// <returns></returns>
        int UpdateUserRankByUid(int Uid, int UserRid);


        /// <summary>
        /// 更新用户解禁时间
        /// </summary>
        /// <param name="Uid">用户ID</param>
        /// <param name="liftBanTime">解禁时间</param>
        /// <returns></returns>
        int UpdateUserLiftBanTimeByUid(int Uid, DateTime liftBanTime);

        /// <summary>
        /// 更新用户在线时间
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="OnlieTime"></param>
        /// <returns></returns>
        int UpdateUserOnlineTime(int Uid, int OnlieTime);


        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        int UpdatePartUser(User Item);


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        int ChangePwd(int Uid, string Pwd);

        /// <summary>
        /// 修改邮箱
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        int UpdateUserEmailByUid(int Uid, string email);

        /// <summary>
        /// 更新手机
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        int UpdateUserMobileByUid(int Uid, string mobile);

        bool UpdateVerifyMobileState(int uID, bool isVerifyMobile);

        bool UpdateVerifyEmailState(int uID, bool isVerifyEmail);

    }
}
