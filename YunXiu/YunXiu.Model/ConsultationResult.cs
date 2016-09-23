using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class ConsultationResult : Base
    {
        public ConsultationResult()
        {
            ConsultationList = new List<Consultation>();
            ReplyList = new List<Model.ConsultationReply>();
        }

        public List<Consultation> ConsultationList { get; set; }

        public List<ConsultationReply> ReplyList { get; set; } 
    }
}
