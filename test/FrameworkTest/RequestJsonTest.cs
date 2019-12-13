using JCSoft.WX.Framework.Models.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JCSoft.WX.FrameworkTest
{
    public class RequestJsonTest
    {
        [Fact]
        public void JsonTest()
        {
            RequestTextMessage message = new RequestTextMessage
            {
                Content = "hello world",
                FromUserName = "james",
                ToUserName = "candy",
                MsgId = 1111111111
            };

            var str = JsonConvert.SerializeObject(message);

            Console.WriteLine(str);

            RequestTextMessage message1 = JsonConvert.DeserializeObject<RequestTextMessage>("{\"MsgType\":0,\"Content\":\"你好\",\"CContent\":{\"#cdata-section\":\"你好\"},\"MsgId\":22556489162208958,\"CFromUserName\":{\"#cdata-section\":\"oGBq6uGtJYFA8MrAtFFLeKLUV0Pk\"},\"CMsgType\":{\"#cdata-section\":\"text\"},\"CreateTime\":1575552307,\"CToUserName\":{\"#cdata-section\":\"gh_4525e175ee5b\"},\"FromUserName\":\"oGBq6uGtJYFA8MrAtFFLeKLUV0Pk\",\"ToUserName\":\"gh_4525e175ee5b\"}");

        }
    }
}
