using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class MessageTb_BLL:IMessageTb
    {
        MessageTb_DAL _dal = new MessageTb_DAL();

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public int SendMessage(MessageTb Item)
        {
            return _dal.SendMessage(Item);
        }


        /// <summary>
        /// 回复消息
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public int ReplyMessage(MessageTb Item)
        {
            return _dal.ReplyMessage(Item);
        }



        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="MId"></param>
        /// <returns></returns>
        public int DeleteMessage(int MId)
        {
            return _dal.DeleteMessage(MId);
        }



        /// <summary>
        /// 根据发件人ID取得消息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public List<MessageTb> GetMessageByCreateUid(int Uid)
        {
            return _dal.GetMessageByCreateUid(Uid);
        }


        /// <summary>
        /// 根据收件人ID取得消息
        /// </summary>
        /// <param name="Uid">用户ID</param>
        /// <returns></returns>
        public List<MessageTb> GetMessageByReceiveUid(int Uid)
        {
            return _dal.GetMessageByReceiveUid(Uid);
        }


    }
}
