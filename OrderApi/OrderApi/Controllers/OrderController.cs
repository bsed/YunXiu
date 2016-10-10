using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
//using YunXiu.Cache;
using YunXiu.Model;
using YunXiu.Model.Global;
using YunXiu.Commom;
using YunXiu.BLL;
using YunXiu.Commom.SMS;

namespace OrderApi.Controllers
{
    public class OrderController : ApiController
    {
        Lazy<PayOrder_BLL> payOrderBll = new Lazy<PayOrder_BLL>();
        Lazy<Invoice_BLL> invoiceBll = new Lazy<Invoice_BLL>();
        Lazy<Logistics_BLL> logisticsBll = new Lazy<Logistics_BLL>();
        Lazy<StoreStaff_BLL> storeStaffBll = new Lazy<StoreStaff_BLL>();
        Lazy<BuyApply_BLL> buyApplyBll = new Lazy<BuyApply_BLL>();
        Lazy<OrderPayOrder_BLL> orderPayOrderBll = new Lazy<OrderPayOrder_BLL>();
        Lazy<Order_BLL> orderBll = new Lazy<Order_BLL>();
        public static string AESKey = CommomClass.GetConfigDictionary("orderAESKey");
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CreateOrder()
        {
            List<Order> resultList = new List<Order>();//创建成功的订单
            HttpResponseMessage response = null;
            try
            {
                List<Order> list = null;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        var cText = WebCommom.HttpRequestBodyConvertToStr(ms);//密文
                        var pText = Security.AESDecrypt(cText, AESKey);//明文
                        list = JsonConvert.DeserializeObject<List<Order>>(pText);
                    }
                }
                if (list != null)
                {
                    //  ProductStock_Cache p = new ProductStock_Cache();
                    //   var updateResult = p.UdpateStock(0, GetUpdateProdcut(list));//修改结果
                    //   resultList = GetSuccessOrder(updateResult, list);//获取修改成功的订单
                    #region 将订单加入到MQ,订单加入MQ之后则代表创建成功
                    //if (resultList.Count > 0)
                    //{
                    //    YunXiu.Commom.MQ.MSMQ mq = new YunXiu.Commom.MQ.MSMQ();
                    //    mq.MSMQIP = "192.168.9.32";
                    //    mq.MSMQName = "OrderQueue";
                    //    mq.MSG = JsonConvert.SerializeObject(resultList);
                    //    mq.SendToMSMQ();
                    //}
                    #endregion
                }
            }
            catch (Exception ex)
            {

            }
            var responseCText = Security.AESEncrypt(JsonConvert.SerializeObject(resultList), AESKey);//结果密文
            response = WebCommom.GetResponse(responseCText);
            return response;
        }

        /// <summary>
        /// 创建支付单 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CreatePayOrder()
        {
            HttpResponseMessage response = null;
            PayOrder payOrder = new PayOrder();
            try
            {
                List<Order> orders = null;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        var cText = WebCommom.HttpRequestBodyConvertToStr(ms);//密文
                        var pText = Security.AESDecrypt(cText, AESKey);
                        orders = JsonConvert.DeserializeObject<List<Order>>(pText);
                    }
                }
                if (orders != null)
                {
                    payOrder.Orders = orders;
                    payOrder.ID = payOrderBll.Value.CreatePayOrder(payOrder);
                }
            }
            catch (Exception ex)
            {

            }
            var responseCText = Security.AESEncrypt(JsonConvert.SerializeObject(payOrder), AESKey);//返回密文
            response = WebCommom.GetResponse(responseCText);
            return response;
        }

        /// <summary>
        /// 修改支付单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdatePayOrder()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                PayOrder payOrder = new PayOrder();
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        var cText = WebCommom.HttpRequestBodyConvertToStr(ms);//密文
                        var pText = Security.AESDecrypt(cText, AESKey);
                        payOrder = JsonConvert.DeserializeObject<PayOrder>(pText);
                    }
                }
                result = payOrderBll.Value.UdpatePayOrder(payOrder);
                #region   如果支付成功则通知店家发货(此处可改为异步处理)
                if (payOrder.TradeStatus == "")
                {
                    for (int i = 0; i < payOrder.Orders.Count; i++)
                    {
                        var storeStaff = storeStaffBll.Value.GetReceiveDeliveryStaff(payOrder.Orders[i].BuyProduct.Store.StoreID);
                        var phoneList = new List<string>();
                        for (int j = 0; j < storeStaff.Count; j++)
                        {
                            phoneList.Add(storeStaff[j].Phone);
                        }
                        SMS sms = new SMS { };
                        //  sms.ReceiveNo = phoneList;
                        //   sms.MSGContent = "";
                        CommomClass.HttpPost(GlobalDictionary.GetSysConfVal("AccountApiAddr"), JsonConvert.SerializeObject(sms));//通知店铺员工发货                   
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 获取发货单信息
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetInvoice()
        {
            HttpResponseMessage response = null;
            Invoice invoice = null;
            try
            {
                var oID = 0;
                invoice = invoiceBll.Value.GetInvoiceByOrder(oID);
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        [HttpPost]
        /// <summary>
        /// 创建发货单
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage CreateInvoice()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                Invoice invoice = null;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        invoice = WebCommom.HttpRequestBodyConvertToObj<Invoice>(ms);
                    }
                }
                result = invoiceBll.Value.CreateInvoice(invoice);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }



        /// <summary>
        /// 获取物流信息
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage QueryLogisticsInfo()
        {
            HttpResponseMessage response = null;
            try
            {
                Dictionary<string, string> dic = null;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        dic = WebCommom.HttpRequestBodyConvertToObj<Dictionary<string, string>>(ms);//获取Request Body
                    }
                }
                if (dic.Count > 0)
                {
                    var orderCode = dic["orderCode"];
                    var shipperCode = dic["shipperCode"];
                    var logisticCode = dic["logisticCode"];
                    logisticsBll.Value.QueryLogisticsInfo(orderCode, shipperCode, logisticCode);
                }

            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public HttpResponseMessage BuyApply()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                BuyApply buyApply = null;
                using (var ms = new MemoryStream())
                {
                    HttpContext.Current.Request.GetBufferlessInputStream().CopyTo(ms);
                    if (ms.Length != 0)
                    {
                        buyApply = WebCommom.HttpRequestBodyConvertToObj<BuyApply>(ms);
                    }
                }
                result = buyApplyBll.Value.CreateBuyApply(buyApply);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 获取用户订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetOrdersByUser()
        {
            HttpResponseMessage response = null;
            List<Order> orders = null;
            try
            {
                var uID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);//用户ID
                orders = orderBll.Value.GetOrderByUser(uID);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(orders);
            return response;
        }

        private Dictionary<int, int> GetUpdateProdcut(List<Order> list)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    dic.Add(list[i].BuyProduct.PID, list[i].BuyNumber);
                }
            }
            catch (Exception ex)
            {

            }
            return dic;
        }

        /// <summary>
        /// 获取库存修改
        /// </summary>
        /// <returns></returns>
        private List<Order> GetSuccessOrder(Dictionary<int, bool> dic, List<Order> orders)
        {
            List<Order> list = orders;
            foreach (var d in dic)
            {
                if (!d.Value)
                {
                    list.RemoveAll(o => o.BuyProduct.PID == d.Key);
                }
            }
            return list;
        }
    }
}