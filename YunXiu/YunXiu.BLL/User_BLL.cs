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
        User_DAL dal = new User_DAL();

        public bool CreateUser(string guid)
        {
            return dal.CreateUser(guid);
        }

        public List<User> GetMultiUserByID(List<string> guid)
        {
            return dal.GetMultiUserByID(guid);
        }

        public List<User> GetUser()
        {
            return dal.GetUser();
        }

        public User GetUserByID(string guid)
        {
            return dal.GetUserByID(guid);
        }
    }
}
