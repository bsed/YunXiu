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
    public class StoreStaff_BLL : IStoreStaff
    {
        StoreStaff_DAL dal = new StoreStaff_DAL();
        public bool AddStoreStaff(StoreStaff storeStaff)
        {
            return dal.AddStoreStaff(storeStaff);
        }

        public bool DeleteStoreStaff(int staffID)
        {
            return dal.DeleteStoreStaff(staffID);
        }

        public List<StoreStaff> GetReceiveDeliveryStaff(int storeID)
        {
            return dal.GetReceiveDeliveryStaff(storeID);
        }

        public List<StoreStaff> GetStoreStaff()
        {
            return dal.GetStoreStaff();
        }

        public List<StoreStaff> GetStoreStaff(int storeID)
        {
            return dal.GetStoreStaff(storeID);
        }

        public bool UpdateStoreStaff(StoreStaff storeStaff)
        {
            return dal.UpdateStoreStaff(storeStaff);
        }
    }
}
