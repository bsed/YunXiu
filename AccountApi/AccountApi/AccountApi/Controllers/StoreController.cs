using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using YunXiu.Commom;
using YunXiu.BLL;
using YunXiu.Model;

namespace AccountApi.Controllers
{
    public class StoreController : ApiController
    {
        Lazy<Store_BLL> bll = new Lazy<Store_BLL>();
        Lazy<StoreHome_BLL> storeHomeBll = new Lazy<StoreHome_BLL>();
        Lazy<FavoriteStore_BLL> fStoreBll = new Lazy<FavoriteStore_BLL>();
        Lazy<StoreNavigation_BLL> navigationBll = new Lazy<StoreNavigation_BLL>();
        /// <summary>
        /// 添加商铺
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddStore()
        {
           
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var store = WebCommom.HttpRequestBodyConvertToObj<Store>(HttpContext.Current);
                if (store != null)
                {
                    result = bll.Value.AddStore(store);
                }
            }
            catch (Exception ex) { }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 修改商铺
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateStore()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var store = WebCommom.HttpRequestBodyConvertToObj<Store>(HttpContext.Current);
                if (store != null)
                {
                    result = bll.Value.UpdateStore(store);
                }
            }
            catch (Exception ex)
            { }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 删除商铺
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DeleteStore()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var sID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                if (sID != 0)
                {
                    result = bll.Value.DeleteStore(sID);
                }
            }
            catch (Exception ex)
            { }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 获取所有商铺
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetStore()
        {
            HttpResponseMessage response = null;
            List<Store> storeList = null;
            try
            {
                storeList = bll.Value.GetStore();
            }
            catch (Exception ex)
            { }
            response = WebCommom.GetResponse(storeList);
            return response;
        }


        /// <summary>
        /// 根据商铺ID获取商铺
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetStoreByID()
        {
            HttpResponseMessage response = null;
            Store store = null;
            try
            {
                var sID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                if (sID != 0)
                {
                    store = bll.Value.GetStoreByID(sID);
                }
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(store);
            return response;
        }

        /// <summary>
        /// 添加收藏店铺
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddFavoriteStore()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var fStore = WebCommom.HttpRequestBodyConvertToObj<FavoriteStore>(HttpContext.Current);
                result = fStoreBll.Value.AddFavoriteStore(fStore);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 获取商铺首页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetStoreHome()
        {
            HttpResponseMessage response = null;
            StoreHome home = null;
            try
            {
                var sID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                home = storeHomeBll.Value.GetStoreHomeByStore(sID);
            }
            catch (Exception ex) { }
            response = WebCommom.GetJsonResponse(home);
            return response;
        }

        /// <summary>
        /// 修改商铺首页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateStoreHome()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var home = WebCommom.HttpRequestBodyConvertToObj<StoreHome>(HttpContext.Current);
                result = storeHomeBll.Value.UpdateStoreHome(home);
            }
            catch (Exception ex) { }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 添加店铺导航
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddStoreNavigation()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var navigation = WebCommom.HttpRequestBodyConvertToObj<StoreNavigation>(HttpContext.Current);
                result = navigationBll.Value.AddStoreNavigation(navigation);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 获取商铺导航
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetStoreNavigation()
        {
            HttpResponseMessage response = null;
            List<StoreNavigation> list = null;
            try
            {
                var sID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                list = navigationBll.Value.GetStoreNavigation(sID);
            }
            catch (Exception ex) { }
            response = WebCommom.GetJsonResponse(list);
            return response;
        }
    }
}
