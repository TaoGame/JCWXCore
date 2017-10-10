using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class UserInfoRequest : ApiRequest<UserInfoResponse>
    {
        public string OpenId { get; set; }

        public string Lang { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Get; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang={2}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, OpenId, Lang);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        internal override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
