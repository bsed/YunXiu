using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IPayOrder
    {
        int CreatePayOrder(PayOrder payOrder);

        List<PayOrder> GetPayOrder();

        PayOrder GetPayOrder(int payOrderID);

        bool UdpatePayOrder(PayOrder payOrder);
    }
}
