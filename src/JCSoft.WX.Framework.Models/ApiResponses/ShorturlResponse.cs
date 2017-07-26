using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class ShorturlResponse : ApiResponse
    {
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
    }
}
