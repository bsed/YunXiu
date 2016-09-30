using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Text.RegularExpressions;
using YunXiu.Model;
using YunXiu.Commom;
using YunXiu.BLL;
using Newtonsoft.Json;

namespace AccountApi.Controllers
{
    public class AccountController : ApiController
    {
        Lazy<TFUser_BLL> tfUserBll = new Lazy<TFUser_BLL>();
        Lazy<User_BLL> userBll = new Lazy<User_BLL>();
        Lazy<ShoppingCart_BLL> shoppingCartBll = new Lazy<ShoppingCart_BLL>();
        Lazy<FavoriteProduct_BLL> fProductBll = new Lazy<FavoriteProduct_BLL>();
        #region 用户
        /// <summary>
        /// 用户登录(目前只支持一种登录方法(账号))
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Login()
        {
            HttpResponseMessage response = null;
            LoginInfo info = new LoginInfo();
            try
            {
                TFUser tfUser = null;
                var dic = WebCommom.HttpRequestBodyConvertToObj<Dictionary<string, string>>(HttpContext.Current);//用户登录页信息
                if (dic.Count > 0)
                {
                    var account = dic["account"];//登录账号
                    var pwd = dic["pwd"];//密码
                    var isExist = tfUserBll.Value.CheckTFUserAccount(account);//查看账号是否存在
                    if (isExist)
                    {
                        tfUser = tfUserBll.Value.Login(account, pwd);
                        if (tfUser != null)
                        {
                            var user = userBll.Value.GetUserByID(tfUser.client_guid.ToString());
                            if (user == null)//商城用户不存在则创建
                            {
                                userBll.Value.CreateUser(tfUser.client_guid.ToString());
                                user = new User
                                {
                                    client_guid = tfUser.client_guid
                                };
                            }
                            info.LoginState = 1;
                            info.User = user;
                            user.TFUser = tfUser;
                        }
                        else
                        {
                            info.LoginState = 0;
                        }
                    }
                    else
                    {
                        info.LoginState = -1;//用户不存在
                    }

                }
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(info);
            return response;
        }

        /// <summary>
        /// 获取多个一账通用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetTFUser()
        {
            HttpResponseMessage response = null;
            List<TFUser> list = null;
            try
            {
                var uIDList = WebCommom.HttpRequestBodyConvertToObj<List<string>>(HttpContext.Current);
                list = tfUserBll.Value.GetTFUser(uIDList);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(list);
            return response;
        }

        /// <summary>
        /// 根据用户GUID获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetTFUserByID()
        {
            HttpResponseMessage response = null;
            TFUser user = null;
            try
            {
                var uID = WebCommom.HttpRequestBodyConvertToObj<Guid>(HttpContext.Current);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(user);
            return response;
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



        #endregion
    }
}
