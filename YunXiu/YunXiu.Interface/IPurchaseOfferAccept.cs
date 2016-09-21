using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IPurchaseOfferAccept
    {
        bool AddPurchaseOfferAccept(PurchaseOfferAccept acceptPlan);

        List<PurchaseOfferAccept> GetPurchaseOfferAcceptByPlan(int pID);

        bool DeletePurchaseOfferAccept(int aID);
    }
}
