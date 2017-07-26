using System;
using System.Text;
using System.Threading.Tasks;

namespace JCSoft.Core.Net.Http
{
    public abstract class HttpAbstraction
    {
        public HttpAbstraction(HttpOptions options) => HttpOptions = options ?? new HttpOptions();

        protected HttpOptions HttpOptions { get; set; }

        protected RequestOption Request { get; private set; }

        public HttpAbstraction Setup()
        {
            Request = new RequestOption();
            return this;
        }

        public HttpAbstraction SetUrl(string url)
        {
            Request.Url = url;
            return this;
        }

        public HttpAbstraction SetEncoding(Encoding encoding)
        {
            Request.Encoding = encoding;
            return this;
        }

        public HttpAbstraction SetContent(string content)
        {
            Request.Content = content;
            return this;
        }

        public async Task<string> GetResponseAsync()
        {
            if (String.IsNullOrWhiteSpace(this.Request.Url))
            {
                throw new ArgumentNullException("Url is null!");
            }

            return await DoGetResponse();
        }

        public abstract Task<string> DoGetResponse();
    }
}
