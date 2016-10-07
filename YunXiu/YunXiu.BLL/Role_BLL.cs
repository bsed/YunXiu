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

        public bool DeleteRole(int rID)
        {
            return dal.DeleteRole(rID);
        }

        public List<Role> GetRole()
        {
            return dal.GetRole();
        }

        public bool UpdateRole(Role role)
        {
            return dal.UpdateRole(role);
        }
    }
}
