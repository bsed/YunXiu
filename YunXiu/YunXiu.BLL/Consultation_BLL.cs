﻿using System;
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

        public List<Consultation> GetConsultationByProduct(int pID)
        {
            return dal.GetConsultationByProduct(pID);
        }

        public List<Consultation> GetConsultationByUser(int uID)
        {
            return dal.GetConsultationByUser(uID);
        }
    }
}
