using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YunXiu.Model;

namespace YunXiu.Interface
{
    /// <summary>
    /// 招标
    /// </summary>
    public interface ITender
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="ExtList"></param>
        /// <returns></returns>
        int AddTender(Tender tender);

        /// <summary>
        /// 删除标书
        /// </summary>
        /// <param name="TTId"></param>
        /// <returns></returns>
        bool DeleteTender(int tID);


        /// <summary>
        /// 更新标书
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="ExtList"></param>
        /// <returns></returns>
        bool UpdateTender(Tender tender);

        List<Tender> GetTender(int uID);


        List<Tender> GetTenderByKey(int uID, string key);

    }
}
