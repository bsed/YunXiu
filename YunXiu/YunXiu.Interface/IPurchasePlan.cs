using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YunXiu.Model;
namespace YunXiu.Interface
{
    public interface IPurchasePlan
    {
        /// <summary>
        /// 发布采购计划
        /// </summary>
        /// <param name="PurchasePlanModel">采购计划总的实体</param>
        /// <returns></returns>
        int AddPurchasePlan(PurchasePlan plan);

        List<PurchasePlan> GetPurchasePlanByStoreID(int storeID);
        
        /// <summary>
        /// 查询采购计划
        /// </summary>
        /// <param name="KeyWord">关键字</param>
        /// <param name="PageSize">显示在页面上的数量</param>
        /// <param name="PageNumber">页码</param>
        /// <param name="State">状态</param>
        /// <param name="TotalCount">总数量</param>
        /// <returns></returns>
        List<PurchasePlanView> ShowPurchasePlan(string KeyWord, int PageSize, int PageNumber, string State, out int TotalCount);


        /// <summary>
        /// 根据PPID取得采购计划
        /// </summary>
        /// <param name="PPId">采购计划ID</param>
        /// <returns></returns>
        PurchasePlanView GetPurchasePlanByPPId(int PPId);


        /// <summary>
        /// 删除采购计划
        /// </summary>
        /// <param name="PPId">采购计划ID</param>
        /// <returns></returns>
        int DeletePurchasePlanByPPId(int PPId);


        /// <summary>
        /// 更新采购计划
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        int UpdatePurchasePlan(PurchasePlanModel Item);

    }
}
