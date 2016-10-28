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
        Lazy<Certificate_BLL> certificateBll = new Lazy<Certificate_BLL>();
        Lazy<StoreImg_BLL> imgBll = new Lazy<StoreImg_BLL>();
        Lazy<StoreDynamics_BLL> dynamicsBll = new Lazy<StoreDynamics_BLL>();
        Lazy<WithdrawalsApply_BLL> wApplyBll = new Lazy<WithdrawalsApply_BLL>();

        #region 商铺
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

        #endregion

        #region 收藏
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

        #endregion

        #region 首页
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
                if (home != null)
                {
                    home.HomeHtml = HttpUtility.UrlDecode(home.HomeHtml);
                    result = storeHomeBll.Value.UpdateStoreHome(home);
                }

            }
            catch (Exception ex) { }
            response = WebCommom.GetResponse(result);
            return response;
        }
        #endregion

        #region 导航
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
        #endregion

        #region 证件
        /// <summary>
        /// 获取证件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetCertificate()
        {
            HttpResponseMessage response = null;
            List<Certificate> list = null;
            try
            {
                var sID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                list = certificateBll.Value.GetCertificate(sID);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(list);
            return response;
        }

        /// <summary>
        /// 添加证件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddCertificate()
        {
            HttpResponseMessage response = null;
            var id = 0;
            try
            {
                var certificate = WebCommom.HttpRequestBodyConvertToObj<Certificate>(HttpContext.Current);
                if (certificate != null)
                {
                    id = certificateBll.Value.AddCertificate(certificate);
                }
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(id);
            return response;
        }

        #endregion

        #region 商铺图片
        /// <summary>
        /// 获取商铺图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetStoreImg()
        {
            HttpResponseMessage response = null;
            List<StoreImg> images = null;
            try
            {
                var sID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                images = imgBll.Value.GetStoreImg(sID);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(images);
            return response;
        }

        /// <summary>
        /// 添加商铺图片
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage AddStoreImg()
        {
            HttpResponseMessage response = null;
            var id = 0;
            try
            {
                var img = WebCommom.HttpRequestBodyConvertToObj<StoreImg>(HttpContext.Current);
                id = imgBll.Value.AddStoreImg(img);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(id);
            return response;
        }
        #endregion

        #region 商铺动态

        /// <summary>
        /// 获取商铺动态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetStoreDynamics()
        {
            HttpResponseMessage response = null;
            List<StoreDynamics> list = null;
            var sID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
            if (sID != 0)
            {
                list = dynamicsBll.Value.GetStoreDynamics(sID);
            }
            response = WebCommom.GetJsonResponse(list);
            return response;
        }

        /// <summary>
        /// 添加商铺动态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddStoreDynamics()
        {
            HttpResponseMessage response = null;
            var result = false;
            var dynamics = WebCommom.HttpRequestBodyConvertToObj<StoreDynamics>(HttpContext.Current);
            if (dynamics != null)
            {
                result = dynamicsBll.Value.AddStoreDynamics(dynamics);
            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 删除商铺动态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DeleteStoreDynamics()
        {
            HttpResponseMessage response = null;
            var result = false;
            var dID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
            if (dID != 0)
            {
                result = dynamicsBll.Value.DeleteStoreDynamics(dID);
            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 修改商铺动态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateStoreDynamics()
        {
            HttpResponseMessage response = null;
            var result = false;
            var dynamics = WebCommom.HttpRequestBodyConvertToObj<StoreDynamics>(HttpContext.Current);
            if (dynamics != null)
            {
                result = dynamicsBll.Value.UpdateStoreDynamics(dynamics);
            }
            response = WebCommom.GetResponse(result);
            return response;


        }
        #endregion


        #region 提现
        /// <summary>
        /// 提现申请
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddWithdrawalsApply()
        {
            HttpResponseMessage response = null;
            var result = false;
            var apply = WebCommom.HttpRequestBodyConvertToObj<WithdrawalsApply>(HttpContext.Current);
            if (apply != null)
            {
                var userStore = bll.Value.GetStoreByID(apply.ApplyUser.UStore.StoreID);
                if (userStore.StoreManager.UID == apply.ApplyUser.UID || userStore.StoreMoney >= apply.ApplyAmount)//店主才可以申请提现
                {
                    result = wApplyBll.Value.AddWithdrawalsApply(apply);
                }
            }
            response = WebCommom.GetResponse(result);
            return response;

        }

        /// <summary>
        /// 修改提现申请
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateWithdrawalsApply()
        {
            HttpResponseMessage response = null;
            var result = false;
            var apply = WebCommom.HttpRequestBodyConvertToObj<WithdrawalsApply>(HttpContext.Current);
            if (apply != null)
            {
                //这里先判断是否有修改权限

                result = wApplyBll.Value.UpdateIWithdrawalsApply(apply);

            }
            response = WebCommom.GetResponse(result);
            return response;
        }
        #endregion
    }
}
