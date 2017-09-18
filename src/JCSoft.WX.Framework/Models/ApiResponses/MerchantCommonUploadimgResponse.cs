using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class MerchantCommonUploadimgResponse : ApiResponse
    {
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }
}
