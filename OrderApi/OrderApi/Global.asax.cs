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

            #region 初始化库存
            ThreadPool.QueueUserWorkItem(o =>
            {
               // ProductStock_Cache cache = new ProductStock_Cache();
                ProductStock_BLL productStockBLL = new ProductStock_BLL();
              //  cache.SaveProductStock(productStockBLL.GetProductStock());
            });
            #endregion

            #region 读取MQ的订单(MSMQ)
            //MSMQ m = new MSMQ
            //{
            //    MSMQIP = "192.168.9.32",
            //    MSMQName = "orderQueue"
            //};

            //ThreadPool.QueueUserWorkItem(o =>
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(100);
            //        m.BeginReceive("", "");
            //        m.receiveComplete += MQMQReceiveComplete;
            //    }


            //});
            #endregion
        }

        private void MQMQReceiveComplete(object sender, string result)
        {
            if (result != "")
            {
                var orders = JsonConvert.DeserializeObject<List<Order>>(result);
                var isCreateSuccess = bll.Value.CreateOrder(orders);

                if (isCreateSuccess)//订单创建成功
                {
                    for (int i = 0; i < orders.Count; i++)
                    {
                        sUserBll.Value.AddStoreUser(orders[i].BuyProduct.Store.StoreID, orders[i].BuyUser.UID);
                    }
                }
            }
        }
    }
}
