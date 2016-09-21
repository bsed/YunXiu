using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IStoreUser
    {
        /// <summary>
        /// 添加商铺会员
        /// </summary>
        /// <param name="storeID"></param>
        /// <param name="userId"></param>
        /// <returns>是否删除成功</returns>
        bool AddStoreUser(int storeID, int userID);

        /// <summary>
        /// 删除商铺会员
        /// </summary>
        /// <param name="storeID"></param>
        /// <param name="userID"></param>
        /// <returns>是否删除成功</returns>
        bool DeleteStoreUser(int storeID, int userID);

        /// <summary>
        /// 获取商铺的会员
        /// </summary>
        /// <param name="storeID">商铺ID</param>
        /// <returns></returns>
        List<StoreUser> GetStoreUserByStore(int storeID);

        /// <summary>
        /// 获取有该会员的商铺
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        List<StoreUser> GetStoreByUser(int userID);

    }
}
