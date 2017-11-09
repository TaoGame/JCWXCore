using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Models.ApiResponses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    /// <summary>
    /// 创建个性化菜单
    /// </summary>
    public class MenuAddConditionalRequest : ApiRequest<MenuAddConditionalResponse>
    {
        protected MenuAddConditionalRequest()
        {
        }

        internal override HttpRequestActionType Method => HttpRequestActionType.Content;

        protected override string UrlFormat => "https://api.weixin.qq.com/cgi-bin/menu/addconditional?access_token={0}";

        protected override bool NeedToken => true;

        internal override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        [JsonProperty("button")]
        public List<ClickButton> Buttons { get; set; }

        [JsonProperty("matchrule")]
        public MatchRule MatchRule { get; set; }
    }

    public class MatchRule
    {
        [JsonProperty("tag_id")]
        public string TagId { get; set; }

        [JsonIgnore]
        public Sex Sex { get; set; }

        [JsonProperty("sex")]
        public string SexString
        {
            get
            {
                return Sex.ToInt32String();
            }
        }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonIgnore]
        public ClientPlatform ClientPlatform { get; set; }

        [JsonProperty("client_platform_type")]
        public string ClientPlatformString
        {
            get
            {
                return ClientPlatform.ToInt32String();
            }
        }

        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public enum Sex
    {
        Male = 1,
        Female = 2,
        None = 99
    }

    public enum ClientPlatform
    {
        IOS = 1,
        Android = 2,
        Other = 3
    }


}
