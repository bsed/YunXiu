using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class Permission
    {
        public int PID { get; set; }

        /// <summary>
        /// 权限名
        /// </summary>
        public string PName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
    }
}
