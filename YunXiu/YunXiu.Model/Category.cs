using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商品分类
    /// </summary>
    public class Category:Base
    {
        /// <summary>
        /// 商品分类ID
        /// </summary>
        public int CateId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 商品类别名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 层级
        /// </summary>
        public int Layer { get; set; }
        /// <summary>
        ///路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 是否有子节点
        /// </summary>
        public int HasChild { get; set; }
    }
}
