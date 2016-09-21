using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 店铺分类表
    /// </summary>
    public class Storeclasses
    {
        /// <summary>
        /// 店铺分类ID
        /// </summary>
        public int storecid { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int storeid { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int displayorder { get; set; }

        public string name { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public int parentid { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public int layer { get; set; }

        /// <summary>
        /// 是否有子节点
        /// </summary>
        public int haschild { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string path { get; set; }

    }
}
