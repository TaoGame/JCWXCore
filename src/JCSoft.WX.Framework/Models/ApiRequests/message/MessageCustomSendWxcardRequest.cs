using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests.message
{
    public class MessageCustomSendWxcardRequest : MessageCustomSendRequest
    {
        public override string MsgType => "wxcard";

        [JsonProperty("wxcard")]
        public CardMessage CardMessage { get; set; }
    }
}
