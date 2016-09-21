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
    public class StoreNavigation_BLL : IStoreNavigation
    {
        StoreNavigation_DAL dal = new StoreNavigation_DAL();
        public bool AddStoreNavigation(StoreNavigation navigation)
        {
            return dal.AddStoreNavigation(navigation);
        }

        public bool DeleteStoreNavigation(int nID)
        {
            return dal.DeleteStoreNavigation(nID);
        }

        public List<StoreNavigation> GetStoreNavigation(int sID)
        {
            return dal.GetStoreNavigation(sID);
        }

        public bool UpdateStoreNavigation(StoreNavigation navigation)
        {
            return dal.UpdateStoreNavigation(navigation);
        }
    }
}
