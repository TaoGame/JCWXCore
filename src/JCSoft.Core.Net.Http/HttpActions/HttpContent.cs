using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.Core.Net.Http.HttpActions
{
    public class HttpContent : HttpPost
    {

        public HttpContent(HttpOptions options) : base(options) { }

        public override string ToString()
        {
            return $"this is a http Content, has headers:{HttpOptions.FileExtContentTypeDict.Count}, url:{Request.Url}, encoding:{Request.Encoding}, content : {Request.Content}";
        }
    }
}
