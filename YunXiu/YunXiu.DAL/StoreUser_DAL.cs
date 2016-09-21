using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using YunXiu.Model;
using YunXiu.Commom;
using YunXiu.Interface;

namespace YunXiu.DAL
{
    public class StoreUser_DAL : IStoreUser
    {
        /// <summary>
        /// 添加商铺会员
        /// </summary>
        /// <param name="storeID"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool AddStoreUser(int storeID, int userID)
        {
            var result = false;
            try
            {
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@StoreID", storeID));
                pars.Add(new SqlParameter("@SUserID", userID));
                result = SQLHelper.ExcuteScalarProc("AddStoreUser", pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteStoreUser(int storeID, int userID)
        {
            var result = false;
            try
            {
                var nowDate = DateTime.Now;
                var sql = "DELETE FROM StoreUser WHERE Store=@storeID AND User=@userID";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@storeID", storeID));
                pars.Add(new SqlParameter("@userID", userID));
                result = SQLHelper.ExcuteSQL(sql, pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<StoreUser> GetStoreByUser(int userID)
        {
            var list = new List<StoreUser>();
            try
            {
                var nullDate = new DateTime();
                var sql = new StringBuilder();
                sql.Append("SELECT s2.[StoreID],s2.[State],s2.[Name],s2.[RegionID],s2.[StorerID],s2.[Logo],s2.[Mobile],s2.[Phone],s2.[QQ],");
                sql.Append("s2.[WW],s2.[DePoint],s2.[SePoint],s2.[ShPoint],s2.[Honesties],s2.[ValidityDate],s2.[Announcement],s2.[Description],s2.[CreateDate] s.[CreateDate] AS SCreateDate FROM StoreUser s ");
                sql.Append("LEFT JOIN Store s2 ON s.Store = s2.StoreID ");
                sql.Append(string.Format("WHERE User={0}", userID));

                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new StoreUser
                    {
                        ID = Convert.ToInt32(dt.Rows[i][""]),
                        Store = new Store
                        {
                            StoreID = Convert.ToInt32(dt.Rows[i]["StoreID"]),
                            State = Convert.ToInt32(dt.Rows[i]["State"]),
                            Name = Convert.ToString(dt.Rows[i]["Name"]),
                            RegionID = Convert.ToInt32(dt.Rows[i]["RegionID"]),
                            StorerID = Convert.ToInt32(dt.Rows[i]["StorerID"]),
                          
                            Logo = Convert.ToString(dt.Rows[i]["Logo"]),
                            Mobile = Convert.ToString(dt.Rows[i]["Mobile"]),
                            Phone = Convert.IsDBNull(dt.Rows[i]["Phone"]) ? Convert.ToString(dt.Rows[i]["Phone"]) : "",

                            DePoint = Convert.IsDBNull(dt.Rows[i]["DePoint"]) ? Convert.ToDecimal(dt.Rows[i]["DePoint"]) : 0,
                            SePoint = Convert.IsDBNull(dt.Rows[i]["SePoint"]) ? Convert.ToDecimal(dt.Rows[i]["SePoint"]) : 0,
                            ShPoint = Convert.IsDBNull(dt.Rows[i]["ShPoint"]) ? Convert.ToDecimal(dt.Rows[i]["ShPoint"]) : 0,
                            Honesties = Convert.IsDBNull(dt.Rows[i]["Honesties"]) ? Convert.ToDecimal(dt.Rows[i]["Honesties"]) : 0,
                            ValidityDate = Convert.IsDBNull(dt.Rows[i]["ValidityDate"]) ? Convert.ToDateTime(dt.Rows[i]["ValidityDate"]) : nullDate,
                            Announcement = Convert.IsDBNull(dt.Rows[i]["Phone"]) ? Convert.ToString(dt.Rows[i]["Announcement"]) : "",
                            Description = Convert.IsDBNull(dt.Rows[i]["Description"]) ? Convert.ToString(dt.Rows[i]["Description"]) : "",
                            CreateDate = Convert.IsDBNull(dt.Rows[i]["SCreateDate"]) ? Convert.ToDateTime(dt.Rows[i]["SCreateDate"]) : nullDate,
                        },
                        CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"])
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        public List<StoreUser> GetStoreUserByStore(int storeID)
        {
            var list = new List<StoreUser>();
            try
            {
                var nullDate = new DateTime();
                var sql = new StringBuilder();
                sql.Append("SELECT u.[UID],u.[UserName],u.[Email],u.[Mobile],u.[Password],u.[UserRID],u.[StoreID],u.[MallagID],u.[NickName],u.[Avatar],u.[PayCredits],");
                sql.Append("u.[RankCredits],u.[IsVerifyEmail],u.[IsVerifyMobile],u.[LiftBanTime],u.[Salt],u.[AccountClientGuid],StoreID, s.[CreateDate] AS SCreateDate FROM StoreUser s ");
                sql.Append("LEFT JOIN User u ON s.User = u.UID ");
                sql.Append(string.Format("WHERE Store={0}", storeID));

                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new StoreUser
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["StoreID"]),
                        SUser = new User
                        {
                            UID = Convert.ToInt32(dt.Rows[i]["UID"]),
                            UserName = Convert.ToString(dt.Rows[i]["UserName"]),
                            Email = Convert.ToString(dt.Rows[i]["Email"]),
                            Mobile = Convert.ToString(dt.Rows[i]["Mobile"]),
                            Password = Convert.ToString(dt.Rows[i]["Password"]),
                            UserRID = Convert.ToInt32(dt.Rows[i]["UserRID"]),
                            NickName = Convert.IsDBNull(dt.Rows[i]["NickName"]) ? Convert.ToString(dt.Rows[i]["NickName"]) : "",
                            Avatar = Convert.IsDBNull(dt.Rows[i]["Avatar"]) ? Convert.ToString(dt.Rows[i]["Avatar"]) : "",
                            PayCredits = Convert.IsDBNull(dt.Rows[i]["PayCredits"]) ? Convert.ToInt32(dt.Rows[i]["PayCredits"]) : 0,
                            RankCredits = Convert.IsDBNull(dt.Rows[i]["RankCredits"]) ? Convert.ToInt32(dt.Rows[i]["RankCredits"]) : 0,
                            IsVerifyEmail = Convert.IsDBNull(dt.Rows[i]["VerifyEmail"]) ? Convert.ToBoolean(dt.Rows[i]["VerifyEmail"]) : false,
                            IsVerifyMobile = Convert.IsDBNull(dt.Rows[i]["IsVerifyMobile"]) ? Convert.ToBoolean(dt.Rows[i]["IsVerifyMobile"]) : false,
                            LiftBanTime = Convert.IsDBNull(dt.Rows[i]["LiftBanTime"]) ? Convert.ToDateTime(dt.Rows[i]["LiftBanTime"]) : nullDate,
                            Salt = Convert.IsDBNull(dt.Rows[i]["Salt"]) ? Convert.ToString(dt.Rows[i]["Salt"]) : "",
                        },
                        CreateDate = Convert.ToDateTime(dt.Rows[i]["SCreateDate"])
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
    }
}
