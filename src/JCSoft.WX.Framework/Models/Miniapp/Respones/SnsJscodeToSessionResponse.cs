using JCSoft.WX.Framework.Models.ApiResponses;
using Newtonsoft.Json;

namespace JCSoft.WX.Framework.Models.Miniapp.Respones
{
    public class SnsJscodeToSessionResponse : ApiResponse
    {
        [JsonProperty("openid")]
        public string OpenId { get; set; }
        [JsonProperty("session_key")]
        public string SessionKey { get; set; }
        [JsonProperty("unionid")]
        public string Unionid { get; set; }
    }
}