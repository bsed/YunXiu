using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface ICertificate
    {
        int AddCertificate(Certificate certificate);

        List<Certificate> GetCertificate(int sID);

        bool DeleteCertificate(int ID);
    }
}
