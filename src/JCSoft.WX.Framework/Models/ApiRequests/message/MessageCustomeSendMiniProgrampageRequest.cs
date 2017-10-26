using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests.message
{
    public class MessageCustomeSendMiniProgrampageRequest : MessageCustomSendRequest
    {
        public override string MsgType => "miniprogrampage";

        [JsonProperty("miniprogrampage")]
        public MiniProgramPage MiniProgramPage { get; set; }
    }
}
