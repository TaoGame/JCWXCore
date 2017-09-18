using JCSoft.Core.Net.Http.HttpActions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.Core.Net.Http
{
    public class HttpFactory : IHttpFactory
    {
        private HttpOptions _options;

        public HttpFactory() { }

        public HttpFactory(HttpOptions options) => _options = options;
        public HttpAbstraction CreateHttp(HttpRequestActionType requestType)
        {
            HttpAbstraction result = null;
            switch (requestType)
            {
                case HttpRequestActionType.Get:
                    result = new HttpGet(_options);
                    break;
                case HttpRequestActionType.Content:
                    result = new HttpContent(_options);
                    break;
                case HttpRequestActionType.File:
                    result = new HttpFile( _options);
                    break;
                case HttpRequestActionType.Xml:
                    result = new HttpXml(_options);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("don't support request Type");
            }

            return result;
        }
    }
}
