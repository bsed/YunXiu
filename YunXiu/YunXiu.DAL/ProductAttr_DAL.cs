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
    public class ProductAttr_DAL : IProductAttr
    {
        public bool AddProductAttr(ProductAttr attr)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductAttr(int aID)
        {
            throw new NotImplementedException();
        }

        public List<ProductAttr> GetProductAttr(int pID)
        {
            List<ProductAttr> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT ca.[AttrID],ca.[Name],av.[AttrValID],av.[AttrVal],av.[IsInput],pa.[PAID],pa.[ProductID],pa.[AttrID],pa.[AttrValID],pa.[InputVal],pa.[CreateDate] FROM ProductAttr pa ");
                sql.Append("LEFT JOIN CateAttribute ca ON ca.[AttrID] = pa.[AttrID]");
                sql.Append("LEFT JOIN AttributeValue av ON av.[AttrValID] = pa.[AttrValID] ");
                sql.Append(string.Format("WHERE pa.[ProductID]={0}", pID));
                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<ProductAttr, CateAttribute, AttributeValue, ProductAttr>(sql.ToString(),
                       (pa, ca, av) =>
                       {
                           pa.Attr = ca;
                           pa.AttrVal = av;
                           return pa;
                       },
                       null,
                       null,
                       true,
                       "Name,AttrValID,AttrVal",
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
