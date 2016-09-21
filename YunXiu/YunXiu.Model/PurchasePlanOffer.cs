using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 采购计划报价
    /// </summary>
    public class PurchasePlanOffer : Base
    {
        public int ID { get; set; }

        public Store Store { get; set; }

        public PurchasePlan Plan { get; set; }

        public decimal Offer { get; set; }

        public bool IsOffer { get; set; }

        public string Remark { get; set; }
    }
}
