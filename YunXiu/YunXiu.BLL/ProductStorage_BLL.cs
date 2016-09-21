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
    public class ProductStorage_BLL : IProductStorage
    {
        ProductStorage_DAL dal = new ProductStorage_DAL();
        public bool AddProductStorage(ProductStorage productStorage)
        {
            return dal.AddProductStorage(productStorage);
        }
    }
}
