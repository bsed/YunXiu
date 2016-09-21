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
    public class User_BLL:IUser
    {
        User_DAL _dal = new User_DAL();
        public int InsertUser(User Item)
        {
            return _dal.InsertUser(Item);
        }

        public User GetUserByUid(int Uid)
        {
            return _dal.GetUserByUid(Uid);
        }

        public User GetPartUserByAccountID(Guid Account_ClientGuid)
        {
            return _dal.GetPartUserByAccountID(Account_ClientGuid);
        }

        public Userdetails GetUserDetailsByUid(int Uid)
        {
            return _dal.GetUserDetailsByUid(Uid);
        }

        public int UpdateUserRankByUid(int Uid, int UserRid)
        {
            return _dal.UpdateUserRankByUid( Uid,  UserRid);
        }

        public int UpdateUserLiftBanTimeByUid(int Uid, DateTime liftBanTime)
        {
            return _dal.UpdateUserLiftBanTimeByUid(Uid, liftBanTime);
        }

        public int UpdateUserOnlineTime(int Uid, int OnlieTime)
        {
            return _dal.UpdateUserOnlineTime( Uid,  OnlieTime);
        }

        public int UpdatePartUser(User Item)
        {
            return _dal.UpdatePartUser(Item);
        }

        public int ChangePwd(int Uid, string Pwd)
        {
            return _dal.ChangePwd(Uid, Pwd);
        }

        public int UpdateUserEmailByUid(int Uid, string email)
        {
            return _dal.UpdateUserEmailByUid(Uid, email);
        }

        public int UpdateUserMobileByUid(int Uid, string mobile)
        {
            return _dal.UpdateUserMobileByUid(Uid, mobile);
        }

        public bool UpdateVerifyMobileState(int uID, bool isVerifyMobile)
        {
            return _dal.UpdateVerifyMobileState(uID,isVerifyMobile);
        }

        public bool UpdateVerifyEmailState(int uID, bool isVerifyEmail)
        {
            return _dal.UpdateVerifyEmailState(uID,isVerifyEmail);
        }
    }
}
