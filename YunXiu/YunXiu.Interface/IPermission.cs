using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IPermission
    {
        bool AddPermission(Permission permission);

        bool UpdatePermission(Permission permission);

        bool DeletePermission(int pID);

        List<Permission> GetPermission();

        List<Permission> GetPermissionByRole(int rID);

        List<Permission> GetPermissionByUser(int uID);

        bool AddRolePermission(int rID,int pID);

        bool AddUserPermission(int uID,int pID);
        bool AddMultipleUserPermission(List<int> uIDList, int pID);

        bool AddMultipleUserPermission(int uID, List<int> pID);

        bool DeleteRolePermission(int rID,int pID);

        bool DeleteUserPermission(int uID,int pID);

        bool DeleteMultipleUserPermission(List<int> uIDList,int pID);

        bool DeleteMultipleUserPermission(int uID, List<int> pID);
    }
}
