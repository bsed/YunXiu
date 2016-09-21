using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YunXiu.Interface;
using YunXiu.DAL;
using YunXiu.Model;

namespace YunXiu.BLL
{
    public class Tender_BLL:ITender
    {
        Tender_DAL dal = new Tender_DAL();

        public int AddTender(Tender tender)
        {
            return dal.AddTender(tender);
        }

        public bool DeleteTender(int tID)
        {
            return dal.DeleteTender(tID);
        }

        public List<Tender> GetTender(int uID)
        {
            return dal.GetTender(uID);
        }

        public List<Tender> GetTenderByKey(int uID, string key)
        {
            return dal.GetTenderByKey(uID,key);
        }

        public bool UpdateTender(Tender tender)
        {
            return dal.UpdateTender(tender);
        }
    }
}
