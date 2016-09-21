using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商铺会员组
    /// </summary>
    public class StoreUserGroup : Base
    {
        public int GID { get; set; }

        public Store Store { get; set; }

        public string GroupName { get; set; }
    }
}
