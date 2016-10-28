using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YunXiu.Model;
using YunXiu.BLL;
using YunXiu.Commom;

namespace OrderApi.Controllers
{

    public class LogisticsController : ApiController
    {
        Logistics_BLL bll = new Logistics_BLL();

        /// <summary>
        /// 获取物流信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetLogistics()
        {
            HttpResponseMessage response = null;
            Logistics l = new Logistics();
            var dic = WebCommom.HttpRequestBodyConvertToObj<Dictionary<string, string>>(HttpContext.Current);
            if (dic.Count > 0)
            {
                var orderCode = dic["orderCode"];
                var shipperCode = dic["shipperCode"];
                var logisticCode = dic["logisticCode"];
                l = bll.QueryLogisticsInfo(orderCode, shipperCode, logisticCode);
            }

            response = WebCommom.GetJsonResponse(l);
            return response;
        }
    }
}
