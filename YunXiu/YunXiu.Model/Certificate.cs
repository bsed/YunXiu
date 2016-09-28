using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class Certificate : Base
    {
        public int ID { get; set; }

        /// <summary>
        /// 商铺
        /// </summary>
        public Store Store { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public CertificateType Type { get; set; }

        /// <summary>
        /// 证件图片
        /// </summary>
        public string Img { get; set; }
    }
}
