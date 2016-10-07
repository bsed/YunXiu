using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model.Global;

namespace YunXiu.Commom.SMS
{
    public class MEILIANSMS : ISMS
    {

        public bool Send(List<string> Phones, string Content)
        {
            var isSend = false;
            var url = GlobalDictionary.GetSMSConfVal("url");
            //UTF-8格式：   String encode="UTF-8"
            String encode = GlobalDictionary.GetSMSConfVal("encode"); //"UTF-8";  //页面编码和短信内容编码为GBK。重要说明：如提交短信后收到乱码，请将GBK改为UTF-8测试。如本程序页面为编码格式为：ASCII/GB2312/GBK则该处为GBK。如本页面编码为UTF-8或需要支持繁体，阿拉伯文等Unicode，请将此处写为：UTF
            String username = GlobalDictionary.GetSMSConfVal("username");  //用户名
            String password_md5 = GlobalDictionary.GetSMSConfVal("password_md5");//"";  ////32位MD5密码加密，不区分大小写                                                                           //  String mobile = GlobalDictionary.GetSMSConfVal"";  //手机号,只发一个号码：13800000001。发多个号码：13800000001,13800000002,...N 。使用半角逗号分隔。
            String apikey = GlobalDictionary.GetSMSConfVal("apikey");// "";  //apikey秘钥（请登录 http://m.5c.com.cn 短信平台-->账号管理-->我的信息 中复制apikey）
            String content2 = UrlEncode(Content);
            //新建一个StringBuilder类
            StringBuilder sbTemp = new StringBuilder();

            //发送链接（用户名，密码，手机号，apikey，短信内容，编码格式）
            sbTemp.Append("username=" + username + "&password_md5=" + password_md5 + "&mobile=" + string.Join(",", Phones) + "&apikey=" + apikey + "&content=" + content2 + "&encode=" + encode);

            //对短信内容做Urlencode编码操作。
            byte[] bTemp = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(sbTemp.ToString());
            //发送返回的结果存入result中
            //  String result = PostRequest("http://m.5c.com.cn/api/send/?", bTemp);  ////如连接超时，可能是您服务器不支持域名解析，请将下面连接中的：【m.5c.com.cn】修改为IP：【115.28.23.78】
            String result = PostRequest(url, bTemp);
            //输出result内容，查看返回值，成功为success，错误为error，详见该文档起始注释
            if (result == "success")
            {
                isSend = true;
            }
            return isSend;
        }

        //POST方式发送得结果
        private static String PostRequest(string url, byte[] bData)
        {
            System.Net.HttpWebRequest hwRequest;
            System.Net.HttpWebResponse hwResponse;

            string strResult = string.Empty;
            try
            {
                //获取上面的URL链接
                hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                //设置超时时间
                hwRequest.Timeout = 5000;
                //发送请求为POST
                hwRequest.Method = "POST";
                hwRequest.ContentType = "application/x-www-form-urlencoded";
                //bData的长度（也就是获取用户名，密码，手机号，apikey，短信内容，编码格式总长度）
                hwRequest.ContentLength = bData.Length;
                //发送
                System.IO.Stream smWrite = hwRequest.GetRequestStream();
                smWrite.Write(bData, 0, bData.Length);
                //释放资源
                smWrite.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
                return strResult;
            }

            //get response
            try
            {
                //使用hwResponse来获取数据
                hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
                strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
            }

            return strResult;
        }
        //URLencode编码
        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }
        private static void WriteErrLog(string strErr)
        {
            Console.WriteLine(strErr);
            System.Diagnostics.Trace.WriteLine(strErr);
        }
    }
}


