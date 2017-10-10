using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Models.ApiResponses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MenuDelconditionalRequest : ApiRequest<MenuDelconditionalResponse>
    {
        internal override HttpRequestActionType Method => HttpRequestActionType.Content;

        protected override string UrlFormat => "https://api.weixin.qq.com/cgi-bin/menu/delconditional?access_token={0}";

        protected override bool NeedToken => true;

        internal override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }

        internal override string GetUrl() => String.Format(UrlFormat, AccessToken);

        [JsonProperty("menuid")]
        public string MenuId { get; set; }
    }
}
