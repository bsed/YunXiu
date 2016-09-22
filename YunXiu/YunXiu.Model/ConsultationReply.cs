using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{

    /// <summary>
    /// 商铺咨询回复
    /// </summary>
    public class ConsultationReply:Base
    {
        public int RID { get; set; }

        public string RContent { get; set; }

        public Consultation RConsultation { get; set; }

        public Product RProduct{ get; set; }
    }
}
