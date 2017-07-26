using System;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using Xunit;
using JCSoft.WX.Framework.Models;

namespace FrameworkCoreTest
{
    public class GroupsUpdateTest : MockPostApiBaseTest<GroupsUpdateRequest, GroupsUpdateResponse>
    {
        [Fact]
        public void GroupsUpdateRequestJsonTest()
        {
            Console.WriteLine(Request.GetPostContent());
        }

        [Fact]
        public void MockGroupsUpdateTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(0, response.ErrorCode);
            Assert.Equal("ok", response.ErrorMessage);
        }

        [Fact]
        public void MockGroupsUpdateError()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(40013, response.ErrorCode);
        }

        protected override GroupsUpdateRequest InitRequestObject()
        {
            return new GroupsUpdateRequest
            {
                AccessToken = "123",
                Group = new Group
                {
                    Name = "testupdate",
                    ID = 100
                }
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
