using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProductReview
    {

        bool AddProductReview(ProductReview review);

        bool UpdateProductReview(ProductReview review);

        bool DeleteProductReview(int reviewID);

        List<ProductReview> GetProductReviewByProductID(int pID);

        List<ProductReview> GetProductReviewByUserID(int uID);

        bool ProductReviewLike(int pReviewID);
    }
}
