using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class SnsUserInfoResponse : ApiResponse
    {
        public string OpenId { get; set; }

        public string NickName { get; set; }

        public string Sex { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [JsonProperty("headimgurl")]
        public string HeadImageUrl { get; set; }

        [JsonProperty("privilege")]
        public IEnumerable<string> Privilege { get; set; }
        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        public string UnionId { get; set; }
    }
}
