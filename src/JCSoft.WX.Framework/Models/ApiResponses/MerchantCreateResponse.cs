using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class MerchantCreateResponse : ApiResponse
    {
        [JsonProperty("product_id")]
        public string ProductID { get; set; }
    }
}
