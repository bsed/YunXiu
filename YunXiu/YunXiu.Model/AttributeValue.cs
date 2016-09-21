using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class AttributeValue : Base
    {
        public int AttrValID { get; set; }

        public string AttrVal { get; set; }

        public CateAttribute AttrID { get; set; }
        public string IsInput { get; set; }
    }
}
