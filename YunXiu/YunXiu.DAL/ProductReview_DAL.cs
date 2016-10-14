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
    public class ProductReview_DAL : IProductReview
    {
        public bool AddProductReview(ProductReview review)
        {
            var result = false;
            try
            {
                var procName = "AddProductReview";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@RProductID", review.RProduct.PID);
                pars.Add("@RUserID", review.RUser.UID);
                pars.Add("@ROrderID", review.ROrder.OID);
                pars.Add("@Star", 0);
                pars.Add("@RContent", review.RContent);
                pars.Add("@ReviewTime", review.ReviewTime);
                pars.Add("@Parent", review.Parent);
                pars.Add("@IsStoreReply", review.IsStoreReply);
                result = DapperHelper.ExecuteProc(procName, pars) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteProductReview(int reviewID)
        {
            throw new NotImplementedException();
        }

        public List<ProductReview> GetProductReviewByProductID(int pID)
        {
            List<ProductReview> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT pr.[RID],pr.[Star],pr.[RContent],pr.[ReviewTime],pr.[Parent],pr.[IsStoreReply],pr.[LikeCount],u.[UID],u.[client_guid],p.[PID],p.[Name],p.[ImgName],o.[OID],o.[CreateDate] FROM ProductReview pr ");
                sql.Append("LEFT JOIN [User] u ON u.[UID]=pr.[RUserID] ");
                sql.Append("LEFT JOIN Product p ON p.[PID]=pr.[RProductID] ");
                sql.Append("LEFT JOIN [Order] o ON o.[OID]=pr.[ROrderID] ");
                sql.Append(string.Format("WHERE pr.[RProductID]={0} ORDER BY pr.[ReviewTime] DESC", pID));
                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<ProductReview, User, Product, Order, ProductReview>(sql.ToString(),
                        (pr, u, p, o) =>
                        {
                            pr.RUser = u;
                            pr.RProduct = p;
                            pr.ROrder = o;
                            return pr;
                        },
                        null,
                        null,
                        true,
                        "RID,UID,PID,OID",
                        null
                        ).ToList();
                }
            }
            catch (Exception ex)
            { }
            return list;
        }

        public List<ProductReview> GetProductReviewByUserID(int uID)
        {
            List<ProductReview> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT pr.[RID],pr.[Star],pr.[RContent],pr.[ReviewTime],pr.[Parent],pr.[IsStoreReply],pr.[LikeCount],u.[UID],u.[client_guid],p.[PID],p.[Name],p.[ImgName],o.[OID] FROM ProductReview pr ");
                sql.Append("LEFT JOIN [User] u ON u.[UID]=pr.[RUserID] ");
                sql.Append("LEFT JOIN Product p ON p.[PID]=pr.[RProductID] ");
                sql.Append("LEFT JOIN [Order] o ON o.[OID]=pr.[ROrderID] ");
                sql.Append(string.Format("WHERE pr.[RUserID]={0} ORDER BY pr.[ReviewTime] DESC", uID));
                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<ProductReview, User, Product, Order, ProductReview>(sql.ToString(),
                        (pr, u, p, o) =>
                        {
                            pr.RUser = u;
                            pr.RProduct = p;
                            pr.ROrder = o;
                            return pr;
                        },
                        null,
                        null,
                        true,
                        "RID,UID,PID,OID",
                        null
                        ).ToList();
                }
            }
            catch (Exception ex)
            { }
            return list;
        }

        public bool ProductReviewLike(int pReviewID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductReview(ProductReview review)
        {
            throw new NotImplementedException();
        }
    }
}
