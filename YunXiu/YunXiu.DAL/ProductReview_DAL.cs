using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;

namespace YunXiu.DAL
{
    public class ProductReview_DAL : IProductReview
    {
        public bool AddProductReview(ProductReview review)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductReview(int reviewID)
        {
            throw new NotImplementedException();
        }

        public List<ProductReview> GetProductReviewByProductID(int pID)
        {
            throw new NotImplementedException();
        }

        public List<ProductReview> GetProductReviewByUserID(int uID)
        {
            throw new NotImplementedException();
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
