using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
   public interface ITenderAccept
    {
        bool AddTenderAccept(TenderAccept aID);

        bool UpdateTenderAccept(TenderAccept aID);

        bool DeleteTenderAccept(int aID);

        List<TenderAccept> GetTenderAcceptByStore(int sID);

        List<TenderAccept> GetBidByTender(int tID);
    }
}
