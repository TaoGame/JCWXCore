using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Models.ApiResponses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MenuTrymatchRequest : ApiRequest<MenuTrymatchResponse>
    {
        internal override HttpRequestActionType Method => HttpRequestActionType.Content;

        protected override string UrlFormat => "/cgi-bin/menu/trymatch?access_token={0}";

        protected override bool NeedToken => true;

        internal override string GetPostContent() => JsonConvert.SerializeObject(this);

        internal override string GetUrl() => String.Format(UrlFormat, AccessToken);

        /// <summary>
        /// user_id可以是粉丝的OpenID，也可以是粉丝的微信号。
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
