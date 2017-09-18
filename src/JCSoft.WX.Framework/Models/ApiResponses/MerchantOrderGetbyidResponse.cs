using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class MerchantOrderGetbyidResponse : ApiResponse
    {
        [JsonProperty("order")]
        public OrderInfo Order { get; set; }
    }
}
