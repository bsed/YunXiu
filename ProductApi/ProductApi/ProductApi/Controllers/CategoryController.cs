using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YunXiu.Model;
using YunXiu.Commom;
using YunXiu.BLL;
using System.IO;
using System.Web;

namespace ProductApi.Controllers
{
    public class CategoryController : ApiController
    {
        Lazy<Category_BLL> bll = new Lazy<Category_BLL>();

        [HttpPost]
        /// <summary>
        /// 获取所有类目
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetCategory()
        {
            HttpResponseMessage response = null;
            try
            {
                var count = 0;
                var list = new List<Category>();
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
                    list = bll.Value.GetCategory();
                }
                else
                {
                    list = bll.Value.GetCategory();
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
        /// 获取所有类目
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetCategoryByID()
        {
            HttpResponseMessage response = null;
            Category cate = null;
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
                    var cID = Convert.ToInt32(str);
                    cate = bll.Value.GetCategoryByID(cID);
                }             
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(cate);
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 添加类目
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage AddCategory()
        {
            HttpResponseMessage response = null;
            try
            {
                Category cate = null;
                var result = false;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        cate = WebCommom.HttpRequestBodyConvertToObj<Category>(ms);
                    }
                }
                if (cate != null)
                {
                    result = bll.Value.AddCategory(cate);
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
        /// 删除类目
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage DeleteCategory()
        {
            HttpResponseMessage response = null;
            try
            {
                var result = false;
                var str = "";
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    str = WebCommom.HttpRequestBodyConvertToStr(ms);//获取Request Body
                }

                if (!string.IsNullOrWhiteSpace(str))
                {
                    var cID = Convert.ToInt32(str);
                    result = bll.Value.DeleteCategory(cID);
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
        /// 修改类目
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage UpdateCategory()
        {
            HttpResponseMessage response = null;
            try
            {
                Category cate = null;
                var result = false;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        cate = WebCommom.HttpRequestBodyConvertToObj<Category>(ms);//获取转换后的Body
                    }
                }
                if (cate != null)
                {
                    result = bll.Value.UpdateCategory(cate);
                }

                response = WebCommom.GetResponse(result);
            }
            catch (Exception ex)
            {

            }
            return response;
        }

    }
}
