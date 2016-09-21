using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 分页结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T>
    {
        public PageResult()
        {
            ResultList = new List<T>();
        }
        /// <summary>
        /// 对象集合
        /// </summary>
        public List<T> ResultList { get; set; }

        /// <summary>
        /// 页数
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalCount { get; set; }
    }
}
