using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace HpEcommerce
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class HttpClient
    {
        public Dictionary<string, string> HttpHeaders { get; set; }
        const string UTF8 = "utf-8";
        const string APPLICATION_XML = "application/xml";

        public HttpClient()
        {
        }

        public HttpWebResponse sendPostRequest(string url, string body, string sharedSecret)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = HttpVerb.POST.ToString();
                request.ContentLength = 0;
                request.ContentType = APPLICATION_XML;

                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding(UTF8).GetBytes(body);
                request.ContentLength = bytes.Length;

                generateHeaders(request, body, sharedSecret);

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
                return (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                return (HttpWebResponse)e.Response;
            }
        }

        public HttpWebResponse sendPutRequest(string url, string body, string sharedSecret)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = HttpVerb.PUT.ToString();
                request.ContentLength = 0;
                request.ContentType = APPLICATION_XML;

                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding(UTF8).GetBytes(body);
                request.ContentLength = bytes.Length;

                generateHeaders(request, body, sharedSecret);

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
                return (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                return (HttpWebResponse)e.Response;
            }
        }

        public HttpWebResponse sendGetRequest(string url, string sharedSecret)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = HttpVerb.GET.ToString();
                request.ContentLength = 0;
                request.ContentType = APPLICATION_XML;

                var encoding = new UTF8Encoding();

                generateHeaders(request, "", sharedSecret);
                return (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                return (HttpWebResponse)e.Response;
            }
        }

        public HttpWebResponse sendDeleteRequest(string url, string sharedSecret)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = HttpVerb.DELETE.ToString();
                request.ContentLength = 0;
                request.ContentType = APPLICATION_XML;

                var encoding = new UTF8Encoding();

                generateHeaders(request, "", sharedSecret);
                return (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                return (HttpWebResponse)e.Response;
            }
        }


        public void generateHeaders(HttpWebRequest request, string body, string sharedSecret)
        {
            string now = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            request.Headers.Add("mws-date", now);
            request.Headers.Add("mws-hmac", generateHmac(getHmacstring(request, now, body), Encoding.UTF8.GetBytes(sharedSecret)));
        }

        public string generateHmac(string input, byte[] sharedSecret)
        {
            HMACSHA1 myhmacsha1 = new HMACSHA1(sharedSecret);
            byte[] byteArray = Encoding.ASCII.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + string.Format("{0:x2}", e), s => s);
        }

        public string getHmacstring(HttpWebRequest request, string date, string body)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(request.Method);
            builder.Append(request.RequestUri.PathAndQuery);
            builder.Append(date);
            builder.Append(body);
            return builder.ToString();
        }
    }
}
