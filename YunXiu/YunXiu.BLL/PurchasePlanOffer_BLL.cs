using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.DAL;
using YunXiu.Model;

namespace YunXiu.BLL
{
    public class PurchasePlanOffer_BLL : IPurchasePlanOffer
    {
        PurchasePlanOffer_DAL dal = new PurchasePlanOffer_DAL();
        public List<PurchasePlanOffer> GetPurchasePlanOfferByPlan(int pID)
        {
            return dal.GetPurchasePlanOfferByPlan(pID);
        }
    }
}
