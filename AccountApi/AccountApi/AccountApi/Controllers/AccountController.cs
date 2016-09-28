using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Text.RegularExpressions;
using YunXiu.Model;
using YunXiu.Commom;
using YunXiu.BLL;

namespace AccountApi.Controllers
{
    public class AccountController : ApiController
    {
        Lazy<TFUser_BLL> tfUserBll = new Lazy<TFUser_BLL>();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Login()
        {
            HttpResponseMessage response = null;
            TFUser tfUser = null;
            User user = null;
            try
            {
                
                var dic = WebCommom.HttpRequestBodyConvertToObj<Dictionary<string, string>>(HttpContext.Current);//用户登录页信息
                if (dic.Count > 0)
                {
                    var account = dic["account"];//登录账号
                    var pwd = dic["pwd"];//密码
                    tfUser = tfUserBll.Value.Login(account, pwd);
                    if (tfUser != null)//
                    {
                        user.TFUser = tfUser;
                    }
                }


                //if (dic.Count > 0) 居然只有一种登录方式
                //{
                //    Regex emailRex = new Regex("^\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");// 邮箱格式验证
                //    Regex phoneRex = new Regex("^[1][3578]\\d{9}$");//手机号码验证正则
                //    var account = dic["account"];
                //    var pwd = dic["pwd"];
                //    if (emailRex.IsMatch(pwd))
                //    {


                //    }
                //}

                //用户登录方式 
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(user);
            return response;
        }
    }
}
