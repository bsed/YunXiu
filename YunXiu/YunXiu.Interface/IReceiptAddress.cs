using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IReceiptAddress
    {
        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <param name="receiptAddress">收货地址</param>
        /// <returns>是否删除成功</returns>
        bool AddReceiptAddress(ReceiptAddress receiptAddress);

        /// <summary>
        /// 删除收货地址
        /// </summary>
        /// <param name="id">收货地址ID</param>
        /// <returns>是否删除成功</returns>
        bool DeleteReceiptAddress(int id);

        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="receiptAddress"></param>
        /// <returns>是否修改成功</returns>
        bool UpdateReceiptAddress(ReceiptAddress receiptAddress);

        /// <summary>
        /// 获取用户收货地址
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>收货地址集合</returns>
        List<ReceiptAddress> GetReceiptAddress(int userID);

        bool SetDefaultAddr(int uID,int id);
    }
}
