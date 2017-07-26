using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Api;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JCSoft.WX.FrameworkTest.Api
{
    public abstract class BaseApiTest<T>
        where T : ApiResponse
    {
        protected readonly IHttpFactory _factory;
        protected readonly ILogger _logger;
        protected readonly Mock<DefaultApiClient> _client;
        public BaseApiTest()
        {
            _factory = new HttpFactory();
            _logger = new Mock<ILogger>().Object;
            _client = new Mock<DefaultApiClient>(_logger, _factory);
            _client.Setup(api => api.DoExecute(Request)).Returns(new Task<string>(() => GetResponse()));
        }

        protected abstract ApiRequest<T> Request { get; }

        protected abstract string GetResponse();
    }
}
