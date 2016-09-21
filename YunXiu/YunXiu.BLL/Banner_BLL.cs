using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class Banner_BLL : IBanner
    {
        Banner_DAL dal = new Banner_DAL();
        public bool AddBanner(Banner banner)
        {
            return dal.AddBanner(banner);
        }

        public bool DeleteBanner(int bID)
        {
            return dal.DeleteBanner(bID);
        }

        public List<Banner> GetBanner()
        {
            return dal.GetBanner();
        }

        public List<Banner> GetBanner(int count)
        {
            return dal.GetBanner(count);
        }

        public Banner GetBannerByID(int bID)
        {
            return dal.GetBannerByID(bID);
        }

        public bool UpdateBanner(Banner banner)
        {
            return dal.UpdateBanner(banner);
        }
    }
}
