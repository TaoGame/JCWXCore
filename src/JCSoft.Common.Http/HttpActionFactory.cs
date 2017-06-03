using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.Common.Http
{
    internal class HttpActionFactory
    {
        private HttpActionFactory() { }

        private static Lazy<HttpActionFactory> lazy_instance = 
            new Lazy<HttpActionFactory>(() => new HttpActionFactory());

        internal static HttpActionFactory Instance
        {
            get
            {
                return lazy_instance.Value;
            }
        }
    }
}
