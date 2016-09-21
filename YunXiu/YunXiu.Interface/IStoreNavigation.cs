using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IStoreNavigation
    {
        bool AddStoreNavigation(StoreNavigation navigation);

        bool UpdateStoreNavigation(StoreNavigation navigation);

        bool DeleteStoreNavigation(int nID);

        List<StoreNavigation> GetStoreNavigation(int sID);
    }
}
