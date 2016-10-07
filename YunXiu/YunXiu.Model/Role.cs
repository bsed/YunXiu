using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class Role:Base
    {

        public int RID { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string RName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
    }
}
