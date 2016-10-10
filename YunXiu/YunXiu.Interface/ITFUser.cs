using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface ITFUser
    {
        TFUser Login(string account, string pwd);

        TFUser GetTFUserByID(int uid);

        TFUser EmailLogin(string email, string pwd);

        TFUser PhoneLogin(string phone,string pwd);

        List<TFUser> GetTFUser(List<string> uIDList);

        bool CheckTFUserAccount(string account);

    }
}
