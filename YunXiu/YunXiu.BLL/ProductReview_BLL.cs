using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.DAL;
using YunXiu.Model;

namespace YunXiu.BLL
{
    public class ProductReview_BLL : IProductReview
    {
        ProductReview_DAL dal = new ProductReview_DAL();
        public bool AddProductReview(ProductReview review)
        {
            return dal.AddProductReview(review);
        }

        public bool DeleteProductReview(int reviewID)
        {
            return dal.DeleteProductReview(reviewID);
        }

        public List<ProductReview> GetProductReviewByProductID(int pID)
        {
            return dal.GetProductReviewByProductID(pID);
        }

        public List<ProductReview> GetProductReviewByUserID(int uID)
        {
            return dal.GetProductReviewByUserID(uID);
        }

        public bool ProductReviewLike(int pReviewID)
        {
            return dal.ProductReviewLike(pReviewID);
        }

        public bool UpdateProductReview(ProductReview review)
        {
            return dal.UpdateProductReview(review);
        }
    }
}
