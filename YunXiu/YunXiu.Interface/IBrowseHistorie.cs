using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IBrowseHistorie
    {
        bool AddBrowseHistorie(BrowseHistorie historie);

        List<BrowseHistorie> GetBrowseHistorieByUser(int uID);

        List<BrowseHistorie> GetBrowseHistorieByProduct(int pID);
    }
}
