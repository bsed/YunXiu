using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class CateAttribute:Base
    {
        public int AttrID { get; set; }

        public string Name { get; set; }

        public Category Cate { get; set; }
    }
}
