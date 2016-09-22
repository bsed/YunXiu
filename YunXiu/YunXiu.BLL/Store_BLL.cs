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
    public class Store_BLL : IStore
    {
        Store_DAL dal = new Store_DAL();
        public bool AddStore(Store store)
        {
            return dal.AddStore(store);
        }

        public bool DeleteStore(int sID)
        {
            return dal.DeleteStore(sID);
        }

        public List<Store> GetStore()
        {
            return dal.GetStore();
        }

        public decimal GetStoreAmount(int sID)
        {
            return dal.GetStoreAmount(sID);
        }

        public Store GetStoreByID(int sID)
        {
            return dal.GetStoreByID(sID);
        }

        public bool UpdateStore(Store store)
        {
            return dal.UpdateStore(store);
        }
    }
}
