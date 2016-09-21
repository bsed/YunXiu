using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YunXiu.Commom;
using YunXiu.Model.Global;

namespace AccountApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
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
                GlobalDictionary.SysConfDictionary = CommomClass.GetXmlNodeVal(sysConfPath,"/Sys");
                #endregion

                #region 短信供应商配置
                GlobalDictionary.SMSConfDic = CommomClass.GetXmlNodeVal(SMSConfPath, "/SMS/SMSProvider[IsUse=1]");
                #endregion
            });
            #endregion
        }
    }
}
