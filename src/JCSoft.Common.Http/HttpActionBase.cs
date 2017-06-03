using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace JCSoft.Common.Http
{
    internal abstract class HttpActionBase : IHttpAction
    {
        protected string Url { get; set; }

        protected abstract string Method { get; }

        public string Content { get; set; }

        public Encoding Encoding { get; set; }

        public HttpResult GetHttpResult()
        {
            try
            {
                var request = CreateRequest(Url, Method);
                SetRequest(request);
                var response = GetResponse(request);

                return new HttpResult
                {
                    Code = 0,
                    IsError = false,
                    StreamResult = response.GetResponseStream()
                };
            }
            catch (Exception ex)
            {
                return new HttpResult
                {
                    Code = -1,
                    IsError = true,
                    ErrorMessage = ex.Message,
                    Exception = ex,
                    StreamResult = null
                };
            }
        }

        protected abstract void SetRequest(HttpWebRequest request);



        protected HttpWebResponse GetResponse(HttpWebRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request is null, please check it.");

            var responseAsync = request.GetResponseAsync();
            if (responseAsync == null)
            {
                throw new WebException("not get the response, please check your internet");
            }

            if (responseAsync.IsCompleted)
            {
                var result = responseAsync.Result as HttpWebResponse;
                if (result == null)
                    throw new WebException("don't get the httpwebresponse");

                return result;
            }

            throw new WebException("the connection throw any exception");
        }

        private HttpWebRequest CreateRequest(string url, string method)
        {
            if (String.IsNullOrEmpty(url))
                throw new ArgumentNullException("the url param is required.");

            if (String.IsNullOrEmpty(method))
                throw new ArgumentNullException("please provide the method, e.g. Get Post such as");

            HttpWebRequest request = null;
            request = HttpWebRequest.CreateHttp(url);
            request.Method = method;

            return request;
        }

        public override string ToString()
        {
            return $"action:{this.GetType().Name}, http method:{Method}, encoding:{Encoding} url:{Url}";
        }
    }
}
