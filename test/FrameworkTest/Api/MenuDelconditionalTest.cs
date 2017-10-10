using FrameworkCoreTest;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JCSoft.WX.FrameworkTest.Api
{
    public class MenuDelconditionalTest : MockPostApiBaseTest<MenuDelconditionalRequest, MenuDelconditionalResponse>
    {
        [Fact]
        public void Success()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);

            Assert.False(response.IsError);
        }

        [Fact]
        public void Error()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(true, response.IsError);
            //Console.WriteLine(response);
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
            {
                return "{\"errcode\":40029,\"errmsg\":\"invalid code\"}";
            }

            return "{\"errcode\":0,\"errmsg\":\"ok\"}";
        }

        protected override MenuDelconditionalRequest InitRequestObject()
        {
            return new MenuDelconditionalRequest
            {
                AccessToken = "123",
                MenuId = "123123"
            };
        }
    }
    
}
