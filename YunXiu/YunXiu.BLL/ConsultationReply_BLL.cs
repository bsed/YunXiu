using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.DAL;
using YunXiu.Model;

namespace YunXiu.BLL
{
    public class ConsultationReply_BLL : IConsultationReply
    {
        ConsultationReply_DAL dal = new ConsultationReply_DAL();
        public bool AddConsultationReply(ConsultationReply reply)
        {
            return dal.AddConsultationReply(reply);
        }

        public bool DeleteConsultationReply(int rID)
        {
            return dal.DeleteConsultationReply(rID);
        }

        public List<ConsultationReply> GetConsultationReplyByProduct(int pID)
        {
            return dal.GetConsultationReplyByProduct(pID);
        }

        public bool UpdateConsultationReply(ConsultationReply reply)
        {
            return dal.UpdateConsultationReply(reply);
        }
    }
}
