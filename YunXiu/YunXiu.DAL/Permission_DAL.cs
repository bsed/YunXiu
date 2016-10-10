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
    public class Permission_DAL : IPermission
    {
        public bool AddPermission(Permission permission)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO Permission([PName],p.[PKey],[Describe],[CreateDate]) VALUES(@PName,@Describe,GETDATE())";
                result = DapperHelper.Execute(sql, permission);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeletePermission(int pID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM Permission WHERE [PID]={0}", pID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Permission> GetPermission()
        {
            List<Permission> list = null;
            try
            {
                var sql = "SELECT [PID],[PName],[PKey],[Describe],[CreateDate] FROM Permission";
                list = DapperHelper.Query<Permission>(sql);
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<Permission> GetPermissionByRole(int rID)
        {
            List<Permission> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT p.[PID],p.[PName],p.[PKey],p.[Describe],p.[CreateDate] FROM RolePermission rp ");
                sql.Append("LEFT JOIN Permission p ON p.[PID] = rp.[PID] ");
                sql.Append(string.Format("WHERE rp.[RID]={0}", rID));
                list = DapperHelper.Query<Permission>(sql.ToString());
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<Permission> GetPermissionByUser(int uID)
        {
            List<Permission> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT p.[PID],p.[PName],p.[PKey],p.[Describe],p.[CreateDate] FROM UserPermission up ");
                sql.Append("LEFT JOIN Permission p ON p.[PID] = up.[PID] ");
                sql.Append(string.Format("WHERE up.[UID]={0}", uID));
                list = DapperHelper.Query<Permission>(sql.ToString());
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool UpdatePermission(Permission permission)
        {
            var result = false;
            try
            {
                var sql = "UPDATE Permission SET [PName]=@PName,[PKey]=@PKey,[Describe]=@Describe WHERE [PID]=@PID";
                result = DapperHelper.Execute(sql, permission);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
