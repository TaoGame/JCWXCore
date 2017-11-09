using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MenuCreateRequest : ApiRequest<MenuCreateResponse>
    {
        [JsonProperty("button")]
        public IEnumerable<ClickButton> Buttons { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Content; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}"; }
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
            return JsonConvert.SerializeObject(this);
        }

        public override void Validate()
        {
            base.Validate();

            if (Buttons == null)
            {
                throw new ArgumentNullException("button is null");
            }
        }
    }
}
