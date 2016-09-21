using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IFavoriteProduct
    {
        bool AddFavoriteProduct(FavoriteProduct fProduct);

        bool DeleteFavoriteProduct(int fID);

        List<Product> GetFavoriteProduct(int uID);
    }
}
