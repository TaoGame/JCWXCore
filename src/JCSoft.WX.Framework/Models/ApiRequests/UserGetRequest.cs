using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class UserGetRequest : ApiRequest<UserGetResponse>
    {
        [JsonProperty("next_openid")]
        public string NextOpenId { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Get; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, NextOpenId);
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
