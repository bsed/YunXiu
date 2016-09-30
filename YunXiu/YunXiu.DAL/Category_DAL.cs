using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using YunXiu.Model;
using YunXiu.Commom;
using YunXiu.Interface;
using Dapper;

namespace YunXiu.DAL
{
    public class Category_DAL : ICategory
    {
        public bool AddCategory(Category category)
        {
            var result = false;
            try
            {
                var procName = "AddCategory";
                //var nowData = DateTime.Now;
                //var sql = "INSERT INTO Category([Sort],[Name],[ParentID],[Layer],[Path],[HasChild],[CreateDate],[CreateUser],[LastUpdateDate],[LastUpdateUser]) VALUES(@Sort,@Name,@ParentID,@Layer,@Path,@HasChild,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser)";
                //var pars = new List<SqlParameter>();
                //pars.Add(new SqlParameter("@Sort", category.Sort));
                //pars.Add(new SqlParameter("@Name", category.Name));
                //pars.Add(new SqlParameter("@ParentID", category.ParentId));
                //pars.Add(new SqlParameter("@Layer", category.Layer));
                //pars.Add(new SqlParameter("@Path", category.Path));
                //pars.Add(new SqlParameter("@HasChild", category.HasChild));
                //pars.Add(new SqlParameter("@CreateDate", nowData));
                //pars.Add(new SqlParameter("@CreateUser", category.CreateUser != null ? category.CreateUser.UID : 0));
                //pars.Add(new SqlParameter("@LastUpdateDate", nowData));
                //pars.Add(new SqlParameter("@LastUpdateUser", category.LastUpdateUser != null ? category.LastUpdateUser.UID : 0));
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@Name", category.Name);
                pars.Add("@ParentID", category.ParentId);
                result = DapperHelper.ExecuteProc(procName, pars) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteCategory(int cID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM Category WHERE [CateID]={0}", cID);
                result = SQLHelper.ExcuteSQL(sql) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Category> GetCategory()
        {
            var list = new List<Category>();
            try
            {
                var sql = "SELECT [CateID],[Sort],[Name],[ParentID],[Layer],[Path],[HasChild],[CreateDate],[LastUpdateDate] FROM Category";
                var dt = SQLHelper.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Category
                    {
                        CateId = Convert.ToInt32(dt.Rows[i]["CateID"]),
                        Sort = Convert.IsDBNull(dt.Rows[i]["Sort"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Name = Convert.IsDBNull(dt.Rows[i]["Name"]) ? "" : Convert.ToString(dt.Rows[i]["Name"]),
                        ParentId = Convert.IsDBNull(dt.Rows[i]["ParentID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ParentID"]),
                        Layer = Convert.IsDBNull(dt.Rows[i]["Layer"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Layer"]),
                        Path = Convert.IsDBNull(dt.Rows[i]["Path"]) ? "" : Convert.ToString(dt.Rows[i]["Path"]),
                        HasChild = Convert.IsDBNull(dt.Rows[i]["HasChild"]) ? 0 : Convert.ToInt32(dt.Rows[i]["HasChild"]),
                        CreateDate = Convert.IsDBNull(dt.Rows[i]["CreateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[i]["CreateDate"]),                    
                        LastUpdateDate = Convert.IsDBNull(dt.Rows[i]["LastUpdateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[i]["LastUpdateDate"]),
                    
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public Category GetCategoryByID(int cID)
        {
            Category cate = null ;
            try
            {
                var sql = string.Format("SELECT [CateID],[Sort],[Name],[ParentId],[Layer],[Path],[HasChild],[CreateDate],[LastUpdateDate] FROM Category WHERE [CateID]={0}", cID);
                cate = DapperHelper.QuerySingle<Category>(sql);
            }
            catch (Exception ex)
            {

            }
            return cate;
        }

        /// <summary>
        /// 获取类目以及类目的子ID
        /// </summary>
        /// <param name="cID">类目父ID</param>
        /// <returns>类目集合</returns>
        public List<int> GetCategoryChildren(int cID)
        {
            var list = new List<int>();
            try
            {
                #region 递归SQL
                var sql = new StringBuilder();
                sql.Append("WITH cte AS ");
                sql.Append("( ");
                sql.Append("SELECT CateID,ParentID,0 AS lvl FROM Category ");
                sql.Append(string.Format("WHERE CateID = {0} ", cID));
                sql.Append("UNION ALL ");
                sql.Append("SELECT c.CateID,c.ParentID,lvl+1 FROM cte c2 inner join Category c ");
                sql.Append(" ON c2.CateID = c.ParentID ");
                sql.Append(") ");
                sql.Append("SELECT * FROM cte");
                #endregion
                var dt = SQLHelper.GetTable(sql.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(Convert.ToInt32(dt.Rows[i]["CateID"]));
                }

            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool UpdateCategory(Category category)
        {
            var result = false;
            try
            {
                var sql = "UPDATE Category SET [Sort]=@Sort,[Name]=@Name,[ParentID]=@ParentID,[Layer]=@Layer,[Path]=@Path,[HasChild]=@HasChild,[LastUpdateDate]=@LastUpdateDate,[LastUpdateUser]=@LastUpdateUser WHERE CateID=@CateID";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@CateID", category.CateId));
                pars.Add(new SqlParameter("@Sort", category.Sort));
                pars.Add(new SqlParameter("@Name", category.Name));
                pars.Add(new SqlParameter("@ParentID", category.ParentId));
                pars.Add(new SqlParameter("@Layer", category.Layer));
                pars.Add(new SqlParameter("@Path", category.Path));
                pars.Add(new SqlParameter("@HasChild", category.HasChild));
                pars.Add(new SqlParameter("@LastUpdateDate", DateTime.Now));
                pars.Add(new SqlParameter("@LastUpdateUser", category.LastUpdateUser != null ? category.LastUpdateUser.UID : 0));
                result = SQLHelper.ExcuteSQL(sql, pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
