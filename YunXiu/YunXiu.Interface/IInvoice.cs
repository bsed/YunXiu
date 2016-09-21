using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IInvoice
    {
        /// <summary>
        /// 创建发货单
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        bool CreateInvoice(Invoice invoice);

        /// <summary>
        /// 根据商铺获取发货单
        /// </summary>
        /// <param name="storeID">商铺ID</param>
        /// <returns></returns>
        List<Invoice> GetInvoiceByStore(int storeID);

        /// <summary>
        /// 根据订单号获取发货单
        /// </summary>
        /// <param name="oID">订单ID</param>
        /// <returns></returns>
        Invoice GetInvoiceByOrder(int oID);

        /// <summary>
        /// 修改发货单
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        bool UpdateInvoice(Invoice invoice);

        /// <summary>
        /// 删除发货单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteInvoice(int id);
    }
}
