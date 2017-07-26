using System;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using Xunit;
using JCSoft.WX.Framework.Models;

namespace FrameworkCoreTest
{
    public class GroupCreateTest : MockPostApiBaseTest<GroupsCreateRequest, GroupCreateResponse>
    {
        
        [Fact]
        public void MockGroupCreateTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Console.WriteLine(response);
        }

        [Fact]
        public void MockGroupCreateErrorTest()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Console.WriteLine(response);
        }


        protected override string GetReturnResult(bool errResult)
        {
            if (!errResult)
            {
                return @"{
                    ""group"": 
                        {
                            ""id"": 0, 
                            ""name"": ""未分组"", 
                            ""count"": 72596
                        }
                }";
            }
            else
            {
                return "{\"errcode\":40013,\"errmsg\":\"invalid appid\"}";
            }
        }

        protected override GroupsCreateRequest InitRequestObject()
        {
            return new GroupsCreateRequest
            {
                AccessToken = "123",
                Group = new Group
                {
                    Name = "test"
                }
            };
        }
    }
}
