using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class MessageMassSendAllResponse : ApiResponse
    {
        [JsonProperty("msg_id")]
        public int MsgId { get; set; }
    }
}
