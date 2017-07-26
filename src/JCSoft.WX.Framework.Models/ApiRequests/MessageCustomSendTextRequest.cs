using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MessageCustomSendTextRequest : MessageCustomSendRequest
    {
        [JsonProperty("text")]
        public TextMessage Text { get; set; }

        public override string MsgType
        {
            get { return "text"; }
        }
    }
}
