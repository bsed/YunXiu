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

        public bool AddMultipleUserPermission(int uID, List<int> pID)
        {
            return dal.AddMultipleUserPermission(uID,pID);
        }

        public bool AddMultipleUserPermission(List<int> uIDList, int pID)
        {
            return dal.AddMultipleUserPermission(uIDList,pID);
        }

        public bool AddPermission(Permission permission)
        {
            return dal.AddPermission(permission);
        }

        public bool AddRolePermission(int rID, int pID)
        {
            return dal.AddRolePermission(rID,pID);
        }

        public bool AddUserPermission(int uID, int pID)
        {
            return dal.AddUserPermission(uID,pID);
        }

        public bool DeleteMultipleUserPermission(int uID, List<int> pID)
        {
            return dal.DeleteMultipleUserPermission(uID,pID);
        }

        public bool DeleteMultipleUserPermission(List<int> uIDList, int pID)
        {
            return dal.DeleteMultipleUserPermission(uIDList,pID);
        }

        public bool DeletePermission(int pID)
        {
            return dal.DeletePermission(pID);
        }

        public bool DeleteRolePermission(int rID, int pID)
        {
            return dal.DeleteRolePermission(rID,pID);
        }

        public bool DeleteUserPermission(int uID, int pID)
        {
            return dal.DeleteUserPermission(uID,pID);
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
