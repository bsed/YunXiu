using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class OrderPayOrder : Base
    {
        public int ID { get; set; }

        public PayOrder PayOrder { get; set; }

        public Order Order { get; set; }
    }
}
