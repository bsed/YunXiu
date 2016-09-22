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
    public class ConsultationType_BLL : IConsultationType
    {
        ConsultationType_DAL dal = new ConsultationType_DAL();
        public bool AddConsultationType(ConsultationType type)
        {
            return dal.AddConsultationType(type);
        }

        public bool DeleteConsultationType(int cID)
        {
            return dal.DeleteConsultationType(cID);
        }

        public List<ConsultationType> GetConsultationType()
        {
            return dal.GetConsultationType();
        }

        public bool UpdateConsultationType(ConsultationType type)
        {
            return dal.UpdateConsultationType(type);
        }
    }
}
