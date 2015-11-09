using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace MateCat.Net.Helpers
{
    internal static class HttpHelper
    {
        public static String Get(String url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (var response = request.GetResponse())
            {
                return response.ResponseToString();
            }
        }

        public static String Post(String url, NameValueCollection parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            var builder = new StringBuilder();
            foreach (String key in parameters.Keys)
            {
                builder.AppendFormat("{0}={1}&", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(parameters[key]));
            }
            builder.Length -= 1;

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(builder.ToString());
            }

            using (var response = request.GetResponse())
            {
                return response.ResponseToString();
            }
        }

        public static String UploadFiles(String url, IEnumerable<HttpPostFile> files, NameValueCollection parameters)
        {
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);

            var request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundary;

            boundary = "--" + boundary;

            using (var stream = request.GetRequestStream())
            {
                foreach (var file in files)
                {
                    var buffer = Encoding.UTF8.GetBytes(boundary + Environment.NewLine);
                    stream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(String.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", file.Name, file.FileName, Environment.NewLine));
                    stream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(String.Format("Content-Type: {0}{1}{1}", file.ContentType, Environment.NewLine));
                    stream.Write(buffer, 0, buffer.Length);
                    file.Stream.CopyTo(stream);
                    buffer = Encoding.UTF8.GetBytes(Environment.NewLine);
                    stream.Write(buffer, 0, buffer.Length);
                }

                foreach (String name in parameters.Keys)
                {
                    var buffer = Encoding.UTF8.GetBytes(boundary + Environment.NewLine);
                    stream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(String.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
                    stream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(parameters[name] + Environment.NewLine);
                    stream.Write(buffer, 0, buffer.Length);
                }

                var boundaryBuffer = Encoding.UTF8.GetBytes(boundary + "--");
                stream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
            }

            using (var response = request.GetResponse())
            {
                return response.ResponseToString();
            }
        }

        #region Private

        private static String ResponseToString(this WebResponse response)
        {
            var result = String.Empty;

            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }

                    stream.Close();
                }
            }

            return result;
        }

        #endregion Private
    }
}
