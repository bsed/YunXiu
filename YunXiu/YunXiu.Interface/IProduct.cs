using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IProduct
    {
        /// <summary>
        /// 根据商品类型获取商品
        /// </summary>
        /// <returns>所有商品</returns>
        List<Product> GetProduct();

        /// <summary>
        /// 根据商品ID获取商品
        /// </summary>
        /// <param name="pID">商品ID</param>
        /// <returns></returns>
        Product GetProductByID(int pID);

        List<Product> GetProductsByID(List<int> pID);

        /// <summary>
        /// 获取指定数量热销商品
        /// </summary>
        /// <returns></returns>
        List<Product> GetHotProduct(int count);

        List<Product> GetHotProduct();

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="product"></param>
        /// <returns>返回插入后的ID</returns>
        int AddProduct(Product product);

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        bool DeleteProduct(int pID);

        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        bool UpdateProduct(Product product);

        /// <summary>
        /// 根据类目获取产品
        /// </summary>
        /// <param name="cateID"></param>
        /// <returns></returns>
        List<Product> GetProductByCate(List<int> cateID,int count);

        List<Product> GetProductByStore(int storeID);
    }
}
