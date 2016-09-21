using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 区域表
    /// </summary>
    public class Regions
    {
        public int regionid { get; set; }

        public string name { get; set; }

        /// <summary>
        /// 简拼
        /// </summary>
        public string shortspell { get; set; }

        public int displayorder { get; set; }

        public int parentid { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public int layer { get; set; }
        /// <summary>
        /// 省ID
        /// </summary>
        public int provinceid { get; set; }
        /// <summary>
        /// 省名称
        /// </summary>
        public string provincename { get; set; }

        /// <summary>
        /// 市ID
        /// </summary>
        public int cityid { get; set; }

        /// <summary>
        /// 市名称
        /// </summary>
        public string cityname { get; set; }
    }
}
