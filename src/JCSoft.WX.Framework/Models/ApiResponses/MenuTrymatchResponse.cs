using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class MenuTrymatchResponse : ApiResponse
    {
        [JsonProperty("button")]
        public List<ClickButton> Buttons { get; set; }
    }
}
