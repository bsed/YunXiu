using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IConsultationType
    {
        bool AddConsultationType(ConsultationType type);

        bool DeleteConsultationType(int cID);

        bool UpdateConsultationType(ConsultationType type);

        List<ConsultationType> GetConsultationType();
    }
}
