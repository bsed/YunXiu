using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class BrowseHistorie_BLL : IBrowseHistorie
    {
        BrowseHistorie_DAL dal = new BrowseHistorie_DAL();
        public bool AddBrowseHistorie(BrowseHistorie historie)
        {
            return dal.AddBrowseHistorie(historie);
        }

        public List<BrowseHistorie> GetBrowseHistorieByProduct(int pID)
        {
            return dal.GetBrowseHistorieByProduct(pID);
        }

        public List<BrowseHistorie> GetBrowseHistorieByUser(int uID)
        {
            return dal.GetBrowseHistorieByUser(uID);
        }
    }
}
