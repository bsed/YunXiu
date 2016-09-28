using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Commom;
using YunXiu.Model;
using Dapper;
using System.Data;

namespace YunXiu.DAL
{
    public class Certificate_DAL : ICertificate
    {
        public int AddCertificate(Certificate certificate)
        {
            var id = 0;
            try
            {
                var sql = "INSER INTO Certificate([StoreID],[TypeID],[Img],[CreateDate]) VALUES(@StoreID,@TypeID,@Img,GETDATE()) SELECT @@IDENTITY";
                DynamicParameters pars = new DynamicParameters(certificate);
                pars.Add("@StoreID",certificate.Store.StoreID);
                pars.Add("@TypeID", certificate.Type.ID);
                id = DapperHelper.ExecuteScalar(sql,pars);
            }
            catch (Exception ex)
            {

            }
            return id;
        }

        public bool DeleteCertificate(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Certificate> GetCertificate(int sID)
        {
            List<Certificate> list = null;
            try
            {
                var sql = new StringBuilder(); 
                sql.Append("SELECT c.[ID],c.[Img],c.[CreateDate] FROM Certificate c ");
                sql.Append("LEFT JOIN CertificateType ct ON ct.[ID]=c.[TypeID] ");
                sql.Append(string.Format("WHERE c.[StoreID]={0}",sID));

                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<Certificate, CertificateType, Certificate>(sql.ToString(),
                        (c, ct) =>
                        {
                            c.Type = ct;
                            return c;
                        },
                        null,
                        null,
                        true,
                        "ID",
                        null
                        ).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
