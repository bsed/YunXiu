using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;
using YunXiu.Model;
using YunXiu.Commom;
using YunXiu.BLL;


namespace ProductApi.Controllers
{
    public class CategoryController : ApiController
    {
        Lazy<Category_BLL> bll = new Lazy<Category_BLL>();
        Lazy<CateAttribute_BLL> cateAttrBll = new Lazy<CateAttribute_BLL>();
        Lazy<AttributeValue_BLL> attrValBll = new Lazy<AttributeValue_BLL>();

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

        /// <summary>
        /// 添加分类属性
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddCateAttr()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var cateAttr = WebCommom.HttpRequestBodyConvertToObj<CateAttribute>(HttpContext.Current);
                result = cateAttrBll.Value.AddCateAttribute(cateAttr);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 获取分类属性
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetCateAttr()
        {
            HttpResponseMessage response = null;
            List<CateAttribute> cateAttrList = null;
            try
            {
                var cateID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                cateAttrList = cateAttrBll.Value.GetCateAttributeByCate(cateID);
            }
            catch (Exception ex)
            {

            }
            return response;
        }


        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAttrVal()
        {
            HttpResponseMessage response = null;
            List<AttributeValue> list = null;
            try
            {
                var attrList = WebCommom.HttpRequestBodyConvertToObj<List<int>>(HttpContext.Current);
                list = attrValBll.Value.GetAttributeValue(attrList);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(list);
            return response;
        }
    }
}
