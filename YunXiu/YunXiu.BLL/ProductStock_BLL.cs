using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class ProductStock_BLL : IProductStock
    {
        ProductStock_DAL dal = new ProductStock_DAL();
        public List<ProductStock> GetProductStock()
        {
            return dal.GetProductStock();
        }

        public ProductStock GetProductStock(int pID)
        {
            return dal.GetProductStock(pID);
        }

        public Dictionary<int,bool> UdpateStock(int userID, Dictionary<int,int> dic)
        {
            return dal.UdpateStock(userID,dic);
        }
    }
}
