using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Web;

namespace YunXiu.Commom
{
    public class WebCommom
    {
        public static HttpResponseMessage GetJsonResponse(object obj)
        {
            HttpResponseMessage response = null;
            try
            {
                response = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "text/json")
                };
            }
            catch (Exception ex) { }
            return response;
        }

        public static HttpResponseMessage GetResponse(object obj)
        {
            HttpResponseMessage response = null;
            try
            {
                response = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "text/plain")
                };
            }
            catch (Exception ex) { }
            return response;
        }

        /// <summary>
        /// 将消息体转换成对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="ms">字节流</param>
        /// <returns>指定类型对象</returns>
        public static T HttpRequestBodyConvertToObj<T>(MemoryStream ms)
        {
            T obj = default(T);
            try
            {
                var httpResult = "";
                var bytes = ms.GetBuffer();
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                byte[] nBytes = new byte[ms.Length];
                for (int i = 0; i < ms.Length; i++)
                {
                    nBytes[i] = bytes[i];
                }
                httpResult = UTF8.GetString(nBytes);
                obj = JsonConvert.DeserializeObject<T>(HttpUtility.UrlDecode(httpResult));
            }
            catch (Exception ex)
            {

            }
            return obj;
        }

        /// <summary>
        /// 将消息体转换成对象
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public static string HttpRequestBodyConvertToStr(MemoryStream ms)
        {
            var httpResult = "";
            try
            {
                var bytes = ms.GetBuffer();
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                byte[] nBytes = new byte[ms.Length];
                for (int i = 0; i < ms.Length; i++)
                {
                    nBytes[i] = bytes[i];
                }
                httpResult = HttpUtility.UrlDecode(UTF8.GetString(nBytes));
            }
            catch (Exception ex)
            {

            }
            return httpResult;
        }

        public static T HttpRequestBodyConvertToObj<T>(HttpContext context)
        {
            T t = default(T);
            using (var ms = new MemoryStream())
            {
                context.Request.GetBufferlessInputStream().CopyTo(ms);
                if (ms.Length != 0)
                {
                    t = HttpRequestBodyConvertToObj<T>(ms);//获取Request Body
                }
            }
            return t;
        }

    }
}
