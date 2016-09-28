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
    public class AttributeValue_DAL : IAttributeValue
    {
        public bool AddAttributeValue(AttributeValue av)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO AttributeValue([AttrVal],[IsInput],[AttrID],[CreateDate]) VALUES(@AttrVal,@IsInput,@AttrID,GETDATE())";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@AttrVal", av.AttrVal);
                pars.Add("@IsInput", av.IsInput);
                pars.Add("@AttrID", av.Attr.AttrID);
                result = DapperHelper.Execute(sql, pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteAttributeValue(int avID)
        {
            throw new NotImplementedException();
        }

        public List<AttributeValue> GetAttributeValue(List<int> attrID)
        {
            List<AttributeValue> list = null;
            try
            {
                var strList = string.Join(",", attrID);
                var sql = new StringBuilder();
                sql.Append("SELECT av.[AttrValID],av.[AttrVal],ca.[AttrID],ca.[Name] FROM AttributeValue av ");
                sql.Append("LEFT JOIN CateAttribute ca ON ca.[AttrID]=[AttrID]");
                sql.Append(string.Format("WHERE [AttrID] IN({0}) AND [IsInput]=0", strList));
                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<AttributeValue,CateAttribute, AttributeValue>(sql.ToString(),
                        (av,ca)=> 
                        {
                            av.Attr = ca;
                            return av;
                        },
                        null,
                        null,
                        true,
                        "AttrID,AttrValID",
                        null
                        ).ToList();
                }         
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool UpdateAttributeValue(AttributeValue av)
        {
            throw new NotImplementedException();
        }
    }
}
