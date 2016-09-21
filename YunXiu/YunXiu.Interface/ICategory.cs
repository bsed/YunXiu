using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface ICategory
    {

        /// <summary>
        /// 获取类别
        /// </summary>
        /// <returns>分类集合</returns>
        List<Category> GetCategory();

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns>是否成功添加</returns>
        bool AddCategory(Category category);

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="cID">分类ID</param>
        /// <returns>是否删除成功</returns>
        bool DeleteCategory(int cID);

        /// <summary>
        /// 修改分类
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns>是否成功修改</returns>
        bool UpdateCategory(Category category);

        /// <summary>
        /// 获取类目以及类目的子ID
        /// </summary>
        /// <param name="cID">类目父ID</param>
        /// <returns>类目集合</returns>
        List<int> GetCategoryChildren(int cID);

        Category GetCategoryByID(int cID);
    }
}
