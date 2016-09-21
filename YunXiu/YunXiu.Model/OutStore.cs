using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class OutStore : Base
    {
        public int ID { get; set; }

        public Product Product { get; set; }
        /// <summary>
        /// 出库数量
        /// </summary>
        public int Number { get; set; }
    }
}
