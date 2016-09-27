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
    public class Product_BLL : IProduct
    {
        Product_DAL dal = new Product_DAL();

        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns>所有商品</returns>
        public List<Product> GetProduct()
        {
            var products = new List<Product>();
            try
            {
                products = dal.GetProduct();
            }
            catch (Exception ex)
            {

            }
            return products;
        }
        /// <summary>
        /// 根据商品ID获取商品
        /// </summary>
        /// <param name="pID">商品ID</param>
        /// <returns></returns>
        public Product GetProductByID(int pID)
        {
            var product = new Product();
            try
            {
                product = dal.GetProductByID(pID);
            }
            catch (Exception ex)
            {

            }
            return product;
        }

        /// <summary>
        /// 获取热销商品(指定条数)
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Product> GetHotProduct(int count)
        {
            return dal.GetHotProduct(count);
        }

        /// <summary>
        /// 获取热销商品
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Product> GetHotProduct()
        {
            return dal.GetHotProduct();
        }

        public int AddProduct(Product product)
        {
            return dal.AddProduct(product);
        }

        public bool DeleteProduct(int pID)
        {
            return dal.DeleteProduct(pID);
        }

        public bool UpdateProduct(Product product)
        {
            return dal.UpdateProduct(product);
        }

        public List<Product> GetProductByCate(List<int> cateID)
        {
            return dal.GetProductByCate(cateID);
        }

        public List<Product> GetProductByCate(List<int> cateID, int count)
        {
            return dal.GetProductByCate(cateID, count);
        }

        public List<Product> GetProductsByID(List<int> pID)
        {
            return dal.GetProductsByID(pID);
        }

        public List<Product> GetProductByStore(int storeID)
        {
            return dal.GetProductByStore(storeID);
        }

        public bool SetProductMainImage(int imgID)
        {
            return dal.SetProductMainImage(imgID);
        }
    }
}
