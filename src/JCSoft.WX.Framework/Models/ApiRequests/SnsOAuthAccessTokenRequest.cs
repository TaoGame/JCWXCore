using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class SnsOAuthAccessTokenRequest : ApiRequest<SnsOAuthAccessTokenResponse>
    {
        public string AppID { get; set; }

        public string AppSecret { get; set; }

        public string Code { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Get; }
        }

        protected override string UrlFormat
        {
            get { return "/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AppID, AppSecret, Code);
        }

        protected override bool NeedToken
        {
            get { return false; }
        }

        internal override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
