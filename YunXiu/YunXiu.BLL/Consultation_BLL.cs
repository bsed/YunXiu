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
    public class Consultation_BLL : IConsultation
    {
        Consultation_DAL dal = new Consultation_DAL();
        public bool AddConsultation(Consultation consultation)
        {
            return dal.AddConsultation(consultation);
        }

        public bool DeleteConsultation(int cID)
        {
            return dal.DeleteConsultation(cID);
        }

        public bool GetConsultationByProduct(int pID)
        {
            return GetConsultationByProduct(pID);
        }
    }
}
