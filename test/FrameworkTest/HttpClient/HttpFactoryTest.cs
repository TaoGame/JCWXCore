using JCSoft.Core.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JCSoft.WX.FrameworkTest.HttpClient
{
    public class HttpFactoryTest
    {
       
        public HttpFactoryTest()
        {
           // _factory = new HttpFactory();
        }
        [Fact]
        public async System.Threading.Tasks.Task CreateHttpActionTestAsync()
        {
            var options = new HttpOptions();
            options.AddFileExtAsContentType(".txt", "is txt file");

            var factory = new HttpFactory(options);
            var httpGet = factory.CreateHttp(HttpRequestActionType.Get)
                .Setup()
                .SetUrl("http://www.baidu.com");

            var response = await httpGet.GetResponseAsync();

            Assert.NotEmpty(response);
        }

        [Fact]
        public void CreateNotSupportActionTest()
        {
            var factory = new HttpFactory();
            Assert.Throws(typeof(ArgumentOutOfRangeException), () =>
            {
                factory.CreateHttp(HttpRequestActionType.None)
                .Setup()
                .SetUrl("http://localhost")
                .SetContent("");
            });
        }
    }
}
