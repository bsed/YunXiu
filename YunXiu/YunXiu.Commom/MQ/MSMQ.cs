using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Commom.MQ
{
    public class MSMQ
    {
        /// <summary>
        /// 将要发送的MSMQ Ip地址
        /// </summary>
        public string MSMQIP { get; set; }
        /// <summary>
        /// 发送的消息
        /// </summary>
        public string MSG { get; set; }
        /// <summary>
        /// MSMQ 名称
        /// </summary>
        public string MSMQName { get; set; }

        /// <summary>
        /// 接收的消息
        /// </summary>
        public Action<object, string> receiveComplete;

        public void BeginReceive(string ip, string msmqName)
        {
            MessageQueue messageQueue = new MessageQueue(string.Format("FormatName:Direct=TCP:{0}\\private$\\{1}", MSMQIP, MSMQName));
            messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            //接收消息完成后触发的事件
            messageQueue.ReceiveCompleted += messageQueue_ReceiveCompleted;
            messageQueue.BeginReceive();
        }

        private void messageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            MessageQueue messageQueue = (MessageQueue)sender;
            //异步接收消息，只要有消息，就接收
            Message msg = messageQueue.EndReceive(e.AsyncResult);
            //取出接收到的信息        
            receiveComplete(sender, msg.Body as string);
        }
        public void SendToMSMQ()
        {
            try
            {
                var par = string.Format("FormatName:Direct=TCP:{0}\\private$\\{1}", MSMQIP, MSMQName);
                MessageQueue messageQueue = new MessageQueue(par);
                Message m = new Message(MSG);
                messageQueue.Send(m, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {

            }
        }
    }
}
