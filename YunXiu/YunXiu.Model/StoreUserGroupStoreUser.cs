using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商铺会员分组
    /// </summary>
    public class StoreUserGroupStoreUser:Base
    {
        public int ID { get; set; }

        /// <summary>
        /// 商铺会员组
        /// </summary>
        public StoreUserGroup SUGroup { get; set; }

        /// <summary>
        /// 商铺会员
        /// </summary>
        public StoreUser SUser { get; set; }
    }
}
