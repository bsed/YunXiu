using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IFavoriteStore
    {
        bool AddFavoriteStore(FavoriteStore store);

        bool DeleteFavoriteStore(int fID);

        List<FavoriteStore> GetFavoriteStore(int uID);
    }
}
