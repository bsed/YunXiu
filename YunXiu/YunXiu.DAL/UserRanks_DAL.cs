using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;


namespace YunXiu.DAL
{
    public class UserRanks_DAL:IUserRanks
    {

        public UserRanks GetUserRankByCredits(int Credit)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] 
                { 
                    new SqlParameter("@Credit",Credit),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT  UserRid ,System ,Title ,Avatar , ");
                sb.Append(" CreditsLower ,CreditsUpper ,LimitDays ");
                sb.Append(" FROM dbo.UserRanks ");
                sb.Append(" WHERE creditslower<@Credit AND creditsupper>@Credit ");

                var dt= SQLHelper.GetTable(sb.ToString(), parms);
                var List= DataTableToList(dt);
                if (List.Count > 0)
                {
                    return List[0];
                }
                else 
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UserRanks> GetUserRankList()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT  UserRid ,System ,Title ,Avatar , ");
                sb.Append(" CreditsLower ,CreditsUpper ,LimitDays ");
                sb.Append(" FROM dbo.userranks ");
                var dt = SQLHelper.GetTable(sb.ToString());
                return DataTableToList(dt);
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        public int AddUserRank(UserRanks Item)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] 
                {
                    new SqlParameter("@Avatar",Item.Avatar),
                    new SqlParameter("@CreditsLower",Item.CreditsLower),
                    new SqlParameter("@CreditsUpper",Item.CreditsUpper),
                    new SqlParameter("@LimitDays",Item.LimitDays),
                    new SqlParameter("@System",Item.System),
                    new SqlParameter("@Title",Item.Title),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" INSERT INTO dbo.UserRanks ");
                sb.Append(" (System,Title,Avatar,CreditsLower,CreditsUpper,LimitDays,System,Title) ");
                sb.Append(" Values(@System,@Title,@Avatar,@CreditsLower,@CreditsUpper,@LimitDays,@System,@Title) ");
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int DelelteUserRank(int UserRid)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] 
                {
                    new SqlParameter("@UserRid",UserRid),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" DELETE dbo.UserRanks  WHERE UserRid=@UserRid ");
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateUserRank(UserRanks Item)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] 
                {
                    new SqlParameter("@Avatar",Item.Avatar),
                    new SqlParameter("@CreditsLower",Item.CreditsLower),
                    new SqlParameter("@CreditsUpper",Item.CreditsUpper),
                    new SqlParameter("@LimitDays",Item.LimitDays),
                    new SqlParameter("@System",Item.System),
                    new SqlParameter("@Title",Item.Title),
                    new SqlParameter("@UserRid",Item.UserRid),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" UPDATE dbo.UserRanks ");
                sb.Append(" set Avatar=@Avatar ,CreditsLower=@CreditsLower,CreditsUpper=@CreditsUpper, ");
                sb.Append(" LimitDays=@LimitDays,System=@System,Title=@Title ");
                sb.Append(" where UserRid=@UserRid ");
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public UserRanks GetUserRankInfoByUid(int Uid)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] 
                {
                    new SqlParameter("@Uid",Uid),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" DECLARE @Credit INT ; ");
                sb.Append(" SELECT @Credit=RankCredits FROM dbo.[User] where UID=@Uid ");
                sb.Append(" SELECT  UserRid ,System ,Title ,Avatar , ");
                sb.Append(" CreditsLower ,CreditsUpper ,LimitDays FROM dbo.userranks ");
                sb.Append(" WHERE creditslower<@Credit AND creditsupper>@Credit ");
                var dt= SQLHelper.GetTable(sb.ToString(), parms);
                var ResList= DataTableToList(dt);
                if (ResList.Count > 0)
                {
                    return ResList[0];
                }
                else 
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UserRanks> DataTableToList(DataTable dt)
        {
            List<UserRanks> ResList = new List<UserRanks>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                var Item = new UserRanks() {
                    UserRid = Convert.IsDBNull(dr["UserRid"]) ? 0 : Convert.ToInt32(dr["UserRid"]),
                    Avatar = Convert.IsDBNull(dr["Avatar"]) ? "" : dr["Avatar"].ToString(),
                    CreditsLower = Convert.IsDBNull(dr["CreditsLower"]) ? 0 : Convert.ToInt32(dr["CreditsLower"]),
                    CreditsUpper = Convert.IsDBNull(dr["CreditsUpper"]) ? 0 : Convert.ToInt32(dr["CreditsUpper"]),
                    LimitDays = Convert.IsDBNull(dr["LimitDays"]) ? 0 : Convert.ToInt32(dr["LimitDays"]),
                    System = Convert.IsDBNull(dr["System"]) ? 0 : Convert.ToInt32(dr["System"]),
                    Title = Convert.IsDBNull(dr["Title"]) ? "" : dr["Title"].ToString()
                };
                ResList.Add(Item);
            }
            return ResList;
        }


    }
}
