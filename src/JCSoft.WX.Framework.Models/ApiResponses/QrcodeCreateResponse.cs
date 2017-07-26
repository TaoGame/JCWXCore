using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class QrcodeCreateResponse : ApiResponse
    {
        public string Ticket { get; set; }

        [JsonProperty("expire_seconds")]
        public int ExpireSeconds { get; set; }
    }
}
