using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JCSoft.Core.Net.Http.HttpActions
{
    public class HttpFile : HttpPost
    {

        public HttpFile(HttpOptions options) : base(options) { }

        public override Task<string> DoGetResponseAsync()
        {
            return base.DoGetResponseAsync();
        }
    }
}
