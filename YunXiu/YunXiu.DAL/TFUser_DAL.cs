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

        public TFUser GetTFUser(int uid)
        {
            TFUser user = null;
            try
            {
                var sql = "";
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

                var sql = "SELECT [client_guid] FROM [client_info] WHERE [client_loginname]=@client_loginname AND [client_password]=@client_password";
            
                using (IDbConnection conn = DapperHelper.GetConn(DbCon))
                {
                    DynamicParameters pars = new DynamicParameters();
                    pars.Add("@client_loginname", account);
                    pars.Add("@client_password",pwd);
                   var guid = conn.Query<string>(sql,pars).FirstOrDefault();
                    //if (guid != null)
                    //{
                    //    var userInfoSql = string.Format("SELECT * FROM user_info WHERE [client_guid]={0}", guid);
                    //  //  user = conn.QuerySingleOrDefault<TFUser>(userInfoSql);
                    //}
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
