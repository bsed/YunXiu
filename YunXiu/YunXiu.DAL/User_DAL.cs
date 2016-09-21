using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Commom;
using YunXiu.Model;
using YunXiu.Interface;
using Dapper;

namespace YunXiu.DAL
{
    public class User_DAL : IUser
    {

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="Item">用户类</param>
        /// <returns></returns>
        public int InsertUser(User Item)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] {
                    new SqlParameter("@AccountClientGuid",Item.AccountClientGuid),
                    new SqlParameter("@Avatar",Item.Avatar),
                    new SqlParameter("@Email",Item.Email),
                    new SqlParameter("@LiftbanTime",Item.LiftBanTime),
                    new SqlParameter("@MallaGID",Item.MallaGID),
                    new SqlParameter("@Mobile",Item.Mobile),
                    new SqlParameter("@NickName",Item.NickName),
                    new SqlParameter("@PayCredits",Item.PayCredits),
                    new SqlParameter("@Salt",Item.Salt),
                    new SqlParameter("@UserName",Item.UserName),
                    new SqlParameter("@UserRId",Item.UserRID),
                    new SqlParameter("@PassWord",Item.Password),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" DECLARE @Uid int ");
                sb.Append(" insert into [User](AccountClientGuid,Avatar,Email,LiftBanTime,MallaGId, ");
                sb.Append(" Mobile,NickName,PayCredits,RankCredits,Salt,StoreId,UserName,UserRId ");
                sb.Append(" ,IsVerifyEmail,IsVerifyMobile,PassWord,CreateDate,CreateUser,LastUpdateUser,LastUpdateDate) ");
                sb.Append(" Values( @AccountClientGuid,@Avatar,@Email,@LiftbanTime,@MallaGID, ");
                sb.Append(" @Mobile,@NickName,@PayCredits,0,@Salt,@UserName,@UserRId,0,0,@PassWord,GETDATE(),0,0,GETDATE()); ");
                sb.Append(" set @Uid= SCOPE_IDENTITY(); ");

                sb.Append(" insert into UserDetails(address,bday,bio,gender, ");
                sb.Append(" idcard,lastvisitip,lastvisitrgid,lastvisittime,realname,regionid,registerip ");
                sb.Append(" ,registerrgid,registertime,uid) Values( ");
                sb.Append(" '','','',0, ");
                sb.Append(" '','',0,GETDATE(),'',0,'' ");
                sb.Append(" ,0,GETDATE(),@Uid) ");


                sb.Append(" select @Uid as 'uid'; ");


                //还有个用户在线时间表的数据没加

                return SQLHelper.ExcuteScalarSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 根据UID取得用户
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public User GetUserByUid(int Uid)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] {
                                      new SqlParameter("@uid",Uid)
                                   };
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM [User] WHERE [uid]=@uid;");

                var dt = SQLHelper.GetTable(sb.ToString(), parms);
                var TempList = GetUserList(dt);
                if (TempList.Count > 0)
                {
                    return TempList[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        /// <summary>
        /// 根据Account_ClientGuid取得用户信息
        /// </summary>
        /// <param name="Account_ClientGuid"></param>
        /// <returns></returns>
        public User GetPartUserByAccountID(Guid Account_ClientGuid)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@AccountClientGuid",Account_ClientGuid)
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT * FROM dbo.[User] WHERE AccountClientGuid=@AccountClientGuid ");
                var dt = SQLHelper.GetTable(sb.ToString(), parms);
                var TempList = GetUserList(dt);
                if (TempList.Count > 0)
                {
                    return TempList[0];
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

        /// <summary>
        /// 根据用户ID取得用户部分信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public Userdetails GetUserDetailsByUid(int Uid)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] {
                    new SqlParameter("@Uid",Uid)
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" select * from Userdetails where uid=@Uid");
                var dt = SQLHelper.GetTable(sb.ToString(), parms);
                Userdetails Item = null;
                if (dt.Rows.Count > 0)
                {
                    Item = new Userdetails();
                    var dr = dt.Rows[0];
                    Item.address = Convert.IsDBNull(dr["address"]) ? "" : dr["address"].ToString();
                    Item.bday = Convert.IsDBNull(dr["bday"]) ? "" : dr["bday"].ToString();
                    Item.bio = Convert.IsDBNull(dr["bio"]) ? "" : dr["bio"].ToString();
                    Item.gender = Convert.IsDBNull(dr["gender"]) ? 0 : Convert.ToInt32(dr["gender"]);
                    Item.idcard = Convert.IsDBNull(dr["idcard"]) ? "" : dr["idcard"].ToString();
                    Item.lastvisitip = Convert.IsDBNull(dr["lastvisitip"]) ? "" : dr["lastvisitip"].ToString();
                    Item.lastvisitrgid = Convert.IsDBNull(dr["lastvisitrgid"]) ? 0 : Convert.ToInt32(dr["lastvisitrgid"]);
                    Item.lastvisittime = Convert.IsDBNull(dr["lastvisittime"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["lastvisittime"]);
                    Item.realname = Convert.IsDBNull(dr["realname"]) ? "" : dr["realname"].ToString();
                    Item.regionid = Convert.IsDBNull(dr["regionid"]) ? 0 : Convert.ToInt32(dr["regionid"]);
                    Item.registerip = Convert.IsDBNull(dr["registerip"]) ? "" : dr["registerip"].ToString();
                    Item.registerrgid = Convert.IsDBNull(dr["registerrgid"]) ? 0 : Convert.ToInt32(dr["registerrgid"]);
                    Item.registertime = Convert.IsDBNull(dr["registertime"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["registertime"]);
                    Item.uid = Convert.IsDBNull(dr["uid"]) ? 0 : Convert.ToInt32(dr["uid"]);
                }
                return Item;
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// 更新用户等级
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="UserRid"></param>
        /// <returns></returns>
        public int UpdateUserRankByUid(int Uid, int UserRid)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[]{
                                       new SqlParameter("@Uid", Uid),
                                       new SqlParameter("@UserRid", UserRid)
                                   };
                StringBuilder sb = new StringBuilder();
                sb.Append(" UPDATE dbo.[User] SET UserRid=@UserRid where Uid=@Uid ");
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }

        }

        /// <summary>
        /// 更新用户解禁时间
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="liftBanTime"></param>
        /// <returns></returns>
        public int UpdateUserLiftBanTimeByUid(int Uid, DateTime liftBanTime)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[]{
                                       new SqlParameter("@uid", Uid),
                                       new SqlParameter("@LiftBanTime", liftBanTime)
                                   };
                StringBuilder sb = new StringBuilder();
                sb.Append(" UPDATE [User] SET [LiftBanTime]=@LiftBanTime WHERE [uid]=@uid; ");
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 更新用户在线时间
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="OnlieTime"></param>
        /// <returns></returns>
        public int UpdateUserOnlineTime(int Uid, int OnlieTime)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[]{
                                    new SqlParameter("@Uid",  Uid),
                                    new SqlParameter("@OnLineTime",OnlieTime)
                                   };
                StringBuilder sb = new StringBuilder();
                sb.Append(" UPDATE [OnlineTime] ");
                sb.Append(" SET [total]=[total]+@OnLineTime,[year]=[year]+@OnLineTime,[month]=[month]+@OnLineTime, ");
                sb.Append(" [week]=[week]+@OnLineTime,[day]=[day]+@OnLineTime,[updatetime]=GETDATE() ");
                sb.Append(" WHERE [Uid]=@Uid ");
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }

        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public int UpdatePartUser(User Item)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@UserName",Item.UserName),
                    new SqlParameter("@Email",Item.Email),
                    new SqlParameter("@Mobile",Item.Mobile),
                    new SqlParameter("@UserRId",Item.UserRID),
                    new SqlParameter("@MallaGId",Item.MallaGID),
                    new SqlParameter("@NickName",Item.NickName),
                    new SqlParameter("@Avatar",Item.Avatar),
                    new SqlParameter("@PayCredits",Item.PayCredits),
                    new SqlParameter("@RankCredits",Item.RankCredits),
                    new SqlParameter("@IsVerifyEmail",Item.IsVerifyEmail),
                    new SqlParameter("@LiftbanTime",Item.LiftBanTime),
                    new SqlParameter("@Salt",Item.Salt),
                    new SqlParameter("@Uid",Item.UID),
                    new SqlParameter("@PassWord",Item.Password),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" update dbo.[User] set UserName=@UserName,Email=@Email,Mobile=@Mobile,");
                sb.Append(" UserRId=@UserRId,MallaGId=@MallaGId,NickName=@NickName, ");
                sb.Append(" Avatar=@Avatar,PayCredits=@PayCredits,RankCredits=@RankCredits,IsVerifyEmail=@IsVerifyEmail, ");
                sb.Append(" LiftbanTime=@LiftbanTime,Salt=@Salt  ");

                if (Item.Password.Trim() != "")
                {
                    sb.Append(",PassWord=@PassWord");
                }


                sb.Append(" where Uid=@Uid ");
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }

        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public int ChangePwd(int Uid, string Pwd)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@Uid",Uid),
                    new SqlParameter("@Pwd",Pwd),
                };

                StringBuilder sb = new StringBuilder();
                sb.Append(" UPDATE dbo.[User] SET password=@Pwd ");
                sb.Append(" WHERE uid=@Uid ");

                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 修改邮箱
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int UpdateUserEmailByUid(int Uid, string email)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@uid", Uid),
                    new SqlParameter("@email",email),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" UPDATE dbo.[User] SET email=@email WHERE uid=@uid ");

                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }

        }

        /// <summary>
        /// 更新手机
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public int UpdateUserMobileByUid(int Uid, string mobile)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@uid", Uid),
                    new SqlParameter("@mobile", mobile)
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" UPDATE dbo.[User] SET mobile=@mobile WHERE uid=@uid ");
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }

        }

        public List<User> GetUserList(DataTable dt)
        {
            List<User> ResList = new List<User>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                var Item = new User()
                {
                    UID = Convert.IsDBNull(dr["UID"].ToString()) ? 0 : Convert.ToInt32(dr["UID"].ToString()),
                    AccountClientGuid = Convert.IsDBNull(dr["AccountClientGuid"].ToString()) ? new Guid() : Guid.Parse(dr["AccountClientGuid"].ToString()),
                    Avatar = Convert.IsDBNull(dr["Avatar"].ToString()) ? "" : dr["Avatar"].ToString(),
                    Email = Convert.IsDBNull(dr["Email"].ToString()) ? "" : dr["Email"].ToString(),
                    LiftBanTime = Convert.IsDBNull(dr["LiftBanTime"].ToString()) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["LiftBanTime"].ToString()),
                    MallaGID = Convert.IsDBNull(dr["MallagID"].ToString()) ? 0 : Convert.ToInt32(dr["MallagID"]),
                    Mobile = Convert.IsDBNull(dr["Mobile"]) ? "" : dr["Mobile"].ToString(),
                    NickName = Convert.IsDBNull(dr["NickName"]) ? "" : dr["NickName"].ToString(),
                    Password = Convert.IsDBNull(dr["Password"]) ? "" : dr["Password"].ToString(),
                    PayCredits = Convert.IsDBNull(dr["PayCredits"]) ? 0 : Convert.ToInt32(dr["PayCredits"]),
                    RankCredits = Convert.IsDBNull(dr["RankCredits"]) ? 0 : Convert.ToInt32(dr["RankCredits"]),
                    Salt = Convert.IsDBNull(dr["Salt"]) ? "" : dr["Salt"].ToString(),
                    UserName = Convert.IsDBNull(dr["UserName"]) ? "" : dr["UserName"].ToString(),
                    UserRID = Convert.IsDBNull(dr["UserRID"]) ? 0 : Convert.ToInt32(dr["UserRID"].ToString()),
                    IsVerifyEmail = Convert.IsDBNull(dr["IsVerifyEmail"]) ? false : Convert.ToBoolean(dr["IsVerifyEmail"]),
                    IsVerifyMobile = Convert.IsDBNull(dr["IsVerifyMobile"]) ? false : Convert.ToBoolean(dr["IsVerifyMobile"]),
                    CreateDate = Convert.IsDBNull(dr["CreateDate"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["CreateDate"]),
                    LastUpdateDate = Convert.IsDBNull(dr["LastUpdateDate"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["LastUpdateDate"]),
                    CreateUser = Convert.IsDBNull(dr["CreateUser"]) ? new User() { UID = 0 } : new User() { UID = Convert.ToInt32(dr["CreateUser"]) },
                    LastUpdateUser = Convert.IsDBNull(dr["LastUpdateUser"]) ? new User() { UID = 0 } : new User() { UID = Convert.ToInt32(dr["LastUpdateUser"]) },
                };
                ResList.Add(Item);
            }
            return ResList;
        }

        public bool UpdateVerifyMobileState(int uID, bool isVerifyMobile)
        {
            var result = false;
            try
            {
                var sql = "UPDATE User SET [IsVerifyMobile]=@IsVerifyMobile WHERE [UID]=@UID";
                DynamicParameters p = new DynamicParameters();
                p.Add("@IsVerifyMobile", isVerifyMobile);
                p.Add("@UID", uID);
                result = DapperHelper.Execute(sql, p) ;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool UpdateVerifyEmailState(int uID, bool isVerifyEmail)
        {
            var result = false;
            try
            {
                var sql = "UPDATE User SET [IsVerifyEmail]=@IsVerifyEmail WHERE [UID]=@UID";
                DynamicParameters p = new DynamicParameters();
                p.Add("@IsVerifyEmail", isVerifyEmail);
                p.Add("@UID", uID);
                result = DapperHelper.Execute(sql, p) ;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
