using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class ConsultationResult : Base
    {
        public List<Consultation> ConsultationList { get; set; } = new List<Consultation>();

        public List<ConsultationReply> ReplyList { get; set; } = new List<ConsultationReply>();
    }
}
