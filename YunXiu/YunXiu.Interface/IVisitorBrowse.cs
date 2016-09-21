using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IVisitorBrowse
    {
        /// <summary>
        /// 添加游客访问记录
        /// </summary>
        /// <param name="list">游客访问集合</param>
        /// <returns></returns>
        bool AddVisitorBrowse(List<VisitorBrowse> list);
        /// <summary>
        /// 获取UV量
        /// </summary>
        /// <returns></returns>
        int GetUV(DateTime startDate, DateTime endDate);

        /// <summary>
        /// 获取PV量
        /// </summary>
        /// <returns></returns>
        int GetPV(DateTime startDate, DateTime endDate);
    }
}
