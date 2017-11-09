using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests.message
{
    public class MessageCustomSendMpnewsRequest : MessageCustomSendRequest
    {
        public override string MsgType => "mpnews";

        [JsonProperty("mpnews")]
        public SendMPNews MpNews { get; set; }
    }
}
