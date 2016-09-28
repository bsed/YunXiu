using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.Commom;

namespace YunXiu.DAL
{
    public class Tender_DAL : ITender
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="ExtList"></param>
        /// <returns></returns>
        public int AddTender(Tender tender)
        {
            var tID = 0;
            try
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO Tender");
                sql.Append("([KeyWord],[Title],[CategoryID],[State],[TenderArea],[TenderStartDate],[TenderEndDate],[TenderSalesAddress],[TenderInvokeOrganization],[DetailsDescript],[CreateDate],[CreateUserID]) ");
                sql.Append("VALUES(@KeyWord,@Title,@CategoryID,@State,@TenderArea,@TenderStartDate,@TenderEndDate,@TenderSalesAddress,@TenderInvokeOrganization,@DetailsDescript,@CreateDate,@CreateUserID) SELECT @@IDENTITY");

                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@KeyWord", tender.KeyWord));
                pars.Add(new SqlParameter("@Title", tender.Title));
                pars.Add(new SqlParameter("@CategoryID", tender.Category.CateId));
                pars.Add(new SqlParameter("@State", tender.State));
                pars.Add(new SqlParameter("@TenderArea", tender.TenderArea));
                pars.Add(new SqlParameter("@TenderStartDate", tender.TenderStartDate));
                pars.Add(new SqlParameter("@TenderEndDate", tender.TenderEndDate));
                pars.Add(new SqlParameter("@TenderSalesAddress", tender.TenderSalesAddress));
                pars.Add(new SqlParameter("@TenderInvokeOrganization", tender.TenderInvokeOrganization));
                pars.Add(new SqlParameter("@DetailsDescript", tender.DetailsDescript));
                pars.Add(new SqlParameter("@CreateDate", DateTime.Now));
                pars.Add(new SqlParameter("@CreateUserID", tender.CreateUser != null ? tender.CreateUser.UID : 0));

                tID = SQLHelper.ExcuteScalarSQL(sql.ToString(), pars.ToArray());
            }
            catch (Exception)
            {

            }
            return tID;
        }

        /// <summary>
        /// 删除标书
        /// </summary>
        /// <param name="TTId"></param>
        /// <returns></returns>
        public bool DeleteTender(int tID)
        {
            var result = false;
            try
            {
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@TTId",tID),
                };
                var sql = "DELETE FROM Tender WHERE [TTId]=@TTId ";
                result = SQLHelper.ExcuteSQL(sql, parms) > 0;
            }
            catch (Exception)
            {

            }
            return result;
        }


        /// <summary>
        /// 修改标书
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="ExtList"></param>
        /// <returns></returns>
        public bool UpdateTender(Tender tender)
        {
            var result = false;
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("UPDATE Tender SET ");
                str.Append("[TTId]=@TTId,[KeyWord]=@KeyWord,[Title]=@Title,[CategoryID]=@CategoryID,[State]=@State,[TenderArea]=@TenderArea,[TenderStartDate]=@TenderStartDate,[TenderEndDate]=@TenderEndDate,[TenderSalesAddress]=@TenderSalesAddress,");
                str.Append("[TenderInvokeOrganization]=@TenderInvokeOrganization,[DetailsDescript]=@DetailsDescript,[LastUpdateDate]=@LastUpdateDate,[LastUpdateUserID]=@LastUpdateUserID");
                str.Append("WHERE TTId=@ID");
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@ID", tender.TTId));
                pars.Add(new SqlParameter("@KeyWord", tender.KeyWord));
                pars.Add(new SqlParameter("@Title", tender.Title));
                pars.Add(new SqlParameter("@CategoryID", tender.Category.CateId));
                pars.Add(new SqlParameter("@State", tender.State));
                pars.Add(new SqlParameter("@TenderArea", tender.TenderArea));
                pars.Add(new SqlParameter("@TenderStartDate", tender.TenderStartDate));
                pars.Add(new SqlParameter("@TenderEndDate", tender.TenderEndDate));
                pars.Add(new SqlParameter("@TenderSalesAddress", tender.TenderSalesAddress));
                pars.Add(new SqlParameter("@TenderInvokeOrganization", tender.TenderInvokeOrganization));
                pars.Add(new SqlParameter("@DetailsDescript", tender.DetailsDescript));
                pars.Add(new SqlParameter("@LastUpdateDate", DateTime.Now));
                pars.Add(new SqlParameter("@LastUpdateUserID", tender.LastUpdateUser != null ? tender.LastUpdateUser.UID : 0));

                result = SQLHelper.ExcuteSQL(str.ToString(), pars.ToArray()) > 0;
            }
            catch (Exception)
            {
            }
            return result;
        }

        public List<Tender> GetTender(int uID)
        {
            List<Tender> list = new List<Tender>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT ");
                sql.Append("[TTId],[KeyWord],[Title],[CategoryID],[State],[TenderArea],[TenderStartDate],[TenderEndDate],[TenderSalesAddress],[TenderInvokeOrganization],[DetailsDescript],");
                sql.Append("[CreateDate],[CreateUserID],[LastUpdateDate],[LastUpdateUserID] ");
                sql.Append(string.Format("FROM Tender WHERE [CreateUserID]={0} ",uID));

                var dt = SQLHelper.GetTable(sql.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Tender
                    {

                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }


        public List<Tender> GetTenderByKey(int uID, string key)
        {
            throw new NotImplementedException();
        }
    }
}
