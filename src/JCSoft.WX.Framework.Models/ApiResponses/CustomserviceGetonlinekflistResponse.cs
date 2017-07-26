using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class CustomserviceGetonlinekflistResponse : ApiResponse
    {
        [JsonProperty("kf_online_list")]
        public IEnumerable<CustomAccount> Account { get; set; }
    }
}
