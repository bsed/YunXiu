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
    class StoreUserGroup_BLL : IStoreUserGroup
    {
        StoreUserGroup_DAL dal = new StoreUserGroup_DAL();
        public bool AddStoreUserGroup(StoreUserGroup group)
        {
            return dal.AddStoreUserGroup(group);
        }

        public bool DeleteStoreUserGroup(int gID)
        {
            return dal.DeleteStoreUserGroup(gID);
        }

        public List<StoreUserGroup> GetStoreUserGroup(int sID)
        {
            return dal.GetStoreUserGroup(sID);
        }

        public bool UpdateStoreUserGroup(StoreUserGroup group)
        {
            return dal.UpdateStoreUserGroup(group);
        }
    }
}
