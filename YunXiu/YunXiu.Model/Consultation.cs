using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 商铺咨询
    /// </summary>
   public class Consultation:Base
    {
        public int ID { get; set; }

        public Product CProduct { get; set; }

        public string CContent { get; set; }

        public ConsultationType CType { get; set; }
    }
}
