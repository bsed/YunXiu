using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class CertificateType_BLL : ICertificateType
    {
        CertificateType_DAL dal = new CertificateType_DAL();
        public bool AddCertificateType(CertificateType type)
        {
            return dal.AddCertificateType(type);
        }

        public bool DeleteCertificateType(int ID)
        {
            throw new NotImplementedException();
        }

        public List<CertificateType> GetCertificateType()
        {
            return dal.GetCertificateType();
        }
    }
}
