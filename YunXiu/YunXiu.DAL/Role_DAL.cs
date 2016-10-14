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
    public class Role_DAL : IRole
    {
        public bool AddRole(Role role)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO Role([RName],[Describe],[CreateDate]) VALUES(@RName,@Describe,GETDATE())";
                result = DapperHelper.Execute(sql, role);
            }
            catch (Exception ex)
            {

            }
            return result;
        }


        public bool AddUserRole(int uID, int rID)
        {
            var result = false;
            var procName = "AddUserRole";
            DynamicParameters pars = new DynamicParameters();
            pars.Add("@uID",uID);
            pars.Add("@rID", rID);
            result = DapperHelper.ExecuteProc(procName, pars)>0;
            return result;
        }

        public bool DeleteRole(int rID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM Role WHERE [RID]={0}", rID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteUserRole(int uID, int rID)
        {
            var result = false;
            var sql =string.Format("DELETE FROM UserRole WHERE [UID]={0} AND [RID]={1}",uID,rID);
            result = DapperHelper.Execute(sql);
            return result;
        }

        public List<Role> GetRole()
        {
            List<Role> list = null;
            try
            {
                var sql = "SELECT [RID],[RName],[Describe],[CreateDate] FROM Role";
                list = DapperHelper.Query<Role>(sql);
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<Role> GetRoleByUser(int uID)
        {
            List<Role> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT r.[RID],r.[RName],r.[Describe],r.[CreateDate] FROM UserRole ur ");
                sql.Append("LEFT JOIN [Role] r ON r.[RID]= ur.[RID] ");
                sql.Append(string.Format("WHERE ur.[UID]={0}", uID));
                list = DapperHelper.Query<Role>(sql.ToString());
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<User> GetUserByRole(int rID)
        {
            List<User> list = null;
            var sql = new StringBuilder();
            sql.Append("SELECT u.[UID],u.[client_guid] FROM UserRole ur ");
            sql.Append("LEFT JOIN [User] u ON u.[UID]= ur.[UID] ");
            sql.Append(string.Format("WHERE ur.[RID]={0}", rID));
            list = DapperHelper.Query<User>(sql.ToString());
            return list;
        }

        public bool UpdateRole(Role role)
        {
            var result = false;
            try
            {
                var sql = "UPDATE Role SET [RName]=@RName,[Describe]=@Describe WHERE [RID]=@RID";
                result = DapperHelper.Execute(sql, role);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
