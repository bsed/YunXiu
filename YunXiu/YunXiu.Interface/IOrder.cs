using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IOrder
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="orders">订单集合</param>
        /// <returns>是否创建成功</returns>
        bool CreateOrder(List<Order> orders);
        /// <summary>
        /// 获取用户订单信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>订单集合</returns>
        List<Order> GetOrderByUser(int userID);

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="oID">订单ID</param>
        /// <returns></returns>
        Order GetOrder(int oID);

        bool UpdateOrder(Order order);

    }
}
