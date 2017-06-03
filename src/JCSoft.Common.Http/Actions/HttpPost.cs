using System.IO;
using System.Net;

namespace JCSoft.Common.Http.Actions
{
    internal class HttpPost : HttpActionBase
    {
        protected override string Method => HttpMethod.POST;

        protected override void SetRequest(HttpWebRequest request)
        {
            request.ContentType = "application/json; charset=utf-8";
            var postBytes = Encoding.GetBytes(Content);

            using (Stream stream = request.GetRequestStreamAsync().Result)
            {
                stream.Write(postBytes, 0, postBytes.Length);
            }
        }
    }
}
