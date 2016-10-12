﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YunXiu.Model;
using YunXiu.Commom;
using YunXiu.BLL;
using Newtonsoft.Json;

namespace AccountApi.Controllers
{
    public class UserInfoController : ApiController
    {
        Lazy<ShoppingCart_BLL> shoppingCartBll = new Lazy<ShoppingCart_BLL>();
        Lazy<FavoriteProduct_BLL> fProductBll = new Lazy<FavoriteProduct_BLL>();
        Lazy<ReceiptAddress_BLL> rAddrBll = new Lazy<ReceiptAddress_BLL>();
        Lazy<ProductReview_BLL> reviewBll = new Lazy<ProductReview_BLL>();

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
                var sc = WebCommom.HttpRequestBodyConvertToObj<ShoppingCart>(HttpContext.Current);
                result = shoppingCartBll.Value.AddProductToShoppingCart(sc);
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


        [HttpPost]
        public HttpResponseMessage AddFavoriteProduct()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var fProduct = WebCommom.HttpRequestBodyConvertToObj<FavoriteProduct>(HttpContext.Current);
                if (fProduct != null)
                {
                    result = fProductBll.Value.AddFavoriteProduct(fProduct);
                }
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 获取用户收藏商品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetFavoriteProduct()
        {
            HttpResponseMessage response = null;
            List<Product> list = null;
            try
            {
                var uid = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                list = fProductBll.Value.GetFavoriteProduct(uid);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(list);
            return response;
        }

        /// <summary>
        /// 获取收货地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetReceiptAddress()
        {
            HttpResponseMessage response = null;
            List<ReceiptAddress> list = null;
            try
            {
                var uID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                list = rAddrBll.Value.GetReceiptAddress(uID);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(list);
            return response;
        }

        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddReceiptAddress()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var addr = WebCommom.HttpRequestBodyConvertToObj<ReceiptAddress>(HttpContext.Current);
                result = rAddrBll.Value.AddReceiptAddress(addr);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(result);
            return response;

        }

        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateReceiptAddress()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var addr = WebCommom.HttpRequestBodyConvertToObj<ReceiptAddress>(HttpContext.Current);
                result = rAddrBll.Value.UpdateReceiptAddress(addr);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(result);
            return response;

        }

        /// <summary>
        /// 删除收货地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DeleteReceiptAddress()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var rID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                result = rAddrBll.Value.DeleteReceiptAddress(rID);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(result);
            return response;

        }

        /// <summary>
        /// 获取用户产品评价
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetProductReviewByUser()
        {
            HttpResponseMessage response = null;
            List<ProductReview> list = null;
            try
            {
                var uid = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                if (uid != 0)
                {
                    list = reviewBll.Value.GetProductReviewByUserID(uid);
                }             
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(list);
            return response;
        }

        #endregion
    }
}
