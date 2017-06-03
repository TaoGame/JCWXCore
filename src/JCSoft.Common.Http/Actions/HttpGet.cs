using System.Net;

namespace JCSoft.Common.Http.Actions
{
    internal class HttpGet : HttpActionBase
    {
        protected override string Method =>  HttpMethod.GET;

        protected override void SetRequest(HttpWebRequest request)
        {
            
        }
    }
}
