using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MerchantShelfDelRequest : ApiRequest<DefaultResponse>
    {
        [JsonProperty("shelf_id")]
        public long ShelfID { get; set; }

        public override string Method
        {
            get { return POSTMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/merchant/shelf/del?access_token={0}"; }
        }

        public override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
