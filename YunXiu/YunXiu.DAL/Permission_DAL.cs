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
                var sql = "INSERT INTO Permission([PName],[PKey],[PTypeID],[Describe],[CreateDate]) VALUES(@PName,@PKey,@PTypeID,@Describe,GETDATE())";
                DynamicParameters pars = new DynamicParameters(permission);
                pars.Add("@PTypeID", permission.PType.TID);
                result = DapperHelper.Execute(sql, pars);
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
                var sql = new StringBuilder();
                sql.Append("SELECT p.[PID],p.[PName],p.[PKey],p.[Describe],p.[CreateDate],pt.[TID],pt.[TName] FROM Permission p ");
                sql.Append("LEFT JOIN PermissionType pt ON pt.[TID]= p.[PTypeID]");
                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<Permission, PermissionType, Permission>(sql.ToString(),
                        (p, pt) =>
                        {
                            p.PType = pt;
                            return p;
                        },
                        null,
                        null,
                        true,
                        "PID,TID",
                        null,
                        null
                        ).ToList();
                }
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
                sql.Append("SELECT p.[PID],p.[PName],p.[PKey],p.[Describe],p.[CreateDate],pt.[TID],pt.[TName] FROM RolePermission rp ");
                sql.Append("LEFT JOIN Permission p ON p.[PID] = rp.[PID] ");
                sql.Append("LEFT JOIN PermissionType pt ON pt.[TID]= p.[PTypeID] ");
                sql.Append(string.Format("WHERE rp.[RID]={0}", rID));
                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<Permission, PermissionType, Permission>(sql.ToString(),
                        (p, pt) =>
                        {
                            p.PType = pt;
                            return p;
                        },
                        null,
                        null,
                        true,
                        "PID,TID",
                        null,
                        null
                        ).ToList();
                }
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
                sql.Append("SELECT p.[PID],p.[PName],p.[PKey],p.[Describe],p.[CreateDate],pt.[TID],pt.[TName] FROM UserPermission up ");
                sql.Append("LEFT JOIN Permission p ON p.[PID] = up.[PID] ");
                sql.Append("LEFT JOIN PermissionType pt ON pt.[TID]= p.[PTypeID] ");
                sql.Append(string.Format("WHERE up.[UID]={0}", uID));
                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<Permission, PermissionType, Permission>(sql.ToString(),
                        (p, pt) =>
                        {
                            p.PType = pt;
                            return p;
                        },
                        null,
                        null,
                        true,
                        "PID,TID",
                        null,
                        null
                        ).ToList();
                }
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
                var procName = "AddRolePermission";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@rID", rID);
                pars.Add("@pID", pID);
                result = DapperHelper.ExecuteProc(procName, pars) > 0;
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
                var sql = "UPDATE Permission SET [PName]=@PName,[PKey]=@PKey,[PTypeID]=@PTypeID,[Describe]=@Describe WHERE [PID]=@PID";
                DynamicParameters pars = new DynamicParameters(permission);
                pars.Add("@PTypeID",permission.PType.TID);
                result = DapperHelper.Execute(sql, pars);
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
