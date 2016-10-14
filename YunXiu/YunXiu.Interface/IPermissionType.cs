using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IPermissionType
    {
        bool AddPermissionType(PermissionType type);

        bool DeletePermissionType(int tID);

        bool UpdatePermissionType(PermissionType type);

        List<PermissionType> GetPermissionType();
    }
}
