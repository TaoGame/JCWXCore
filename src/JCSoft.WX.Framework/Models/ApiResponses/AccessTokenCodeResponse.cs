using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class AccessTokenCodeResponse : ApiResponse
    {
        public string Access_Token { get; set; }
        public int Expires_in { get; set; }
        public string Refresh_token { get; set; }
        public string OpenId { get; set; }
        public string Scope { get; set; }
    }
}
