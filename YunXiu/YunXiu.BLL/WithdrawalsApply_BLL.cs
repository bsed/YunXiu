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
    public class WithdrawalsApply_BLL : IWithdrawalsApply
    {
        WithdrawalsApply_DAL dal = new WithdrawalsApply_DAL();
        public bool AddWithdrawalsApply(WithdrawalsApply apply)
        {
            return dal.AddWithdrawalsApply(apply);
        }

        public bool DeleteWithdrawalsApply(int aID)
        {
            return dal.DeleteWithdrawalsApply(aID);
        }

        public List<WithdrawalsApply> GetWithdrawalsApplyByUser(int uID)
        {
            return dal.GetWithdrawalsApplyByUser(uID);
        }

        public bool UpdateWithdrawalsApply(WithdrawalsApply apply)
        {
            return dal.UpdateWithdrawalsApply(apply);
        }
    }
}
