using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IUser
    {
      
        List<User> GetUser();

        List<User> GetMultiUserByID(List<string> guid);

        User GetUserByID(string guid);

        bool CreateUser(string guid);
    }
}
