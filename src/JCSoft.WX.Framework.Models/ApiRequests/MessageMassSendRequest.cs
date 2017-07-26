using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MessageMassSendRequest : ApiRequest<MessageMassSendResponse>
    {
        [JsonProperty("touser")]
        public string[] ToUsers { get; set; }

        [JsonProperty("mpnews")]
        public SendMPNews MpNews { get; set; }

        [JsonProperty("msgtype")]
        public string MsgType { get; set; }

        public override string Method
        {
            get { return "POST"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}"; }
        }

        public override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
