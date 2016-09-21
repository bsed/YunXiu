using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class ProductStorage : Base
    {
        public int ID { get; set; }
        /// <summary>
        /// 入库产品
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int Number { get; set; }
    }
}
