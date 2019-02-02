using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.WX.Framework.Models.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using JCSoft.WX.Framework.Extensions;
using Microsoft.Extensions.Options;

namespace JCSoft.WX.Framework.Api
{
    public class DefaultApiClient : IApiClient
    {
        private readonly ILogger Logger;
        private readonly IHttpFactory _factory;
        private readonly WXOptions _options;


        public DefaultApiClient(ILoggerFactory loggerFactory, IHttpFactory factory, IOptions<WXOptions> options)
        {
            Logger = loggerFactory?.CreateLogger<DefaultApiClient>();
            _factory = factory;
            _options = options.Value;
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

                var url = $"{_options.ApiUrl.TrimEnd('/')}{request.GetUrl()}";
                var result = String.Empty;
                HttpAbstraction http = _factory.CreateHttp(request.Method);


                if (request.Method == HttpRequestActionType.Get)
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
