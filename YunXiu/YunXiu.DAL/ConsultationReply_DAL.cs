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
    public class ConsultationReply_DAL : IConsultationReply
    {
        public bool AddConsultationReply(ConsultationReply reply)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO ConsultationReply([RContent],[RConsultationID],[RProductID],[CreateDate]) VALUES(@RContent,@RConsultationID,@RProductID,GETDATE())";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@RContent",reply.RContent);
                pars.Add("@RConsultationID", reply.RConsultation.ID);
                pars.Add("@RProductID", reply.RProduct.PID);
                result = DapperHelper.Execute(sql,pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteConsultationReply(int rID)
        {
            throw new NotImplementedException();
        }

        public List<ConsultationReply> GetConsultationReplyByProduct(int pID)
        {
            List<ConsultationReply> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT r.[ID],c.[RContent],r.[CreateDate],p.[PID],p.[Name],p.[ShowImg],c.[ID],c.[CContent],u.[UserName] FROM ConsultationReply r ");
                sql.Append("LEFT JOIN Product p ON r.[RProductID]=p.[PID] ");
                sql.Append("LEFT JOIN Consultation c ON r.[RConsultationID]= c.[ID] ");
                sql.Append(string.Format("WHERE [RProductID]={0}", pID));

                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<ConsultationReply, Product, Consultation, ConsultationReply>(sql.ToString(),
                        (r, p, c) =>
                        {
                            r.RProduct= p;
                            r.RConsultation = c;
                            return r;
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

        public bool UpdateConsultationReply(ConsultationReply reply)
        {
            throw new NotImplementedException();
        }
    }
}
