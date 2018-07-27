using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class SnsOauthRefreshTokenRequest : ApiRequest<SnsOAuthAccessTokenResponse>
    {
        public string AppID { get; set; }

        public string RefreshToken { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Get; }
        }

        protected override string UrlFormat
        {
            get { return "/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AppID, RefreshToken);
        }

        protected override bool NeedToken
        {
            get { return false; }
        }

        internal override string GetPostContent()
        {
            return String.Empty;
        }
    }
}
