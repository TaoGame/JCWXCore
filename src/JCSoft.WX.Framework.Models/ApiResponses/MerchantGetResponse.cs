using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class MerchantGetResponse : ApiResponse
    {
        [JsonProperty("product_info")]
        public ProductInfo ProductInfo { get; set; }
    }
}
