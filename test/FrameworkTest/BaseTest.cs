using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Api;
using JCSoft.WX.FrameworkTest.MockObject;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.IO;
using System.Text;

namespace FrameworkCoreTest
{
    public abstract class BaseTest
    {
        private static string tokenfile = "token.txt";

        static BaseTest()
        {
            //ApiAccessTokenManager.Instance.SetAppIdentity(m_appIdentity);
            
        }

        
        public BaseTest()
        {
            var factory = new HttpFactory();
            var logger = new MockLogger();
            var mockLogger = new Mock<ILogger>();
            mock_client = new Mock<DefaultApiClient>(logger, factory);
        }

        //protected IApiClient m_client = new DefaultApiClient();

        protected Mock<DefaultApiClient> mock_client = null;

       // protected Mock<ILogger> mock_logger = new Mock<ILogger>();

        public virtual string GetCurrentToken()
        {
            if (File.Exists(tokenfile))
            {
                var strs = File.ReadAllText(tokenfile, Encoding.UTF8);
                var splitstrs = strs.Split(new char[] { '|' });
                var token = splitstrs[0];
                var expirtime = DateTime.Parse(splitstrs[1]);
                if (expirtime <= DateTime.Now)
                {
                    return GetToken();
                }

                return token;
            }
            else
            {
                return GetToken();
            }
            
        }

        private string GetToken()
        {
            var token = GetCurrentToken();
            var expirtime = "7200";
            File.WriteAllText(tokenfile, token + "|" + expirtime.ToString(), Encoding.UTF8);

            return token;
        }
    }
}
