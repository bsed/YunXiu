using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class OrderPayOrder_BLL : IOrderPayOrder
    {
        OrderPayOrder_DAL dal = new OrderPayOrder_DAL();

        public bool CreateOrderPayOrder(PayOrder payOrder)
        {
            return dal.CreateOrderPayOrder(payOrder);
        }

        public List<Order> GetOrderByPayOrder(int payOrderID)
        {
            return dal.GetOrderByPayOrder(payOrderID);
        }

        public PayOrder GetPayOrderByOrder(int orderID)
        {
            return dal.GetPayOrderByOrder(orderID);
        }
    }
}
