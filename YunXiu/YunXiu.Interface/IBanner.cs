using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IBanner
    {
        /// <summary>
        /// 添加横幅
        /// </summary>
        /// <param name="banner">横幅</param>
        /// <returns>是否删除成功</returns>
        bool AddBanner(Banner banner);

        /// <summary>
        /// 删除横幅
        /// </summary>
        /// <param name="bID">横幅ID</param>
        /// <returns>是否删除成功</returns>
        bool DeleteBanner(int bID);

        /// <summary>
        /// 修改横幅
        /// </summary>
        /// <param name="banner"></param>
        /// <returns>是否修改成功</returns>
        bool UpdateBanner(Banner banner);

        /// <summary>
        /// 获取横幅
        /// </summary>
        /// <returns></returns>
        List<Banner> GetBanner();

        /// <summary>
        /// 获取横幅(指定条数)
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        List<Banner> GetBanner(int count);

        Banner GetBannerByID(int bID);
    }
}
