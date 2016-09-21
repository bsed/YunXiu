using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IBid
    {
        bool AddBid(Bid bid);

        bool UpdateBid(Bid bid);

        bool DeleteBid(int bID);

        List<Bid> GetBidByStore(int sID);

        List<Bid> GetBidByTender(int tID);
    }
}
