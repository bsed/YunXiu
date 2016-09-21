using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IUserRanks
    {
        /// <summary>
        /// 根据积分取得等级信息
        /// </summary>
        /// <param name="Credit">积分</param>
        /// <returns></returns>
        UserRanks GetUserRankByCredits(int Credit);


        /// <summary>
        /// 所有的积分等级
        /// </summary>
        /// <returns></returns>
        List<UserRanks> GetUserRankList();


        /// <summary>
        /// 添加用户等级
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        int AddUserRank(UserRanks Item);


        /// <summary>
        /// 删除用户等级
        /// </summary>
        /// <param name="UserRid"></param>
        /// <returns></returns>
        int DelelteUserRank(int UserRid);


        /// <summary>
        /// 更新用户等级
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        int UpdateUserRank(UserRanks Item);


        /// <summary>
        /// 根据用户ID取得用户等级信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        UserRanks GetUserRankInfoByUid(int Uid);

    }
}
