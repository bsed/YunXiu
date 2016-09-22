using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Web;

namespace YunXiu.Commom
{
    public class CommomClass
    {
        public static string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "text/json";
            //  request.ContentLength = Encoding.UTF8.GetByteCount(HttpUtility.UrlEncode(postDataStr));

            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(HttpUtility.UrlEncode(postDataStr));
            myStreamWriter.AutoFlush = true;
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        public static string HttpPost(string Url, string postDataStr, string contentType)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = contentType;
            //request.ContentLength = Encoding.UTF8.GetByteCount(HttpUtility.UrlEncode(postDataStr));
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(HttpUtility.UrlEncode(postDataStr));
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        public static string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        public static string HttpGet(string Url, string postDataStr, string contentType)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = contentType;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        /// <summary>
        /// 读取xml文件
        /// </summary>
        /// <param name="path">完整路径</param>
        /// <returns></returns>
        public static XmlDocument LoadXml(string path)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(path);
            }
            catch (Exception ex)
            {

            }
            return doc;
        }

        /// <summary>
        /// 获取XML节点值
        /// </summary>
        /// <param name="xmlFilePath">XML路径</param>
        /// <param name="xmlFilePath">路径表达式</param>
        /// <returns></returns>
        public static List<string> GetXmlNodeValue(string xmlFilePath, string xpath)
        {
            var list = new List<string>();
            try
            {
                var doc = LoadXml(xmlFilePath);
                var nodes = doc.SelectNodes(xpath);
                for (int i = 0; i < nodes.Count; i++)
                {
                    list.Add(nodes[i].InnerText);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        /// <summary>
        /// 读取系统配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigDictionary(string key)
        {
            var value = "";
            try
            {
                value = Model.Global.GlobalDictionary.SysConfDictionary[key];
                if (value == "")//如果字典里面没有这个配置则重新读取web.conf至字典
                {
                    value = ConfigurationManager.AppSettings[key];
                    Model.Global.GlobalDictionary.SysConfDictionary[key] = value;
                }
            }
            catch (Exception ex) { }
            return value;
        }
        /// <summary>
        /// 加载系统配置
        /// </summary>
        /// <param name="needLoadConfigList">需要加载的配置</param>
        /// <returns></returns>
        public static bool LoadConfigDictionary(List<string> needLoadConfigList)
        {
            var isLoadSuccess = false;//配置是否加载成功
            try
            {
                for (int i = 0; i < needLoadConfigList.Count; i++)
                {
                    var value = ConfigurationManager.AppSettings[needLoadConfigList[i]];
                    Model.Global.GlobalDictionary.SysConfDictionary[needLoadConfigList[i]] = value;
                }
                isLoadSuccess = true;
            }
            catch (Exception ex)
            {
                isLoadSuccess = false;
            }
            return isLoadSuccess;
        }

        public static Dictionary<string, string> GetXmlNodeVal(string filePath, string xPath)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var doc = LoadXml(filePath);
            var node = doc.SelectSingleNode(xPath);
            if (node != null)
            {
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    dic.Add(node.ChildNodes[i].Name, node.ChildNodes[i].InnerText);
                }
            }       
            return dic;
        }

        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
