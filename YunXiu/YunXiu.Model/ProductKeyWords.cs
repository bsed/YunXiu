using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商品关键字表
    /// </summary>
    public class ProductKeyWords
    {
        public int KeyWordId { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord { get; set; }

        public int Pid { get; set; }

        /// <summary>
        /// 权重值
        /// </summary>
        public int Relevancy { get; set; }
    }
}
