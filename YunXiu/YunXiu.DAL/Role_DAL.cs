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

        public bool UpdateRole(Role role)
        {
            var result = false;
            try
            {
                var sql = "UPDATE Role SET [RName]=@RName,[Describe]=@Describe WHERE [RID]=@RID";
                result = DapperHelper.Execute(sql,role);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
