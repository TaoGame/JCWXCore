using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class CustomserviceGetkflistResponse : ApiResponse
    {
        [JsonProperty("kf_list")]
        public IEnumerable<CustomAccount> Accounts { get; set; }
    }
}
