using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.DAL;
using YunXiu.Model;
using YunXiu.Interface;

namespace YunXiu.BLL
{
    public class PayOrder_BLL : IPayOrder
    {
        PayOrder_DAL dal = new PayOrder_DAL();
        public int CreatePayOrder(PayOrder pay)
        {
            for (int i = 0; i < pay.Orders.Count; i++)
            {
                pay.PayAmount += pay.Orders[i].BuyUnitPrice * pay.Orders[i].BuyNumber;
            }
            return dal.CreatePayOrder(pay);
        }

        public List<PayOrder> GetPayOrder()
        {
            return dal.GetPayOrder();
        }

        public PayOrder GetPayOrder(int payOrderID)
        {
            return dal.GetPayOrder(payOrderID);
        }

        public bool UdpatePayOrder(PayOrder payOrder)
        {
            return dal.UdpatePayOrder(payOrder);
        }
    }
}
