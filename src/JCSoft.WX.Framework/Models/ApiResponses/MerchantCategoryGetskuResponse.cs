using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class MerchantCategoryGetskuResponse : ApiResponse
    {
        [JsonProperty("sku_table")]
        public IEnumerable<SkuTable> SkuTables { get; set; }
    }
}
