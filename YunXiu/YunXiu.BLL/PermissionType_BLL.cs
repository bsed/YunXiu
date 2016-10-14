using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class PermissionType_BLL : IPermissionType
    {
        PermissionType_DAL dal = new PermissionType_DAL();
        public bool AddPermissionType(PermissionType type)
        {
            return dal.AddPermissionType(type);
        }

        public bool DeletePermissionType(int tID)
        {
            return dal.DeletePermissionType(tID);
        }

        public List<PermissionType> GetPermissionType()
        {
            return dal.GetPermissionType();
        }

        public bool UpdatePermissionType(PermissionType type)
        {
            return dal.UpdatePermissionType(type);
        }
    }
}
