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
    public class CateAttribute_DAL : ICateAttribute
    {
        public bool AddCateAttribute(CateAttribute ca)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO CateAttribute(Name,CateID) VALUES(@Name,@CateID)";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@Name", ca.Name);
                pars.Add("@CateID", ca.Cate.CateId);
                result = DapperHelper.Execute(sql,pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteCateAttribute(int caID)
        {
            throw new NotImplementedException();
        }

        public List<CateAttribute> GetCateAttribute()
        {
            throw new NotImplementedException();
        }

        public List<CateAttribute> GetCateAttributeByCate(int cateID)
        {
            List<CateAttribute> list = null;
            try
            {
                var sql = string.Format("SELECT [AttrID],[Name] FROM CateAttribute WHERE [CateID]={0}");
                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<CateAttribute>(sql).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
