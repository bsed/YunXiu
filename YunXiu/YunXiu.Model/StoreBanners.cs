using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 店铺BANNER表
    /// </summary>
    public class StoreBanners
    {
        public int Id {get;set;}

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int Storeid {get;set;}

        /// <summary>
        /// 排序
        /// </summary>
        public int displayorder { get; set; }

        /// <summary>
        /// BANNER地址
        /// </summary>
        public string BannerPath {get;set;}
    }
}
