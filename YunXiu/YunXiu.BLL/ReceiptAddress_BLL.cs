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
    public class ReceiptAddress_BLL : IReceiptAddress
    {
        ReceiptAddress_DAL dal = new ReceiptAddress_DAL();
        public bool AddReceiptAddress(ReceiptAddress receiptAddress)
        {
            return dal.AddReceiptAddress(receiptAddress);
        }

        public bool DeleteReceiptAddress(int id)
        {
            return dal.DeleteReceiptAddress(id);
        }

        public List<ReceiptAddress> GetReceiptAddress(int userID)
        {
            return dal.GetReceiptAddress(userID);
        }

        public bool SetDefaultAddr(int uID, int id)
        {
            return dal.SetDefaultAddr(uID,id);
        }

        public bool UpdateReceiptAddress(ReceiptAddress receiptAddress)
        {
            return dal.UpdateReceiptAddress(receiptAddress);
        }
    }
}
