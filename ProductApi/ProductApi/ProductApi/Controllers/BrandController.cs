using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using YunXiu.Model;
using YunXiu.BLL;
using YunXiu.Commom;
using System.Web;
using System.IO;

namespace ProductApi.Controllers
{
    public class BrandController : ApiController
    {
        Lazy<Brand_BLL> bll = new Lazy<Brand_BLL>();
        Lazy<Category_BLL> cateBll = new Lazy<Category_BLL>();

        [HttpPost]
        /// <summary>
        /// 获取商家品牌
        /// </summary>
        /// <returns></returns>
        public string GetBrand()
        {
            var result = "";
            try
            {
                var list = bll.Value.GetBrand();
                result = JsonConvert.SerializeObject(list);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        [HttpPost]
        /// <summary>
        /// 获取热门品牌
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetBrandByID()
        {
            HttpResponseMessage response = null;
            var brand = new Brand();
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
                    brand = bll.Value.GetBrandByID(id);
                }            
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(brand);
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 获取热门品牌
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetHotBrand()
        {
            HttpResponseMessage response = null;
            try
            {
                var count = 0;
                var list = new List<Brand>();
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
                    list = bll.Value.GetHotBrand(count);
                }
                else
                {
                    list = bll.Value.GetHotBrand();
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
        /// 根据类目获取品牌
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetBrandByCategory()
        {
            HttpResponseMessage response = null;
            try
            {
                var count = 0;
                List<Brand> list = new List<Brand>();
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
                        list = bll.Value.GetBrandByCategory(cateIDList, count);
                    }
                    else
                    {
                        list = bll.Value.GetBrandByCategory(cateIDList);
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
        /// 获取展示动态的品牌
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetShowDynamicBrand()
        {
            HttpResponseMessage response = null;
            try
            {
                var count = 0;
                var list = new List<Brand>();
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
                    list = bll.Value.GetShowDynamicBrand(count);
                }
                else
                {
                    list = bll.Value.GetShowDynamicBrand();
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
        /// 添加品牌
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage AddBrand()
        {
            HttpResponseMessage response = null;
            try
            {
                Brand brand = null;
                var bID = 0;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        brand = WebCommom.HttpRequestBodyConvertToObj<Brand>(ms);//获取Request Body
                    }                 
                }
                if (brand != null)
                {
                    bID = bll.Value.AddBrand(brand);
                }
              
                response = WebCommom.GetResponse(bID);
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 修改品牌
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage UpdateBrand()
        {
            HttpResponseMessage response = null;
            try
            {
                Brand brand = null;
                var result = false;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        brand = WebCommom.HttpRequestBodyConvertToObj<Brand>(ms);//获取转换后的Body
                    }                
                }

                if (brand != null)
                {
                   result = bll.Value.UpdateBrand(brand);
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
        /// 删除品牌
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage DeleteBrand()
        {
            HttpResponseMessage response = null;
            try
            {
                var result = false;
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
                    var bID = Convert.ToInt32(str);
                    result = bll.Value.DeleteBrand(bID);           
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
