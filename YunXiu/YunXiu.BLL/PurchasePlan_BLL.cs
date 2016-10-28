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
    public class PurchasePlan_BLL : IPurchasePlan
    {
        PurchasePlan_DAL dal = new PurchasePlan_DAL();

        public bool AddPurchasePlan(PurchasePlan plan)
        {
            throw new NotImplementedException();
        }

        public bool DeletePurchasePlan(int id)
        {
            throw new NotImplementedException();
        }

        public List<PurchasePlan> GetPurchasePlan(int id)
        {
            throw new NotImplementedException();
        }

        public List<PurchasePlan> GetPurchasePlanByStore(int sID)
        {
            throw new NotImplementedException();
        }

        public List<PurchasePlan> GetPurchasePlanByUser(int uID)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePurchasePlan(PurchasePlan plan)
        {
            throw new NotImplementedException();
        }
    }
}
