using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.DAL;
using YunXiu.Interface;

namespace YunXiu.BLL
{
    public class Order_BLL : IOrder
    {
        Order_DAL dal = new Order_DAL();
        public bool CreateOrder(List<Order> orders)
        {
            return dal.CreateOrder(orders);
        }

        public Order GetOrder(int oID)
        {
            return dal.GetOrder(oID);
        }

        public List<Order> GetOrderByUser(int userID)
        {
            return dal.GetOrderByUser(userID);
        }

        public bool UpdateOrder(Order order)
        {
            return dal.UpdateOrder(order);
        }
    }
}
