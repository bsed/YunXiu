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

     
    }
}
