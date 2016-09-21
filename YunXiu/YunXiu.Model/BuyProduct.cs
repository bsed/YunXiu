using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 购买商品
    /// </summary>
    public class BuyProduct : Base
    {
        public int ID { get; set; }

        public Product BProduct { get; set; }

        public User BUser { get; set; }
    }
}
