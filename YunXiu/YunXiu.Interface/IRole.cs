using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IRole
    {
        bool AddRole(Role role);

        bool AddUserRole(int uID,int rID);

        bool UpdateRole(Role role);

        bool DeleteRole(int rID);

        List<Role> GetRole();

        List<Role> GetRoleByUser(int uID);

        List<User> GetUserByRole(int rID);

    }
}
