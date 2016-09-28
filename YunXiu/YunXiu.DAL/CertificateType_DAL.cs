using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.Commom;
using Dapper;

namespace YunXiu.DAL
{
    public class CertificateType_DAL : ICertificateType
    {
        public bool AddCertificateType(CertificateType type)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO CertificateType([TypeName],[CreateDate]) VALUES(@TypeName,GETDATE())";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@TypeName",type.TypeName);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteCertificateType(int ID)
        {
            throw new NotImplementedException();
        }

        public List<CertificateType> GetCertificateType()
        {
            List<CertificateType> list = null;
            try
            {
                var sql = "SELECT [ID],[TypeName],[CreateDate] FROM CertificateType";
                list = DapperHelper.Query<CertificateType>(sql);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
