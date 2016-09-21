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
    public class PurchaseOfferAccept_BLL : IPurchaseOfferAccept
    {
        PurchaseOfferAccept_DAL dal = new PurchaseOfferAccept_DAL();
        public bool AddPurchaseOfferAccept(PurchaseOfferAccept acceptPlan)
        {
            return dal.AddPurchaseOfferAccept(acceptPlan);
        }

        public bool DeletePurchaseOfferAccept(int aID)
        {
            return dal.DeletePurchaseOfferAccept(aID);
        }

        public List<PurchaseOfferAccept> GetPurchaseOfferAcceptByPlan(int pID)
        {
            return dal.GetPurchaseOfferAcceptByPlan(pID);
        }
    }
}
