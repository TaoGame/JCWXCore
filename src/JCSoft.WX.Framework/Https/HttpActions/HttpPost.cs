using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JCSoft.Core.Net.Http.HttpActions
{
    public abstract class HttpPost : HttpAbstraction
    {

        public HttpPost(HttpOptions options) : base(options) { }

        public override  Task<string> DoGetResponseAsync()
        {
            throw new NotImplementedException();
        }
    }
}
