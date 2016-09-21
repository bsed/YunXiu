using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class Brand : Base
    {
        /// <summary>
        /// 品牌ID
        /// </summary>
        public int BrandID { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Logo
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// 品牌类目
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// 品牌动态
        /// </summary>
        public string BrandDynamic { get; set; }
        /// <summary>
        /// 是否在品牌动态展示
        /// </summary>
        public bool IsShowDynamic { get; set; }
        /// <summary>
        /// 品牌动态排序
        /// </summary>
        public int ShowDynamicSort { get; set; }
        /// <summary>
        /// 是否是热门品牌
        /// </summary>
        public bool IsHotBrand { get; set; }
    }
}
