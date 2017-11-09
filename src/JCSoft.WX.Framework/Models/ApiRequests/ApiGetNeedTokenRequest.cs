using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public abstract class ApiGetNeedTokenRequest<T> : ApiRequest<T>
        where T : ApiResponse
    {

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Get; }
        }

        protected abstract  override string UrlFormat { get; }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        internal override string GetPostContent()
        {
            return String.Empty;
        }
    }
}
