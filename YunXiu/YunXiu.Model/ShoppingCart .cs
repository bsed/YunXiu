using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class ShoppingCart : Base
    {
        /// <summary>
        /// ID
        /// </summary>
        public int SID { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public User User { get; set; }

    }
}
