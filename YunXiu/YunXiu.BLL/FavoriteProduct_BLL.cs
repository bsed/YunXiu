using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class FavoriteProduct_BLL : IFavoriteProduct
    {
        FavoriteProduct_DAL dal = new FavoriteProduct_DAL();
        
        public bool AddFavoriteProduct(FavoriteProduct fProduct)
        {
            return dal.AddFavoriteProduct(fProduct);
        }

        public bool DeleteFavoriteProduct(int fID)
        {
            return dal.DeleteFavoriteProduct(fID);
        }

        public List<Product> GetFavoriteProduct(int uID)
        {
            return dal.GetFavoriteProduct(uID);
        }
    }
}
