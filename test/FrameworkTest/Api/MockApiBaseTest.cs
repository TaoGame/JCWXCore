using FrameworkCoreTest;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JCSoft.WX.FrameworkTest.Api
{
    public abstract class MockApiBaseTest<TRequest, TResponse> : MockPostApiBaseTest<TRequest, TResponse>
        where TRequest : ApiRequest<TResponse>
        where TResponse : ApiResponse, new()
    {
        [Fact]
        public void Success()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);

            Assert.False(response.IsError);
        }

        [Fact]
        public void Fail()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(true, response.IsError);
        }
    }
}
