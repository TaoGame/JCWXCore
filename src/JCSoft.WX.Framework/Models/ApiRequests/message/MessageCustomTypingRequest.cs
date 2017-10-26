using JCSoft.WX.Framework.Models.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;
using JCSoft.Core.Net.Http;
using Newtonsoft.Json;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MessageCustomTypingRequest : ApiRequest<DefaultResponse>
    {
        [JsonProperty("touser")]
        public string ToUser { get; set; }

        [JsonProperty("command")]
        public TypeCommand Comand { get; set; }


        protected override string UrlFormat => "htts://api.weixin.qq.com/cgi-bin/message/custom/typing?access_token={0}";

        protected override bool NeedToken => true;

        internal override HttpRequestActionType Method => HttpRequestActionType.Content;

        internal override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }
    }

    public enum TypeCommand
    {
        Typing,
        CancelTyping
    }
}
