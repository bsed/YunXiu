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
    public class BuyProduct_BLL : IBuyProduct
    {
        BuyProduct_DAL dal = new BuyProduct_DAL();
        public bool AddBuyProdcut(BuyProduct bProduct)
        {
            return dal.AddBuyProdcut(bProduct);
        }

        public bool DeleteBuyProduct(int bPID)
        {
            return dal.DeleteBuyProduct(bPID);
        }

        public List<BuyProduct> GetBuyProductByUser(int uID)
        {
            return dal.GetBuyProductByUser(uID);
        }
    }
}
