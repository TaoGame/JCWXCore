using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JCSoft.Core.Net.Http.HttpActions
{
    public class HttpGet : HttpAbstraction
    {
        public HttpGet(HttpOptions options) : base(options) { }

        public override async Task<string> DoGetResponseAsync()
        {
            HttpClient httpClient = new HttpClient();
            var data = await httpClient.GetByteArrayAsync(Request.Url);
            var ret = Request.Encoding.GetString(data);
            return ret;
        }
    }
}
