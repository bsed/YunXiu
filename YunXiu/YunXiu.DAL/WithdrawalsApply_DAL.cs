using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;
using Dapper;

namespace YunXiu.DAL
{
    public class WithdrawalsApply_DAL : IWithdrawalsApply
    {
        public bool AddWithdrawalsApply(WithdrawalsApply apply)
        {
            var result = false;
            var sql = "INSERT INTO WithdrawalsApply([ApplyUserID],[ApplyAmount],[ApplyStatus]) VALUES(@ApplyUserID,@ApplyAmount,@ApplyStatus)";
            DynamicParameters pars = new DynamicParameters(apply);
            pars.Add("@ApplyUserID", apply.ApplyUser.UID);
            return result;
        }

        public bool DeleteWithdrawalsApply(int aID)
        {
            throw new NotImplementedException();
        }

        public List<WithdrawalsApply> GetWithdrawalsApplyByUser(int uID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateWithdrawalsApply(WithdrawalsApply apply)
        {
            throw new NotImplementedException();
        }
    }
}
