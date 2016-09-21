using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商品SKU表
    /// </summary>
    public class Productskus
    {

        public int Recordid { get; set; }
        /// <summary>
        /// sku组ID
        /// </summary>
        public int SkuGid { get; set; }
        public int Pid { get; set; }

        /// <summary>
        /// 属性ID
        /// </summary>
        public int Attrid { get; set; }

        /// <summary>
        /// 属性值ID
        /// </summary>
        public int AttrValueId { get; set; }

        /// <summary>
        /// 输入值
        /// </summary>
        public string InputValue { get; set; }
    }
}
