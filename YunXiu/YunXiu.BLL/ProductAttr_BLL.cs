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
    public class ProductAttr_BLL : IProductAttr
    {
        ProductAttr_DAL dal = new ProductAttr_DAL();
        public bool AddProductAttr(ProductAttr attr)
        {
            return dal.AddProductAttr(attr);
        }

        public bool DeleteProductAttr(int aID)
        {
            return dal.DeleteProductAttr(aID);
        }
    }
}
