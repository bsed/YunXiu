using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 用于传输JSON
    /// </summary>
    public class PurchasePlanModel
    {
        public PurchasePlan Item { get; set; }
        public  List<ExtTable> ExtList { get; set; }
    }
}
