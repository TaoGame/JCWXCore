using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MerchantShelfUpdatestatusRequest : ApiRequest<MerchantShelfUpdatestatusResponse>
    {
        [JsonProperty("shelf_id")]
        public long ShelfID { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        public override string Method
        {
            get { return POSTMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/merchant/shelf/updatestatus?access_token={0}"; }
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

        public override void Validate()
        {
            base.Validate();
            if (Status < 0 || Status > 1)
            {
                throw new ArgumentOutOfRangeException("只能为0：下架，1：上架");
            }
        }
    }
}
