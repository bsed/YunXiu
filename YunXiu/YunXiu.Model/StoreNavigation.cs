using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商铺导航
    /// </summary>
    public class StoreNavigation : Base
    {
        public int NID { get; set; }

        public Store Store { get; set; }

        public string NName { get; set; }

        public string NLink { get; set; }

        public int Sort { get; set; }

        public bool IsShow { get; set; }

        public bool IsOpenNew { get; set; }
    }
}
