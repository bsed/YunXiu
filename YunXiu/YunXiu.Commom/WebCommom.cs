using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using System.Web.SessionState;

namespace YunXiu.Commom
{
    public class WebCommom: IRequiresSessionState
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

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="cookieName">cookie名</param>
        /// <param name="cookieVal">cookie值</param>
        public static void SetCookie(string cookieName, string cookieVal)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Value = cookieVal;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="cookieName">cookie名</param>
        /// <param name="cookieVal">cookie值</param>
        /// <param name="expires">过期天数</param>
        public static void SetCookie(string cookieName, string cookieVal, int expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Value = cookieVal;
            cookie.Expires = DateTime.Now.AddDays(expires);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 设置Session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        public static void SetSession<T>(string key,T t)
        {
            HttpContext.Current.Session[key] = t;
        }

        /// <summary>
        /// 获取Session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetSession<T>(string key)
        {
            return (T)(HttpContext.Current.Session[key]);
        }

    }
}
