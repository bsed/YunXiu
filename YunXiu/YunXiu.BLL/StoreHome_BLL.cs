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
    public class StoreHome_BLL : IStoreHome
    {
        StoreHome_DAL dal = new StoreHome_DAL();
        public bool UpdateStoreHome(StoreHome home)
        {
            return dal.UpdateStoreHome(home);
        }

        public StoreHome GetStoreHomeByStore(int sID)
        {
            return dal.GetStoreHomeByStore(sID);
        }
    }
}
