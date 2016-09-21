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
    public class StoreUser_BLL : IStoreUser
    {
        StoreUser_DAL dal = new StoreUser_DAL();
        public bool AddStoreUser(int storeID, int userID)
        {
            return dal.AddStoreUser(storeID, userID);
        }

        public bool DeleteStoreUser(int storeID, int userID)
        {
            return dal.DeleteStoreUser(storeID, userID);
        }

        public List<StoreUser> GetStoreByUser(int userID)
        {
            return dal.GetStoreByUser(userID);
        }

        public List<StoreUser> GetStoreUserByStore(int storeID)
        {
            return dal.GetStoreUserByStore(storeID);
        }
    }
}
