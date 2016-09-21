using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class Banner : Base
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 展示开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 展示结束时间
        /// </summary>
        public DateTime EndDate { get; set; }       
        /// <summary>
        /// 是否展示
        /// </summary>
        public bool IsShow { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

    }
}
