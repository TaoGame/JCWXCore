using JCSoft.WX.Framework.Common;
using System;
using System.Diagnostics;
using Xunit;

namespace JCSoft.WX.FrameworkTest
{
    public class HttpHelpTest
    {

        private static string s_url = "http://www.sh-bus.com";

        [Fact]
        public void GetTest()
        {
            var getresult = HttpHelper.HttpGet(s_url);
            var postresult = HttpHelper.HttpPost(s_url, "");

            Assert.True(getresult.Length > 0);
            Assert.True(postresult.Length > 0);

            Assert.Equal(getresult.Length, postresult.Length);
        }
    }
}
