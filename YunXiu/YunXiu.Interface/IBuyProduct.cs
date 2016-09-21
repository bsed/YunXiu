using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IBuyProduct
    {
        bool AddBuyProdcut(BuyProduct bProduct);

        bool DeleteBuyProduct(int bPID);

        List<BuyProduct> GetBuyProductByUser(int uID);
    }
}
