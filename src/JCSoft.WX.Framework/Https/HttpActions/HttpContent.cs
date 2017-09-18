using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JCSoft.Core.Net.Http.HttpActions
{
    public class HttpContent : HttpPost
    {

        public HttpContent(HttpOptions options) : base(options) { }

        public override async Task<string> DoGetResponseAsync()
        {
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsync(Request.Url, new StringContent(Request.Content));

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return String.Empty;
            }
        }
    }
}
