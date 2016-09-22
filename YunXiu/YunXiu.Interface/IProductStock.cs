using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IProductStock
    {
        /// <summary>
        /// 获取商品库存
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        List<ProductStock> GetProductStock();

        /// <summary>
        /// 获取指定商品库存
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        int GetProductStock(int pID);

        /// <summary>
        /// 修改库存
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="dic"></param>
        /// <returns>是否修改成功</returns>
        Dictionary<int,bool> UdpateStock(int userID, Dictionary<int, int> dic);
    }
}
