using JCSoft.WX.Framework.Exceptions;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace JCSoft.WX.Framework.Common
{
    public static class HttpHelper
    {
        public static string HttpGet(string url)
        {
            var req = CreateRequest(url, "GET");

            using (var res = GetResponse(req))
            using (var stream = res.GetResponseStream())
            using (var reader = new System.IO.StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static string HttpPost(string url, string content)
        {
            var req = CreateRequest(url, "POST");
            var postBytes = Encoding.UTF8.GetBytes(content);
            req.ContentType = "application/json; charset=utf-8";
            using (Stream stream = req.GetRequestStreamAsync().Result)
            {
                stream.Write(postBytes, 0, postBytes.Length);
                using (var res = GetResponse(req))
                using (var rstream = res.GetResponseStream())
                using (var reader = new System.IO.StreamReader(rstream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static string HttpPostXml(string url, string content)
        {
            var req = CreateRequest(url, "POST");
            var postdate = content;
            var postBytes = Encoding.UTF8.GetBytes(postdate);
            req.ContentType = "text/xml; charset=utf-8";
            using (var stream = req.GetRequestStreamAsync().Result)
            {
                stream.Write(postBytes, 0, postBytes.Length);
            }

            using (var res = GetResponse(req))
            using (var rstream = res.GetResponseStream())
            using (var reader = new System.IO.StreamReader(rstream, Encoding.UTF8))
            {
                var result = reader.ReadToEnd();

                return result;
            }
        }

        public static string HttpUploadFile(string url, string file)
        {
            if (!File.Exists(file))
            {
                throw new WXApiException(WXErrorCode.FileNotFind, "upload file not found!");
            }

            FileInfo fileInfo = new FileInfo(file);

            string result = string.Empty;
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            var request = CreateRequest(url, "POST");
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Headers["KeepAlive"] = "true";

            var stream = request.GetRequestStreamAsync().Result;
            stream.Write(boundarybytes, 0, boundarybytes.Length);

            var headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            var header = string.Format(headerTemplate, fileInfo.Name, file, GetContentType(fileInfo));
            var headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            stream.Write(headerbytes, 0, headerbytes.Length);

            var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            var buffer = new byte[4096];
            var bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                stream.Write(buffer, 0, bytesRead);
            }

            var trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            stream.Write(trailer, 0, trailer.Length);

            using (var res = GetResponse(request))
            using (var rstream = res.GetResponseStream())
            using (var reader = new System.IO.StreamReader(rstream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();

                return result;
            }
        }

        internal static string HttpGetFile(string url)
        {
            var req = CreateRequest(url, "GET");

            using (var res = GetResponse(req))
            using (var stream = res.GetResponseStream())
            using (var reader = new System.IO.StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        private static HttpWebRequest CreateRequest(string url, string method)
        {
            HttpWebRequest request = null;
            try
            {
                request = HttpWebRequest.CreateHttp(url);
                request.Method = method;
            }
            catch (Exception ex)
            {
                throw new WXApiException(WXErrorCode.CreateRequestFaild, "error in the creating HttpwebRequest", ex);
            }

            return request;
        }

        private static string GetContentType(FileInfo fileInfo)
        {
            var contentType = "";
            switch (fileInfo.Extension.ToLower())
            {
                case ".jpg":
                    contentType = "image/jpeg";
                    break;

                case ".mp3":
                    contentType = "audio/mp3";
                    break;

                case ".amr":
                    contentType = "audio/amr";
                    break;

                case ".mp4":
                    contentType = "video/mp4";
                    break;

                default:
                    throw new NotSupportedException("文件格式不支持");
            }

            return contentType;
        }

        private static HttpWebResponse GetResponse(HttpWebRequest request)
        {
            var task = request.GetResponseAsync();
            var response = task.Result as HttpWebResponse;
            if (response == null)
            {
                throw new WXApiException(WXErrorCode.GetResponseFaild, "GetRequest find error!");
            }
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new WXApiException(WXErrorCode.GetResponseFaild, "GetRequest status code isnot ok!");
            }

            return response;
        }
    }
}