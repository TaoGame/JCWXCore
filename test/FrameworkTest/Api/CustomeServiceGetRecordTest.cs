using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using Xunit;

namespace FrameworkCoreTest
{
    public class CustomeServiceGetRecordTest : MockPostApiBaseTest<CustomServiceGetRecordRequest, CustomServiceGetRecordResponse>
    {
        
        protected override CustomServiceGetRecordRequest InitRequestObject()
        {
            return new CustomServiceGetRecordRequest
            {
                StartTime = new DateTime(2014,1,1),
                EndTime = new DateTime(2014,3,1),
                AccessToken = "123",
                OpenId = "123",
                PageIndex = 1,
                PageSize = 10
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
            {
                return "{\"errcode\":40029,\"errmsg\":\"invalid code\"}";
            }

            return @"{
                ""recordlist"": [
                    {
                        ""worker"": "" test1"",
                        ""openid"": ""oDF3iY9WMaswOPWjCIp_f3Bnpljk"",
                        ""opercode"": 2002,
                        ""time"": 1400563710,
                        ""text"": "" 您好，客服test1为您服务。""
                    },
                    {
                        ""worker"": "" test1"",
                        ""openid"": ""oDF3iY9WMaswOPWjCIp_f3Bnpljk"",
                        ""opercode"": 2003,
                        ""time"": 1400563731,
                        ""text"": "" 你好，有什么事情？ ""
                    },
                ]
            }";
        }
    }
}
