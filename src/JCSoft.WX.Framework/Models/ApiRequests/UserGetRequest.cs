using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class UserGetRequest : ApiRequest<UserGetResponse>
    {
        [JsonProperty("next_openid")]
        public string NextOpenId { get; set; }

        public override string Method
        {
            get { return "GET"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}"; }
        }

        public override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, NextOpenId);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
