using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YunXiu.Model;
namespace YunXiu.Interface
{
    public interface IPurchasePlan
    {
        bool AddPurchasePlan(PurchasePlan plan);

        List<PurchasePlan> GetPurchasePlan(int id);

        List<PurchasePlan> GetPurchasePlanByStore(int sID);

        List<PurchasePlan> GetPurchasePlanByUser(int uID);

        bool UpdatePurchasePlan(PurchasePlan plan);

        bool DeletePurchasePlan(int id);

    }
}
