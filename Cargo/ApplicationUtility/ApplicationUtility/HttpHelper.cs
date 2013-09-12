using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationUtility
{
    public class HttpHelper
    {
         protected int defer;

        //public CookieContainer cookies = new CookieContainer();

         public HttpHelper()
        {
            //this.cookies = new CookieContainer();

            this.defer = 1000;
        }

        public WebResponse doPost(string url, string postData)
        {
            try
            {
                Thread.Sleep(this.defer);
                byte[] paramByte = Encoding.UTF8.GetBytes(postData);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                //webRequest.Accept = "application/x-shockwave-flash, image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-silverlight, */*";
                //webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; CIBA)";
                webRequest.ContentLength = paramByte.Length;
                //webRequest.CookieContainer = this.cookies;
                //webRequest.Timeout = 5000;
                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(paramByte, 0, paramByte.Length);
                newStream.Close();
                return webRequest.GetResponse();
            }
            catch (Exception ce)
            {
                return null;
            }
        }
        public WebResponse doPost(string url, string postData, string referer)
        {
            try
            {
                Thread.Sleep(this.defer);
                byte[] paramByte = Encoding.UTF8.GetBytes(postData);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                //webRequest.CookieContainer = this.cookies;
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Referer = referer;

                //webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; CIBA)";
                webRequest.ContentLength = paramByte.Length;
                webRequest.Timeout = 5000;
                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(paramByte, 0, paramByte.Length);
                newStream.Close();
                return webRequest.GetResponse();
            }
            catch (Exception ce)
            {
                return null;
            }
        }

        public WebResponse doGet(string url)
        {
            try
            {
                //Thread.Sleep(1000);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                //webRequest.CookieContainer = this.cookies;
                webRequest.Method = "get";
                webRequest.Timeout = 5000;
                return webRequest.GetResponse();
            }
            catch (Exception ce)
            {
                return null;
            }
        }
        public WebResponse doGet(string url, string referer)
        {
            try
            {
                //Thread.Sleep(1000);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                //webRequest.CookieContainer = this.cookies;
                webRequest.Method = "get";
                webRequest.Referer = referer;
                //webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; CIBA)";
                return webRequest.GetResponse();
            }
            catch (Exception ce)
            {
                return null;
            }
        }

        public string ResponseToString(WebResponse response)
        {
            if (response == null)
                return "";
            try
            {
                Encoding encoding = Encoding.Default;
                string ContentType = response.ContentType.Trim();
                if (ContentType.IndexOf("utf-8") != -1)
                    encoding = Encoding.UTF8;
                else if (ContentType.IndexOf("utf-7") != -1)
                    encoding = Encoding.UTF7;
                else if (ContentType.IndexOf("unicode") != -1)
                    encoding = Encoding.Unicode;
                StreamReader stream = new StreamReader(response.GetResponseStream(), encoding);
                string code = stream.ReadToEnd();
                stream.Close();
                response.Close();
                return code;
            }
            catch (Exception ce)
            {
                return null;
            }
        }


        public string ResponseToStringWithGzip(WebResponse response)
        {
            if (response == null)
                return "";
            try
            {
                Encoding encoding = Encoding.Default;
                string ContentType = response.ContentType.Trim().ToLower();
                if (ContentType.IndexOf("utf-8") != -1)
                    encoding = Encoding.UTF8;
                else if (ContentType.IndexOf("utf-7") != -1)
                    encoding = Encoding.UTF7;
                else if (ContentType.IndexOf("unicode") != -1)
                    encoding = Encoding.Unicode;
                else if (ContentType.IndexOf("gbk") != -1)
                    encoding = Encoding.GetEncoding("GBK");

                StreamReader stream;
                GZipStream gz = null;

                if (!string.IsNullOrEmpty(response.Headers["Content-Encoding"]) && response.Headers["Content-Encoding"].ToLower() == "gzip")
                {
                    gz = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    stream = new StreamReader(gz, encoding);
                }
                else
                {
                    stream = new StreamReader(response.GetResponseStream(), encoding);
                }
                string code = stream.ReadToEnd();
                stream.Close();
                if (gz != null)
                    gz.Close();
                response.Close();
                return code;
            }
            catch (Exception ce)
            {
                return null;
            }
        }
    }
}
