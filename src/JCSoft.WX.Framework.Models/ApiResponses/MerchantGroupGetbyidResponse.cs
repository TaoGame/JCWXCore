using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class MerchantGroupGetbyidResponse : ApiResponse
    {
        [JsonProperty("group_detail")]
        public MerchantGroupDetail GroupDetail { get; set; }
    }
}
