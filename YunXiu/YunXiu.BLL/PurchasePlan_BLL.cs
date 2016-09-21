using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YunXiu.Interface;
using YunXiu.DAL;
using YunXiu.Model;

namespace YunXiu.BLL
{
    public class PurchasePlan_BLL : IPurchasePlan
    {
        PurchasePlan_DAL dal = new PurchasePlan_DAL();

        /// <summary>
        /// 发布采购计划
        /// </summary>
        /// <param name="PurchasePlanModel">采购计划总的实体</param>
        /// <returns></returns>
        public int AddPurchasePlan(PurchasePlan plan)
        {
            return dal.AddPurchasePlan(plan);
        }



        /// <summary>
        /// 查询采购计划
        /// </summary>
        /// <param name="KeyWord">关键字</param>
        /// <param name="PageSize">显示在页面上的数量</param>
        /// <param name="PageNumber">页码</param>
        /// <param name="State">状态</param>
        /// <param name="TotalCount">总数量</param>
        /// <returns></returns>
        public List<PurchasePlanView> ShowPurchasePlan(string KeyWord, int PageSize, int PageNumber, string State, out int TotalCount)
        {
            return dal.ShowPurchasePlan(KeyWord, PageSize, PageNumber, State, out TotalCount);
        }




        /// <summary>
        /// 根据PPID取得采购计划
        /// </summary>
        /// <param name="PPId">采购计划ID</param>
        /// <returns></returns>
        public PurchasePlanView GetPurchasePlanByPPId(int PPId)
        {
            return dal.GetPurchasePlanByPPId(PPId);
        }


        /// <summary>
        /// 删除采购计划
        /// </summary>
        /// <param name="PPId">采购计划ID</param>
        /// <returns></returns>
        public int DeletePurchasePlanByPPId(int PPId)
        {
            return dal.DeletePurchasePlanByPPId(PPId);
        }


        /// <summary>
        /// 更新采购计划
        /// </summary>
        /// <param name="BigModel"></param>
        /// <returns></returns>
        public int UpdatePurchasePlan(PurchasePlanModel BigModel)
        {
            return dal.UpdatePurchasePlan(BigModel);
        }

      

        public List<PurchasePlan> GetPurchasePlanByStoreID(int storeID)
        {
            throw new NotImplementedException();
        }
    }
}
