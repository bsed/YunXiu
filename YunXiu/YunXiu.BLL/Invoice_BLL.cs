using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.DAL;
using YunXiu.Interface;

namespace YunXiu.BLL
{
    public class Invoice_BLL : IInvoice
    {
        Invoice_DAL dal = new Invoice_DAL();
        public bool CreateInvoice(Invoice invoice)
        {
            return dal.CreateInvoice(invoice);
        }

        public bool DeleteInvoice(int id)
        {
            return dal.DeleteInvoice(id);
        }

        public Invoice GetInvoiceByOrder(int oID)
        {
            return dal.GetInvoiceByOrder(oID);
        }

        public List<Invoice> GetInvoiceByStore(int storeID)
        {
            return dal.GetInvoiceByStore(storeID);
        }

        public bool UpdateInvoice(Invoice invoice)
        {
            return dal.UpdateInvoice(invoice);
        }
    }
}
