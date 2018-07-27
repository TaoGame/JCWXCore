using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class GetCurrentAutoreplyInfoRequest : ApiRequest<GetCurrentAutoreplyInfoResponse>
    {
        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Get; }
        }

        protected override string UrlFormat
        {
            get { return "/cgi-bin/get_current_autoreply_info?access_token={0}"; }
        }

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
