using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class DatacubeGetUserSummaryResponse : ApiResponse
    {
        [JsonProperty("list")]
        public IEnumerable<UserDatacube> List { get; set; }
    }
}
