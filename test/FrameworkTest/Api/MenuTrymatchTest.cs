using JCSoft.WX.Framework.Models.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;
using JCSoft.WX.Framework.Models.ApiRequests;

namespace JCSoft.WX.FrameworkTest.Api
{
    public class MenuTrymatchTest : MockApiBaseTest<MenuTrymatchRequest, MenuTrymatchResponse>
    {
        protected override string GetReturnResult(bool errResult)
        {
            if(errResult)
                return "{\"errcode\":40029,\"errmsg\":\"invalid code\"}";
            return @"{
    ""button"": [
        {
                ""type"": ""view"", 
            ""name"": ""tx"", 
            ""url"": ""http://www.qq.com/"", 
            ""sub_button"": [ ]
    }, 
        {
            ""type"": ""view"", 
            ""name"": ""tx"", 
            ""url"": ""http://www.qq.com/"", 
            ""sub_button"": [ ]
}, 
        {
            ""type"": ""view"", 
            ""name"": ""tx"", 
            ""url"": ""http://www.qq.com/"", 
            ""sub_button"": [ ]
        }
    ]
}";
        }

        protected override MenuTrymatchRequest InitRequestObject()
        {
            return new MenuTrymatchRequest
            {
                AccessToken = "123",
                UserId = "weixin"
            };
        }
    }
}
