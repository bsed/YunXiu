using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 关联商品表
    /// </summary>
    public class Relateproducts
    {
        public int recordid { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int pid { get; set; }

        /// <summary>
        /// 关联的商品ID
        /// </summary>
        public int relatepid { get; set; }
    }
}
