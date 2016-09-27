using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.DAL;
using YunXiu.Interface;

namespace YunXiu.BLL
{
    public class ProductImage_BLL : IProductImage
    {
        ProductImage_DAL dal = new ProductImage_DAL();
        public int AddProductImg(ProductImage img)
        {
            return dal.AddProductImg(img);
        }

        public bool DeleteProductImg(int piID)
        {
            return dal.DeleteProductImg(piID);
        }

        public List<ProductImage> GetProductImg(int pID)
        {
            return dal.GetProductImg(pID);
        }
    }
}
