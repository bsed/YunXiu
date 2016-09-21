using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
   public interface IStoreUserGroup
    {
        bool AddStoreUserGroup(StoreUserGroup group);

        bool DeleteStoreUserGroup(int gID);

        bool UpdateStoreUserGroup(StoreUserGroup group);

        List<StoreUserGroup> GetStoreUserGroup(int sID);
    }
}
