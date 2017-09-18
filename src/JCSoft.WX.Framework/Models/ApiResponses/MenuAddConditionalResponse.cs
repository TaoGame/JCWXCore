using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class MenuAddConditionalResponse : ApiResponse
    {
        [JsonProperty("menuid")]
        public string MenuId { get; set; }
    }
}
