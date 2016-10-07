using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YunXiu.Commom;
using YunXiu.BLL;
using YunXiu.Model;

namespace AccountApi.Controllers
{
    public class SMSController : ApiController
    {
        SMS_BLL bll = new SMS_BLL();

        [HttpPost]
        public HttpResponseMessage Send()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var sms = WebCommom.HttpRequestBodyConvertToObj<SMS>(HttpContext.Current);
                result= bll.Send(sms);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }
    }
}
