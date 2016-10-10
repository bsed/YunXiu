using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.Commom;
using Dapper;

namespace YunXiu.DAL
{
    /// <summary>
    /// 临时获取
    /// </summary>
    public class TFUser_DAL : ITFUser
    {
        string DbCon = Model.Global.GlobalDictionary.GetSysConfVal("TFDbCon");

        public bool CheckTFUserAccount(string account)
        {
            var result = false;
            try
            {
             
                var sql = "SELECT COUNT(*) FROM [client_info] WHERE [client_loginname]=@ID";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@ID", account);

                using (IDbConnection conn = DapperHelper.GetConn(DbCon))
                {
                    result = conn.Query<int>(sql,pars).FirstOrDefault() > 0;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public TFUser EmailLogin(string email, string pwd)
        {
            TFUser user = null;
            try
            {

            }
            catch (Exception ex)
            {

            }
            return user;
        }


        public List<TFUser> GetTFUser(List<string> uIDList)
        {
            List<TFUser> list = null;
            try
            {
                var idListStr = Utilities.ListToListStr(uIDList);
                var sql = string.Format("SELECT * FROM [user_info] WHERE [client_guid] IN ({0})", idListStr);
                DynamicParameters pars = new DynamicParameters();
              //  pars.Add("@ID", idListStr);
                using (IDbConnection conn = DapperHelper.GetConn(DbCon))
                {
                    list = conn.Query<TFUser>(sql).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public TFUser GetTFUserByID(int uid)
        {
            TFUser user = null;
            try
            {
                var sql = "SELECT * FROM TFUser WHERE [client_guid] WHERE =@uid";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@uid", uid);
                using (IDbConnection conn = DapperHelper.GetConn(DbCon))
                {
                    user = conn.Query<TFUser>(sql, pars).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public TFUser Login(string account, string pwd)
        {
            TFUser user = null;
            try
            {
                var sql = "SELECT [client_guid] FROM [client_info] WHERE [client_loginname]=@client_loginname AND [client_password]=@client_password ";
                using (IDbConnection conn = DapperHelper.GetConn(DbCon))
                {
                    DynamicParameters pars = new DynamicParameters();
                    pars.Add("@client_loginname", account);
                    pars.Add("@client_password", pwd);
                    var guid = conn.Query<Guid>(sql, pars).FirstOrDefault();
                    var guidStr = guid.ToString();
                    if (guidStr != null)
                    {
                        var userInfoSql = string.Format("SELECT * FROM user_info WHERE [client_guid]='{0}' AND [status]=1", guid);
                        user = conn.Query<TFUser>(userInfoSql).Single();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public TFUser PhoneLogin(string phone, string pwd)
        {
            TFUser user = null;
            try
            {

            }
            catch (Exception ex)
            {

            }
            return user;
        }
    }
}
