using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商铺首页
    /// </summary>
    public class StoreHome : Base
    {
        public int ID { get; set; }

        public Store Store { get; set; }

        public string HomeHtml { get; set; }
    }
}
