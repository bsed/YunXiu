using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.Commom;
using System.Data;

namespace YunXiu.DAL
{
    public class MessageTb_DAL : IMessageTb
    {

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public int SendMessage(MessageTb Item)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] { 
                    new SqlParameter("@Title",Item.Title),
                    new SqlParameter("@MessageBody",Item.MessageBody),
                    new SqlParameter("@MessageToUId",Item.MessageBody),
                    new SqlParameter("@Attachment",Item.MessageBody),
                    new SqlParameter("@Uid",Item.CreateUid),
                };

                StringBuilder sb = new StringBuilder();
                sb.Append(" DECLARE @MId int ");
                sb.Append(" INSERT INTO dbo.MessageTb( Title,MessageBody ,MessageToUId ,Attachment , ");
                sb.Append(" DeleteFlag ,IsReply ,PMid ,CreateDate ,CreateUid ,LastUpdateDate ,LastUpdateUId) ");
                sb.Append(" VALUES  (@Title,@MessageBody,@MessageToUId,@Attachment,'N',0,0,GETDATE(),@Uid,GETDATE(),@Uid) ");
                sb.Append(" set @MId= SCOPE_IDENTITY(); ");
                sb.Append(" select @MId as 'MId' ");
                return SQLHelper.ExcuteScalarSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }

        }


        /// <summary>
        /// 回复消息
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public int ReplyMessage(MessageTb Item)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] { 
                    new SqlParameter("@PMid",Item.PMid),
                    new SqlParameter("@MessageBody",Item.MessageBody),
                    new SqlParameter("@PMid",Item.MessageToUId),
                    new SqlParameter("@MessageToUId",Item.MessageToUId),
                    new SqlParameter("@Uid",Item.CreateUid),
                    new SqlParameter("@Title",Item.Title),
                };

                StringBuilder sb = new StringBuilder();

                sb.Append(" INSERT INTO dbo.MessageTb( Title,MessageBody ,MessageToUId ,Attachment ,DeleteFlag , ");
                sb.Append(" IsReply ,PMid ,CreateDate ,CreateUid ,LastUpdateDate ,LastUpdateUId) ");
                sb.Append(" VALUES  (@Title, @MessageBody ,@MessageToUId,'',0,1,@PMid,GETDATE(),@Uid,GETDATE(),Uid)");

                return SQLHelper.ExcuteScalarSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }



        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="MId"></param>
        /// <returns></returns>
        public int DeleteMessage(int MId)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] { 
                    new SqlParameter("@Mid",MId),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" UPDATE dbo.MessageTb SET DeleteFlag=1 WHERE Mid=@Mid ");
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }



        /// <summary>
        /// 根据发件人ID取得消息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public List<MessageTb> GetMessageByCreateUid(int Uid)
        {
            List<MessageTb> Res = null;
            try
            {
                SqlParameter[] parms = new SqlParameter[] { 
                    new SqlParameter("@Uid",Uid),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT * FROM dbo.MessageTb WHERE CreateUid=@Uid AND DeleteFlag=0 ");
                var dt = SQLHelper.GetTable(sb.ToString(), parms);
                Res = DataTableToList(dt);
                return Res;
            }
            catch (Exception)
            {
                return null;
            }

        }


        /// <summary>
        /// 根据收件人ID取得消息
        /// </summary>
        /// <param name="Uid">用户ID</param>
        /// <returns></returns>
        public List<MessageTb> GetMessageByReceiveUid(int Uid)
        {
            try
            {
                SqlParameter[] parms = new SqlParameter[] { 
                    new SqlParameter("@Uid",Uid),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT * FROM dbo.MessageTb  WHERE MessageToUId=@Uid  ORDER BY CreateDate DESC ");
                var dt = SQLHelper.GetTable(sb.ToString(), parms);
                var Res = DataTableToList(dt);
                return Res;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }



        private List<MessageTb> DataTableToList(DataTable dt)
        {
            List<MessageTb> Res = new List<MessageTb>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                var Item = new MessageTb()
                {
                    Title = Convert.IsDBNull(dr["Title"]) ? "" : dr["Title"].ToString(),
                    Attachment = Convert.IsDBNull(dr["Attachment"]) ? "" : dr["Attachment"].ToString(),
                    CreateDate = Convert.IsDBNull(dr["CreateDate"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["CreateDate"]),
                    CreateUid = Convert.IsDBNull(dr["CreateUid"]) ? 0 : Convert.ToInt32(dr["CreateUid"]),
                    DeleteFlag = Convert.IsDBNull(dr["DeleteFlag"]) ? 0 : Convert.ToInt32(dr["DeleteFlag"]),
                    IsReply = Convert.IsDBNull(dr["IsReply"]) ? 0 : Convert.ToInt32(dr["IsReply"]),
                    LastUpdateDate = Convert.IsDBNull(dr["LastUpdateDate"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["LastUpdateDate"]),
                    LastUpdateUId = Convert.IsDBNull(dr["LastUpdateUId"]) ? 0 : Convert.ToInt32(dr["LastUpdateUId"]),
                    MessageBody = Convert.IsDBNull(dr["MessageBody"]) ? "" : dr["MessageBody"].ToString(),
                    MessageToUId = Convert.IsDBNull(dr["MessageToUId"]) ? 0 : Convert.ToInt32(dr["MessageToUId"]),
                    Mid = Convert.IsDBNull(dr["Mid"]) ? 0 : Convert.ToInt32(dr["Mid"]),
                    PMid = Convert.IsDBNull(dr["PMid"]) ? 0 : Convert.ToInt32(dr["PMid"])
                };
            }
            return Res;
        }
    }
}
