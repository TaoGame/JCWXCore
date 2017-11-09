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
    public class GroupsMembersUpdateTest : MockPostApiBaseTest<GroupsMembersUpdateRequest, GroupsMembersUpdateResponse>
    {
       

        protected override GroupsMembersUpdateRequest InitRequestObject()
        {
            return new GroupsMembersUpdateRequest
            {
                AccessToken = "123",
                OpenId = "test_openid",
                ToGroupId = 100
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
                return "{\"errcode\":40013,\"errmsg\":\"invalid appid\"}";
            return "{\"errcode\": 0, \"errmsg\": \"ok\"}";
        }
    }
}
