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
    public class TFUser_BLL : ITFUser
    {
        TFUser_DAL dal = new TFUser_DAL();

        public bool CheckTFUserAccount(string account)
        {
            return dal.CheckTFUserAccount(account);
        }

        public TFUser EmailLogin(string email, string pwd)
        {
            return dal.EmailLogin(email,pwd);
        }

        public List<TFUser> GetTFUser(List<string> uIDList)
        {
            return dal.GetTFUser(uIDList);
        }

        public TFUser GetTFUserByID(int uid)
        {
            return dal.GetTFUserByID(uid);
        }

        public TFUser Login(string account, string pwd)
        {
            return dal.Login(account,pwd);
        }

        public TFUser PhoneLogin(string phone, string pwd)
        {
            return dal.PhoneLogin(phone,pwd);
        }
    }
}
