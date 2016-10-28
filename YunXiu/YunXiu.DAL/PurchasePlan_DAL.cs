using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.Commom;

namespace YunXiu.DAL
{
    public class PurchasePlan_DAL : IPurchasePlan
    {
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
