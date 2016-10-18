using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using YunXiu.BLL;
using YunXiu.Model;
using YunXiu.Model.Global;
using YunXiu.Commom;
using YunXiu.Commom.MQ;
//using YunXiu.Cache;
using System.Threading;

namespace OrderApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        Lazy<Order_BLL> bll = new Lazy<Order_BLL>();
        Lazy<StoreUser_BLL> sUserBll = new Lazy<StoreUser_BLL>();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            #region  初始化配置
            var sysConfPath = Server.MapPath("/App_Data/SysConf.xml");
            var SMSConfPath = Server.MapPath("/App_Data/SMSConfig.xml");
            ThreadPool.QueueUserWorkItem(o =>
            {
                #region 系统配置
                GlobalDictionary.SysConfDictionary = CommomClass.GetXmlNodeVal(sysConfPath, "/Sys");
                #endregion

                #region 短信供应商配置
                GlobalDictionary.SMSConfDic = CommomClass.GetXmlNodeVal(SMSConfPath, "/SMS/SMSProvider[IsUse=1]");
                #endregion
            });
            #endregion
        }

       
    }
}
