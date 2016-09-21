using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using Newtonsoft.Json;
using YunXiu.BLL;
using YunXiu.Model;
using System.IO;
using YunXiu.Commom;


namespace AccountApi.Controllers
{
    public class MessageController : ApiController
    {


        [HttpPost]
        public HttpResponseMessage SendMessage()
        {
            HttpResponseMessage result = null;

            try
            {
                string str = "";
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        str = WebCommom.HttpRequestBodyConvertToStr(ms);//获取Request Body
                    }
                }

                var Item = JsonConvert.DeserializeObject<MessageTb>(str);
                
                MessageTb_BLL bll = new MessageTb_BLL();
                return  WebCommom.GetJsonResponse(bll.SendMessage(Item));
                
            }
            catch (Exception)
            {
            }
            return result;
        }



        public HttpResponseMessage ReplyMessage()
        {
            HttpResponseMessage result = null;

            try
            {
                string str = "";
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        str = WebCommom.HttpRequestBodyConvertToStr(ms);//获取Request Body
                    }
                }

                var Item = JsonConvert.DeserializeObject<MessageTb>(str);

                MessageTb_BLL bll = new MessageTb_BLL();
                return WebCommom.GetJsonResponse(bll.ReplyMessage(Item));

            }
            catch (Exception)
            {
                
            }
            return result;
        }

        //怀疑有问题，所以注释，后面的人，交给你了
        //public HttpResponseMessage DeleteMessage()
        //{
        //    HttpResponseMessage result = null;

        //    try
        //    {
        //        string str = "";
        //        using (var ms = new MemoryStream())
        //        {
        //            HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
        //            if (ms.Length != 0)
        //            {
        //                str = WebCommom.HttpRequestBodyConvertToStr(ms);//获取Request Body
        //            }
        //        }


        //        var ResponseArray = JsonConvert.DeserializeObject<string[]>(str);
        //        MessageTb_BLL bll = new MessageTb_BLL();
        //        var Mid= Convert.ToInt32( ResponseArray[0]);

        //        return WebCommom.GetJsonResponse(bll.DeleteMessage(Mid));

        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return result;
        //}


        public HttpResponseMessage GetMessageByCreateUid()
        {
            HttpResponseMessage result = null;
            try
            {
                string str = "";
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        str = WebCommom.HttpRequestBodyConvertToStr(ms);//获取Request Body
                    }
                }
                var ResponseArray = JsonConvert.DeserializeObject<string>(str);

                var Uid = Convert.ToInt32(ResponseArray);

                MessageTb_BLL bll = new MessageTb_BLL();


                return WebCommom.GetJsonResponse(bll.GetMessageByCreateUid(Uid));

            }
            catch (Exception)
            {
            }
            return  result;
        }



        public HttpResponseMessage GetMessageByReceiveUid()
        {
            HttpResponseMessage result = null;
            try
            {
                string str = "";
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        str = WebCommom.HttpRequestBodyConvertToStr(ms);//获取Request Body
                    }
                }
                var ResponseArray = JsonConvert.DeserializeObject<string>(str);

                var Uid = Convert.ToInt32(ResponseArray);

                MessageTb_BLL bll = new MessageTb_BLL();

                
                return WebCommom.GetJsonResponse(bll.GetMessageByReceiveUid(Uid));

            }
            catch (Exception)
            {
            }
            return result;
        }





    }
}
