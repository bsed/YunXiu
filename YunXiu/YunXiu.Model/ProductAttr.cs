using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商品属性
    /// </summary>
    public class ProductAttr : Base
    {
        public int PAID { get; set; }

        public Product Product { get; set; }

        public CateAttribute Attr { get; set; }

        public AttributeValue AttrVal { get; set; }

        public string InputVal { get; set; }
    }
}
