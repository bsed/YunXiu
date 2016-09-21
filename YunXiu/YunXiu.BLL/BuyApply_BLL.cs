using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.DAL;
using YunXiu.Model;
using YunXiu.Interface;

namespace YunXiu.BLL
{
    public class BuyApply_BLL : IBuyApply
    {
        BuyApply_DAL dal = new BuyApply_DAL();
        public bool CreateBuyApply(BuyApply apply)
        {
            return dal.CreateBuyApply(apply);
        }
    }
}
