using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IConsultationReply
    {
        bool AddConsultationReply(ConsultationReply reply);

        bool UpdateConsultationReply(ConsultationReply reply);

        bool DeleteConsultationReply(int rID);

        List<ConsultationReply> GetConsultationReplyByProduct(int pID);

        List<ConsultationReply> GetConsultationReplyByUser(int uID);
    }
}
