using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YunXiu.Commom;
using YunXiu.Model;
using YunXiu.BLL;
using System.Threading;

namespace ProductApi
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

            #region  初始化系统配置
            var sysConfPath = Server.MapPath("/App_Data/SysConfKey.xml");
            var keys = YunXiu.Commom.CommomClass.GetXmlNodeValue(sysConfPath, "/keys/key");
            var isLoad = YunXiu.Commom.CommomClass.LoadConfigDictionary(keys);
            if (!isLoad)
            {
                //如果配置没有加载成功通知运维
            }
            #endregion

            #region 初始化产品索引
            var indexPath = Server.MapPath("/IndexData/ProductIndex");
            ThreadPool.QueueUserWorkItem(o =>
            {
                CreateProductIndex(indexPath);
            });


            #endregion
        }

        /// <summary>
        /// 创建产品索引
        /// </summary>
        private void CreateProductIndex(string indexPath)
        {
            Product_BLL productBll = new Product_BLL();
            LuceneNet lucene = new LuceneNet(indexPath);
            var products = productBll.GetProduct();
            #region 需要添加到索引的字段
            var needCreateField = new Dictionary<string, bool>();
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.PID), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.Description), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.Name), true);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.IsBest), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.IsHot), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.IsNew), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.IsRecommend), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.MarketPrice), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.OfficialGuarantee), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.SaleCount), false);
            needCreateField.Add(Utilities.GetPropertyName<Product>(f => f.ImgID), false);
            #endregion
            var isCreateSuccess = lucene.CreateIndexByData<Product>(products, needCreateField,true);
            if (!isCreateSuccess)
            {
                //如果索引没有创建成功通知管理员 
            }
        }
    }
}
