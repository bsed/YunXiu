using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 接受的报价合同
    /// </summary>
    public class PurchaseOfferAccept:Base
    {
        public int ID { get; set; }

        public PurchasePlanOffer Offer { get; set; }

        public PurchasePlan Plan { get; set; }

        public Store Store { get; set; }
    }
}
