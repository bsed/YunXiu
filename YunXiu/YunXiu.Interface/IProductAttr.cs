using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IProductAttr
    {
        bool AddProductAttr(ProductAttr attr);

        bool DeleteProductAttr(int aID);

        List<ProductAttr> GetProductAttr(int pID);
    }
}
