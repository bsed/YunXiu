using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YunXiu.BLL;
using YunXiu.Commom;

namespace AccountApi.Controllers
{
    public class ProductConsultController : ApiController
    {

        /// <summary>
        /// 获得用户商品评价列表
        /// </summary>
        [HttpPost]
        public HttpResponseMessage GetUserProductConsultList()
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
                var Item = JsonConvert.DeserializeObject<string[]>(str);
                int uid = Convert.ToInt32(Item[0]);
                int pageSize = Convert.ToInt32(Item[1]);
                int pageNumber = Convert.ToInt32(Item[2]);
                ProductConsult_BLL bll = new ProductConsult_BLL();

                var Res = bll.GetProductConsultListByUid(uid,0, pageSize, pageNumber);

                return WebCommom.GetJsonResponse(Res);
            }
            catch (Exception)
            {
            }
            return result;
        }



    }
}
