using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;
using Dapper;
using System.Data;

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

        public bool AddRolePermission(int rID, int pID)
        {
            var result = false;
            try
            {
                var sql = string.Format("INSERT INTO RolePermission([RID],[PID]) VALUES({0},{1})", rID, pID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool AddUserPermission(int uID, int pID)
        {
            var result = false;
            try
            {
                var sql = string.Format("INSERT INTO UserPermission([UID],[PID]) VALUES({0},{1})", uID, pID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
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

        public bool DeleteRolePermission(int rID, int pID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM RolePermission WHERE [RID]={0} AND [PID]={1}", rID, pID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteUserPermission(int uID, int pID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM UserPermission WHERE [UID]={0} AND [PID]={1}", uID, pID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteMultipleUserPermission(List<int> uIDList, int pID)
        {
            var result = false;
            var sql = string.Format("DELETE FROM UserPermission WHERE [UID] IN ({0}) AND [PID]={1}", string.Join(",", uIDList), pID);
            result = DapperHelper.Execute(sql);
            return result;
        }

        public bool AddMultipleUserPermission(List<int> uIDList, int pID)
        {
            var result = false;
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("UPID"));
            table.Columns.Add(new DataColumn("PID"));
            table.Columns.Add(new DataColumn("UID"));
            for (var i = 0; i < uIDList.Count; i++)
            {
                DataRow r = table.NewRow();
                r["PID"] = pID;
                r["UID"] = uIDList[i];
                table.Rows.Add(r);
            }

            SQLHelper.BulkToDB(table, "UserPermission");
            result = true;
            return result;
        }

        public bool AddMultipleUserPermission(int uID, List<int> pID)
        {
            var result = false;
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("UPID"));
            table.Columns.Add(new DataColumn("PID"));
            table.Columns.Add(new DataColumn("UID"));
            for (var i = 0; i < pID.Count; i++)
            {
                DataRow r = table.NewRow();
                r["PID"] = pID[i];
                r["UID"] = uID;
                table.Rows.Add(r);
            }

            SQLHelper.BulkToDB(table, "UserPermission");
            result = true;
            return result;
        }

        public bool DeleteMultipleUserPermission(int uID, List<int> pID)
        {
            var result = false;
            var sql = string.Format("DELETE FROM UserPermission WHERE [UID] = {0} AND [PID] IN ({1})", uID, string.Join(",", pID));
            result = DapperHelper.Execute(sql);
            return result;
        }
    }
}
