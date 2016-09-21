using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using YunXiu.Commom;
using YunXiu.Interface;
using YunXiu.Model;

namespace YunXiu.DAL
{
    public class Banner_DAL : IBanner
    {
        public bool AddBanner(Banner banner)
        {
            var result = false;
            try
            {
                var nowDate = DateTime.Now;
                var sql = new StringBuilder("INSERT INTO Banner ");
                sql.Append("([StartDate],[EndDate],[IsShow],[Title],[Img],[Sort],[CreateDate],[CreateUser],[LastUpdateDate],[LastUpdateUser]) ");
                sql.Append("VALUES(@StartDate,@EndDate,@IsShow,@Title,@Img,@Sort,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser)");
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@StartDate", banner.StartDate));
                pars.Add(new SqlParameter("@EndDate", banner.EndDate));
                pars.Add(new SqlParameter("@IsShow", banner.IsShow));
                pars.Add(new SqlParameter("@Title", banner.Title));
                pars.Add(new SqlParameter("@Img", banner.Img));
                pars.Add(new SqlParameter("@Sort", banner.Sort));
                pars.Add(new SqlParameter("@CreateDate", nowDate));
                pars.Add(new SqlParameter("@CreateUser", banner.CreateUser != null ? banner.CreateUser.UID : 0));
                pars.Add(new SqlParameter("@LastUpdateDate", nowDate));
                pars.Add(new SqlParameter("@LastUpdateUser", banner.LastUpdateUser != null ? banner.LastUpdateUser.UID : 0));
                result = SQLHelper.ExcuteSQL(sql.ToString(), pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteBanner(int bID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM Banner WHERE ID={0} ", bID);
                result = SQLHelper.ExcuteSQL(sql) > 0;
            }
            catch (Exception ex) { }
            return result;
        }

        public List<Banner> GetBanner()
        {
            var list = new List<Banner>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT [ID],[StartDate],[EndDate],[Title],[Img],[Sort],[CreateDate],[CreateUser],[LastUpdateDate],[LastUpdateUser] ");
                sql.Append("FROM Banner WHERE IsShow=1 AND GETDATE()>StartDate AND GETDATE()<EndDate");

                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Banner
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                        StartDate = Convert.ToDateTime(dt.Rows[i]["StartDate"]),
                        EndDate = Convert.ToDateTime(dt.Rows[i]["EndDate"]),
                        Title = Convert.ToString(dt.Rows[i]["Title"]),
                        Img = Convert.ToString(dt.Rows[i]["Img"]),
                        Sort = Convert.ToInt32(dt.Rows[i]["Sort"]),
                        CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]),
                        CreateUser = new User
                        {

                        },
                        LastUpdateDate = Convert.ToDateTime(dt.Rows[i]["LastUpdateDate"]),
                        LastUpdateUser = new User
                        {

                        }
                    };
                    list.Add(obj);
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<Banner> GetBanner(int count)
        {
            var list = new List<Banner>();
            try
            {
                var sql = new StringBuilder();
                sql.Append(string.Format("SELECT TOP {0} [ID],[StartDate],[EndDate],[Title],[Img],[Sort],[CreateDate],[CreateUser],[LastUpdateDate],[LastUpdateUser] ", count));
                sql.Append("FROM Banner WHERE IsShow=1 AND GETDATE()>StartDate AND GETDATE()<EndDate");

                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Banner
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                        StartDate = Convert.ToDateTime(dt.Rows[i]["StartDate"]),
                        EndDate = Convert.ToDateTime(dt.Rows[i]["EndDate"]),
                        Title = Convert.ToString(dt.Rows[i]["Title"]),
                        Img = Convert.ToString(dt.Rows[i]["Img"]),
                        Sort = Convert.ToInt32(dt.Rows[i]["Sort"]),
                        CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]),
                        CreateUser = new User
                        {

                        },
                        LastUpdateDate = Convert.ToDateTime(dt.Rows[i]["LastUpdateDate"]),
                        LastUpdateUser = new User
                        {

                        }
                    };
                    list.Add(obj);
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public Banner GetBannerByID(int bID)
        {
            var banner = new Banner();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT [ID],[StartDate],[EndDate],[Title],[Img],[Sort],[CreateDate],[CreateUser],[LastUpdateDate],[LastUpdateUser] ");
                sql.Append(string.Format("FROM Banner WHERE [ID]={0}",bID));

                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据

                banner = new Banner
                {
                    ID = Convert.ToInt32(dt.Rows[0]["ID"]),
                    StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"]),
                    EndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"]),
                    Title = Convert.ToString(dt.Rows[0]["Title"]),
                    Img = Convert.ToString(dt.Rows[0]["Img"]),
                    Sort = Convert.ToInt32(dt.Rows[0]["Sort"]),
                    CreateDate = Convert.ToDateTime(dt.Rows[0]["CreateDate"]),
                    CreateUser = new User
                    {

                    },
                    LastUpdateDate = Convert.ToDateTime(dt.Rows[0]["LastUpdateDate"]),
                    LastUpdateUser = new User
                    {

                    }
                };
                #endregion
            }
            catch (Exception ex)
            {

            }
            return banner;
        }

        public bool UpdateBanner(Banner banner)
        {
            var result = false;
            try
            {
                var sql = "UPDATE Banner SET [StartDate]=@StartDate,[EndDate]=@EndDate,[Title]=@Title,[Img]=@Img,[Sort]=@Sort,[LastUpdateDate]=@LastUpdateDate,[LastUpdateUser]=@LastUpdateUser WHERE ID=@ID";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@ID", banner.ID));
                pars.Add(new SqlParameter("@StartDate", banner.StartDate));
                pars.Add(new SqlParameter("@EndDate", banner.EndDate));
                pars.Add(new SqlParameter("@IsShow", banner.IsShow));
                pars.Add(new SqlParameter("@Title", banner.Title));
                pars.Add(new SqlParameter("@Img", banner.Img));
                pars.Add(new SqlParameter("@Sort", banner.Sort));
                pars.Add(new SqlParameter("@LastUpdateDate", DateTime.Now));
                pars.Add(new SqlParameter("@LastUpdateUser", banner.LastUpdateUser != null ? banner.LastUpdateUser.UID : 0));
                result = SQLHelper.ExcuteSQL(sql, pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
