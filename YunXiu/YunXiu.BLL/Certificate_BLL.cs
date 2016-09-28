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
    public class Certificate_BLL : ICertificate
    {
        Certificate_DAL dal = new Certificate_DAL();
        public int AddCertificate(Certificate certificate)
        {
            return dal.AddCertificate(certificate);
        }

        public bool DeleteCertificate(int ID)
        {
            return dal.DeleteCertificate(ID);
        }

        public List<Certificate> GetCertificate(int sID)
        {
            return dal.GetCertificate(sID);
        }
    }
}
