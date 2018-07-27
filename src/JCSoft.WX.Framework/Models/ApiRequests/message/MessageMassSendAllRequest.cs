using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class SendFilter
    {
        [JsonProperty("group_id")]
        public string GroupId { get; set; }
    }

    public class SendMPNews
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }


    public class MessageMassSendAllRequest : ApiRequest<MessageMassSendAllResponse>
    {
        [JsonProperty("filter")]
        public SendFilter Filter { get; set; }

        [JsonProperty("mpnews")]
        public SendMPNews MPNews { get; set; }

        [JsonProperty("msgtype")]
        public string MsgType { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Content; }
        }

        protected override string UrlFormat
        {
            get { return "/cgi-bin/message/mass/sendall?access_token={0}"; }
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
    }
}
