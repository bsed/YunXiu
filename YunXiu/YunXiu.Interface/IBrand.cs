using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IBrand
    {
        /// <summary>
        /// 获取指定条数品牌
        /// </summary>
        /// <returns></returns>
        List<Brand> GetBrand(int count);
        /// <summary>
        /// 获取所有商家品牌
        /// </summary>
        /// <returns></returns>
        List<Brand> GetBrand();
        /// <summary>
        /// 获取展示动态的品牌
        /// </summary>
        /// <returns></returns>
        List<Brand> GetShowDynamicBrand();

        /// <summary>
        /// 获取展示动态的品牌(根据条数)
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        List<Brand> GetShowDynamicBrand(int count);
        /// <summary>
        /// 删除品牌
        /// </summary>
        /// <param name="bID">品牌ID</param>
        /// <returns>是否删除成功</returns>
        bool DeleteBrand(int bID);

        /// <summary>
        /// 添加品牌
        /// </summary>
        /// <param name="brand">品牌</param>
        /// <returns>是否添加成功</returns>
        bool AddBrand(Brand brand);

        /// <summary>
        /// 修改品牌
        /// </summary>
        /// <param name="brand">要修改的品牌</param>
        /// <returns>是否修改成功</returns>
        bool UpdateBrand(Brand brand);

        /// <summary>
        /// 根据类目获取品牌
        /// </summary>
        /// <param name="cID">类目ID</param>
        /// <returns></returns>
        List<Brand> GetBrandByCategory(List<int> cID);

        List<Brand> GetBrandByCategory(List<int> cID,int count);

        /// <summary>
        /// 获取热门品牌
        /// </summary>
        /// <returns></returns>
        List<Brand> GetHotBrand();

        List<Brand> GetHotBrand(int count);
      
        Brand GetBrandByID(int bID);
    }
}
