using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class Trace
    {
        public int ID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string AcceptTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string AcceptStation { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
