using FrameworkCoreTest;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JCSoft.WX.FrameworkTest.Api
{
    public class AccessTokenCodeTests : MockPostApiBaseTest<AccessTokenCodeRequest, AccessTokenCodeResponse>
    {
        [Fact]
        public void SuccessTests()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(response.IsError, false);
            Assert.Equal(response.OpenId, "OPENID");
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
            {
                return @"{""errcode"":40029,""errmsg"":""invalid code""}";
            }
            else
            {
                return @"{""access_token"":""ACCESS_TOKEN"",
                            ""expires_in"":7200,
                            ""refresh_token"":""REFRESH_TOKEN"",
                            ""openid"":""OPENID"",
                            ""scope"":""SCOPE"" }";
            }
        }

        protected override AccessTokenCodeRequest InitRequestObject()
        {
            return new AccessTokenCodeRequest
            {
                AppId = "123",
                AppSecret = "123123",
                Code = "123123123"
            };
        }
    }
}
