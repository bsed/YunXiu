﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IConsultation
    {
        bool AddConsultation(Consultation consultation);

        bool DeleteConsultation(int cID);

        List<Consultation> GetConsultationByProduct(int pID);
    }
}
