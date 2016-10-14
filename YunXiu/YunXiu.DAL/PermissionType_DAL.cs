using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;
using Dapper;

namespace YunXiu.DAL
{
    public class PermissionType_DAL : IPermissionType
    {
        public bool AddPermissionType(PermissionType type)
        {
            var result = false;
            var sql = "INSERT INTO PermissionType(TName,CreateDate) VALUES(@TName,GETDATE())";
            result = DapperHelper.Execute(sql, type);
            return result;
        }

        public bool DeletePermissionType(int tID)
        {
            var result = false;
            var sql = string.Format("DELETE FROM PermissionType WHERE [TID]={0}", tID);
            result = DapperHelper.Execute(sql);
            return result;
        }

        public List<PermissionType> GetPermissionType()
        {
            List<PermissionType> list = null;
            var sql = "SELECT [TID],[TName],[CreateDate] FROM PermissionType";
            list = DapperHelper.Query<PermissionType>(sql);
            return list;
        }

        public bool UpdatePermissionType(PermissionType type)
        {
            var result = false;
            var sql = "UPDATE PermissionType SET [TName]=@TName WHERE [TID]=@TID";
            result = DapperHelper.Execute(sql, type);
            return result;
        }
    }
}
