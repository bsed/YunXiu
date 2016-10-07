using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class Permission_BLL : IPermission
    {
        Permission_DAL dal = new Permission_DAL();
        public bool AddPermission(Permission permission)
        {
            return dal.AddPermission(permission);
        }

        public bool DeletePermission(int pID)
        {
            return dal.DeletePermission(pID);
        }

        public List<Permission> GetPermission()
        {
            return dal.GetPermission();
        }

        public List<Permission> GetPermissionByRole(int rID)
        {
            return dal.GetPermissionByRole(rID);
        }

        public List<Permission> GetPermissionByUser(int uID)
        {
            return dal.GetPermissionByUser(uID);
        }

        public bool UpdatePermission(Permission permission)
        {
            return dal.UpdatePermission(permission);
        }
    }
}
