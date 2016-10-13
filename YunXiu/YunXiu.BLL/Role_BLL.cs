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
    public class Role_BLL : IRole
    {
        Role_DAL dal = new Role_DAL();
        public bool AddRole(Role role)
        {
            return dal.AddRole(role);
        }

        public bool AddUserRole(int uID, int rID)
        {
            return dal.AddUserRole(uID, rID);
        }

        public bool DeleteRole(int rID)
        {
            return dal.DeleteRole(rID);
        }

        public bool DeleteUserRole(int uID, int rID)
        {
            return dal.DeleteUserRole(uID,rID);
        }

        public List<Role> GetRole()
        {
            return dal.GetRole();
        }

        public List<Role> GetRoleByUser(int uID)
        {
            return dal.GetRoleByUser(uID);
        }

        public List<User> GetUserByRole(int rID)
        {
            return dal.GetUserByRole(rID);
        }

        public bool UpdateRole(Role role)
        {
            return dal.UpdateRole(role);
        }
    }
}
