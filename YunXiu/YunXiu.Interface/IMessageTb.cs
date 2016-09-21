using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IMessageTb
    {

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        int SendMessage(MessageTb Item);


        /// <summary>
        /// 回复消息
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        int ReplyMessage(MessageTb Item);


        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="MId"></param>
        /// <returns></returns>
        int DeleteMessage(int MId);


        /// <summary>
        /// 根据发件人ID取得消息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        List<MessageTb> GetMessageByCreateUid(int Uid);

        /// <summary>
        /// 根据收件人ID取得消息
        /// </summary>
        /// <param name="Uid">用户ID</param>
        /// <returns></returns>
        List<MessageTb> GetMessageByReceiveUid(int Uid);

    }
}
