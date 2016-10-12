using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;
using Dapper;
using System.Data;

namespace YunXiu.DAL
{
    public class Consultation_DAL : IConsultation
    {
        public bool AddConsultation(Consultation consultation)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO Consultation([CProductID],[CContent],[CTypeID],[CreateDate]) VALUES(@CProductID,@CContent,@CTypeID,GETDATE())";
                DynamicParameters pars = new DynamicParameters(consultation);
                pars.Add("@CProductID", consultation.CProduct.PID);
                pars.Add("@CTypeID", consultation.CType.ID);
                result = DapperHelper.Execute(sql,pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteConsultation(int cID)
        {
            throw new NotImplementedException();
        }

        public List<Consultation> GetConsultationByProduct(int pID)
        {
            List<Consultation> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT c.[ID],c.[CContent],c.[CreateDate],ct.[ID],ct.[CTypeName],p.[PID],p.[Name],p.[ImgID],u.[UID],u.[client_guid] FROM Consultation c ");
                sql.Append("LEFT JOIN Product p ON c.[CProductID]=p.[PID] ");
                sql.Append("LEFT JOIN ConsultationType ct ON c.[CTypeID]= ct.[ID] ");
                sql.Append("LEFT JOIN [User] u ON c.[CreateUserID]=u.[UID] ");
                sql.Append(string.Format("WHERE c.[CProductID]={0}",pID));

                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<Consultation, ConsultationType, Product, User, Consultation>(sql.ToString(),
                        (c, ct, p,u)=> 
                        {
                            c.CProduct = p;
                            c.CType = ct;
                            c.CreateUser = u;
                            return c;
                        },
                        null,
                        null,
                        true,
                        "ID,CreateDate,PID,UID",
                        null,
                        null).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public List<Consultation> GetConsultationByUser(int uID)
        {
            List<Consultation> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT c.[ID],c.[CContent],c.[CreateDate],ct.[ID],ct.[CTypeName],p.[PID],p.[Name],p.[ImgID],u.[UID],u.[client_guid] FROM Consultation c ");
                sql.Append("LEFT JOIN Product p ON c.[CProductID]=p.[PID] ");
                sql.Append("LEFT JOIN ConsultationType ct ON c.[CTypeID]= ct.[ID] ");
                sql.Append("LEFT JOIN [User] u ON c.[CreateUserID]=u.[UID] ");
                sql.Append(string.Format("WHERE c.[CreateUserID]={0}", uID));

                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<Consultation, ConsultationType, Product, User, Consultation>(sql.ToString(),
                        (c, ct, p, u) =>
                        {
                            c.CProduct = p;
                            c.CType = ct;
                            c.CreateUser = u;
                            return c;
                        },
                        null,
                        null,
                        true,
                        "ID,CreateDate,PID,UID",
                        null,
                        null).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
    }
}
