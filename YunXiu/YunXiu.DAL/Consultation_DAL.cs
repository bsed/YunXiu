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
                sql.Append("SELECT c.[ID],c.[CContent],c.[CreateDate],p.[PID],p.[Name],p.[ShowImg],ct.[ID],ct.[CTypeName],u.[UserName],u.[UID] FROM Consultation c ");
                sql.Append("LEFT JOIN Product p ON c.[CProductID]=p.[PID] ");
                sql.Append("LEFT JOIN ConsultationType ct ON c.[CTypeID]= ct.[ID] ");
                sql.Append("LEFT JOIN User u ON c.[CreateUserID]=u.[UID]");
                sql.Append(string.Format("WHERE [CProductID]={0}",pID));

                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<Consultation, Product, ConsultationType, User, Consultation>(sql.ToString(),
                        (c,p,ct,u)=> 
                        {
                            c.CProduct = p;
                            c.CType = ct;
                            c.CreateUser = u;
                            return c;
                        },
                        null,
                        null,
                        true,
                        "ID",
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
