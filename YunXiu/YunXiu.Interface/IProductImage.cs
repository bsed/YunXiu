using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IProductImage
    {
        bool AddProductImg(ProductImage img);

        bool DeleteProductImg(int piID);

        List<ProductImage> GetProductImg(int pID);
    }
}
