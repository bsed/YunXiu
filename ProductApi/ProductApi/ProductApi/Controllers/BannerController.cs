using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YunXiu.Model;
using YunXiu.BLL;
using YunXiu.Commom;
using System.IO;
using System.Web;

namespace ProductApi.Controllers
{
    public class BannerController : ApiController
    {
        Lazy<Banner_BLL> bll = new Lazy<Banner_BLL>();

        [HttpPost]
        /// <summary>
        /// 添加横幅
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage AddBanner()
        {
            HttpResponseMessage response = null;
            try
            {
                Banner banner = null;
                var result = false;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        banner = WebCommom.HttpRequestBodyConvertToObj<Banner>(ms);
                    }
                }
                if (banner != null)
                {
                    result = bll.Value.AddBanner(banner);
                }
                response = WebCommom.GetResponse(result);
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 删除横幅
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage DeleteBanner()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {            
                var str = "";
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    str = WebCommom.HttpRequestBodyConvertToStr(ms);//获取Request Body
                }

                if (!string.IsNullOrWhiteSpace(str))
                {
                    var bID = Convert.ToInt32(str);
                    result = bll.Value.DeleteBanner(bID);
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
        public HttpResponseMessage UpdateBanner()
        {
            HttpResponseMessage response = null;
            try
            {
                Banner banner = null;
                var result = false;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        banner = WebCommom.HttpRequestBodyConvertToObj<Banner>(ms);//获取转换后的Body
                    }
                }
                if (banner != null)
                {
                    result = bll.Value.UpdateBanner(banner);
                }

                response = WebCommom.GetResponse(result);
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 获取横幅
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetBanner()
        {
            HttpResponseMessage response = null;
            try
            {
                var count = 0;
                var list = new List<Banner>();
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
                    list = bll.Value.GetBanner();
                }
                else
                {
                    list = bll.Value.GetBanner();
                }
                response = WebCommom.GetJsonResponse(list);
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetBannerByID()
        {
            HttpResponseMessage response = null;
            try
            {
                var banner = new Banner();
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
                    banner = bll.Value.GetBannerByID(id);
                }
                response = WebCommom.GetJsonResponse(banner);
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
