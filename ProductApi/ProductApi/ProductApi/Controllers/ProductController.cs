using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Newtonsoft.Json;
using YunXiu.Model;
using YunXiu.BLL;
using System.Text;
using YunXiu.Commom;
using System.IO;

namespace ProductApi.Controllers
{
    public class ProductController : ApiController
    {
        Lazy<Product_BLL> bll = new Lazy<Product_BLL>();
        Lazy<ShoppingCart_BLL> shoppingCartBll = new Lazy<ShoppingCart_BLL>();
        Lazy<Category_BLL> cateBll = new Lazy<Category_BLL>();
        Lazy<LuceneNet> lucene = new Lazy<LuceneNet>();
        Lazy<ProductReview_BLL> reviewBll = new Lazy<ProductReview_BLL>();
      //  Lazy<ProductState_BLL> productStateBll = new Lazy<ProductState_BLL>();
        static string indexPath = HttpContext.Current.Server.MapPath("/IndexData/ProductIndex");//商品索引 
        #region 商品

        [HttpPost]
        /// <summary>
        /// 根据商品ID获取商品
        /// </summary>
        /// <param name="pID">商品ID</param>
        /// <returns></returns>
        public HttpResponseMessage GetProduct()
        {
            HttpResponseMessage response = null;
            var products = new List<Product>();
            try
            {
                products = bll.Value.GetProduct();

            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(products);
            return response;
        }

        [HttpPost]
        /// <summary> 
        /// 获取所有商品
        /// </summary>
        /// <returns>所有商品</returns>
        public HttpResponseMessage SearchProduct()
        {
            HttpResponseMessage response = null;
            PageResult<Product> pageResult = new PageResult<Product>();
            try
            {
                var searchKey = "";
                var pageIndex = 0;
                var pageSize = 0;
                string[] arr = new string[5];
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        arr = WebCommom.HttpRequestBodyConvertToObj<string[]>(ms);//获取Request Body
                    }

                }
                if (arr.Length > 0)
                {
                    var totalCount = 0;
                    searchKey = Convert.ToString(arr[0]);
                    pageIndex = Convert.ToInt32(arr[1]);
                    pageSize = Convert.ToInt32(arr[2]);
                    lucene.Value.IndexPath = indexPath;
                    var products = new List<Product>();
                    if (arr.Length == 3)
                    {
                        products = lucene.Value.SearchFromIndexData<Product>(searchKey, pageIndex, pageSize, out totalCount, Utilities.GetPropertyName<Product>(f => f.Name));
                    }
                    pageResult = new PageResult<Product>
                    {
                        ResultList = products,
                        TotalCount = totalCount,
                        PageIndex = pageSize
                    };
                }

            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(pageResult);
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 根据商品ID获取商品
        /// </summary>
        /// <param name="pID">商品ID</param>
        /// <returns></returns>
        public HttpResponseMessage GetProductByID()
        {
            HttpResponseMessage response = null;
            var product = new Product();
            try
            {
                var str = "";
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        str = WebCommom.HttpRequestBodyConvertToStr(ms);//获取Request Body
                    }
                }
                if (!string.IsNullOrWhiteSpace(str))
                {
                    var id = Convert.ToInt32(str);
                    product = bll.Value.GetProductByID(id);
                }
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(product);
            return response;
        }

        

        [HttpPost]
        /// <summary>
        /// 获取热销商品
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetHotProduct()
        {
            HttpResponseMessage response = null;
            try
            {
                var count = 0;
                var list = new List<Product>();
                var str = "";
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        str = WebCommom.HttpRequestBodyConvertToStr(ms);//获取Request Body
                    }
                }
                if (!string.IsNullOrWhiteSpace(str))
                {
                    count = Convert.ToInt32(str);
                    list = bll.Value.GetHotProduct(count);
                }
                else
                {
                    list = bll.Value.GetHotProduct();
                }

                response = WebCommom.GetJsonResponse(list);
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 根据类目获取产品
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetProductByCategory()
        {
            HttpResponseMessage response = null;
            try
            {
                var count = 0;
                List<Product> list = new List<Product>();
                var str = "";
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        str = WebCommom.HttpRequestBodyConvertToStr(ms);//获取Request Body
                    }
                }
                if (!string.IsNullOrWhiteSpace(str))
                {
                    var arr = str.Split(',');
                    var cateID = Convert.ToInt32(arr[0]);
                    if (arr.Length > 1)//Index 0是cateID,1是count
                    {
                        count = Convert.ToInt32(arr[1]);
                    }
                    var cateIDList = cateBll.Value.GetCategoryChildren(cateID);//获取cate子ID
                    if (count != 0)
                    {
                        list = bll.Value.GetProductByCate(cateIDList, count);
                    }
                    else
                    {
                        list = bll.Value.GetProductByCate(cateIDList);
                    }
                }
                response = WebCommom.GetJsonResponse(list);
            }
            catch (Exception ex)
            {

            }
            return response;
        }
      
        [HttpPost]
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage AddProduct()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                Product product = null;
                var id = 0;//插入后返回的ID
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        product = WebCommom.HttpRequestBodyConvertToObj<Product>(ms);
                    }
                }
                if (product != null)
                {
                    id = bll.Value.AddProduct(product);
                    product.PID = id;
                }
                if (id != 0)
                {
                    result = true;
                }
                if (result)//更新全文索引
                {
                    lucene.Value.IndexPath = indexPath;
                    lucene.Value.CreateIndexByData<Product>(new List<Product> { product }, GetIndexField(), false);
                }
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 删除横幅
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage DeleteProduct()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var pID = 0;
                var str = "";
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    str = WebCommom.HttpRequestBodyConvertToStr(ms);//获取Request Body
                }

                if (!string.IsNullOrWhiteSpace(str))
                {
                    pID = Convert.ToInt32(str);
                    result = bll.Value.DeleteProduct(pID);
                }
                if (result)
                {
                    lucene.Value.IndexPath = indexPath;
                    lucene.Value.DeleteDocument(Utilities.GetPropertyName<Product>(f => f.Name), pID.ToString());
                }
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 修改横幅
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage UpdateProduct()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                Product product = null;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        product = WebCommom.HttpRequestBodyConvertToObj<Product>(ms);//获取转换后的Body
                    }
                }
                if (product != null)
                {
                    result = bll.Value.UpdateProduct(product);
                }
                if (result)//修改成功更新产品索引
                {
                    lucene.Value.IndexPath = indexPath;
                    lucene.Value.UpdateDocument(product, Utilities.GetPropertyName<Product>(f => f.PID), GetIndexField());
                }
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }


        /// <summary>
        /// 获取商铺产品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetProductByStore()
        {
            HttpResponseMessage response = null;
            List<Product> list = null;
            try
            {
                var storeID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                if (storeID != 0)
                {
                    list = bll.Value.GetProductByStore(storeID);
                }
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(list);
            return response;
        }

        private Dictionary<string, bool> GetIndexField()
        {
            var needCreateField = new Dictionary<string, bool>();
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.PID), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.Description), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.Name), true);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.IsBest), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.IsHot), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.IsNew), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.IsRecommend), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.MarketPrice), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.OfficialGuarantee), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.SaleCount), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.ShowImg), false);
            return needCreateField;
        }
        #endregion

        #region 购物车
        [HttpPost]
        /// <summary>
        /// 添加商品到购物车
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage AddProductToShoppingCart()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                Dictionary<string, int> dic = null;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        dic = WebCommom.HttpRequestBodyConvertToObj<Dictionary<string, int>>(ms);
                    }
                }
                if (dic.Count > 0)
                {
                    var userID = dic["userID"];
                    var productID = dic["productID"];
                    var number = dic["number"];
                    result = shoppingCartBll.Value.AddProductToShoppingCart(userID, productID, number);
                }
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 删除购物车商品
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage DeleteShoppingCartProduct()
        {
            HttpResponseMessage response = null;
            try
            {
                var pID = new List<int>();
                var result = shoppingCartBll.Value.DeleteShoppingCartProduct(pID);
                response = WebCommom.GetResponse(result);
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 根据用户ID获取购物车商品
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetShoppingCartByUserID()
        {
            HttpResponseMessage response = null;
            try
            {
                var userID = 0;
                var list = shoppingCartBll.Value.GetShoppingCartByUserID(userID);
                var result = JsonConvert.SerializeObject(list);
                response = WebCommom.GetJsonResponse(result);
            }
            catch (Exception ex)
            {

            }
            return response;
        }



        #endregion

        #region 商品评论

        [HttpPost]
        /// <summary>
        /// 添加商品评论
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage AddProductReview()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var review = WebCommom.HttpRequestBodyConvertToObj<ProductReview>(HttpContext.Current);
                result = reviewBll.Value.AddProductReview(review);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetProductReviewByProductID()
        {
            HttpResponseMessage response = null;
            List<ProductReview> list = null;
            try
            {
                var pID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                list = reviewBll.Value.GetProductReviewByProductID(pID);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(list);
            return response;
        }
        #endregion
    }
}
