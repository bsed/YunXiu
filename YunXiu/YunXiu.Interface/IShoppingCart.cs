using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IShoppingCart
    {
        /// <summary>
        /// 获取用户购物车商品信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>获取购物车信息</returns>
        List<ShoppingCart> GetShoppingCartByUser(int userID);

        /// <summary>
        /// 删除购物车商品
        /// </summary>
        /// <param name="pID">产品ID</param>
        /// <returns>是否删除成功</returns>
        bool DeleteShoppingCartProduct(List<int> pID);

        /// <summary>
        /// 添加商品到购物车
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="productID">商品ID</param>
        /// <returns>是否添加成功</returns>
        bool AddProductToShoppingCart(ShoppingCart sc);

        List<ShoppingCart> GetShoppingCartByProduct(List<int> pID);
    }
}
