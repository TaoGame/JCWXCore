using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Api;
using JCSoft.WX.Framework.Models;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.WX.FrameworkTest.MockObject;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JCSoft.WX.FrameworkTest.Api
{
    public class AccessTokenTest
    {

        [Fact]
        public void GetResponseTest()
        {
            var request = new AccessTokenRequest(new AppIdentication("james", "mySecret"));
            var factory = new HttpFactory();
            var logger = new MockLogger();
            var mockLogger = new Mock<ILogger>();
            var client = new Mock<DefaultApiClient>(logger, factory);

                client.Setup(api => api.DoExecute(request))
                .Returns(new Task<string>(() => "{\"access_token\":\"ACCESS_TOKEN\",\"expires_in\":7200}"));

            var response = client.Object.Execute(request);

            Assert.Equal(0, response.ErrorCode);
            Assert.Equal("ACCESS_TOKEN", response.Access_Token);
            Assert.Equal(7200, response.Expires_In);
        }
    }
}
