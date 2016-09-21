using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IStoreStaff
    {
        List<StoreStaff> GetStoreStaff();

        List<StoreStaff> GetStoreStaff(int storeID);

        List<StoreStaff> GetReceiveDeliveryStaff(int storeID);

        bool DeleteStoreStaff(int staffID);

        bool UpdateStoreStaff(StoreStaff storeStaff);

        bool AddStoreStaff(StoreStaff storeStaff);


    }
}
