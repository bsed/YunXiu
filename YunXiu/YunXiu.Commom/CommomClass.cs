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

        public static Dictionary<string, Dictionary<string, string>> CreateDictionaries(string filePath, string xPath)
        {
            Dictionary<string, Dictionary<string, string>> dictionaries = new Dictionary<string, Dictionary<string, string>>();
            var doc = LoadXml(filePath);
            var nodes = doc.SelectNodes(xPath);
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    var node = nodes[i];
                    var dic = new Dictionary<string, string>();
                    for (int j = 0; j < node.ChildNodes.Count; j++)
                    {
                        dic.Add(node.ChildNodes[j].Name, node.ChildNodes[j].InnerText);
                    }
                    dictionaries.Add(node.FirstChild.InnerText, dic);
                }
            }
            return dictionaries;
        }

        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
