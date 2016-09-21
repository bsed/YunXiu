using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商铺会员
    /// </summary>
    public class StoreUser : Base
    {
        public int ID { get; set; }

        /// <summary>
        /// 商铺 
        /// </summary>
        public Store Store { get; set; }

        /// <summary>
        /// 商铺会员
        /// </summary>
        public User SUser { get; set; }

        /// <summary>
        /// 会员等级
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// 会员平台积分
        /// </summary>
        public int Integral { get; set; }

        /// <summary>
        /// 会员店铺积分
        /// </summary>
        public int StoreIntegral { get; set; }
    }
}
