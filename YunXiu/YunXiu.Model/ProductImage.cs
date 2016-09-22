using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商品图片表
    /// </summary>
    public class ProductImage
    {
        public int PImgID { get; set; }
        public Product Product { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string ShowImg { get; set; }

        /// <summary>
        /// 是否为主图
        /// </summary>
        public int IsMain { get; set; }
        public int DisplayOrder { get; set; }
        public int StoreId { get; set; }
    }
}
