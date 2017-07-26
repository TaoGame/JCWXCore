using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class SnsOauthRefreshTokenRequest : ApiRequest<SnsOAuthAccessTokenResponse>
    {
        public string AppID { get; set; }

        public string RefreshToken { get; set; }

        public override string Method
        {
            get { return "GET"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}"; }
        }

        public override string GetUrl()
        {
            return String.Format(UrlFormat, AppID, RefreshToken);
        }

        protected override bool NeedToken
        {
            get { return false; }
        }

        public override string GetPostContent()
        {
            return String.Empty;
        }
    }
}
