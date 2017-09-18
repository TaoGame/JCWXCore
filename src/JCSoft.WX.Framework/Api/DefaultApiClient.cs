using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.WX.Framework.Models.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace JCSoft.WX.Framework.Api
{
    public class DefaultApiClient : IApiClient
    {
        private readonly ILogger Logger;
        private readonly IHttpFactory _factory;


        public DefaultApiClient(ILoggerFactory loggerFactory, IHttpFactory factory)
        {
            Logger = loggerFactory?.CreateLogger<DefaultApiClient>();
            _factory = factory;
        }

        public T Execute<T>(ApiRequest<T> request)
                    where T : ApiResponse, new()
        {
            request.Validate();

            var execResult = DoExecute(request);
            T result = null;
            try
            {
                result = JsonConvert.DeserializeObject<T>(execResult.Result);

                return result;
            }
            catch (Exception ex)
            {

                if (request.NotHasResponse)
                {
                    return new T();
                }

                Logger?.LogError(ex.ToString());
                throw new WXApiException(WXErrorCode.GetResponseFaild, ex.ToString());
            }
        }

        public virtual async Task<string> DoExecute<T>(ApiRequest<T> request)
            where T : ApiResponse
        {
            try
            {
                var url = request.GetUrl();
                var result = String.Empty;
                HttpAbstraction http = null;
                switch (request.Method)
                {
                    case "FILE":
                        http = _factory.CreateHttp(HttpRequestActionType.File);
                        break;
                    case "POST":
                        http = _factory.CreateHttp(HttpRequestActionType.Content);
                        break;
                    case "GET":
                        http = _factory.CreateHttp(HttpRequestActionType.Get);
                        break;
                    case "XML":
                        http = _factory.CreateHttp(HttpRequestActionType.Xml);
                        break;
                }

                if (request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
                {
                    return await http.Setup()
                    .SetUrl(url)
                    .GetResponseAsync();
                }

                return await http.Setup()
                    .SetUrl(url)
                    .SetContent(request.GetPostContent())
                    .GetResponseAsync();
            }
            catch (Exception ex)
            {
                throw new WXApiException(WXErrorCode.GetResponseFaild, $"get response is faild, method is :{request.GetType().FullName}", ex);
            }
        }
    }
}
