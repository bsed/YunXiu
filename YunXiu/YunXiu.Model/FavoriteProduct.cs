using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商品收藏 
    /// </summary>
    public class FavoriteProduct : Base
    {
        /// <summary>
        /// 收藏ID
        /// </summary>
        public int FID { get; set; }

        /// <summary>
        /// 收藏商品
        /// </summary>
        public Product FProduct { get; set; }

        /// <summary>
        /// 收藏用户 
        /// </summary>
        public User FUser { get; set; }

    }
}
