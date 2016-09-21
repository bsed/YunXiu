using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IOrderPayOrder
    {
        /// <summary>
        /// 根据付款单获取订单
        /// </summary>
        /// <returns></returns>
        List<Order> GetOrderByPayOrder(int payOrderID);

        /// <summary>
        /// 根据订单获取付款单
        /// </summary>
        /// <returns></returns>
        PayOrder GetPayOrderByOrder(int orderID);

        bool CreateOrderPayOrder(PayOrder payOrder);  
    }
}
