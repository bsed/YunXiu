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
    public class FavoriteStore_BLL : IFavoriteStore
    {
        FavoriteStore_DAL dal = new FavoriteStore_DAL();
        public bool AddFavoriteStore(FavoriteStore store)
        {
            return dal.AddFavoriteStore(store);
        }

        public bool DeleteFavoriteStore(int fID)
        {
            return dal.DeleteFavoriteStore(fID);
        }

        public List<FavoriteStore> GetFavoriteStore(int uID)
        {
            return dal.GetFavoriteStore(uID);
        }
    }
}
