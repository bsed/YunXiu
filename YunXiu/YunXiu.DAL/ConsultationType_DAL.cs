using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Commom;
using YunXiu.Model;
using Dapper;

namespace YunXiu.DAL
{
    public class ConsultationType_DAL : IConsultationType
    {
        public bool AddConsultationType(ConsultationType type)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO ConsultationType(CTypeName,CreateDate) VALUES(@CTypeName,GETDATE())";
                result = DapperHelper.Execute(sql, type);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteConsultationType(int cID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM ConsultationType WHERE [ID]={0}",cID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ConsultationType> GetConsultationType()
        {
            List<ConsultationType> list = null;
            try
            {
                var sql = "SELECT [ID],[CTypeName] FROM ConsultationType";
                list = DapperHelper.Query<ConsultationType>(sql);
            }
            catch (Exception ex)
            { }
            return list;
        }

        public bool UpdateConsultationType(ConsultationType type)
        {
            var result = false;
            try
            {
                var sql = "UPDATE ConsultationType SET [CTypeName]=@CTypeName WHERE [ID]=@ID";
                result = DapperHelper.Execute(sql,type);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
