using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.DAL;
using YunXiu.Interface;
using YunXiu.Model;

namespace YunXiu.BLL
{
    public class Bid_BLL : IBid
    {
        Bid_DAL dal = new Bid_DAL();
        public bool AddBid(Bid bid)
        {
            return dal.AddBid(bid);
        }

        public bool DeleteBid(int bID)
        {
            return dal.DeleteBid(bID);
        }

        public List<Bid> GetBidByStore(int sID)
        {
            return dal.GetBidByStore(sID);
        }

        public List<Bid> GetBidByTender(int tID)
        {
            return dal.GetBidByTender(tID);
        }

        public bool UpdateBid(Bid bid)
        {
            return dal.UpdateBid(bid);
        }
    }
}
