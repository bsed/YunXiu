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
    public class UserRanks_BLL:IUserRanks
    {
        UserRanks_DAL _dal = new UserRanks_DAL();


        public UserRanks GetUserRankByCredits(int Credit)
        {
            return _dal.GetUserRankByCredits(Credit);
        }

        public List<UserRanks> GetUserRankList()
        {
            return _dal.GetUserRankList();
        }

        public int AddUserRank(UserRanks Item)
        {
            return _dal.AddUserRank(Item);
        }

        public int DelelteUserRank(int UserRid)
        {
            return _dal.DelelteUserRank(UserRid);
        }

        public int UpdateUserRank(UserRanks Item)
        {
            return _dal.UpdateUserRank(Item);
        }

        public UserRanks GetUserRankInfoByUid(int Uid)
        {
            return _dal.GetUserRankInfoByUid(Uid);
        }
    }
}
