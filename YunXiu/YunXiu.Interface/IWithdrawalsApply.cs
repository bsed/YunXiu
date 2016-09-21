using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
  public  interface IWithdrawalsApply
    {

        bool AddWithdrawalsApply(WithdrawalsApply apply);

        bool UpdateIWithdrawalsApply(WithdrawalsApply apply);

        bool DeleteWithdrawalsApply(int aID);

        List<WithdrawalsApply> GetWithdrawalsApplyByUser(int uID);

    }
}
