using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class MerchantCategoryGetpropertyResponse : ApiResponse
    {
        [JsonProperty("properties")]
        public IEnumerable<Property> Properties { get; set; }
    }
}
